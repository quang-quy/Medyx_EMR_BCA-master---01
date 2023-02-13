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
using System.Linq;
namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnTtvltlThuchienService
    {
        private IRepository<BenhAnTtvltlThuchien> repository = null;
        public BenhAnTtvltlThuchienService(IHttpContextAccessor accessor = null)
        {
            repository = new GenericRepository<BenhAnTtvltlThuchien>(accessor);
        }

        public IQueryable<BenhAnTtvltlThuchienDto> Get(BenhAnTtvltlThuchienParameters parameters, UserSession user = null)
        {
            var query = repository.Table.AsQueryable();

            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.Huy.HasValue)
            {
                query = query.Where(x => x.Huy == parameters.Huy);
            }
            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = SortHelper.ApplySort(query, parameters.SortBy);

            return query.Select(x => new BenhAnTtvltlThuchienDto()
            {
                Idba = x.Idba,
                Stt = x.Stt,
                SttdotDt = x.SttdotDt,
                SttchiDinh = x.SttchiDinh,
                NgayThucHien = x.NgayThucHien,
                PhuongPhap = new DmdichVuDto()
                {
                    MaDv = x.BenhanTtvltl.MaDv,
                    TenDv = x.BenhanTtvltl.DmdichVu.TenDv
                },
                ThoiGian = x.ThoiGian,
                LieuLuong = x.LieuLuong,
                GhiChu = x.GhiChu,
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgaySd = x.NgaySd,
                NgayHuy = x.NgayHuy,
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
                NguoiSD = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },
            });
        }

        public BenhAnTtvltlThuchienDto Detail(decimal idba, int stt)
        {
			var query = repository.Table.AsQueryable();

			var queryBenhAnTtvltlThuchienDetail = query.Select(x => new BenhAnTtvltlThuchienDto()
			{
                Idba = x.Idba,
                Stt = x.Stt,
                SttdotDt = x.SttdotDt,
                SttchiDinh = x.SttchiDinh,
                NgayThucHien = x.NgayThucHien,
                PhuongPhap = new DmdichVuDto()
                {
                    MaDv = x.BenhanTtvltl.MaDv,
                    TenDv = x.BenhanTtvltl.DmdichVu.TenDv
                },
                ThoiGian = x.ThoiGian,
                LieuLuong = x.LieuLuong,
                GhiChu = x.GhiChu,
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgaySd = x.NgaySd,
                NgayHuy = x.NgayHuy,
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
                NguoiSD = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },
            });
			return queryBenhAnTtvltlThuchienDetail.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);
		}
        public void Store(BenhAnTtvltlThuchienCreateVM info)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(info.Idba);
            var stt = (repository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            info.Stt = stt;
            // info.Idhis = stt.ToString();
            repository.Insert(info);
        }
        public void Update(decimal id, int stt, BenhAnTtvltlThuchienVM info)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
            repository.Update(info, stt, id);
        }

        public void Destroy(decimal id, int stt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
            repository.Delete(stt, id);
        }
    }
}
