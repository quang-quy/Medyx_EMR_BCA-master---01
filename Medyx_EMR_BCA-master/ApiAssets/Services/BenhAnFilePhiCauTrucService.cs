using AutoMapper;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnFilePhiCauTrucService
    {
        private IRepository<BenhAnFilePhiCauTruc> _benhAnFilePhiCauTrucRepository;
        private UploadFileRespository _uploadFileRepository;

        private BenhAnService _benhAnSerice;

        public BenhAnFilePhiCauTrucService(IHttpContextAccessor accessor = null, UploadFileRespository uploadFileRespository = null)
        {
            _benhAnFilePhiCauTrucRepository = new GenericRepository<BenhAnFilePhiCauTruc>(accessor);
            _uploadFileRepository = uploadFileRespository;
            _benhAnSerice = new BenhAnService();
        }

        public IQueryable<BenhAnFilePhiCauTrucDto> Get(BenhAnFilePhiCauTrucParameters parameters, UserSession user = null)
        {
            var query = _benhAnFilePhiCauTrucRepository.Table
                .Include(x => x.DmbaLoaiTaiLieu)
                .Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
                .Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmnhanVien)
                .Include(x => x.BenhanCls).ThenInclude(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
                .Include(x => x.BenhanCls).ThenInclude(x => x.DmdichVu)
                .Include(x => x.BenhanCls).ThenInclude(x => x.DmnhanVien)
                .Include(x => x.BenhanCpm).ThenInclude(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
                .Include(x => x.BenhanCpm).ThenInclude(x => x.DmchephamMau)
                .Include(x => x.BenhanCpm).ThenInclude(x => x.DmnhanVien)
                .Include(x => x.BenhanTtvltl).ThenInclude(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
                .Include(x => x.BenhanTtvltl).ThenInclude(x => x.DmdichVu)
                .Include(x => x.BenhanTtvltl).ThenInclude(x => x.DmnhanVien)
                .Include(x => x.BenhanPhauThuat).ThenInclude(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
                .Include(x => x.BenhanPhauThuat).ThenInclude(x => x.DmphauThuat)
                .Include(x => x.BenhanPhauThuat).ThenInclude(x => x.DmBschiDinh)
                .AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.LoaiTaiLieu.HasValue)
            {
                query = query.Where(x => x.LoaiTaiLieu == parameters.LoaiTaiLieu);
            }
            if (parameters.Sttdv.HasValue)
            {
                query = query.Where(x => x.Sttdv == parameters.Sttdv);
            }
            if (parameters.Huy.HasValue)
            {
                query = query.Where(x => x.Huy == parameters.Huy);
            }
            if (parameters.Loai.HasValue)
            {
                query = query.Where(x => x.Loai == parameters.Loai);
            }
            query = SortHelper.ApplySort(query, parameters.SortBy);

            IQueryable<BenhAnFilePhiCauTrucDto> benhAnFileCauTrucQuery = query.Select(x => new BenhAnFilePhiCauTrucDto()
            {
                Idba = x.Idba,
                Stt = x.Stt,
                LoaiTaiLieu = x.LoaiTaiLieu,
                Sttdv = x.Sttdv,
                TaiLiieuDinhKem = x.TaiLiieuDinhKem,
                Link = x.Link,
                Loai = x.Loai,
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgaySd = x.NgaySd,
                NgayHuy = x.NgayHuy,
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
                NguoiSd = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                DichVu = GetDichVu(x)
            });
            return benhAnFileCauTrucQuery;
        }

        public void Store(BenhAnFilePhiCauTrucVM info)
        {
            var loaiTaiLieu = _benhAnFilePhiCauTrucRepository._context.DmbaLoaiTaiLieu.FirstOrDefault(x => x.MaLoaiTaiLieu == info.LoaiTaiLieu);
            BenhAn benhAn = _benhAnSerice.Show(info.Idba);
            //permission
            PermissionThrowHelper.GetBenhAnAndCheckPermission(info.Idba);
            if (loaiTaiLieu != null)
            {
                _uploadFileRepository.setDirectoryName($"HSBA\\{benhAn.MaBa}\\{loaiTaiLieu.TableName}");
            }

            UploadFileStoreResult uploadResult = _uploadFileRepository.Store(info.File);

            var query = _benhAnFilePhiCauTrucRepository.Table.Where(x => x.Idba == benhAn.Idba);

            _benhAnFilePhiCauTrucRepository.Insert(new BenhAnFilePhiCauTruc()
            {
                Idba = benhAn.Idba,
                LoaiTaiLieu = info.LoaiTaiLieu,
                MaBa = benhAn.MaBa,
                MaBn = benhAn.MaBn,
                Link = uploadResult.Link,
                Stt = Convert.ToBoolean(query.Count()) ? query.Max(x => x.Stt) + 1 : 1,
                Sttdv = info.Sttdv
            });
            _benhAnFilePhiCauTrucRepository.Save();
        }

        public void Destroy(decimal idba, int stt)
        {
            //permission
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnFilePhiCauTrucRepository.Delete(idba, stt);
        }

        private BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto GetDichVu(BenhAnFilePhiCauTruc benhAnFilePhiCauTruc)
        {
            if (!benhAnFilePhiCauTruc.Sttdv.HasValue)
            {
                return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto();
            }
            switch (benhAnFilePhiCauTruc.DmbaLoaiTaiLieu.TableName.ToUpper())
            {
                case "BENHAN_KHOADIEUTRI":
                    return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        SttKhoa = benhAnFilePhiCauTruc.BenhAnKhoaDieuTri?.Stt,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = benhAnFilePhiCauTruc.BenhAnKhoaDieuTri?.Dmkhoa?.MaKhoa,
                            TenKhoa = benhAnFilePhiCauTruc.BenhAnKhoaDieuTri?.Dmkhoa?.TenKhoa
                        },
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = benhAnFilePhiCauTruc.BenhAnKhoaDieuTri?.DmnhanVien?.MaNv,
                            HoTen = benhAnFilePhiCauTruc.BenhAnKhoaDieuTri?.DmnhanVien?.HoTen
                        },
                    };
                case "BENHAN_CLS":
                    return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        SttKhoa = benhAnFilePhiCauTruc.BenhanCls?.Sttkhoa,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = benhAnFilePhiCauTruc.BenhanCls?.BenhAnKhoaDieuTri?.Dmkhoa?.MaKhoa,
                            TenKhoa = benhAnFilePhiCauTruc.BenhanCls?.BenhAnKhoaDieuTri?.Dmkhoa?.TenKhoa
                        },
                        TenDichVu = benhAnFilePhiCauTruc.BenhanCls?.DmdichVu?.TenDv,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = benhAnFilePhiCauTruc.BenhanCls?.DmnhanVien?.MaNv,
                            HoTen = benhAnFilePhiCauTruc.BenhanCls?.DmnhanVien?.HoTen
                        },
                    };
                case "BENHAN_TTVLTL":
                    return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        SttKhoa = benhAnFilePhiCauTruc.BenhanTtvltl?.Sttkhoa,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = benhAnFilePhiCauTruc.BenhanTtvltl?.BenhAnKhoaDieuTri?.Dmkhoa?.MaKhoa,
                            TenKhoa = benhAnFilePhiCauTruc.BenhanTtvltl?.BenhAnKhoaDieuTri?.Dmkhoa?.TenKhoa
                        },
                        TenDichVu = benhAnFilePhiCauTruc.BenhanTtvltl?.DmdichVu?.TenDv,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = benhAnFilePhiCauTruc.BenhanTtvltl?.DmnhanVien?.MaNv,
                            HoTen = benhAnFilePhiCauTruc.BenhanTtvltl?.DmnhanVien?.HoTen
                        },
                    };
                case "BENHAN_PHAUTHUAT":
                    return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        SttKhoa = benhAnFilePhiCauTruc.BenhanPhauThuat?.Sttkhoa,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = benhAnFilePhiCauTruc.BenhanPhauThuat?.BenhAnKhoaDieuTri?.Dmkhoa?.MaKhoa,
                            TenKhoa = benhAnFilePhiCauTruc.BenhanPhauThuat?.BenhAnKhoaDieuTri?.Dmkhoa?.TenKhoa
                        },
                        TenDichVu = benhAnFilePhiCauTruc.BenhanPhauThuat?.DmphauThuat?.TenPt,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = benhAnFilePhiCauTruc.BenhanPhauThuat?.DmBschiDinh?.MaNv,
                            HoTen = benhAnFilePhiCauTruc.BenhanPhauThuat?.DmBschiDinh?.HoTen
                        },
                    };
                case "BENHAN_CPM":
                    return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        SttKhoa = benhAnFilePhiCauTruc.BenhanCpm?.Sttkhoa,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = benhAnFilePhiCauTruc.BenhanCpm?.BenhAnKhoaDieuTri?.Dmkhoa?.MaKhoa,
                            TenKhoa = benhAnFilePhiCauTruc.BenhanCpm?.BenhAnKhoaDieuTri?.Dmkhoa?.TenKhoa
                        },
                        TenDichVu = benhAnFilePhiCauTruc.BenhanCpm?.DmchephamMau?.TenCpmau,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = benhAnFilePhiCauTruc.BenhanCpm?.DmnhanVien?.MaNv,
                            HoTen = benhAnFilePhiCauTruc.BenhanCpm?.DmnhanVien?.HoTen
                        },
                    };
                default:
                    return new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto();
            }
        }
    }
}
