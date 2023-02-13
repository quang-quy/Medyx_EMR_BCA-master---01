using Medyx_EMR_BCA.ApiAssets.Models.Configure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Medyx_EMR_BCA.ApiAssets.Repository
{
    public class UploadFileStoreResult
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Extention { get; set; }
        public long Size { get; set; }
    }
    public class DownloadFileResult
    {
        public string FileName { get; set; }
        public byte[] FileBytes { get; set; }
        public string contentType { get; set; }
    }
    public class UploadFileRespository
    {
        private string DirectoryName { get; set; }
        private string DiskStorage { get; set; }
        public const string DEFAULT_DIRECTORY_NAME = "Uploads";
        public const string DEFAULT_DIRECTORY_PREFIX = "Storage";

        public UploadFileRespository(string directoryName = DEFAULT_DIRECTORY_NAME, IOptions<StorageSetting> options = null)
        {
            //this.env = env;
            DirectoryName = directoryName;
            DiskStorage = options != null ? options.Value.Location : null;
        }

        public void setDirectoryName(string directoryName)
        {
            DirectoryName = directoryName;
        }
        public UploadFileStoreResult Store(IFormFile file, bool withoutConfig = false)
        {
            var uniqueFileName = GetUniqueFileName(file.FileName);
            var uploads = Path.Combine(DEFAULT_DIRECTORY_PREFIX, DirectoryName);
            var filePath = Path.Combine(uploads, uniqueFileName);
            var pathCreate = filePath;
            if (!string.IsNullOrEmpty(DiskStorage) && !withoutConfig)
            {
                pathCreate = $"{DiskStorage}/{filePath}";
            }
            Directory.CreateDirectory(Path.GetDirectoryName(pathCreate));
            using (var FileStream = new FileStream(pathCreate, FileMode.Create))
            {
                file.CopyTo(FileStream);
                FileStream.Close();
            }
            UploadFileStoreResult result = new UploadFileStoreResult
            {
                Name = file.FileName,
                Link = filePath,
                Extention = Path.GetExtension(file.FileName),
                Size = file.Length
            };
            return result;
        }
        public UploadFileStoreResult Store(IFormFile file, string directoryPath)
        {
            var uniqueFileName = GetUniqueFileName(file.FileName);
            var uploads = Path.Combine(DEFAULT_DIRECTORY_PREFIX, $"{DirectoryName}/{directoryPath}");
            var filePath = Path.Combine(uploads, uniqueFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (var FileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(FileStream);
                FileStream.Close();
            }
            UploadFileStoreResult result = new UploadFileStoreResult
            {
                Name = file.FileName,
                Link = filePath,
                Extention = Path.GetExtension(file.FileName),
                Size = file.Length
            };
            return result;
        }

        public void RemoveFile(string path, bool withoutDiskPath = false)
        {
            path = withoutDiskPath ? path : AddStoragePath(path);
            if (File.Exists(Path.Combine(path)))
            {
                File.Delete(Path.Combine(path));
            }
        }
        public void RemoveDirectoryPath(string directoryPath, bool withoutConfig = false, bool withPrefix = false)
        {
            var path = $"{DirectoryName}/{directoryPath}";
            if (withPrefix)
            {
                path = $"{DEFAULT_DIRECTORY_PREFIX}/{path}";
            }
            path = withoutConfig ? path : AddStoragePath(path);
            if (Directory.Exists(Path.Combine(path)))
            {
                Directory.Delete(Path.Combine(path), true);
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Regex.Replace(Path.GetFileName(fileName), @"\s+", "");
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public string GetFullDirectoryWithDishStorage(string path)
        {
            path = AddStoragePath(path);
            if (CheckPathAbsolute(path))
            {
                return path;
            }
            return Path.GetFullPath(path);
        }
        public string[] GetDirectory(string directoryPath = "")
        {
            var path = String.IsNullOrEmpty(directoryPath) ? Path.Combine(DEFAULT_DIRECTORY_PREFIX, DirectoryName) : Path.Combine(DEFAULT_DIRECTORY_PREFIX, $"{DirectoryName}/{directoryPath}");
            if (Directory.Exists(path))
            {
                return Directory.GetDirectories(String.IsNullOrEmpty(directoryPath) ? Path.Combine(DEFAULT_DIRECTORY_PREFIX, DirectoryName) : Path.Combine(DEFAULT_DIRECTORY_PREFIX, $"{DirectoryName}/{directoryPath}"))
                    .Select(x => (new DirectoryInfo(x)).Name).ToArray();
            }
            return new string[] { };
        }
        public string[] GetFiles(string directoryPath = "")
        {
            var path = String.IsNullOrEmpty(directoryPath) ? Path.Combine(DEFAULT_DIRECTORY_PREFIX, DirectoryName) : Path.Combine(DEFAULT_DIRECTORY_PREFIX, $"{DirectoryName}/{directoryPath}");
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(String.IsNullOrEmpty(path) ? Path.Combine(DEFAULT_DIRECTORY_PREFIX, DirectoryName) : Path.Combine(DEFAULT_DIRECTORY_PREFIX, $"{DirectoryName}/{directoryPath}"))
                            .Select(x => Path.GetFileName(x)).ToArray();
            }
            return new string[] { };
        }
        private string AddStoragePath(string path)
        {
            if (CheckPathAbsolute(path))
            {
                return path;
            }
            if (!string.IsNullOrEmpty(DiskStorage))
            {
                return $"{DiskStorage}/{path}";
            }
            return path;
        }
        private bool CheckPathAbsolute(string path)
        {
            return Regex.IsMatch(path, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");
        }
        public DownloadFileResult Download(string path, bool deleteAfterDownload = false, bool withoutDiskPath = false)
        {
            path = withoutDiskPath ? path : AddStoragePath(path);
            byte[] fileBytes = File.ReadAllBytes(path);

            if (deleteAfterDownload)
            {
                RemoveFile(path);
            }

            return new DownloadFileResult
            {
                FileName = Path.GetFileName(path),
                FileBytes = fileBytes,
                contentType = MimeMapping.GetMimeMapping(Path.GetFileName(path))
            };
        }
        public void CopyFile(string source_path, string destination_directory, string name)
        {
            source_path = AddStoragePath(source_path);
            destination_directory = AddStoragePath(destination_directory);
            if (File.Exists(Path.Combine(source_path)))
            {
                var file = new FileInfo(source_path);
                if (!Directory.Exists(Path.Combine(destination_directory)))
                {
                    Directory.CreateDirectory(destination_directory);
                }
                var filePath = Path.Combine(destination_directory, name);
                file.CopyTo(filePath, true);
                //File.Delete(Path.Combine(path));
            }
        }
        public void Delete(string path)
        {
            path = AddStoragePath(path);
            if (File.Exists(Path.Combine(path)))
            {
                var file = new FileInfo(path);
                file.Delete();
            }
        }
    }
}
