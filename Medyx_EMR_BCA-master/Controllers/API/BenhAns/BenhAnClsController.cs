using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
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
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
    [Route("api/benh-an-cls")]
    [ApiController]
    [SessionFilter]
    public class BenhAnClsController : ControllerBase
    {
        private readonly BenhAnClsService _benhAnClsService;
        private UploadFileRespository _uploadFileRespository = null;
        public BenhAnClsController(BenhAnClsService benhAnClsService, UploadFileRespository uploadFileRespository = null)
        {
            _benhAnClsService = benhAnClsService;
            _uploadFileRespository = uploadFileRespository;
        }

        // GET: api/<BenhAnKhoaDieuTriController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhAnClsDto> Get([FromQuery] BenhAnClsParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhAnClsDto> query = _benhAnClsService.Get(parameters, user);
            return Res<BenhAnClsDto>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<BenhAnKhoaDieuTriController>/5
        [HttpGet("{id}/chi-tiet/{stt}")]
        public BenhAnClsDto Detail(decimal id, int stt)
        {
            return _benhAnClsService.Show(id, stt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        public ActionResult Post([FromForm] BenhAnClsWithFileCreateVM info)
        {
            if (ModelState.IsValid)
            {
                _benhAnClsService.Store(info);
            }
            return Ok();
        }

        [HttpPost("to-dieu-tri")]
        [SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/todieutri/canlamsang/create", "HSBA/todieutri/thuthuatvltl/create")]
        public ActionResult Post([FromBody] BenhAnClsCreateVM benhAnClsCreateVM)
        {
            if (ModelState.IsValid)
            {
                _benhAnClsService.StoreInToDieuTri(benhAnClsCreateVM);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ChuanDoanHinhAnh/modify", "HSBA/ThongTinThamDoChucNang/modify")]
        public ActionResult Put(int stt, decimal idba, [FromBody] BenhAnClsVM info)
        {
            if (ModelState.IsValid)
            {
                _benhAnClsService.Update(idba, stt, info);
            }
            return Ok();
        }

        [HttpPut("{idba}/chi-tiet/{stt}/to-dieu-tri")]
        [SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/todieutri/canlamsang/modify")]
        public ActionResult Put(int stt, decimal idba, [FromBody] BenhAnClsUpdateVM info)
        {
            if (ModelState.IsValid)
            {
                _benhAnClsService.UpdateInToDieuTri(idba, stt, info);
            }
            return Ok();
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/todieutri/canlamsang/delete", "HSBA/chuandoanhindexhanh/delete", "HSBA/ThongTinThamDoChucNang/delete")]
        public ActionResult Delete(decimal idba, int stt)
        {
            if (ModelState.IsValid)
            {
                _benhAnClsService.Destroy(idba, stt);
            }
            return Ok();
        }

        [HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/ChuanDoanHinhAnh/export", "HSBA/ThongTinThamDoChucNang/export")]
        public ActionResult Print(decimal idba, int stt, [FromQuery] BenhAnClsPrintParameters parameters)
        {
            var path = _benhAnClsService.Print(idba, stt, parameters);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = _uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }

        [HttpPost("{idba}/image-print/{stt}")]
        [SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ChuanDoanHinhAnh/export", "HSBA/ThongTinThamDoChucNang/export")]
        public ActionResult UploadImagePrint(decimal idba, int stt, [FromForm] BenhAnClsFilePrintUploadVM info)
        {
            if (ModelState.IsValid)
            {
                _benhAnClsService.PrintSaveImageFile(idba, stt, info);
            }
            return Ok();
        }
        [HttpGet("{idba}/image-print/{stt}")]
        public BenhAnClsFilePrintVM getdImagePrint(decimal idba, int stt)
        {
            return _benhAnClsService.getFilePrint(idba, stt);
        }
    }
}
