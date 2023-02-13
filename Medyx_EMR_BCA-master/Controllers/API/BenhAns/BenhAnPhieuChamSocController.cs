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
	[Route("api/benh-an-phieu-cham-soc")]
	[ApiController]
	[SessionFilter]
	public class BenhAnPhieuChamSocController : ControllerBase
	{
		private readonly BenhAnPhieuChamSocService _benhAnPhieuChamSocService;

		private UploadFileRespository uploadFileRespository = null;
		public BenhAnPhieuChamSocController(BenhAnPhieuChamSocService benhAnPhieuChamSocService)
		{
			_benhAnPhieuChamSocService = benhAnPhieuChamSocService;
			uploadFileRespository = new UploadFileRespository();
		}

		// GET: api/<BenhAnPhieuChamSocController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnPhieuChamSocDto> Get([FromQuery] BenhAnPhieuChamSocParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnPhieuChamSocDto> query = _benhAnPhieuChamSocService.Get(parameters, user);

			return Res<BenhAnPhieuChamSocDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}


		// GET api/<BenhAnPhieuChamSocController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnPhieuChamSocDetailDto Detail(decimal idba, int stt)
		{
			return _benhAnPhieuChamSocService.Detail(idba, stt);
		}
		// POST api/<BenhAnPhieuChamSocController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/TheoDoiVaChamSoc/create")]
		public BenhAnPhieuChamSoc Post([FromBody] BenhAnPhieuChamSocCreateVM benhAnPhieuChamSocVM)
		{
			var benhAnPhieuChamSoc = new BenhAnPhieuChamSoc();
			if (ModelState.IsValid)
			{
				benhAnPhieuChamSoc = _benhAnPhieuChamSocService.Store(benhAnPhieuChamSocVM);
			}
			return benhAnPhieuChamSoc;
		}

		// PUT api/<BenhAnPhieuChamSocController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/TheoDoiVaChamSoc/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnPhieuChamSocVM benhAnPhieuChamSocVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhieuChamSocService.Update(idba, stt, benhAnPhieuChamSocVM);
			}
			return Ok();
		}

		// DELETE api/<BenhAnPhieuChamSocController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/TheoDoiVaChamSoc/delete")]
		public void Delete(decimal idba, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhieuChamSocService.Destroy(idba, stt);
			}
		}
		[HttpGet("{idba}/print-ba-file/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/TheoDoiVaChamSoc/export")]
		public ActionResult Print(decimal idba, [FromQuery] BenhAnChamSocPrintVM info, [FromQuery] PrintParameters parameters)
		{
			if (ModelState.IsValid)
			{
				string path =_benhAnPhieuChamSocService.Print(idba, info);
				if (parameters.ShouldReturnPath)
                	return new JsonResult(new { path });
				DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
				return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
			}
			return Ok();
		}
		[HttpGet("{idba}/print-ba-file/so-do/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/TheoDoiVaChamSoc/export")]
		public ActionResult SoDoPrint(decimal idba, [FromQuery] BenhAnChamSocPrintVM info, [FromQuery] PrintParameters parameters)
		{
			if (ModelState.IsValid)
			{
				string path =_benhAnPhieuChamSocService.SoDoPrint(idba, info);
				if (parameters.ShouldReturnPath)
                	return new JsonResult(new { path });
				DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
				return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
			}
			return Ok();
		}

        [HttpPost("sao-chep")]
        [SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/TheoDoiVaChamSoc/create")]
        public ActionResult MakeCopy([FromBody] BenhAnPhieuChamSocSaoChepVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhAnPhieuChamSocService.MakeCopy(parameters);
            }
            return Ok();
        }
    }
}
