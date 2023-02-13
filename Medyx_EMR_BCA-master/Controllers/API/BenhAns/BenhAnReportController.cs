using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using System.Linq;
using System;
using Microsoft.AspNetCore.Hosting.Internal;
using System.Collections.Generic;
using System.IO;
using Medyx_EMR_BCA.Controllers.API.BenhAns;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data.SqlClient;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris


{
    public struct CustomQuery
    {
        public List<string> Columns;
        public string Query;
        public CustomQuery(List<string> columns, string query)
        {
            Columns = columns;
            Query = query;
        }
    }
    [Route("api/benh-an-report")]
    [ApiController]
    // [ApiAssets.AttributeCustom.SessionFilter]


    public class BenhAnReportController : ControllerBase
    {
        private IRepository<BenhAnFilePhiCauTruc> _benhAnFilePhiCauTrucRepository = null;
        private IHttpContextAccessor _accessor = null;
        private IOptions<PrintSetting> _options = null;
        private HostingEnvironment _hostingEnvironment = null;
        private readonly IRepository<BenhAn> _benhAnRepository = null;
        private readonly BenhAnService _benhAnService;
        private UploadFileRespository _uploadFileRespository = null;
        public BenhAnReportController(HostingEnvironment hostingEnvironment, IHttpContextAccessor accessor, IOptions<PrintSetting> options, BenhAnService benhAnService)
        {
            _benhAnFilePhiCauTrucRepository = new GenericRepository<BenhAnFilePhiCauTruc>(accessor);
            _benhAnRepository = new GenericRepository<BenhAn>(accessor);
            _benhAnService = benhAnService;
            _uploadFileRespository = new UploadFileRespository();
            _accessor = accessor;
            _options = options;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet("check-report-generation/{id}")]
        public dynamic CheckReportGeneration(decimal id)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == id && x.Loai == 1).AsQueryable();
            var benhAn = _benhAnRepository.GetById(id);
            if (benhAn.XacNhanKetThucHs == 0 || benhAn.XacNhanKetThucHs == null)
            {
                return null;
            }
            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }
            return query.Count() > 0;
        }

        [HttpPut("dong-benh-an/{id}")]
        public ActionResult DongBenhAn(decimal id, [FromBody] BenhAn benhAn)
        {
            if (ModelState.IsValid)
            {
                var newBenhAn = _benhAnRepository.GetById(id);
                newBenhAn.XacNhanKetThucHs = benhAn.XacNhanKetThucHs;
                newBenhAn.NguoiXacnhanKetThucHs = benhAn.NguoiXacnhanKetThucHs;
                newBenhAn.NgayXacNhanKetThucHs = benhAn.NgayXacNhanKetThucHs;
                _benhAnService.Update(id, newBenhAn);
            }
            return Ok();
        }

        [HttpPost("luu-tru/{id}")]
        public ActionResult LuuTru(decimal id, [FromBody] BenhAn benhAn)
        {

            string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
            var client = new MongoClient(constr);
            var ctx = _benhAnRepository._context;
            IMongoDatabase db = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
            var collection1 = db.GetCollection<BsonDocument>("HoSoBenhAn");
            var collection2 = db.GetCollection<BsonDocument>("HoSoBenhAn_C");
            var backup = BsonDocument.Parse(System.IO.File.ReadAllText("backup.json"));
            var tables1 = backup.Where(x => x.Name == "HoSoBenhAn").First().Value.AsBsonArray.Select(x => x.ToString()).ToList();
            var tables2 = DatabaseContextHelpers.RawSqlQuery<string>($"SELECT table_name FROM INFORMATION_SCHEMA.columns WHERE column_name='idba' and table_name not in ({string.Join(",", tables1.Select(x => $"'{x}'"))})", x => (string)x[0]);
            var commonColumns = backup.Where(x => x.Name == "Common").First().Value.AsBsonArray;
            var excludedTables = backup.Where(x => x.Name == "ExcludedCommonTables").First().Value.AsBsonArray.Select(x => x.ToString());
            Func<string, CustomQuery> getCustomQuery = table =>
            {
                if (backup.Where(x => x.Name == table).Count() == 0)
                {
                    return new CustomQuery(new List<string> { }, "");
                }
                var customColumns = backup.Where(x => x.Name == table).First().Value.AsBsonArray.Concat(excludedTables.Where(x => x == table).Count() > 0 ? new BsonArray() { } : commonColumns);
                var selectedColumns = new List<string> { $"{table}.*" };
                var joins = new List<string> { };
                var columns = new List<string> { };
                foreach (var (column, i) in customColumns.Select((value, i) => (value.AsBsonDocument, i)))
                {
                    var t = column.Where(x => x.Name == "table").First().Value.ToString();
                    var p = column.Where(x => x.Name == "primaryKeys").First().Value.AsBsonArray.Select(x => x.ToString()).ToList();
                    var f = column.Where(x => x.Name == "foreignKeys").First().Value.AsBsonArray.Select(x => x.ToString()).ToList();
                    var c = column.Where(x => x.Name == "column").First().Value.ToString();
                    var columnName = (p[0].StartsWith("Ma") ? p[0].Replace("Ma", "Ten") : "Ten" + p[0]);
                    if (column.Where(x => x.Name == "as").Count() > 0)
                    {
                        columnName = column.Where(x => x.Name == "as").First().Value.ToString();
                    }
                    var selectedColumn = $"table{i}.{c} as " + columnName;
                    var join = $"LEFT JOIN {t} table{i} on " + string.Join(" and ", p.Select((v, i1) => $"{table}.{v}=table{i}.{f[i1]}"));
                    selectedColumns.Add(selectedColumn);
                    joins.Add(join);
                    columns.Add(columnName);
                }

                var query = $"SELECT {string.Join(", ", selectedColumns)} from {table} {string.Join(" ", joins)} where idba={id}";
                return new CustomQuery(columns, query);
            };
            var document1 = tables1.ToDictionary(table => table, table => GetRows(id, table, getCustomQuery(table))).ToBsonDocument();
            var document2 = tables2.ToDictionary(table => table, table => GetRows(id, table, getCustomQuery(table))).ToBsonDocument();
            var newBenhAn = _benhAnRepository.GetById(id);
            document1.Add(new BsonElement("idba", newBenhAn.Idba));
            document2.Add(new BsonElement("idba", newBenhAn.Idba));
            collection1.InsertOne(document1);
            collection2.InsertOne(document2);

            var notDeletableTables = backup.Where(x => x.Name == "NotDeletable").First().Value.AsBsonArray.Select(x => x.ToString()).ToList();
            DeleteTables(id, tables1.Concat(tables2).Where(x => notDeletableTables.IndexOf(x) == -1).ToList());

            if (ModelState.IsValid)
            {
                newBenhAn.SoLuuTru = benhAn.SoLuuTru;
                newBenhAn.NgayLuuTru = benhAn.NgayLuuTru;
                newBenhAn.NguoiLuuTru = benhAn.NguoiLuuTru;
                newBenhAn.XacNhanLuuTru = 1;
                newBenhAn.NguoiLuuTru = benhAn.NguoiLuuTru;
                _benhAnService.Update(id, newBenhAn);
            }

            return Ok();
        }

        public void DeleteTables(decimal idba, List<string> tables)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var table in tables)
                        {
                            using (var command = connection.CreateCommand())
                            {
                                Console.WriteLine($"DELETE FROM {table} WHERE IDBA={idba};");
                                command.CommandText = $"DELETE FROM {table} WHERE IDBA={idba};";
                                command.Transaction = transaction;
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (System.Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }

                }
            }
        }

        [HttpGet("khoi-phuc/{id}")]
        public ActionResult Restore(decimal id)
        {
            var backup = BsonDocument.Parse(System.IO.File.ReadAllText("backup.json"));
            var notDeletableTables = backup.Where(x => x.Name == "NotDeletable").First().Value.AsBsonArray.Select(x => x.ToString()).ToList();
            string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
            var client = new MongoClient(constr);
            var ctx = _benhAnRepository._context;
            IMongoDatabase db = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
            var collection1 = db.GetCollection<BsonDocument>("HoSoBenhAn");
            var collection2 = db.GetCollection<BsonDocument>("HoSoBenhAn_C");
            var doc1 = collection1.Find($"{{ idba: {id} }}").FirstOrDefault();
            var doc2 = collection2.Find($"{{ idba: {id} }}").FirstOrDefault();
            var doc = doc1.Merge(doc2);
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        foreach (var el in doc)
                        {
                            var tableName = el.Name;
                            if (new List<string>() { "_id", "idba" }.Concat(notDeletableTables).ToList().IndexOf(tableName) != -1)
                            {
                                continue;
                            }
                            BsonArray rows = el.Value.AsBsonArray;
                            foreach (var row in rows)
                            {
                                var columns = DatabaseContextHelpers.RawSqlQuery<string>($"SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", x => (string)x[0]);
                                List<string> values = new List<string>();
                                foreach (var col in columns)
                                {
                                    var value = row.AsBsonDocument.Elements.Where(x => x.Name == col).First();
                                    var type = value.Value.GetType().ToString();
                                    if (type == "MongoDB.Bson.BsonNull")
                                    {
                                        values.Add("null");
                                    }
                                    else if (type == "MongoDB.Bson.BsonString")
                                    {
                                        values.Add($"N'{value.Value.ToString().Replace("'", "''")}'");
                                    }
                                    else if (type == "MongoDB.Bson.BsonDateTime")
                                    {
                                        values.Add($"'{DateTime.Parse(value.Value.ToString()).ToLocalTime().ToString("yyyy-MM-dd HH:mm")}'");
                                    }
                                    else if (type == "MongoDB.Bson.BsonBoolean")
                                    {
                                        values.Add(Convert.ToByte(value.Value).ToString());
                                    }
                                    else values.Add(value.Value.ToString());
                                }
                                var query = $"INSERT INTO {tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", values)}) ";
                                using (var command = connection.CreateCommand())
                                {
                                    command.CommandText = query;
                                    command.Transaction = transaction;
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = $"UPDATE BenhAn SET xacNhanLuuTru=0 where idba={id}";
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                        }
                        collection1.DeleteOne($"{{ idba: {id} }}");
                        collection2.DeleteOne($"{{ idba: {id} }}");
                        transaction.Commit();
                    }
                    catch (System.Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
            return Ok();
        }
        private BsonArray GetRows(decimal idba, string tableName, CustomQuery customQuery)
        {
            var additionalColumns = customQuery.Columns;
            var dataQuery = customQuery.Query;
            var columns = DatabaseContextHelpers.RawSqlQuery<string>($"SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", x => (string)x[0]);
            columns = columns.Concat(additionalColumns).ToList();
            var data = DatabaseContextHelpers.RawSqlQuery<BsonDocument>(string.IsNullOrEmpty(dataQuery) ? $"SELECT * FROM {tableName} where idba={idba}" : dataQuery, x =>
            {
                var row = new Dictionary<string, dynamic>();
                for (int i = 0; i < columns.Count; i++)
                {
                    dynamic value = x[i];
                    if (x[i].GetType().Equals(typeof(System.DBNull)))
                    {
                        value = null;
                    }
                    if (x[i].GetType().Equals(typeof(System.Byte)) || x[i].GetType().Equals(typeof(System.Decimal)))
                    {
                        value = Convert.ToInt32(x[i]);
                    }
                    if (!row.ContainsKey(columns[i]))
                    {
                        row.Add(columns[i], value);
                    }
                }

                return row.ToBsonDocument();
            }
            );
            return BsonArray.Create(data);
        }

        [HttpGet("luu-tru/{id}")]
        public dynamic LuuTru(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            if (benhAn.XacNhanLuuTru == 0 || benhAn.XacNhanLuuTru == null)
            {
                return false;
            }
            return new JsonResult(new
            {
                xacNhanLuuTru = benhAn.XacNhanLuuTru,
                soLuuTru = benhAn.SoLuuTru,
                nguoiLuuTru = benhAn.NguoiLuuTru,
                ngayLuuTru = benhAn.NgayLuuTru
            });
        }


        [HttpGet("thong-tin-to-benh-an/{id}")]
        public bool ThongTinToBenhAn(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var path = _benhAnService.Print(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\BenhAn";
            var fileName = $"{benhAn.MaBa}_ThongTinToBenhAn.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 1,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }


        [HttpGet("phieu-kham-sang-loc-dinh-duong/{id}")]
        public bool PhieuKhamSangLocDinhDuong(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuKhamSangLocDinhDuong";
            var danhSachPhieuKhamSangLocDinhDuong = _benhAnRepository._context.BenhAnKhamSangLocDd.Where(x => x.Idba == id).ToList();
            var benhAnKhamSangLocDDService = new BenhAnKhamSangLocDDService(_accessor, _options, _hostingEnvironment);
            foreach (var phieuKhamSangLocDinhDuong in danhSachPhieuKhamSangLocDinhDuong)
            {
                string path;
                try
                {
                    path = benhAnKhamSangLocDDService.Print(id, phieuKhamSangLocDinhDuong.Stt, phieuKhamSangLocDinhDuong.Sttkhoa);
                }
                catch
                {
                    continue;
                }
                var fileName = $"{benhAn.MaBa}_{phieuKhamSangLocDinhDuong.Sttkhoa}_{phieuKhamSangLocDinhDuong.Stt}_PhieuKhamSangLocDinhDuong.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 2,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }

        [HttpGet("tai-bien-phau-thuat-thu-thuat/{id}")]
        public bool TaiBienPhauThuatThuThuat(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\TaiBienPhauThuatThuThuat";
            var danhSachTaiBienPhauThuatThuThuat = _benhAnRepository._context.BenhAnTaiBienPttt.Where(x => x.Idba == id).ToList();
            var benhAnTaiBienPhauThuatThuThuatService = new BenhAnTaiBienPtttService(_accessor, _hostingEnvironment);
            foreach (var taiBienPhauThuatThuThuat in danhSachTaiBienPhauThuatThuThuat)
            {
                string path;
                try
                {
                    path = benhAnTaiBienPhauThuatThuThuatService.Print(id, taiBienPhauThuatThuThuat.Stt);
                }
                catch
                {
                    continue;
                }
                var fileName = $"{benhAn.MaBa}_{taiBienPhauThuatThuThuat.Stt}_TaiBienPhauThuatThuThuat.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 17,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }

        [HttpGet("phieu-theo-doi-truyen-mau/{id}")]
        public bool PhieuTheoDoiTruyenMau(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuTheoDoiTruyenMau";
            var danhSachPhieuTheoDoiTruyenMau = _benhAnRepository._context.BenhAnTheoDoiTruyenMau.Where(x => x.Idba == id).ToList();
            var benhAnTheoDoiTruyenMauService = new BenhAnTheoDoiTruyenMauService(_hostingEnvironment, _accessor, _options);
            foreach (var phieuTheoDoiTruyenMau in danhSachPhieuTheoDoiTruyenMau)
            {
                string path;
                try
                {
                    path = benhAnTheoDoiTruyenMauService.Print(id, phieuTheoDoiTruyenMau.Stt);
                }
                catch
                {
                    continue;
                }
                var fileName = $"{benhAn.MaBa}_{phieuTheoDoiTruyenMau.Stt}_PhieuTheoDoiTruyenMau.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 20,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }

        [HttpGet("phieu-cham-soc/{id}")]
        public bool PhieuChamSoc(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuChamSoc";
            var danhSachPhieuChamSoc = _benhAnRepository._context.BenhAnPhieuChamSoc.Where(x => x.Idba == id).ToList();
            var benhAnPhieuChamSocService = new BenhAnPhieuChamSocService(_hostingEnvironment, _options, _accessor);
            var infor = new BenhAnChamSocPrintVM();
            infor.Stt = danhSachPhieuChamSoc.Select(x => x.Stt).ToList();
            var path = benhAnPhieuChamSocService.Print(id, infor);
            var fileName = $"{benhAn.MaBa}_PhieuChamSoc.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 19,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }

        /*[HttpGet("ket-qua-xet-nghiem/{id}")]
        public bool PhieuXetNghiem(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuXetNghiem";
            //var danhSachPhieuXetNghiem = _benhAnRepository._context.BenhanClsKqcs.Where(x => x.Idba == id).ToList();
            var benhAnPhieuSetNghiemService = new BenhAnPhieuXetNghiemService(_accessor, _hostingEnvironment, _options);
            var danhSachPhieuXetNghiem = benhAnPhieuSetNghiemService.Get(new BenhAnPhieuXetNghiemParameters()
            {
                Idba = id
            });
            foreach (var phieuXetNghiem in danhSachPhieuXetNghiem)
            {
                string path;
                try
                {
                    path = benhAnPhieuSetNghiemService.Print(id, phieuXetNghiem.Sttdv);
                }
                catch (Exception e)
                {
                    continue;
                }
                var fileName = $"{benhAn.MaBa}_{phieuXetNghiem.Sttdv}_{phieuXetNghiem.Stt}_KetQuaXetNghiem.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 9,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }*/
        [HttpGet("giay-bao-tu/{id}")]
        public bool GiayBaoTu(decimal id)
        {
            var _benhAnThongTinTuVongService = new BenhAnThongTinTuVongService(_accessor, _hostingEnvironment, _options);
            var benhAn = _benhAnRepository.GetById(id);
            var path = _benhAnThongTinTuVongService.Print(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\GiayBaoTu";
            var fileName = $"{benhAn.MaBa}_GiayBaoTu.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 24,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }

        [HttpGet("giay-ra-vien/{id}")]
        public bool GiayRaVien(decimal id)
        {
            var benhAnService = new BenhAnService(_hostingEnvironment, _accessor, _options);
            var benhAn = _benhAnRepository.GetById(id);
            var path = benhAnService.GiayRaVienPrint(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\GiayRaVien";
            var fileName = $"{benhAn.MaBa}_GiayRaVien.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 22,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }

        [HttpGet("phieu-chan-doan-nguyen-nhan-tu-vong/{id}")]
        public bool PhieuChanDoanNguyenNhanTuVong(decimal id)
        {
            var _benhAnThongTinTuVongService = new BenhAnThongTinTuVongService(_accessor, _hostingEnvironment, _options);
            var benhAn = _benhAnRepository.GetById(id);
            var path = _benhAnThongTinTuVongService.TrichBienBanPrint(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuChanDoanNguyenNhanTuVong";
            var fileName = $"{benhAn.MaBa}_PhieuChanDoanNguyenNhanTuVong.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 25,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }

        [HttpGet("bien-ban-kiem-diem-tu-vong/{id}")]
        public bool BienBanKiemDiemTuVong(decimal id)
        {
            var _benhAnThongTinTuVongService = new BenhAnThongTinTuVongService(_accessor, _hostingEnvironment, _options);
            var benhAn = _benhAnRepository.GetById(id);
            var path = _benhAnThongTinTuVongService.KiemDiemTuVongPrint(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\BienBanKiemDiemTuVong";
            var fileName = $"{benhAn.MaBa}_BienBanKiemDiemTuVong.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 23,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }

        [HttpGet("phieu-thu-phan-ung-thuoc/{id}")]
        public bool PhieuThuPhanUngThuoc(decimal id)
        {
            var _benhAnThuocThuPhanUngService = new BenhAnThuocThuPhanUngService(_hostingEnvironment, _accessor, _options);
            var benhAn = _benhAnRepository.GetById(id);
            var path = _benhAnThuocThuPhanUngService.Print(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuThuPhanUngThuoc";
            var fileName = $"{benhAn.MaBa}_PhieuThuPhanUngThuoc.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 7,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }

        [HttpGet("to-dieu-tri/{id}")]
        public bool ToDieuTri(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\ToDieuTri";
            var danhSachToDieuTri = _benhAnRepository._context.BenhAnToDieuTri.Where(x => x.Idba == id).ToList();
            var benhAnToDieuTri = new BenhAnToDieuTriService(_hostingEnvironment, _accessor, _options);
            var stts = danhSachToDieuTri.Select(x => x.Stt).ToList();
            var infor = new ToDieuTriPrintVM();
            infor.Stt = stts;
            var path = benhAnToDieuTri.Print(id, infor);
            var fileName = $"{benhAn.MaBa}_ToDieuTri.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 6,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }
        [HttpGet("can-lam-sang/{maChungLoai}/{id}")]
        public bool CanLamSang(string maChungLoai, decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var danhSachCanLamSang = _benhAnRepository._context.BenhanCls.Where(x => x.Idba == id && x.DmdichVu.MaChungloai == maChungLoai).ToList();
            var benhAnClsService = new BenhAnClsService(_hostingEnvironment, _options, _accessor);
            foreach (var canLamSang in danhSachCanLamSang)
            {
                var path = "";
                try
                {
                    path = benhAnClsService.Print(id, canLamSang.Stt);
                }
                catch
                {
                    continue;
                }
                var loaiTaiLieu = new Dictionary<string, dynamic>();
                switch (maChungLoai)
                {
                    case "1":
                        loaiTaiLieu["ten"] = "KetQuaKhamChuyenKhoa";
                        loaiTaiLieu["ma"] = 8;
                        break;
                    case "3":
                        loaiTaiLieu["ten"] = "KetQuaChanDoanHinhAnh";
                        loaiTaiLieu["ma"] = 10;
                        break;
                    case "4":
                        loaiTaiLieu["ten"] = "KetQuaThamDoChucNang";
                        loaiTaiLieu["ma"] = 11;
                        break;
                    default:
                        break;
                }

                var fileName = $"{benhAn.MaBa}_{canLamSang.Stt}({canLamSang.Sttkhoa})_{loaiTaiLieu["ten"]}.pdf";
                var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\{loaiTaiLieu["ten"]}";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = Convert.ToByte(loaiTaiLieu["ma"]),
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = canLamSang.Stt,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }
        [HttpGet("phieu-kham-benh-vao-vien/{id}")]
        public bool PhieuKhamBenhVaoVien(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var benhAnKhamVaoVienController = new BenhAnKhamVaoVienController(_hostingEnvironment, _options);
            var path = benhAnKhamVaoVienController.Print(id, true);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuKhamBenhVaoVien";
            var fileName = $"{benhAn.MaBa}_PhieuKhamBenhVaoVien.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 3,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }
        [HttpGet("phieu-tong-ket-15-ngay-dieu-tri/{id}")]
        public bool PhieuTongKet15NgayDieuTri(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuTongKet15NgayDieuTri";
            var danhSachPhieuTongKet15NgayDieuTri = _benhAnRepository._context.BenhAnTongKet15NgayDt.Where(x => x.Idba == id).ToList();
            var benhAnKhamVaoVienController = new BenhAnTongKet15NgayDTController(_hostingEnvironment, _options, _accessor);
            foreach (var phieuTongKet15NgayDieuTri in danhSachPhieuTongKet15NgayDieuTri)
            {
                var path = "";
                try
                {
                    path = benhAnKhamVaoVienController.Print(id, phieuTongKet15NgayDieuTri.Stt, true);
                }
                catch { continue; }
                var fileName = $"{benhAn.MaBa}_{phieuTongKet15NgayDieuTri.Stt}_PhieuTongKet15NgayDieuTri.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 16,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }

        [HttpGet("phieu-hoi-chan/{id}")]
        public bool PhieuHoiChan(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuHoiChan";
            var danhSachPhieuHoiChan = _benhAnRepository._context.BenhAnTongKet15NgayDt.Where(x => x.Idba == id).ToList();
            var benhAnHoiChuanController = new BenhAnHoiChuanController(_hostingEnvironment, _accessor);
            foreach (var phieuHoiChan in danhSachPhieuHoiChan)
            {
                var path = "";
                try
                {
                    path = benhAnHoiChuanController.Print(id, phieuHoiChan.Stt, true);
                }
                catch { continue; }
                var fileName = $"{benhAn.MaBa}_{phieuHoiChan.Stt}_PhieuHoiChan.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 15,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }

        [HttpGet("theo-doi-truyen-dich/{id}")]
        public bool TheoDoiTruyenDich(decimal id)
        {
            var benhAnTheoDoiTruyenDichService = new BenhAnTheoDoiTruyenDichService(_hostingEnvironment, _accessor, _options);
            var benhAn = _benhAnRepository.GetById(id);
            var path = benhAnTheoDoiTruyenDichService.Print(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\TheoDoiTruyenDich";
            var fileName = $"{benhAn.MaBa}_TheoDoiTruyenDich.pdf";
            _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = 18,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = destinationFolder + '\\' + fileName,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = null,
                Loai = 1
            });
            _benhAnFilePhiCauTrucRepository.Save();
            return true;
        }



        [HttpGet("phieu-kham-gay-me-truoc-mo/{id}")]
        public bool PhieuKhamGayMeTruocMo(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuKhamGayMeTruocMo";
            var danhSachPhieuKhamGayMeTruocMo = _benhAnRepository._context.BenhanPhauThuatPhieuKhamGayMeTruocMo.Where(x => x.Idba == id).ToList();
            var benhAnPhauThuatPhieuKhamGayMeTruocMoService = new BenhanPhauThuatPhieuKhamGayMeTruocMoService(_accessor, _hostingEnvironment);
            foreach (var phieuKhamGayMeTruocMo in danhSachPhieuKhamGayMeTruocMo)
            {
                var path = "";
                try
                {
                    path = benhAnPhauThuatPhieuKhamGayMeTruocMoService.Print(id, phieuKhamGayMeTruocMo.Sttpt);
                }
                catch { continue; }
                var fileName = $"{benhAn.MaBa}_{phieuKhamGayMeTruocMo.Sttpt}_PhieuKhamGayMeTruocMo.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 13,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }
        [HttpGet("phieu-phau-thuat-thu-thuat/{id}")]
        public bool PhieuPhauThuatThuThuat(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\PhieuPhauThuatThuThuat";
            var danhSachBenhanPhauThuatPhieuPttt = _benhAnRepository._context.BenhanPhauThuatPhieuPttt.Where(x => x.Idba == id).ToList();
            var benhanPhauThuatPhieuPtttService = new BenhanPhauThuatPhieuPtttService(_accessor, _options, _hostingEnvironment);
            foreach (var benhanPhauThuatPhieuPttt in danhSachBenhanPhauThuatPhieuPttt)
            {
                var path = "";
                try
                {
                    path = benhanPhauThuatPhieuPtttService.Print(id, benhanPhauThuatPhieuPttt.Sttpt);
                }
                catch { continue; }
                var fileName = $"{benhAn.MaBa}_{benhanPhauThuatPhieuPttt.Sttpt}_PhieuPhauThuatThuThuat.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 14,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }
        [HttpGet("reset/{id}")]
        public bool Reset(decimal id)
        {
            var danhSachFilePhiCauTruc = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == id && x.Loai == 1).AsQueryable().ToList();
            foreach (var filePhiCauTruc in danhSachFilePhiCauTruc)
            {
                _benhAnFilePhiCauTrucRepository._context.BenhAnFilePhiCauTruc.Remove(filePhiCauTruc);
                _benhAnFilePhiCauTrucRepository._context.SaveChanges();
                _uploadFileRespository.Delete(filePhiCauTruc.Link);
            }
            return true;
        }
        [HttpGet("chi-dinh-vat-ly-tri-lieu/{id}")]
        public bool ChiDinhVatLyTriLieu(decimal id)
        {
            var benhAn = _benhAnRepository.GetById(id);
            var destinationFolder = $"Storage\\HSBA\\{benhAn.MaBa}\\ChiDinhVatLyTriLieu";
            var danhSachChiDinhVatLyTriLieu = _benhAnRepository._context.BenhanTtvltlDotDieuTri.Where(x => x.Idba == id).ToList();
            var chiDinhVatLyTriLieuService = new BenhAnTtvltlDotDieuTriService(_accessor, _hostingEnvironment, _options);
            foreach (var chiDinhVatLyTriLieu in danhSachChiDinhVatLyTriLieu)
            {
                var path = "";
                try
                {
                    path = chiDinhVatLyTriLieuService.Print(id, chiDinhVatLyTriLieu.Stt);
                }
                catch { continue; }
                var fileName = $"{benhAn.MaBa}_{chiDinhVatLyTriLieu.Stt}_ChiDinhVatLyTriLieu.pdf";
                _uploadFileRespository.CopyFile(path, destinationFolder, fileName);
                var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);
                _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
                {
                    Idba = benhAn.Idba,
                    LoaiTaiLieu = 12,
                    MaBa = benhAn.MaBa,
                    MaBn = benhAn.MaBn,
                    Link = destinationFolder + '\\' + fileName,
                    Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                    Sttdv = null,
                    Loai = 1
                });
                _benhAnFilePhiCauTrucRepository.Save();
            }
            return true;
        }

    }


}
