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
using System.Runtime.InteropServices.ComTypes;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnThuocYhctCService
	{
		private IRepository<BenhanThuocYhctC> _benhAnThuocYhctCRepository = null;
		public BenhAnThuocYhctCService(IHttpContextAccessor accessor = null)
		{
			_benhAnThuocYhctCRepository = new GenericRepository<BenhanThuocYhctC>(accessor);
		}

		public IQueryable<BenhAnThuocYhctCDto> Get(BenhanThuocYhctCParameters parameters, UserSession user = null)
		{
			var query = _benhAnThuocYhctCRepository.Table.AsQueryable();

			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}

			query = QueryFilter(query, parameters);
			query = SortHelper.ApplySort(query, parameters.SortBy);

			IQueryable<BenhAnThuocYhctCDto> benhAnThuocYhctQuery = query.Select(x => new BenhAnThuocYhctCDto()
			{
				Stt = x.Stt,
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
					}
				},
				DonVi = x.DonVi,
				SoLuong = x.SoLuong,
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
			return benhAnThuocYhctQuery;
		}

		private IQueryable<BenhanThuocYhctC> QueryFilter(IQueryable<BenhanThuocYhctC> query, BenhanThuocYhctCParameters parameters)
		{
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			if (parameters.Sttthuoc.HasValue)
			{
				query = query.Where(x => x.Sttthuoc == parameters.Sttthuoc);
			}
			return query;
		}

		public BenhanThuocYhctC Detail(decimal idba, int stt)
		{
			return _benhAnThuocYhctCRepository.GetById(stt, idba);
		}

		public void Store(BenhAnThuocYhctCCreateVM parameters)
		{
			var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
			if (parameters.Thuocs.Any())
			{
				foreach (var thuoc in parameters.Thuocs)
				{
					var benhAnThuocYhctc = _benhAnThuocYhctCRepository.Table.FirstOrDefault(x => x.Idba == parameters.Idba && x.Sttthuoc == parameters.Sttthuoc && x.MaThuoc == thuoc.MaThuoc);
					if (benhAnThuocYhctc != null)
					{
						benhAnThuocYhctc.SoLuong = (benhAnThuocYhctc.SoLuong ?? 0) + thuoc.SoLuong;
						benhAnThuocYhctc.NgaySd = DateTime.Now;
						benhAnThuocYhctc.NguoiSd = _benhAnThuocYhctCRepository.GetUser();
					}
					else
					{
						// var benhan = _benhAnThuocYhctCRepository._context.BenhAn.First(x => x.Idba == parameters.Idba);
						var stt = (_benhAnThuocYhctCRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

						_benhAnThuocYhctCRepository._context.Add(new BenhanThuocYhctC()
						{
							Idba = parameters.Idba,
							Stt = stt,
							// Idhis = stt.ToString(),
							MaBa = benhan.MaBa,
							MaBn = benhan.MaBn,
							Sttkhoa = parameters.Sttkhoa,
							Sttthuoc = parameters.Sttthuoc,
							MaThuoc = thuoc.MaThuoc,
							SoLuong = thuoc.SoLuong,
							DonVi = thuoc.DonVi,
							NgayLap = DateTime.Now,
							NguoiLap = _benhAnThuocYhctCRepository.GetUser(),
							MaMay = LocationHelper.GetLocalIPAddress()
						});
					}
					_benhAnThuocYhctCRepository._context.SaveChanges();
				}
			}
			else
			{
				var benhAnThuocYhctc = _benhAnThuocYhctCRepository.Table.FirstOrDefault(x => x.Idba == parameters.Idba && x.Sttthuoc == parameters.Sttthuoc && x.MaThuoc == parameters.MaThuoc);
				if (benhAnThuocYhctc != null)
				{
					benhAnThuocYhctc.SoLuong = (benhAnThuocYhctc.SoLuong ?? 0) + parameters.SoLuong;
					_benhAnThuocYhctCRepository.Update(benhAnThuocYhctc, benhAnThuocYhctc.Idba, benhAnThuocYhctc.Stt);
				}
				else
				{
					// var benhan = _benhAnThuocYhctCRepository._context.BenhAn.First(x => x.Idba == parameters.Idba);
					var stt = (_benhAnThuocYhctCRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

					parameters.Stt = stt;
					// parameters.Idhis = stt.ToString();
					parameters.MaBa = benhan.MaBa;
					parameters.MaBn = benhan.MaBn;

					_benhAnThuocYhctCRepository.Insert(parameters);
				}
			}

		}

		public void Update(decimal idba, int stt, BenhAnThuocYhctCVM benhAnThuocYhctCVM)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnThuocYhctCRepository.Update(benhAnThuocYhctCVM, idba, stt);
		}

		public void Destroy(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnThuocYhctCRepository.Delete(idba, stt);
		}
	}
}
