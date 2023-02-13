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
    [Route("api/benh-an-phau-thuat-duyet-mo")]
    [ApiController]
    [SessionFilter]
    public class BenhAnPhauThuatDuyetMoController : ControllerBase
    {
        private BenhAnPhauThuatDuyetMoService _benhAnPhauThuatDuyetMoService;
        public BenhAnPhauThuatDuyetMoController(BenhAnPhauThuatDuyetMoService benhAnPhauThuatDuyetMoService)
        {
            _benhAnPhauThuatDuyetMoService = benhAnPhauThuatDuyetMoService;
        }

        #region Phau thuat duyet mo chi tiet
        [HttpGet("{idba}/chi-tiet/{sttpt}")]
        public BenhAnPhauThuatDuyetMoDto DetailPhauThuatDuyetMo(decimal idba, int sttpt)
        {
            return _benhAnPhauThuatDuyetMoService.DetailPhauThuatDuyetMo(idba, sttpt);
        }
        #endregion

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/PhieuDuyetMo/create")]
        public ActionResult Post([FromBody] BenhAnPhauThuatDuyetMoCreateVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhAnPhauThuatDuyetMoService.Store(parameters);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{sttpt}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/PhieuDuyetMo/modify")]
        public ActionResult Put(decimal idba, int sttpt, [FromBody] BenhAnPhauThuatDuyetMoVM parameters)
        {
            if (ModelState.IsValid)
            {
                _benhAnPhauThuatDuyetMoService.Update(idba, sttpt, parameters);
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
                // _benhAnPhauThuatDuyetMoService.Destroy(idba, sttpt);
            }
            return Ok();
        }

        [HttpGet("{idba}/print-ba-file/{sttpt}/{maba}.pdf")]
        [SessionMiddlewareFilter("HSBA/PhieuDuyetMo/export")]
        public ActionResult Print(decimal idba, int sttpt, [FromQuery] PrintParameters parameters){
			var uploadFileRespository = new UploadFileRespository();
            var path = _benhAnPhauThuatDuyetMoService.Print(idba, sttpt);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
    }
}
