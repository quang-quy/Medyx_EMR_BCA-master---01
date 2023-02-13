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
	[Route("api/benh-an-tai-bien-pttt")]
	[ApiController]
	[SessionFilter]
	public class BenhAnTaiBienPtttController : ControllerBase
	{
		private readonly BenhAnTaiBienPtttService _benhAnTaiBienPtttService;
        private UploadFileRespository _uploadFileRespository = null;
		public BenhAnTaiBienPtttController(BenhAnTaiBienPtttService benhAnTaiBienPtttService, UploadFileRespository uploadFileRespository = null)
		{
			_benhAnTaiBienPtttService = benhAnTaiBienPtttService;
            _uploadFileRespository = uploadFileRespository;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnTaiBienPtttDto> Get([FromQuery] BenhAnTaiBienPtttParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnTaiBienPtttDto> query = _benhAnTaiBienPtttService.Get(parameters, user);

			return Res<BenhAnTaiBienPtttDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnTaiBienPtttDto Detail(decimal idba, int stt)
		{
			return _benhAnTaiBienPtttService.Detail(idba, stt);
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
        [SetActionContextItem(ActionType.Create)]
        //[SessionMiddlewareFilter("HSBA/taibien/create")]
		public ActionResult Post([FromBody] BenhAnTaiBienPtttCreateVM info)
        {

			if (ModelState.IsValid)
			{
				_benhAnTaiBienPtttService.Store(info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ThongTinTaiBienPhauThuThuat/modify")]
		public void Put(decimal id, int stt, [FromBody] BenhAnTaiBienPtttVM info)
		{
			if (ModelState.IsValid)
			{
				_benhAnTaiBienPtttService.Update(id, stt, info);
			}
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/ThongTinTaiBienPhauThuThuat/delete")]
		public void Delete(decimal id, int stt)
        {
			if (ModelState.IsValid)
			{
				_benhAnTaiBienPtttService.Destroy(id, stt);
			}
		}
		[HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ThongTinTaiBienPhauThuThuat/export")]
        public ActionResult Print(decimal idba, int stt, [FromQuery] BenhAnClsPrintParameters parameters)
        {
            var path = _benhAnTaiBienPtttService.Print(idba, stt);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = _uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
	}
}
