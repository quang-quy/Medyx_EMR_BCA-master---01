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
	[Route("api/benh-an-phau-thuat")]
	[ApiController]
	[SessionFilter]
	public class BenhAnPhauThuatController : ControllerBase
	{
		private readonly BenhAnPhauThuatService _benhAnPhauThuatService;

		public BenhAnPhauThuatController(BenhAnPhauThuatService benhAnPhauThuatService)
		{
			_benhAnPhauThuatService = benhAnPhauThuatService;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhanPhauThuatDto> Get([FromQuery] BenhanPhauThuatParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhanPhauThuatDto> query = _benhAnPhauThuatService.Get(parameters, user);

			return Res<BenhanPhauThuatDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhanPhauThuat Detail(decimal idba, int stt)
		{
			return _benhAnPhauThuatService.Detail(idba, stt);
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/todieutri/phauthuthuat/create", "HSBA/PhieuPhauThuat/create")]
		public ActionResult Post([FromBody] BenhAnPhauThuatCreateVM benhAnPhauThuatCreateVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhauThuatService.Store(benhAnPhauThuatCreateVM);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/todieutri/phauthuthuat/modify", "HSBA/PhieuPhauThuat/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnPhauThuatVM benhanPhauThuat)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhauThuatService.Update(idba, stt, benhanPhauThuat);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/todieutri/phauthuthuat/delete", "HSBA/PhauThuatThuThuat/delete")]
		public ActionResult Delete(decimal idba, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnPhauThuatService.Destroy(idba, stt);
			}
			return Ok();
		}
	}
}
