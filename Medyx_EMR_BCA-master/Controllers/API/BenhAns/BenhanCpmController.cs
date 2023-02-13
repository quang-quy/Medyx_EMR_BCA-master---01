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
    [Route("api/benh-an-cpm")]
    [ApiController]
    [SessionFilter]
    public class BenhanCpmController : ControllerBase
    {
        private readonly BenhAnCpmService _benhAnCpmService;

        public BenhanCpmController(BenhAnCpmService benhAnCpmService)
        {
            _benhAnCpmService = benhAnCpmService;
        }

        // GET: api/<BenhAnKhoaDieuTriController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhanCpmDto> Get([FromQuery] BenhanCpmParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhanCpmDto> query = _benhAnCpmService.Get(parameters, user);

            return Res<BenhanCpmDto>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<BenhAnKhoaDieuTriController>/5
        [HttpGet("{id}/chi-tiet/{stt}")]
        public BenhanCpmDto Detail(decimal id, int stt)
        {
            return _benhAnCpmService.Detail(id, stt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
		[SessionMiddlewareFilter("HSBA/todieutri/chephammau/create", "HSBA/ChePhamMau/TheoDoiTruyenMau/create")]
        public ActionResult Post([FromBody] BenhAnCpmCreateVM benhAnCpmCreateVM)
        {
            if (ModelState.IsValid)
            {
                _benhAnCpmService.Store(benhAnCpmCreateVM);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{stt}")]
		[SessionMiddlewareFilter("HSBA/todieutri/chephammau/modify", "HSBA/ChePhamMau/TheoDoiTruyenMau/modify")]
        public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnCpmVM benhanCpm)
        {
            if (ModelState.IsValid)
            {
                _benhAnCpmService.Update(idba, stt, benhanCpm);
            }
            return Ok();
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{idba}/chi-tiet/{stt}")]
		[SessionMiddlewareFilter("HSBA/todieutri/chephammau/delete", "HSBA/ChePhamMau/TheoDoiTruyenMau/delete")]
        public ActionResult Delete(decimal idba, int stt)
        {
            if (ModelState.IsValid)
            {
                _benhAnCpmService.Destroy(idba, stt);
            }
            return Ok();
        }
    }
}
