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

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-ttvlt-dot-dieu-tri")]
	[ApiController]
	[SessionFilter]
	public class BenhanTtvltlDotDieuTriController : ControllerBase
	{
		private readonly BenhAnTtvltlDotDieuTriService _benhAnTtvltlDotDieuTriService;
        private UploadFileRespository _uploadFileRespository = null;
		public BenhanTtvltlDotDieuTriController(BenhAnTtvltlDotDieuTriService benhAnTtvltlDotDieuTriService, UploadFileRespository uploadFileRespository = null)
		{
			_benhAnTtvltlDotDieuTriService = benhAnTtvltlDotDieuTriService;
            _uploadFileRespository = uploadFileRespository;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnTtvltlDotDieuTriDto> Get([FromQuery] BenhanTtvltlDotDieuTriParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnTtvltlDotDieuTriDto> query = _benhAnTtvltlDotDieuTriService.Get(parameters, user);

			return Res<BenhAnTtvltlDotDieuTriDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnTtvltlDotDieuTriDto Detail(decimal idba, int stt)
		{
			return _benhAnTtvltlDotDieuTriService.Detail(idba, stt);
		}

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/ThucHienVatLyTriLieu/create")]
        public ActionResult Post([FromBody] BenhAnTtvltlDotDieuTriCreateVM info)
        {

            if (ModelState.IsValid)
            {
                _benhAnTtvltlDotDieuTriService.Store(info);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{id}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/ThucHienVatLyTriLieu/modify")]
        public void Put(decimal id, int stt, [FromBody] BenhAnTtvltlDotDieuTriVM info)
        {
            if (ModelState.IsValid)
            {
                _benhAnTtvltlDotDieuTriService.Update(id, stt, info);
            }
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{id}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
        public void Delete(decimal id, int stt)
        {
            if (ModelState.IsValid)
            {
                _benhAnTtvltlDotDieuTriService.Destroy(id, stt);
            }
        }

		[HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
        [SessionMiddlewareFilter("HSBA/ThucHienVatLyTriLieu/export")]
        public ActionResult Print(decimal idba, int stt, [FromQuery] BenhAnClsPrintParameters parameters)
        {
            var path = _benhAnTtvltlDotDieuTriService.Print(idba, stt);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = _uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        } 
	}
}
