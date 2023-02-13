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
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
    [Route("api/benh-an-to-dieu-tri")]
    [ApiController]
    [SessionFilter]
    public class BenhAnToDieuTriController : ControllerBase
    {
        private readonly BenhAnToDieuTriService _benhAnToDieuTriService;
        private UploadFileRespository uploadFileRespository = null;
        public BenhAnToDieuTriController(BenhAnToDieuTriService benhAnToDieuTriService)
        {
            _benhAnToDieuTriService = benhAnToDieuTriService;
            uploadFileRespository = new UploadFileRespository();
        }

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnToDieuTriDto> Get([FromQuery] BenhAnToDieuTriParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnToDieuTriDto> query = _benhAnToDieuTriService.Get(parameters, user);

			return Res<BenhAnToDieuTriDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnToDieuTriDetailDto Detail(string idba, string stt)
		{
			return _benhAnToDieuTriService.Detail(idba, stt);
		}

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/todieutri/create")]
		public ActionResult Post([FromBody] BenhAnToDieuTriCreateVM benhAnToDieuTri)
        {
			if (ModelState.IsValid)
			{
				_benhAnToDieuTriService.Store(benhAnToDieuTri);
			}
			return Ok();
		}

		[HttpPost("sao-chep")]
		[SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/todieutri/create")]
		public ActionResult MakeCopy([FromBody] BenhAnToDieuTriSaoChepVM benhAnToDieuTri)
        {
			if (ModelState.IsValid)
			{
				_benhAnToDieuTriService.MakeCopy(benhAnToDieuTri);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/todieutri/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnToDieuTriVM benhAnToDieuTri)
        {
			if (ModelState.IsValid)
			{
				_benhAnToDieuTriService.Update(idba, stt, benhAnToDieuTri);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
        [SessionMiddlewareFilter("HSBA/todieutri/delete")]
		public ActionResult Delete(decimal idba, int stt)
        {
			if (ModelState.IsValid)
			{
				_benhAnToDieuTriService.Destroy(idba, stt);
			}
			return Ok();
		}
		[HttpGet("{idba}/print-ba-file/{maba}.pdf")]
        [SessionMiddlewareFilter("HSBA/todieutri/export")]
		public ActionResult Print(decimal idba, [FromQuery] ToDieuTriPrintVM info, [FromQuery] PrintParameters parameters)
		{
            if (ModelState.IsValid)
            {
				string path = _benhAnToDieuTriService.Print(idba, info);
				if (parameters.ShouldReturnPath)
                	return new JsonResult(new { path });
				DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
				return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
            }
			return Ok();
        }
    }
}
