using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnTheoDoiTruyenMauCService
	{
		private IRepository<BenhAnTheodoiTruyenMauC> _benhanTheodoiTruyenMauCRepository = null;
		private PrintSetting PrintSetting { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;
		public BenhAnTheoDoiTruyenMauCService(IHostingEnvironment hostingEnvironment = null, IHttpContextAccessor accessor = null, IOptions<PrintSetting> options = null)
		{
			_benhanTheodoiTruyenMauCRepository = new GenericRepository<BenhAnTheodoiTruyenMauC>(accessor);
			PrintSetting = options != null ? options.Value : new PrintSetting();
			_hostingEnvironment = hostingEnvironment;
		}

		public IQueryable<BenhanTheodoiTruyenMauCDto> Get(BenhAnTheodoiTruyenMauCParameters parameters, UserSession user = null)
		{
			var query = _benhanTheodoiTruyenMauCRepository.Table.AsQueryable();

			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			if (parameters.StttruyenMau.HasValue)
			{
				query = query.Where(x => x.StttruyenMau == parameters.StttruyenMau);
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);

			IQueryable<BenhanTheodoiTruyenMauCDto> benhAnPhauThuatQuery = query.Select(x => new BenhanTheodoiTruyenMauCDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				StttruyenMau = x.StttruyenMau,
				ThoiGian = x.ThoiGian,
				TocDo = x.TocDo,
				MauSacDa = x.MauSacDa,
				NhipTho = x.NhipTho,
				Mach = x.Mach,
				NhietDo = x.NhietDo,
				HuyetAp = x.HuyetAp,
				DienBienKhac = x.DienBienKhac,
				Huy = x.Huy,
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
			return benhAnPhauThuatQuery;
		}

		public BenhanTheodoiTruyenMauCDto Detail(decimal idba, int stt)
		{
			return _benhanTheodoiTruyenMauCRepository.Table.Where(x => x.Idba == idba && x.Stt == stt).Select(x => new BenhanTheodoiTruyenMauCDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				StttruyenMau = x.StttruyenMau,
				ThoiGian = x.ThoiGian,
				TocDo = x.TocDo,
				MauSacDa = x.MauSacDa,
				NhipTho = x.NhipTho,
				Mach = x.Mach,
				NhietDo = x.NhietDo,
				HuyetAp = x.HuyetAp,
				DienBienKhac = x.DienBienKhac,
				Huy = x.Huy,
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

		public void Store(BenhAnTheoDoiTruyenMauCCreateVM parameters)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);

			var stt = (_benhanTheodoiTruyenMauCRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

			parameters.Stt = stt;
			_benhanTheodoiTruyenMauCRepository.Insert(parameters);
		}

		public void Update(decimal idba, int stt, BenhAnTheoDoiTruyenMauCVM parameters)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhanTheodoiTruyenMauCRepository.Update(parameters, idba, stt);
		}

		public void Destroy(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhanTheodoiTruyenMauCRepository.Delete(idba, stt);
		}
	}

}
