using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-khoa-dieu-tri")]
	[ApiController]
	[SessionFilter]
	public class BenhAnKhoaDieuTriController : ControllerBase
	{
		private readonly BenhAnKhoaDieuTriService _benhAnKhoaDieuTriService;
		public BenhAnKhoaDieuTriController(BenhAnKhoaDieuTriService benhAnKhoaDieuTriService)
		{
			_benhAnKhoaDieuTriService = benhAnKhoaDieuTriService;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnKhoaDieuTriDto> Get([FromQuery] BenhAnKhoaDieuTriParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			return _benhAnKhoaDieuTriService.Get(parameters, user);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{id}")]
		public BenhAnKhoaDieuTri Detail(string id)
		{
			return _benhAnKhoaDieuTriService.Show(Convert.ToDecimal(id));
		}
		[HttpGet("{idba}/chi-tiet/{stt}")]
		public BenhAnKhoaDieuTri Show(decimal idba, int stt)
		{
			return _benhAnKhoaDieuTriService.Show(idba, stt);
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
        [SessionMiddlewareFilter("HSBA/khoadieutri/create")]
		public ActionResult Post([FromBody] BenhAnKhoaDieuTriCreateVM info)
        {

			if (ModelState.IsValid)
			{
				_benhAnKhoaDieuTriService.Store(info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}/chi-tiet/{stt}")]
        [SessionMiddlewareFilter("HSBA/khoadieutri/modify")]
		public void Put(decimal id, int stt, [FromBody] BenhAnKhoaDieuTriVM info)
		{
			if (ModelState.IsValid)
			{
				_benhAnKhoaDieuTriService.Update(id, stt, info);
			}
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}/chi-tiet/{stt}")]
        [SessionMiddlewareFilter("HSBA/khoadieutri/delete")]
		public void Delete(decimal id, int stt)
        {
			if (ModelState.IsValid)
			{
				_benhAnKhoaDieuTriService.Destroy(id, stt);
			}
		}
	}
}
