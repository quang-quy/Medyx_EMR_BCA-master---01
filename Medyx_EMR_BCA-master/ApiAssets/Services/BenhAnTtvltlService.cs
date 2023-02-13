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
    public class BenhAnTtvltlService
    {
        private IRepository<BenhanTtvltl> _benhAnTtvltlRepository = null;
        private IRepository<DmdichvuGoiC> _dmdichvuGoiCRepositoty;
        public BenhAnTtvltlService(IHttpContextAccessor accessor = null)
        {
            _benhAnTtvltlRepository = new GenericRepository<BenhanTtvltl>(accessor);
            _dmdichvuGoiCRepositoty = new GenericRepository<DmdichvuGoiC>(accessor);
        }

        public IQueryable<BenhanTtvltlDto> Get(BenhanTtvltlParameters parameters, UserSession user = null)
        {
            var query = _benhAnTtvltlRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);

            IQueryable<BenhanTtvltlDto> benhAnTtvltlQuery = query.Select(x => new BenhanTtvltlDto()
            {
                Stt = x.Stt,
                NgayYlenh = x.NgayYlenh,
                DichVu = new DmdichVuDto()
                {
                    MaDv = x.DmdichVu.MaDv,
                    MaChungloai = x.DmdichVu.MaChungloai,
                    TenDv = x.DmdichVu.TenDv,
                    TenTat = x.DmdichVu.TenTat,
                    DonViDo = x.DmdichVu.DonViDo
                },
                SoLuong = x.SoLuong,
                ViTri = x.ViTri,
                ThoiGian = x.ThoiGian,
                Huy = x.Huy,
                NgaySd = x.NgaySd,
                NguoiSD = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },
                NgayHuy = x.NgayHuy,
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                NgayLap = x.NgayLap,
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
            });
            return benhAnTtvltlQuery;
        }

        private IQueryable<BenhanTtvltl> QueryFilter(IQueryable<BenhanTtvltl> query, BenhanTtvltlParameters parameters)
        {
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.NgayYlenh.HasValue)
            {
                query = query.Where(x => x.NgayYlenh == parameters.NgayYlenh);
            }
            if(parameters.NgayVaoDieuTri == "null" || !string.IsNullOrEmpty(parameters.NgayVaoDieuTri))
            {
                query = query.Where(x => Convert.ToDateTime(x.NgayYlenh).ToString("yyyy-MM-dd") == parameters.NgayVaoDieuTri);
            }
            if(parameters.Sttkhoa.HasValue)
            {
                query = query.Where(x => x.Sttkhoa == parameters.Sttkhoa);
            }
            return query;
        }

        public void Store(BenhAnTtvltlCreateVM benhAnTtvltlVM)
        {
            var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnTtvltlVM.Idba);
            var benhAnToDieuTri = _benhAnTtvltlRepository._context.BenhAnToDieuTri.First(x => x.Idba == benhAnTtvltlVM.Idba && x.NgayYlenh == benhAnTtvltlVM.NgayYlenh);
            var stt = (_benhAnTtvltlRepository.Table.Where(x => x.Idba == benhAnTtvltlVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

            if (!string.IsNullOrEmpty(benhAnTtvltlVM.MaGoi))
            {
                var dichVuGois = _benhAnTtvltlRepository._context.DmdichvuGoiC.Where(x => x.MaGoi == benhAnTtvltlVM.MaGoi).ToList();
                foreach (var dichVuGoi in dichVuGois)
                {
                    _benhAnTtvltlRepository.Insert(new BenhanTtvltl()
                    {
                        Idba = benhAnTtvltlVM.Idba,
                        Stt = stt,
                        // Idhis = stt.ToString(),
                        MaBa = benhan.MaBa,
                        MaBn = benhan.MaBn,
                        Sttkhoa = benhAnToDieuTri.Sttkhoa,
                        NgayYlenh = benhAnTtvltlVM.NgayYlenh,
                        MaDv = dichVuGoi.MaDv,
                        Bschidinh = benhAnToDieuTri.BsdieuTri,
                    });
                }
            }
            else
            {
                benhAnTtvltlVM.Stt = stt;
                // benhAnTtvltlVM.Idhis = stt.ToString();
                benhAnTtvltlVM.MaBa = benhan.MaBa;
                benhAnTtvltlVM.MaBn = benhan.MaBn;
                benhAnTtvltlVM.Sttkhoa = benhAnToDieuTri.Sttkhoa;
                benhAnTtvltlVM.Bschidinh = benhAnToDieuTri.BsdieuTri;
                _benhAnTtvltlRepository.Insert(benhAnTtvltlVM);
            }
        }

        public void Update(decimal idba, int stt, BenhAnTtvltlVM benhanTtvltl)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnTtvltlRepository.Update(benhanTtvltl, idba, stt);
        }

        public void Destroy(decimal idba, int stt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnTtvltlRepository.Delete(idba, stt);
        }
    }
}
