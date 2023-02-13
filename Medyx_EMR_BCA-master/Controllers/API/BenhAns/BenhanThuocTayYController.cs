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
    [Route("api/benh-an-thuoc-tay-y")]
    [ApiController]
    [SessionFilter]
    public class BenhanThuocTayYController : ControllerBase
    {
        private readonly BenhAnThuocTayYService _benhAnThuocTayYService;

        public BenhanThuocTayYController(BenhAnThuocTayYService benhAnThuocTayYService)
        {
            _benhAnThuocTayYService = benhAnThuocTayYService;
        }

        // GET: api/<BenhAnKhoaDieuTriController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public ActionResult Get([FromQuery] BenhanThuocTayYParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhAnThuocTayYDto> query = _benhAnThuocTayYService.Get(parameters, user);
            if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x =>
					x.TenThuoc.ToLower().Contains(parameters.Search.ToLower())
					|| x.MaThuoc.ToLower().Contains(parameters.Search.ToLower())
				);
			}
            if(Convert.ToBoolean(parameters.ForFilter)){
                var repository = new GenericRepository<BenhanThuocTayY>();
                return Ok(QueryParamsHelper.ResultDanhMucDTOParams<BenhanThuocTayY, BenhAnThuocTayYDto>(repository, query, parameters, _benhAnThuocTayYService.DtoQuery(), "MaThuoc"));
            }
            return Ok(Res<BenhAnThuocTayYDto>.Get(query, parameters.PageNumber, parameters.PageSize));
        }

        // GET api/<BenhAnKhoaDieuTriController>/5
        [HttpGet("{idba}/chi-tiet/{stt}")]
        public BenhanThuocTayY Detail(decimal idba, int stt)
        {
            return _benhAnThuocTayYService.Detail(idba, stt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/todieutri/thuoctayy/create")]
        public ActionResult Post([FromBody] BenhAnThuocTayYCreateVM benhAnThuocTayY)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocTayYService.Store(benhAnThuocTayY);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/todieutri/thuoctayy/modify")]
        public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnThuocTayYVM benhanThuocTayY)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocTayYService.Update(idba, stt, benhanThuocTayY);
            }
            return Ok();
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
        [SessionMiddlewareFilter("HSBA/todieutri/thuoctayy/delete")]
        public ActionResult Delete(decimal idba, int stt)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocTayYService.Destroy(idba, stt);
            }
            return Ok();
        }
    }
}
