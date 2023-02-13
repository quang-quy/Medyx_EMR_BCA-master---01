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

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
	[Route("api/benh-an-ttvltl")]
	[ApiController]
	[SessionFilter]
	public class BenhanTtvltlController : ControllerBase
	{
		private IRepository<BenhanTtvltl> repository = null;
		private readonly BenhAnTtvltlService _benhAnTtvltlService;
		public BenhanTtvltlController(IHttpContextAccessor accessor)
		{
			repository = new GenericRepository<BenhanTtvltl>(accessor);
			_benhAnTtvltlService = new BenhAnTtvltlService(accessor);
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhanTtvltlDto> Get([FromQuery] BenhanTtvltlParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhanTtvltlDto> query = _benhAnTtvltlService.Get(parameters, user);

			return Res<BenhanTtvltlDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{id}/chi-tiet/{stt}")]
		public BenhanTtvltl Detail(string id, string stt)
		{
			var model = repository.GetById(Convert.ToInt32(stt), Convert.ToDecimal(id));
			return model;
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/todieutri/thuthuatvltl/create")]
		public ActionResult Post([FromBody] BenhAnTtvltlCreateVM benhAnTtvltlVM)
		{
			if (ModelState.IsValid)
			{
				_benhAnTtvltlService.Store(benhAnTtvltlVM);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/todieutri/thuthuatvltl/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnTtvltlVM benhanTtvltl)
		{
			if (ModelState.IsValid)
			{
				_benhAnTtvltlService.Update(idba, stt, benhanTtvltl);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/todieutri/thuthuatvltl/delete")]
		public ActionResult Delete(decimal idba, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnTtvltlService.Destroy(idba, stt);
			}
			return Ok();
		}
	}
}
