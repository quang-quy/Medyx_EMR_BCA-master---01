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
	[Route("api/benh-an-theo-doi-truyen-mau")]
	[ApiController]
	[SessionFilter]
	public class BenhAnTheoDoiTruyenMauController : ControllerBase
	{
        private readonly BenhAnTheoDoiTruyenMauService _benhAnTheoDoiTruyenMauService;

        private UploadFileRespository _uploadFileRespository = null;
        public BenhAnTheoDoiTruyenMauController(BenhAnTheoDoiTruyenMauService benhAnTheoDoiTruyenMauService, UploadFileRespository uploadFileRespository = null)
		{
            _benhAnTheoDoiTruyenMauService = benhAnTheoDoiTruyenMauService;
            _uploadFileRespository = uploadFileRespository;
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhanTheodoiTruyenMauDto Detail(decimal idba, int stt)
		{
			return _benhAnTheoDoiTruyenMauService.Detail(idba, stt);

        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        public ActionResult Post([FromBody] BenhAnTheoDoiTruyenMauVM parameters)
		{
            if (ModelState.IsValid)
            {
                _benhAnTheoDoiTruyenMauService.Store(parameters);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		[HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ChePhamMau/TheoDoiTruyenMau/export")]
        public ActionResult Print(decimal idba, int stt, [FromQuery] BenhAnClsPrintParameters parameters)
        {
            var path = _benhAnTheoDoiTruyenMauService.Print(idba, stt);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = _uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
	}
}
