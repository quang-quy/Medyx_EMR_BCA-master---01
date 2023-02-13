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
	public class BenhAnPhauThuatService
	{
		private IRepository<BenhanPhauThuat> _benhAnPhauThuatRepository = null;

		public BenhAnPhauThuatService(IHttpContextAccessor accessor = null)
		{
			_benhAnPhauThuatRepository = new GenericRepository<BenhanPhauThuat>(accessor);
		}

		public IQueryable<BenhanPhauThuatDto> Get(BenhanPhauThuatParameters parameters, UserSession user = null)
		{
			var query = _benhAnPhauThuatRepository.Table.AsQueryable();

			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}

			query = QueryFilter(query, parameters);
			query = SortHelper.ApplySort(query, parameters.SortBy);

			IQueryable<BenhanPhauThuatDto> benhAnPhauThuatQuery = query.Select(x => new BenhanPhauThuatDto()
			{
				Stt = x.Stt,
				Idba = x.Idba,
				Idhis = x.Idhis,
				MaBa = x.MaBa,
				MaBn = x.MaBn,
				Sttkhoa = x.Sttkhoa,
				Khoa = new DmkhoaDto()
				{
					MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
					TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
				},
				PhauThuat = new DmphauThuatDto()
				{
					MaPt = x.DmphauThuat.MaPt,
					TenPt = x.DmphauThuat.TenPt
				},
				DoiTuong = x.DoiTuong,
				BschiDinh = new DmnhanVienDto()
				{
					MaNv = x.DmBschiDinh.MaNv,
					HoTen = x.DmBschiDinh.HoTen
				},
				MaMay = x.MaMay,
				Huy = x.Huy,
				ViTri = x.ViTri,
				NgayLap = x.NgayLap,
				NgayHuy = x.NgayHuy,
				NgayYlenh = x.NgayYlenh,
				NgaySd = x.NgaySd,
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
				NguoiHuy = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiHuy.MaNv,
					HoTen = x.DmNguoiHuy.HoTen
				}
			});
			return benhAnPhauThuatQuery;
		}

		private IQueryable<BenhanPhauThuat> QueryFilter(IQueryable<BenhanPhauThuat> query, BenhanPhauThuatParameters parameters)
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

		public BenhanPhauThuat Detail(decimal idba, int stt)
		{
			return _benhAnPhauThuatRepository.GetById(idba, stt);
		}

		public void Store(BenhAnPhauThuatCreateVM benhAnPhauThuatCreateVM)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnPhauThuatCreateVM.Idba);
			var benhAnToDieuTri = _benhAnPhauThuatRepository._context.BenhAnToDieuTri.Where(x => x.Idba == benhAnPhauThuatCreateVM.Idba && x.NgayYlenh == benhAnPhauThuatCreateVM.NgayYlenh).First();
			var stt = (_benhAnPhauThuatRepository.Table.Where(x => x.Idba == benhAnPhauThuatCreateVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

			benhAnPhauThuatCreateVM.Stt = stt;
			benhAnPhauThuatCreateVM.MaBa = benhAn.MaBa;
			benhAnPhauThuatCreateVM.MaBn = benhAn.MaBn;
			// benhAnPhauThuatCreateVM.Idhis = "";
			benhAnPhauThuatCreateVM.Sttkhoa = benhAnToDieuTri.Sttkhoa;
			benhAnPhauThuatCreateVM.Bschidinh = benhAnPhauThuatCreateVM.Bschidinh ?? benhAnToDieuTri.BsdieuTri;

			_benhAnPhauThuatRepository.Insert(benhAnPhauThuatCreateVM);
		}

		public void Update(decimal idba, int stt, BenhAnPhauThuatVM benhanPhauThuat)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnPhauThuatRepository.Update(benhanPhauThuat, idba, stt);
		}

		public void Destroy(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnPhauThuatRepository.Delete(idba, stt);
		}
	}
}
