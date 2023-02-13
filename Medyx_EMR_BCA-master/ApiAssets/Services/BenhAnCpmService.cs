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
    public class BenhAnCpmService
    {
        private IRepository<BenhanCpm> _benhAnCpmRepository = null;
        public BenhAnCpmService(IHttpContextAccessor accessor = null)
        {
            _benhAnCpmRepository = new GenericRepository<BenhanCpm>(accessor);
        }

        public IQueryable<BenhanCpmDto> Get(BenhanCpmParameters parameters, UserSession user = null)
        {
            var query = _benhAnCpmRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);

            IQueryable<BenhanCpmDto> benhAnCpmQuery = query.Select(x => new BenhanCpmDto()
            {
                Idba = x.Idba,
                Stt = x.Stt,
                KhoaDieuTri = new BenhAnKhoaDieuTriDto()
                {
                    Stt = x.BenhAnKhoaDieuTri.Stt,
                    NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
                    Khoa = new DmkhoaDto()
                    {
                        MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                        TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
                    }
                },
                ChePhamMau = new DmchephamMauDto()
                {
                    MaDV = x.DmchephamMau.MaCpmau,
                    TenDV = x.DmchephamMau.TenCpmau,
                },
                NgayYlenh = x.NgayYlenh,
                BsChiDinh = new DmnhanVienDto()
                {
                    MaNv = x.DmnhanVien.MaNv,
                    HoTen = x.DmnhanVien.HoTen
                },
                TruyenMau = new TruyenMauDto()
                {
                    TheTich = x.BenhAnTheoDoiTruyenMau.TheTich,
                    ThoiGianBd = x.BenhAnTheoDoiTruyenMau.ThoiGianBd,
                    ThoiGianKt = x.BenhAnTheoDoiTruyenMau.ThoiGianKt
                },
                Huy = x.Huy,
                DonVi = x.DonVi,
                SoLuong = x.SoLuong,
                Nhommau = x.Nhommau,
                Rh = x.Rh,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                NguoiSD = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },
            });
            return benhAnCpmQuery;
        }

        private IQueryable<BenhanCpm> QueryFilter(IQueryable<BenhanCpm> query, BenhanCpmParameters parameters)
        {
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.NgayYlenh.HasValue)
            {
                query = query.Where(x => x.NgayYlenh == parameters.NgayYlenh);
            }
            return query;
        }

        public BenhanCpmDto Detail(decimal id, int stt)
        {
            return _benhAnCpmRepository.Table.Where(x => x.Idba == id && x.Stt == stt).Select(x => new BenhanCpmDto()
            {
                Idba = x.Idba,
                Stt = x.Stt,
                KhoaDieuTri = new BenhAnKhoaDieuTriDto()
                {
                    Stt = x.BenhAnKhoaDieuTri.Stt,
                    NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
                    Khoa = new DmkhoaDto()
                    {
                        MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                        TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
                    }
                },
                ChePhamMau = new DmchephamMauDto()
                {
                    MaDV = x.DmchephamMau.MaCpmau,
                    TenDV = x.DmchephamMau.TenCpmau,
                },
                NgayYlenh = x.NgayYlenh,
                BsChiDinh = new DmnhanVienDto()
                {
                    MaNv = x.DmnhanVien.MaNv,
                    HoTen = x.DmnhanVien.HoTen
                },
                TruyenMau = new TruyenMauDto()
                {
                    TheTich = x.BenhAnTheoDoiTruyenMau.TheTich,
                    ThoiGianBd = x.BenhAnTheoDoiTruyenMau.ThoiGianBd,
                    ThoiGianKt = x.BenhAnTheoDoiTruyenMau.ThoiGianKt
                },
                Huy = x.Huy,
                DonVi = x.DonVi,
                SoLuong = x.SoLuong,
                Nhommau = x.Nhommau,
                Rh = x.Rh,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                NguoiSD = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },
            }).FirstOrDefault();
        }

        public void Store(BenhAnCpmCreateVM benhAnCpmCreateVM)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnCpmCreateVM.Idba);
            var benhAnToDieuTri = _benhAnCpmRepository._context.BenhAnToDieuTri.Where(x => x.Idba == benhAnCpmCreateVM.Idba && x.NgayYlenh == benhAnCpmCreateVM.NgayYlenh).First();
            var stt = (_benhAnCpmRepository.Table.Where(x => x.Idba == benhAnCpmCreateVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

            benhAnCpmCreateVM.Stt = stt;
            benhAnCpmCreateVM.MaBa = benhAn.MaBa;
            benhAnCpmCreateVM.MaBn = benhAn.MaBn;
            // benhAnCpmCreateVM.Idhis = "";
            benhAnCpmCreateVM.Sttkhoa = benhAnToDieuTri.Sttkhoa;
            benhAnCpmCreateVM.BschiDinh = benhAnCpmCreateVM.BschiDinh ?? benhAnToDieuTri.BsdieuTri;

            _benhAnCpmRepository.Insert(benhAnCpmCreateVM);
        }
        public void Destroy(decimal idba, int stt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnCpmRepository.Delete(idba, stt);
        }
        public void Update(decimal idba, int stt, BenhAnCpmVM benhanCpm)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnCpmRepository.Update(benhanCpm, idba, stt);
        }
    }
}
