using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Microsoft.AspNetCore.Hosting;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-thuoc-thu-phan-ung")]
	[ApiController]
	[SessionFilter]
	public class BenhAnThuocThuPhanUngController : ControllerBase
	{
		private BenhAnThuocThuPhanUngService _benhAnThuocThuPhanUngService;
		private UploadFileRespository uploadFileRespository = null;
		public BenhAnThuocThuPhanUngController(BenhAnThuocThuPhanUngService benhAnThuocThuPhanUngService)
		{
			_benhAnThuocThuPhanUngService = benhAnThuocThuPhanUngService;
			uploadFileRespository = new UploadFileRespository();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnThuocThuPhanUngDto> Get([FromQuery] BenhAnThuocThuPhanUngParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			return _benhAnThuocThuPhanUngService.Get(parameters, user);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{id}/chi-tiet/{stt}")]
		public BenhAnThuocThuPhanUng Detail(string id, string stt)
		{
			return _benhAnThuocThuPhanUngService.Show(Convert.ToDecimal(id), Convert.ToInt32(stt));
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
        [SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/phieuphanungthuoc/create")]
		public ActionResult Store([FromBody] BenhAnThuocThuPhanUngCreateVM info)
		{
			if (ModelState.IsValid)
			{
				_benhAnThuocThuPhanUngService.Store(info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/phieuphanungthuoc/modify")]
		public ActionResult Update(decimal idba, int stt, [FromBody] BenhAnThuocThuPhanUngVM info)
		{
			if (ModelState.IsValid)
			{
				_benhAnThuocThuPhanUngService.Update(idba, stt, info);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/phieuphanungthuoc/delete")]
		public ActionResult Destroy(decimal idba, int stt)
		{
			_benhAnThuocThuPhanUngService.Destroy(idba, stt);
			return Ok();
		}

		[HttpGet("{idba}/print-ba-file/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/phieuphanungthuoc/export")]
		public ActionResult Print(decimal idba, [FromQuery] PrintParameters parameters){
			string path = _benhAnThuocThuPhanUngService.Print(idba);
			if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
	}
}
