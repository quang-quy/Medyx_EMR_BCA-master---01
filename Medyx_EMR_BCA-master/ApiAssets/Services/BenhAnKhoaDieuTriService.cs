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
	public class BenhAnKhoaDieuTriService
	{
		private IRepository<BenhAnKhoaDieuTri> repository = null;
		public BenhAnKhoaDieuTriService(IHttpContextAccessor accessor = null)
		{
			repository = new GenericRepository<BenhAnKhoaDieuTri>(accessor);
		}

		public Response<BenhAnKhoaDieuTriDto> Get(BenhAnKhoaDieuTriParameters parameters, UserSession user = null)
		{
			var query = repository.Table
				 .Include(x => x.Dmkhoa)
				.Include(x => x.DmnhanVien)
				.Include(x => x.DmkhoaBuong)
				.Include(x => x.DmkhoaGiuong)
				.Include(x => x.BenhChinh)
				.Include(x => x.BenhKem1)
				.Include(x => x.BenhKem2)
				.Include(x => x.BenhKem3)
				.Include(x => x.DmNguoiHuy)
				.Include(x => x.DmNguoiLap)
				.Include(x => x.DmNguoiSD)
				.AsQueryable();
			if ((parameters.forSelect.HasValue && parameters.forSelect.Value) || user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}
			if (!string.IsNullOrEmpty(parameters.Search))
			{
			}
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}

			if (parameters.NgayGioVaoKhoa.HasValue)
			{
				query = query.Where(x => DateTime.Compare((DateTime)parameters.NgayGioVaoKhoa, x.NgayVaoKhoa) <= 0);
			}
			if (!string.IsNullOrEmpty(parameters.KhoaDieuTri))
			{
				query = query.Where(x => x.Dmkhoa.TenKhoa.ToLower().Contains(parameters.KhoaDieuTri.ToLower()) || x.MaKhoa == parameters.KhoaDieuTri);
			}
			if (!string.IsNullOrEmpty(parameters.Giuong))
			{
				query = query.Where(x => x.DmkhoaGiuong.TenGiuong.ToLower().Contains(parameters.Giuong.ToLower()) || x.Giuong == parameters.Giuong);
			}
			if (!string.IsNullOrEmpty(parameters.Buong))
			{
				query = query.Where(x => x.DmkhoaBuong.TenBuong.ToLower().Contains(parameters.Buong.ToLower()) || x.Buong == parameters.Buong);
			}
			if (!string.IsNullOrEmpty(parameters.BenhChinh))
			{
				query = query.Where(x => x.BenhChinh.TenBenh.ToLower().Contains(parameters.BenhChinh.ToLower()) || x.MaBenhChinhVk == parameters.BenhChinh);
			}
			if (!string.IsNullOrEmpty(parameters.BenhKem1))
			{
				query = query.Where(x => x.BenhKem1.TenBenh.ToLower().Contains(parameters.BenhKem1.ToLower()) || x.MaBenhKemVk1 == parameters.BenhKem1);
			}
			if (!string.IsNullOrEmpty(parameters.BenhKem2))
			{
				query = query.Where(x => x.BenhKem2.TenBenh.ToLower().Contains(parameters.BenhKem2.ToLower()) || x.MaBenhKemVk2 == parameters.BenhKem2);
			}
			if (!string.IsNullOrEmpty(parameters.BenhKem3))
			{
				query = query.Where(x => x.BenhKem3.TenBenh.ToLower().Contains(parameters.BenhKem3.ToLower()) || x.MaBenhKemVk3 == parameters.BenhKem3);
			}
			if (!string.IsNullOrEmpty(parameters.nguoiLap))
			{
				query = query.Where(x => x.DmNguoiLap.HoTen.ToLower().Contains(parameters.nguoiLap.ToLower()) || x.NguoiLap == parameters.nguoiLap);
			}
			if (!string.IsNullOrEmpty(parameters.nguoiHuy))
			{
				query = query.Where(x => x.DmNguoiHuy.HoTen.ToLower().Contains(parameters.nguoiHuy.ToLower()) || x.NguoiHuy == parameters.nguoiHuy);
			}
			if (!string.IsNullOrEmpty(parameters.bsDieuTri))
			{
				query = query.Where(x => x.DmnhanVien.HoTen.ToLower().Contains(parameters.bsDieuTri.ToLower()) || x.BsdieuTri.ToLower() == parameters.bsDieuTri.ToLower() || x.DmnhanVien.MaKhoa.ToLower() == parameters.bsDieuTri.ToLower());
			}
			if (parameters.Huy.HasValue)
			{
				query = query.Where(x => x.Huy == parameters.Huy);
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);
			var query_result = query.Select(ba => new BenhAnKhoaDieuTriDto()
			{
				Idba = ba.Idba,
				Stt = ba.Stt,
				Idhis = ba.Idhis,
				MaBa = ba.MaBa,
				MaBn = ba.MaBn,
				MaKhoa = ba.MaKhoa,
				NgayVaoKhoa = ba.NgayVaoKhoa,
				SoNgayDt = ba.SoNgayDt,
				Huy = ba.Huy,
				MaMay = ba.MaMay,
				NgayLap = ba.NgayLap,
				NgaySd = ba.NgaySd,
				NgayHuy = ba.NgayHuy,
				Khoa = new DmkhoaDto()
				{
					MaKhoa = ba.Dmkhoa.MaKhoa,
					TenKhoa = ba.Dmkhoa.TenKhoa
				},
				Buong = new DmkhoaBuongDto()
				{
					MaBuong = ba.DmkhoaBuong.MaBuong,
					TenBuong = ba.DmkhoaBuong.TenBuong
				},
				Giuong = new DmkhoaGiuongDto()
				{
					MaGiuong = ba.DmkhoaGiuong.MaGiuong,
					TenGiuong = ba.DmkhoaGiuong.TenGiuong
				},
				BenhChinh = new DmbenhTatDto()
				{
					MaBenh = ba.BenhChinh.MaBenh,
					TenBenh = ba.BenhChinh.TenBenh
				},
				BenhKem1 = new DmbenhTatDto()
				{
					MaBenh = ba.BenhKem1.MaBenh,
					TenBenh = ba.BenhKem1.TenBenh
				},
				BenhKem2 = new DmbenhTatDto()
				{
					MaBenh = ba.BenhKem2.MaBenh,
					TenBenh = ba.BenhKem2.TenBenh
				},
				BenhKem3 = new DmbenhTatDto()
				{
					MaBenh = ba.BenhKem3.MaBenh,
					TenBenh = ba.BenhKem3.TenBenh
				},
				BsdieuTri = new DmnhanVienDto()
				{
					MaNv = ba.DmnhanVien.MaNv,
					HoTen = ba.DmnhanVien.HoTen
				},
				NguoiHuy = new DmnhanVienDto()
				{
					MaNv = ba.DmNguoiHuy.MaNv,
					HoTen = ba.DmNguoiHuy.HoTen
				},
				NguoiLap = new DmnhanVienDto()
				{
					MaNv = ba.DmNguoiLap.MaNv,
					HoTen = ba.DmNguoiLap.HoTen
				},
				NguoiSD = new DmnhanVienDto()
				{
					MaNv = ba.DmNguoiSD.MaNv,
					HoTen = ba.DmNguoiSD.HoTen
				},
			});
			return Res<BenhAnKhoaDieuTriDto>.Get(query_result, parameters.PageNumber, parameters.PageSize);

		}

		public BenhAnKhoaDieuTri Show(decimal id)
		{
			var model = repository.Table.Where(x => x.Idba == id).FirstOrDefault();
			return model;
		}

		public BenhAnKhoaDieuTri Show(decimal id, int stt)
		{
			var model = repository.GetById(id, stt);
			return model;
		}
		public void Store(BenhAnKhoaDieuTriCreateVM info)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(info.Idba);
			var stt = (repository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
			info.MaBa = benhAn.MaBa;
			info.MaBn = benhAn.MaBn;
			info.Stt = stt;
			// info.Idhis = "";
			repository.Insert(info);
		}
		public void Update(decimal id, int stt, BenhAnKhoaDieuTriVM info)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
			repository.Update(info, id, stt);
		}

		public void Destroy(decimal id, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
			repository.Delete(id, stt);
		}
	}
}
