using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-combods")]
	[ApiController]
	// [SessionFilter]
	public class DmbaCombodsController : ControllerBase
	{
		private IRepository<DmbaCombods> repository = null;
		public DmbaCombodsController()
		{
			repository = new GenericRepository<DmbaCombods>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmbaCombods> Get([FromQuery] DmbaCombodsParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Ma))
			{
				query = query.Where(x => x.Ma == parameters.Ma);
			}
			if (!string.IsNullOrEmpty(parameters.MaParent))
			{
				query = query.Where(x => x.MaParent == parameters.MaParent);
			}
			if (!string.IsNullOrEmpty(parameters.TenParent))
			{
				query = query.Where(x => x.TenParent.ToLower().Contains(parameters.TenParent.ToLower()));
			}

            return QueryParamsHelper.ResultDanhMucParams<DmbaCombods>(repository, query, parameters, "Ma");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmbaCombods Detail(string Ma)
		{
			var model = repository.GetById(Ma);
			return model;
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
