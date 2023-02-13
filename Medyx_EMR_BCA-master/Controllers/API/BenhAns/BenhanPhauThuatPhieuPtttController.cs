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
    [Route("api/benh-an-phau-thuat-phieu-pttt")]
    [ApiController]
    [SessionFilter]
    public class BenhanPhauThuatPhieuPtttController : ControllerBase
    {
        private BenhanPhauThuatPhieuPtttService _benhanPhauThuatPhieuPtttService;

		private UploadFileRespository uploadFileRespository = null;
        public BenhanPhauThuatPhieuPtttController(BenhanPhauThuatPhieuPtttService benhanPhauThuatPhieuPtttService)
        {
            _benhanPhauThuatPhieuPtttService = benhanPhauThuatPhieuPtttService;
			uploadFileRespository = new UploadFileRespository();
        }

        [HttpGet("{idba}/chi-tiet/{sttpt}")]
        public BenhanPhauThuatPhieuPtttDto DetailBenhanPhauThuatPhieuPttt(decimal idba, int sttpt)
        {
            return _benhanPhauThuatPhieuPtttService.DetailBenhanPhauThuatPhieuPttt(idba, sttpt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult Post([FromBody] BenhAnPhauThuatPhieuPtttCreateVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhanPhauThuatPhieuPtttService.Store(parameters);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{sttpt}")]
        [SetActionContextItem(ActionType.Update)]
        public ActionResult Put(decimal idba, int sttpt, [FromBody] BenhAnPhauThuatPhieuPtttVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhanPhauThuatPhieuPtttService.Update(idba, sttpt, parameters);
            }
            return Ok();
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{idba}/chi-tiet/{sttpt}")]
        [SetActionContextItem(ActionType.Delete)]
        public ActionResult Delete(decimal idba, int sttpt)
        {
            if (ModelState.IsValid)
            {
                _benhanPhauThuatPhieuPtttService.Destroy(idba, sttpt);
            }
            return Ok();
        }
        [HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/PhieuPhauThuat/export")]
		public ActionResult Print(decimal idba, int stt, [FromQuery] PrintParameters parameters)
		{
			var path = _benhanPhauThuatPhieuPtttService.Print(idba, stt);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
        [HttpGet("{idba}/print-ba-file/{stt}/giay-chung-nhan-bao-tu/{maba}.pdf")]
		public ActionResult GiayChungNhanBaoTuPrint(decimal idba, int stt, [FromQuery] PrintParameters parameters)
		{
			var path = _benhanPhauThuatPhieuPtttService.GiayChungNhanBaoTu(idba, stt);
			if (parameters.ShouldReturnPath)
				return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
    }
}
