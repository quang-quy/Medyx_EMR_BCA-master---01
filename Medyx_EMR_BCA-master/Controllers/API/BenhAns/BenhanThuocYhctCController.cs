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
	[Route("api/benh-an-thuoc-yhct-c")]
	[ApiController]
	[SessionFilter]
	public class BenhanThuocYhctCController : ControllerBase
	{
		private BenhAnThuocYhctCService _benhAnThuocYhctCService;
		public BenhanThuocYhctCController(BenhAnThuocYhctCService benhAnThuocYhctCService)
		{
			_benhAnThuocYhctCService = benhAnThuocYhctCService;

        }

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnThuocYhctCDto> Get([FromQuery] BenhanThuocYhctCParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnThuocYhctCDto> query = _benhAnThuocYhctCService.Get(parameters, user);

			return Res<BenhAnThuocYhctCDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhanThuocYhctC Detail(decimal idba, int stt)
		{
			return _benhAnThuocYhctCService.Detail(idba, stt);
        }

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/todieutri/thuocdongy/create")]
		public ActionResult Post([FromBody] BenhAnThuocYhctCCreateVM benhAnThuocYhctCCreateVM)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocYhctCService.Store(benhAnThuocYhctCCreateVM);
            }
            return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/todieutri/thuocdongy/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnThuocYhctCVM benhAnThuocYhctCVM)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocYhctCService.Update(idba, stt, benhAnThuocYhctCVM);
            }
            return Ok();
        }

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
        [SessionMiddlewareFilter("HSBA/todieutri/thuocdongy/delete")]
        public ActionResult Delete(decimal idba, int stt)
        {
            if (ModelState.IsValid)
            {
                _benhAnThuocYhctCService.Destroy(idba, stt);
            }
            return Ok();
        }
    }
}
