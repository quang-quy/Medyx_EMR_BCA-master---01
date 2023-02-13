using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
	[Route("api/benh-an-thong-tin-tu-vong")]
	[ApiController]
	[SessionFilter]
	public class BenhAnThongTinTuVongController : ControllerBase
	{
		private readonly BenhAnThongTinTuVongService _benhAnThongTinTuVongService;
		private UploadFileRespository uploadFileRespository = null;
		public BenhAnThongTinTuVongController(BenhAnThongTinTuVongService benhAnThongTinTuVongService)
		{
			_benhAnThongTinTuVongService = benhAnThongTinTuVongService;
			uploadFileRespository = new UploadFileRespository();
		}

		#region Bien ban kiem diem
		[HttpGet("bien-ban-kiem-diem/{idba}")]
		public BenhAnTvBbkiemDiemDto DetailBienBanKiemDiem(decimal idba)
		{
			return _benhAnThongTinTuVongService.DetailBienBanKiemDiem(idba);
		}

		[HttpPost("bien-ban-kiem-diem")]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/KiemDiemTuVong/modify")]
		public ActionResult PostBienBanKiemDiem([FromBody] BenhAnTvBbkiemDiemCreateVM benhAnTvBbkiemDiemVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.StoreBienBanKiemDiem(benhAnTvBbkiemDiemVM);
			}
			return Ok();
		}

		[HttpPut("bien-ban-kiem-diem/{idba}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/KiemDiemTuVong/modify")]
		public ActionResult PutBienBanKiemDiem(decimal idba, [FromBody] BenhAnTvBbkiemDiemVM benhAnTvBbkiemDiemVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.UpdateBienBanKiemDiem(idba, benhAnTvBbkiemDiemVM);
			}
			return Ok();
		}

		[HttpDelete("bien-ban-kiem-diem/{idba}")]
		[SetActionContextItem(ActionType.Delete)]
		public void DeleteBienBanKiemDiem(decimal idba)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.DestroyBienBanKiemDiem(idba);
			}
		}
		#endregion

		#region Thanh vien tham gia
		[HttpGet("bien-ban-kiem-diem/thanh-vien-tham-gia")]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnTvBbkiemDiemTvDto> GetThanhVienThamGia([FromQuery] BenhAnThongTinTuVongParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnTvBbkiemDiemTvDto> query = _benhAnThongTinTuVongService.GetThanhVienThamGia(parameters, user);

			return Res<BenhAnTvBbkiemDiemTvDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}
		[HttpPost("bien-ban-kiem-diem/thanh-vien-tham-gia")]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/ThanhVienThamGia/create")]
		public ActionResult PostThanhVienThamGia([FromBody] BenhAnTvBbkiemDiemTvCreateVM benhAnTvBbkiemDiemTvVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.StoreThanhVienThamGia(benhAnTvBbkiemDiemTvVM);
			}
			return Ok();
		}

		[HttpPut("bien-ban-kiem-diem/thanh-vien-tham-gia/{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/ThanhVienThamGia/modify")]
		public ActionResult PutThanhVienThamGia(decimal idba, int stt, [FromBody] BenhAnTvBbkiemDiemTvVM BenhAnTvBbkiemDiemTvVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.UpdateThanhVienThamGia(idba, stt, BenhAnTvBbkiemDiemTvVM);
			}
			return Ok();
		}

		[HttpDelete("bien-ban-kiem-diem/thanh-vien-tham-gia/{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/ThanhVienThamGia/delete")]
		public void DeleteThanhVienThamGia(decimal idba, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.DestroyThanhVienThamGia(idba, stt);
			}
		}
		#endregion

		#region Chan doan nguyen nhan
		[HttpGet("chan-doan-nguyen-nhan/{idba}")]
		public BenhAnTvPhieuCdnguyenNhanDto DetailChanDoanNguyenNhan(decimal idba)
		{
			return _benhAnThongTinTuVongService.DetailChanDoanNguyenNhan(idba);
		}

		[HttpPost("chan-doan-nguyen-nhan")]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/ChanDoanNguyenNhanTuVong/modify")]
		public ActionResult PostChanDoanNguyenNhan([FromBody] BenhAnTvPhieuCdnguyenNhanCreateVM benhAnTvPhieuCdnguyenNhanCreateVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.StoreChanDoanNguyenNhan(benhAnTvPhieuCdnguyenNhanCreateVM);
			}
			return Ok();
		}

		[HttpPut("chan-doan-nguyen-nhan/{idba}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/ChanDoanNguyenNhanTuVong/modify")]
		public ActionResult PutChanDoanNguyenNhan(decimal idba, [FromBody] BenhAnTvPhieuCdnguyenNhanVM benhAnTvPhieuCdnguyenNhanVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.UpdateChanDoanNguyenNhan(idba, benhAnTvPhieuCdnguyenNhanVM);
			}
			return Ok();
		}

		[HttpDelete("chan-doan-nguyen-nhan/{idba}")]
		[SetActionContextItem(ActionType.Delete)]
		public void DeleteChanDoanNguyenNhan(decimal idba)
		{
			if (ModelState.IsValid)
			{
				_benhAnThongTinTuVongService.DestroyChanDoanNguyenNhan(idba);
			}
		}
		[HttpGet("{idba}/print-ba-file/chuan-doan-nguyen-nhan/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/ChanDoanNguyenNhanTuVong/export")]
		public ActionResult Print(decimal idba, [FromQuery] PrintParameters parameters)
		{
			var path = _benhAnThongTinTuVongService.Print(idba);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
		[HttpGet("{idba}/print-ba-file/trich-bien-ban/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/KiemDiemTuVong/trichbienban/export")]
		public ActionResult TrichBienBanPrint(decimal idba, [FromQuery] PrintParameters parameters)
		{
			var path = _benhAnThongTinTuVongService.TrichBienBanPrint(idba);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
		[HttpGet("{idba}/print-ba-file/kiem-diem-tu-vong/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/KiemDiemTuVong/bienban/export")]
		public ActionResult KiemDiemPrint(decimal idba, [FromQuery] PrintParameters parameters)
		{
			var path = _benhAnThongTinTuVongService.KiemDiemTuVongPrint(idba);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
		[HttpGet("{idba}/print-ba-file/giay-bao-tu/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ThongTinTuVong/GiayBaoTu/export")]
		public ActionResult BaoTuPrint(decimal idba, [FromQuery] PrintParameters parameters)
		{
			var path = _benhAnThongTinTuVongService.BaoTuPrint(idba);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
		#endregion
	}
}
