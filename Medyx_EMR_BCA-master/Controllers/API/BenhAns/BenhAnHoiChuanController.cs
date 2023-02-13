using Medyx.ApiAssets.Dto.Print;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-hoi-chuan")]
	[ApiController]
	[SessionFilter]
	public class BenhAnHoiChuanController : ControllerBase
	{
		private IRepository<BenhAnHoiChan> repository = null;
		private readonly IHostingEnvironment _hostingEnvironment;
		private UploadFileRespository uploadFileRespository = null;
		private PrintSetting PrintSetting { get; set; }
		public BenhAnHoiChuanController(IHostingEnvironment hostingEnvironment, IHttpContextAccessor accessor, IOptions<PrintSetting> options = null)
		{
			repository = new GenericRepository<BenhAnHoiChan>(accessor);
			_hostingEnvironment = hostingEnvironment;
			uploadFileRespository = new UploadFileRespository();
			PrintSetting = options != null ? options.Value : new PrintSetting();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnHoiChanDto> Get([FromQuery] BenhanHoiChanParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			var query = repository.Table.AsQueryable();
			query = query.Include(x => x.DmChuToa)
						.Include(x => x.DmThuKy)
						.Include(x => x.DmNguoiLap)
						.Include(x => x.DmNguoiSD)
						.Include(x => x.DmNguoiHuy)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa);
			query = SortHelper.ApplySort(query, parameters.SortBy);
			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}
			if (parameters.Idba.HasValue)
			{
				query = query = query.Where(x => x.Idba == parameters.Idba);
			}
			query = SortHelper.ApplySort(query, parameters.SortBy);

			var querySelect = BenhAnHoiChanDtoQuery();
			var new_query = query.Select(querySelect);

			return Res<BenhAnHoiChanDto>.Get(new_query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnHoiChan Detail(decimal idba, int stt)
		{
			var model = repository.GetById(idba, stt);
			return model;
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost("{idba}")]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/HoiChan/create")]
		public ActionResult Store(decimal idba, [FromBody] BenhAnHoiChanCreateVM info)
		{
			if (ModelState.IsValid)
			{
				var benhan = repository._context.BenhAn.First(x => x.Idba == idba);
				PermissionThrowHelper.DongBenhAnCheck(benhan.XacNhanKetThucHs);
				info.MaBa = benhan.MaBa;
				info.MaBn = benhan.MaBn;
				info.Idba = idba;
				info.Stt = (repository.Table.Where(x => x.Idba == idba).Max(x => (int?)x.Stt) ?? 0) + 1;
				repository.Insert(info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/HoiChan/modify")]
		public ActionResult Update(decimal idba, int stt, [FromBody] BenhAnHoiChanVM info)
		{
			if (ModelState.IsValid)
			{
				PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);

                repository.Update(info, idba, stt);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/HoiChan/delete")]
		public ActionResult Delete(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			repository.Delete(idba, stt);
            return Ok();
		}
		[HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/HoiChan/export")]
		public ActionResult Print(decimal idba, int stt)
		{
			var benhAn = repository._context.BenhAn
			.Include(x => x.ThongTinBn).ThenInclude(x => x.Dmtinh)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquanHuyen)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmphuongXa)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquocGia)
			.Select(ba => new BenhAnDto()
			{
				Idba = ba.Idba,
				SoVaoVien = ba.SoVaoVien,
				NgayVv = ba.NgayVv,
				BenhNhan = new ThongTinBnDto()
				{
					MaBn = ba.ThongTinBn.MaBn,
					Idba = ba.ThongTinBn.Idba,
					HoTen = ba.ThongTinBn.HoTen,
					NgaySinh = ba.ThongTinBn.NgaySinh,
					Tuoi = ba.ThongTinBn.Tuoi,
					GioiTinh = ba.ThongTinBn.GioiTinh
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var query = repository.Table.Include(x => x.DmChuToa)
						.Include(x => x.DmThuKy)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmkhoaBuong)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmkhoaGiuong)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.BenhChinh)
						.AsQueryable();
			var querySelect = BenhAnHoiChanDtoQuery();
			var new_query = query.Select(querySelect);
			var benhAnHoiChan = new_query.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);
			DateTime? dieuTriDenNgay = null;
			if (benhAnHoiChan?.KhoaDieuTri != null)
			{
				dieuTriDenNgay = repository._context.BenhAnKhoaDieuTri.Where(x => x.NgayVaoKhoa > benhAnHoiChan.KhoaDieuTri.NgayVaoKhoa && x.Idba == idba).OrderBy(x => x.NgayVaoKhoa).Select(x => x.NgayVaoKhoa).FirstOrDefault();
			}
			dieuTriDenNgay = dieuTriDenNgay == null ? dieuTriDenNgay : benhAnHoiChan.NgayHoiChan;

			List<BenhAnHoiChanPrintDto> benhAnHoiChans = new List<BenhAnHoiChanPrintDto>();
			benhAnHoiChans.Add(new BenhAnHoiChanPrintDto()
			{
				SoYTe = PrintSetting.SoYTe,
				BenhVien = PrintSetting.BenhVien,
				SoVaoVien = benhAn.SoVaoVien,
				HoTen = benhAn.BenhNhan.HoTen,
				Tuoi = benhAn.BenhNhan.Tuoi.ToString(),
				GioiTinh = Convert.ToBoolean(benhAn.BenhNhan.GioiTinh) ? "Nam" : "Nữ",
				Khoa = benhAnHoiChan?.KhoaDieuTri?.Khoa?.TenKhoa,
				DieuTriTuNgay = (PrintHelper.DateText(benhAnHoiChan?.KhoaDieuTri?.NgayVaoKhoa))?.ToLower(),
				DieuTriDenNgay = (PrintHelper.DateText(dieuTriDenNgay))?.ToLower(),
				BienBanHoiChan = benhAnHoiChan?.TenBienBanHoiChan,
				Giuong = benhAnHoiChan?.KhoaDieuTri?.Giuong?.TenGiuong,
				Buong = benhAnHoiChan?.KhoaDieuTri?.Buong?.TenBuong,
				ChuanDoan = PrintHelper.ConcatStringArr((object)" - ", benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.MaBenh, benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.TenBenh),
				HoiChanG = PrintHelper.TimeText(benhAnHoiChan?.NgayHoiChan),
				HoiChuanNgay = PrintHelper.DateTextShort(benhAnHoiChan?.NgayHoiChan),
				ChuToa = benhAnHoiChan?.ChuToa?.HoTen,
				ThuKi = benhAnHoiChan?.ThuKy?.HoTen,
				ThanhVienThamGia = benhAnHoiChan?.ThanhVien,
				TomTatDienBien = benhAnHoiChan?.TomTatDienBienBenh,
				KetLuan = benhAnHoiChan?.KetLuan,
				HuongDieuTri = benhAnHoiChan?.HuongDt,
				NgayThang = PrintHelper.DateText(benhAnHoiChan?.NgayHoiChan)
			});
			string path = PrintHelper.PrintFile<BenhAnHoiChanPrintDto>(_hostingEnvironment, "Trich-bien-ban-hoi-chuan.doc", null, null, benhAnHoiChans, "BenhAnHoiChan");
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}

		public string Print(decimal idba, int stt, bool shouldReturnPath = true)
		{
			var benhAn = repository._context.BenhAn
			.Include(x => x.ThongTinBn).ThenInclude(x => x.Dmtinh)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquanHuyen)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmphuongXa)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquocGia)
			.Select(ba => new BenhAnDto()
			{
				Idba = ba.Idba,
				SoVaoVien = ba.SoVaoVien,
				NgayVv = ba.NgayVv,
				BenhNhan = new ThongTinBnDto()
				{
					MaBn = ba.ThongTinBn.MaBn,
					Idba = ba.ThongTinBn.Idba,
					HoTen = ba.ThongTinBn.HoTen,
					NgaySinh = ba.ThongTinBn.NgaySinh,
					Tuoi = ba.ThongTinBn.Tuoi,
					GioiTinh = ba.ThongTinBn.GioiTinh
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var query = repository.Table.Include(x => x.DmChuToa)
						.Include(x => x.DmThuKy)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmkhoaBuong)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmkhoaGiuong)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.BenhChinh)
						.AsQueryable();
			var querySelect = BenhAnHoiChanDtoQuery();
			var new_query = query.Select(querySelect);
			var benhAnHoiChan = new_query.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);
			DateTime? dieuTriDenNgay = null;
			if (benhAnHoiChan?.KhoaDieuTri != null)
			{
				dieuTriDenNgay = repository._context.BenhAnKhoaDieuTri.Where(x => x.NgayVaoKhoa > benhAnHoiChan.KhoaDieuTri.NgayVaoKhoa && x.Idba == idba).OrderBy(x => x.NgayVaoKhoa).Select(x => x.NgayVaoKhoa).FirstOrDefault();
			}
			dieuTriDenNgay = dieuTriDenNgay == null ? dieuTriDenNgay : benhAnHoiChan.NgayHoiChan;
			List<BenhAnHoiChanPrintDto> benhAnHoiChans = new List<BenhAnHoiChanPrintDto>();
			benhAnHoiChans.Add(new BenhAnHoiChanPrintDto()
			{
				SoYTe = PrintSetting.SoYTe,
				BenhVien = PrintSetting.BenhVien,
				SoVaoVien = benhAn.SoVaoVien,
				HoTen = benhAn.BenhNhan.HoTen,
				Tuoi = benhAn.BenhNhan.Tuoi.ToString(),
				GioiTinh = Convert.ToBoolean(benhAn.BenhNhan.GioiTinh) ? "Nam" : "Nữ",
				Khoa = benhAnHoiChan?.KhoaDieuTri?.Khoa?.TenKhoa,
				DieuTriTuNgay = (PrintHelper.DateText(benhAnHoiChan?.KhoaDieuTri?.NgayVaoKhoa))?.ToLower(),
				DieuTriDenNgay = (PrintHelper.DateText(dieuTriDenNgay))?.ToLower(),
				BienBanHoiChan = benhAnHoiChan?.TenBienBanHoiChan,
				Giuong = benhAnHoiChan?.KhoaDieuTri?.Giuong?.TenGiuong,
				Buong = benhAnHoiChan?.KhoaDieuTri?.Buong?.TenBuong,
				ChuanDoan = $"{benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.MaBenh} - {benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.TenBenh}",
				HoiChanG = PrintHelper.TimeText(benhAnHoiChan?.NgayHoiChan),
				HoiChuanNgay = PrintHelper.DateTextShort(benhAnHoiChan?.NgayHoiChan),
				ChuToa = benhAnHoiChan?.ChuToa?.HoTen,
				ThuKi = benhAnHoiChan?.ThuKy?.HoTen,
				ThanhVienThamGia = benhAnHoiChan?.ThanhVien,
				TomTatDienBien = benhAnHoiChan?.TomTatDienBienBenh,
				KetLuan = benhAnHoiChan?.KetLuan,
				HuongDieuTri = benhAnHoiChan?.HuongDt,
				NgayThang = PrintHelper.DateText(benhAnHoiChan?.NgayHoiChan)
			});
			string path = PrintHelper.PrintFile<BenhAnHoiChanPrintDto>(_hostingEnvironment, "Trich-bien-ban-hoi-chuan.doc", null, null, benhAnHoiChans, "BenhAnHoiChan");
			return path;
		}
		private Expression<Func<BenhAnHoiChan, BenhAnHoiChanDto>> BenhAnHoiChanDtoQuery()
		{
			return ba => new BenhAnHoiChanDto()
			{
				Idba = ba.Idba,
				Stt = ba.Stt,
				Idhis = ba.Idhis,
				MaBa = ba.MaBa,
				MaBn = ba.MaBn,
				Sttkhoa = ba.Sttkhoa,
				TenBienBanHoiChan = ba.TenBienBanHoiChan,
				NgayHoiChan = ba.NgayHoiChan,
				ThanhVien = ba.ThanhVien,
				ChuToa = new DmnhanVienDto()
				{
					HoTen = ba.DmChuToa.HoTen,
					MaNv = ba.DmChuToa.MaNv,
				},
				ThuKy = new DmnhanVienDto()
				{
					HoTen = ba.DmThuKy.HoTen,
					MaNv = ba.DmThuKy.MaNv,
				},
				TomTatDienBienBenh = ba.TomTatDienBienBenh,
				KetLuan = ba.KetLuan,
				HuongDt = ba.HuongDt,
				Huy = ba.Huy,
				MaMay = ba.MaMay,
				NgayLap = ba.NgayLap,
				NguoiLap = new DmnhanVienDto()
				{
					HoTen = ba.DmNguoiLap.HoTen,
					MaNv = ba.DmNguoiLap.MaNv,
				},
				NgaySd = ba.NgaySd,
				NguoiSd = new DmnhanVienDto()
				{
					HoTen = ba.DmNguoiSD.HoTen,
					MaNv = ba.DmNguoiSD.MaNv,
				},
				NgayHuy = ba.NgayHuy,
				NguoiHuy = new DmnhanVienDto()
				{
					HoTen = ba.DmNguoiHuy.HoTen,
					MaNv = ba.DmNguoiHuy.MaNv,
				},
				KhoaDieuTri = ba.Sttkhoa != null ? new BenhAnKhoaDieuTriDto()
				{
					NgayVaoKhoa = ba.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Stt = ba.BenhAnKhoaDieuTri.Stt,
					Idba = ba.BenhAnKhoaDieuTri.Idba,
					Khoa = new DmkhoaDto()
					{
						TenKhoa = ba.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
						MaKhoa = ba.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
					},
					Buong = new DmkhoaBuongDto()
					{
						MaBuong = ba.BenhAnKhoaDieuTri.DmkhoaBuong.MaBuong,
						TenBuong = ba.BenhAnKhoaDieuTri.DmkhoaBuong.TenBuong
					},
					Giuong = new DmkhoaGiuongDto()
					{
						MaGiuong = ba.BenhAnKhoaDieuTri.DmkhoaGiuong.MaGiuong,
						TenGiuong = ba.BenhAnKhoaDieuTri.DmkhoaGiuong.TenGiuong
					},
					BenhChinh = new DmbenhTatDto()
					{
						MaBenh = ba.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
						TenBenh = ba.BenhAnKhoaDieuTri.BenhChinh.TenBenh
					},
				} : new BenhAnKhoaDieuTriDto()
			};
		}
	}
}
