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
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
    [Route("api/benh-an")]
    [ApiController]
    [SessionFilter]
    public class BenhAnController : ControllerBase
    {
        private readonly BenhAnService _benhAnService;
        private UploadFileRespository uploadFileRespository = null;
        public BenhAnController(BenhAnService benhAnService)
        {
            _benhAnService = benhAnService;
            uploadFileRespository = new UploadFileRespository();
        }

        // GET: api/<BenhAnController>
        [HttpGet]
        // [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhAnDto> Get([FromQuery] BenhAnParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhAnDto> benhAnQuery = _benhAnService.Get(parameters, user);
            //return Res<BenhAnDto>.Get(benhAnQuery, parameters.PageNumber, parameters.PageSize);
            var kq = Res<BenhAnDto>.Get(benhAnQuery, parameters.PageNumber, parameters.PageSize);
            return kq;
        }

        // GET api/<BenhAnController>/5
        [HttpGet("{id}")]
        public BenhAnDetailDto Detail(decimal id)
        {
            return _benhAnService.Detail(id);
        }

        [HttpGet("{id}/detail")]
        public BenhAn Show(decimal id)
        {
            var data = _benhAnService.Show(id);
            return _benhAnService.Show(id);
        }

        [HttpGet("{id}/loai-benh-an")]
        public object GetLoaiBA(decimal id)
        {
            return _benhAnService.GetLoaiBA(id);
        }

        // POST api/<BenhAnController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/thongtinbenhan/create")]
        public ActionResult Post([FromBody] BenhAn benhAn)
        {
            if (ModelState.IsValid)
            {
                _benhAnService.Store(benhAn);
            }
            return Ok();
        }

        // PUT api/<BenhAnController>/5
        [HttpPut("{id}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/thongtinbenhan/modify")]
        public ActionResult Update(decimal id, [FromBody] BenhAn benhAn)
        {
            if (ModelState.IsValid)
            {
                _benhAnService.Update(id, benhAn);
            }
            return Ok();
        }

        [HttpPost("them-moi-thong-tin-benh-an")]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/thongtinbenhan/create")]
        public ActionResult ThongTinBenhAnCreate([FromBody] BenhAnDetailDto benhAn)
        {
            if (ModelState.IsValid)
            {
                _benhAnService.ThongTinBnCreate(benhAn);
            }
            return Ok();
        }

        [HttpPost("{idba}/cap-nhap-thong-tin-benh-an")]
        [SessionMiddlewareFilter("HSBA/thongtinbenhan/modify")]
        [SetActionContextItem(ActionType.Update)]
        public ActionResult ThongTinBenhAnUpdate([FromBody] BenhAnDetailDto benhAn, decimal idba)
        {
            if (ModelState.IsValid)
            {
                _benhAnService.ThongTinBnUpdate(benhAn, idba);
            }
            return Ok();
        }
        [HttpPost("{idba}/dong-thong-tin-benh-an")]
        [SessionMiddlewareFilter("HSBA/thongtinbenhan/close")]
        [SetActionContextItem(ActionType.Update)]
        public ActionResult DongBenhAn([FromBody] BenhAnDetailDto benhAn, decimal idba)
        {
            if (ModelState.IsValid)
            {
                _benhAnService.ThongTinBnUpdate(benhAn, idba, true);
            }
            return Ok();
        }

        [HttpPost("{idba}/cap-nhap-to-benh-an")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/tobenhan/modify")]
        public ActionResult CapNhapToBenhAn(ToBenhAnVM info, decimal idba)
        {
            if (ModelState.IsValid)
            {
                _benhAnService.ThongTinToBenhAnCreateUpdate(info, idba);
            }
            return Ok();
        }
        // DELETE api/<BenhAnController>/5
        [HttpDelete("{id}")]
        [SetActionContextItem(ActionType.Delete)]
        public ActionResult Delete(decimal id)
        {
            _benhAnService.Destroy(id);
            return Ok();
        }
        [HttpGet("{id}/print-ba-file/{maba}.pdf")]
        [SessionMiddlewareFilter("HSBA/thongtinbenhan/export", "HSBA/tobenhan/export")]
        public ActionResult Print(decimal id, [FromQuery] PrintParameters parameters)
        {
            var path = _benhAnService.Print(id);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
        [HttpGet("{id}/print-ba-file/giay-ra-vien/{maba}.pdf")]
        public ActionResult GiayRaVienPrint(decimal id, [FromQuery] PrintParameters parameters)
        {
            var path = _benhAnService.GiayRaVienPrint(id);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
            DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
    }
}
