using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
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
    [Route("api/benh-an-thuoc-yhct")]
    [ApiController]
    [SessionFilter]
    public class BenhanThuocYhctController : ControllerBase
    {
        private readonly BenhAnThuocYhctService _benhAnThuocYhctService;
        public BenhanThuocYhctController(BenhAnThuocYhctService benhAnThuocYhctService)
        {
            _benhAnThuocYhctService = benhAnThuocYhctService;
        }

        // GET: api/<BenhAnKhoaDieuTriController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhanThuocYhct> Get([FromQuery] BenhanThuocYhctParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhanThuocYhct> query = _benhAnThuocYhctService.Get(parameters, user);

            return Res<BenhanThuocYhct>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<BenhAnKhoaDieuTriController>/5
        [HttpGet("{idba}/chi-tiet/{stt}")]
        public BenhanThuocYhct Detail(decimal idba, int stt)
        {
            return _benhAnThuocYhctService.Detail(idba, stt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult Post([FromBody] BenhAnThuocYhctCreateVM benhAnThuocYhctVM)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocYhctService.Store(benhAnThuocYhctVM);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Update)]
        public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnThuocYhctVM benhAnThuocYhctVM)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocYhctService.Update(idba, stt, benhAnThuocYhctVM);
            }
            return Ok();
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
