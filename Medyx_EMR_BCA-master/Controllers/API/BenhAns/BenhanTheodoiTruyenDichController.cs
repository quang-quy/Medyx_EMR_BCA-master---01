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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-theo-gioi-truyen-dich")]
	[ApiController]
	[SessionFilter]
	public class BenhanTheodoiTruyenDichController : ControllerBase
	{
		private readonly BenhAnTheoDoiTruyenDichService _benhAnTheoDoiTruyenDichService;
		private UploadFileRespository uploadFileRespository = null;
		public BenhanTheodoiTruyenDichController(BenhAnTheoDoiTruyenDichService benhAnTheoDoiTruyenDichService)
		{
			_benhAnTheoDoiTruyenDichService = benhAnTheoDoiTruyenDichService;
			uploadFileRespository = new UploadFileRespository();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhanTheodoiTruyenDichDto> Get([FromQuery] BenhanTheodoiTruyenDichParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhanTheodoiTruyenDichDto> query = _benhAnTheoDoiTruyenDichService.Get(parameters, user);

			return Res<BenhanTheodoiTruyenDichDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{id}/chi-tiet/{stt}")]
		public BenhanTheodoiTruyenDichDto Detail(decimal id, int stt)
		{
			return _benhAnTheoDoiTruyenDichService.Detail(id, stt);
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/TheoDoiTruyenDich/create")]
		public ActionResult Post([FromBody] BenhAnTheoDoiTruyenDichCreateVM parameters)
		{
			if (ModelState.IsValid)
			{
				_benhAnTheoDoiTruyenDichService.Store(parameters);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/TheoDoiTruyenDich/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnTheoDoiTruyenDichVM parameters)
		{
			if (ModelState.IsValid)
			{
				_benhAnTheoDoiTruyenDichService.Update(idba, stt, parameters);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/TheoDoiTruyenDich/delete")]
		public ActionResult Delete(decimal idba, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnTheoDoiTruyenDichService.Destroy(idba, stt);
			}
			return Ok();
		}
		[HttpGet("{idba}/print-ba-file/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/TheoDoiTruyenDich/export")]
		public ActionResult Print(decimal idba, [FromQuery] PrintParameters parameters)
		{
			string path = _benhAnTheoDoiTruyenDichService.Print(idba);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
	}
}
