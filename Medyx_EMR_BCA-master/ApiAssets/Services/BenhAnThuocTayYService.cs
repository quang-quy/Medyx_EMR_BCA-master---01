using AutoMapper;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnThuocTayYService
    {
        private IRepository<BenhanThuocTayY> _benhAnThuocTayYRepository = null;
        public BenhAnThuocTayYService(IHttpContextAccessor accessor = null)
        {
            _benhAnThuocTayYRepository = new GenericRepository<BenhanThuocTayY>(accessor);
        }

        public IQueryable<BenhAnThuocTayYDto> Get(BenhanThuocTayYParameters parameters, UserSession user = null)
        {
            var query = _benhAnThuocTayYRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);
            var selectQuery = DtoQuery();
            IQueryable<BenhAnThuocTayYDto> benhAnThuocTayYQuery = query.Select(selectQuery);
            return benhAnThuocTayYQuery;
        }

        public Expression<Func<BenhanThuocTayY, BenhAnThuocTayYDto>> DtoQuery()
        {
			return x => new BenhAnThuocTayYDto()
            {
                Stt = x.Stt,
                MaThuoc = x.Dmthuoc.MaThuoc,
                TenThuoc = x.Dmthuoc.TenTm,
                SoDangKi = x.Dmthuoc.SoDangKy,
                NgayYLenh = x.NgayYlenh,
                Thuoc = new DmthuocDto()
                {
                    MaThuoc = x.Dmthuoc.MaThuoc,
                    MaPl = x.Dmthuoc.MaPl,
                    TenGoc = x.Dmthuoc.TenGoc,
                    TenTm = x.Dmthuoc.TenTm,
                    HamLuong = x.Dmthuoc.HamLuong,
                    DonViTinh = new DmthuocDonvitinhDto()
                    {
                        MaDvt = x.Dmthuoc.DmthuocDonvitinh.MaDvt,
                        TenDvt = x.Dmthuoc.DmthuocDonvitinh.TenDvt
                    },
                    ThuocDuongDung = new DmthuocDuongDungDto()
                    {
                        MaDuongDung = x.Dmthuoc.DmthuocDuongDung.MaDuongDung,
                        TenDuongDung = x.Dmthuoc.DmthuocDuongDung.TenDuongDung,
                    },
                },
                SoLuong = x.SoLuong,
                Lieudung = x.Lieudung,
                CachDung = x.CachDung,
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
                BsChiDinh = new DmnhanVienDto()
                {
                    MaNv = x.DmnhanVien.MaNv,
                    HoTen = x.DmnhanVien.HoTen
                }
            };
		}

        private IQueryable<BenhanThuocTayY> QueryFilter(IQueryable<BenhanThuocTayY> query, BenhanThuocTayYParameters parameters)
        {
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.NgayYlenh.HasValue)
            {
                query = query.Where(x => x.NgayYlenh == parameters.NgayYlenh);
            }
            if(parameters.Sttkhoa.HasValue)
            {
                query = query.Where(x => x.Sttkhoa == parameters.Sttkhoa);
            }

            return query;
        }

        public BenhanThuocTayY Detail(decimal idba, int stt)
        {
            return _benhAnThuocTayYRepository.GetById(stt, idba);
        }

        public void Store(BenhAnThuocTayYCreateVM benhAnThuocTayY)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnThuocTayY.Idba);
            var stt = (_benhAnThuocTayYRepository.Table.Where(x => x.Idba == benhAnThuocTayY.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

            var thuoc = _benhAnThuocTayYRepository._context.Dmthuoc.First(x => x.MaThuoc == benhAnThuocTayY.MaThuoc);

            benhAnThuocTayY.MaBa = benhAn.MaBa;
            // benhAnThuocTayY.Idhis = stt.ToString();
            benhAnThuocTayY.Stt = stt;
            benhAnThuocTayY.MaBn = benhAn.MaBn;
            benhAnThuocTayY.TenThuoc = thuoc.TenTm;
            _benhAnThuocTayYRepository.Insert(benhAnThuocTayY);
        }

        public void Update(decimal idba, int stt, BenhAnThuocTayYVM benhAnThuocTayY)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            var thuoc = _benhAnThuocTayYRepository._context.Dmthuoc.First(x => x.MaThuoc == benhAnThuocTayY.MaThuoc);
            benhAnThuocTayY.TenThuoc = thuoc.TenTm;

            _benhAnThuocTayYRepository.Update(benhAnThuocTayY, idba, stt);
        }
        public void Destroy(decimal idba, int stt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnThuocTayYRepository.Delete(idba, stt);
        }
    }
}
