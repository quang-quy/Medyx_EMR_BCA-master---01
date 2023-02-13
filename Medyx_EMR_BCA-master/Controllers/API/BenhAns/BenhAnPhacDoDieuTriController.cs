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
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-phac-do-dt")]
	[ApiController]
	[SessionFilter]
	public class BenhAnPhacDoDieuTriController : ControllerBase
	{
		private readonly BenhAnPhacDoDtService _benhAnPhacDoDtService;
        private UploadFileRespository _uploadFileRespository = null;
		public BenhAnPhacDoDieuTriController(BenhAnPhacDoDtService benhAnPhacDoDtService, UploadFileRespository uploadFileRespository = null)
		{
			_benhAnPhacDoDtService = benhAnPhacDoDtService;
            _uploadFileRespository = uploadFileRespository;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnPhacDoDtDto> Get([FromQuery] BenhAnPhacDoDtParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnPhacDoDtDto> query = _benhAnPhacDoDtService.Get(parameters, user);

			return Res<BenhAnPhacDoDtDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnPhacDoDtDto Detail(decimal idba, int stt)
		{
			return _benhAnPhacDoDtService.Detail(idba, stt);
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/PhacDoDieuTri/create")]
		public ActionResult Post([FromBody] BenhAnPhacDoDtCreateVM info)
		{

			if (ModelState.IsValid)
			{
				_benhAnPhacDoDtService.Store(info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/PhacDoDieuTri/modify")]
		public void Put(decimal id, int stt, [FromBody] BenhAnPhacDoDtVM info)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhacDoDtService.Update(id, stt, info);
			}
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/PhacDoDieuTri/delete")]
		public void Delete(decimal id, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhacDoDtService.Destroy(id, stt);
			}
		}
		[HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/PhacDoDieuTri/export")]
		public ActionResult Print(decimal idba, int stt, [FromQuery] BenhAnClsPrintParameters parameters)
		{
			var path = _benhAnPhacDoDtService.Print(idba, stt);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = _uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
	}
}
