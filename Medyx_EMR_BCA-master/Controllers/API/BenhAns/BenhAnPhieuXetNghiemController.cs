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
	[Route("api/benh-an-phieu-xet-nghiem")]
	[ApiController]
	[SessionFilter]
	public class BenhAnPhieuXetNghiemController : ControllerBase
	{
		private readonly BenhAnPhieuXetNghiemService _benhAnPhieuXetNghiemService;
		private UploadFileRespository uploadFileRespository = null;
		public BenhAnPhieuXetNghiemController(BenhAnPhieuXetNghiemService benhAnPhieuXetNghiemService)
		{
			_benhAnPhieuXetNghiemService = benhAnPhieuXetNghiemService;
			uploadFileRespository = new UploadFileRespository();
		}

		// GET: api/<BenhAnPhieuXetNghiemController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnPhieuXetNghiemDto> Get([FromQuery] BenhAnPhieuXetNghiemParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnPhieuXetNghiemDto> query = _benhAnPhieuXetNghiemService.Get(parameters, user);

			return Res<BenhAnPhieuXetNghiemDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

        // GET api/<BenhAnPhieuChamSocController>/5
        /*[HttpGet("{idba}/chi-tiet/{stt}")]
        public BenhAnPhieuXetNghiemDto Detail(decimal idba, int stt)
        {
            return _benhAnPhieuXetNghiemService.Detail(idba, stt);
        }*/

        // PUT api/<BenhAnPhieuXetNghiemController>/5
        [HttpPost]
		[SessionMiddlewareFilter("HSBA/PhieuXetNghiem/modify")]
		public ActionResult CreateOrUpdate([FromBody] BenhAnPhieuXetNghiemVM benhAnPhieuXetNghiemVM)
        {
			if (ModelState.IsValid)
			{
				_benhAnPhieuXetNghiemService.CreateOrUpdate(benhAnPhieuXetNghiemVM);
			}
			return Ok();
		}

		// DELETE api/<BenhAnPhieuXetNghiemController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/PhieuXetNghiem/delete")]
		public void Delete(decimal idba, int stt)
        {
			if (ModelState.IsValid)
			{
				_benhAnPhieuXetNghiemService.Destroy(idba, stt);
			}
		}

		[HttpGet("{idba}/print-ba-file/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/PhieuXetNghiem/export")]
		public ActionResult Print(decimal idba, [FromQuery] PrintParameters parameters)
		{
			string path = _benhAnPhieuXetNghiemService.Print(idba, parameters);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
	}
}
