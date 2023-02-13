using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-kham-yhct")]
	[ApiController]
	[SessionFilter]
	public class BenhAnKhamYhctController : ControllerBase
	{
		private IRepository<BenhAnKhamYhct> repository = null;
		public BenhAnKhamYhctController(IHttpContextAccessor accessor)
		{
			repository = new GenericRepository<BenhAnKhamYhct>(accessor);
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnKhamYhct> Get([FromQuery] BenhAnKhamYhctParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			query = SortHelper.ApplySort(query, parameters.SortBy);

			return Res<BenhAnKhamYhct>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Idba}")]
		public BenhAnKhamYhct Detail(string Idba)
		{
			var model = repository.GetById(Convert.ToDecimal(Idba));
			return model;
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
        [SessionMiddlewareFilter("HSBA/todieutri/thuocdongy/create")]
		public ActionResult Post([FromBody] BenhAnKhamYhct Info)
        {
			if (ModelState.IsValid)
			{
				PermissionThrowHelper.GetBenhAnAndCheckPermission(Info.Idba);
				repository.Insert(Info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}")]
        [SessionMiddlewareFilter("HSBA/todieutri/thuocdongy/modify")]
		public ActionResult Put(int id, [FromBody] BenhAnKhamYhct Info)
        {
			if (ModelState.IsValid)
			{
				PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
				repository.Update(Info, id);
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
