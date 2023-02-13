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
    [Route("api/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo")]
    [ApiController]
    [SessionFilter]
    public class BenhanPhauThuatPhieuKhamGayMeTruocMoController : ControllerBase
    {
        private BenhanPhauThuatPhieuKhamGayMeTruocMoService _benhanPhauThuatPhieuKhamGayMeTruocMoService;

        public BenhanPhauThuatPhieuKhamGayMeTruocMoController(BenhanPhauThuatPhieuKhamGayMeTruocMoService benhanPhauThuatPhieuKhamGayMeTruocMoService)
        {
            _benhanPhauThuatPhieuKhamGayMeTruocMoService = benhanPhauThuatPhieuKhamGayMeTruocMoService;
        }

        [HttpGet("{idba}/chi-tiet/{sttpt}")]
        public BenhanPhauThuatPhieuKhamGayMeTruocMoDto DetailBenhanPhauThuatPhieuKhamGayMeTruocMo(decimal idba, int sttpt)
        {
            return _benhanPhauThuatPhieuKhamGayMeTruocMoService.DetailBenhanPhauThuatPhieuKhamGayMeTruocMo(idba, sttpt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/PhieuKhamGayMe/create")]
        public ActionResult Post([FromBody] BenhAnPhauThuatPhieuKhamGayMeTruocMoCreateVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhanPhauThuatPhieuKhamGayMeTruocMoService.Store(parameters);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{sttpt}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/PhieuKhamGayMe/modify")]
        public ActionResult Put(decimal idba, int sttpt, [FromBody] BenhAnPhauThuatPhieuKhamGayMeTruocMoVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhanPhauThuatPhieuKhamGayMeTruocMoService.Update(idba, sttpt, parameters);
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
                // _benhanPhauThuatPhieuKhamGayMeTruocMoService.Destroy(idba, sttpt);
            }
            return Ok();
        }

        [HttpGet("{idba}/print-ba-file/{sttpt}/{maba}.pdf")]
        [SessionMiddlewareFilter("HSBA/PhieuKhamGayMe/export")]
        public ActionResult Print(decimal idba, int sttpt, [FromQuery] PrintParameters parameters){
			var uploadFileRespository = new UploadFileRespository();
            var path = _benhanPhauThuatPhieuKhamGayMeTruocMoService.Print(idba, sttpt);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
    }
}
