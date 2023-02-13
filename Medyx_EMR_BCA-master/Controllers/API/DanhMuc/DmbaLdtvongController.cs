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

namespace Medyx_EMR_BCA.Controllers.API
{
	[Route("api/benh-an-tinh-trang-tu-vong")]
	[ApiController]
	// [SessionFilter]
	public class DmbaLdtvongController : ControllerBase
	{
		private IRepository<DmbaLdtvong> repository = null;
		public DmbaLdtvongController()
		{
			repository = new GenericRepository<DmbaLdtvong>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmbaLdtvong> Get([FromQuery] DmbaLdtvongParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaLdtvong.ToLower().Contains(parameters.Search.ToLower()) || x.TenLdtvong.ToLower().Contains(parameters.Search.ToLower()));
			}
			if (!string.IsNullOrEmpty(parameters.MaLdtvong))
			{
				query = query.Where(x => x.MaLdtvong == parameters.MaLdtvong);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmbaLdtvong>(repository, query, parameters, "MaLdtvong");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmbaLdtvong Detail(string Ma)
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
