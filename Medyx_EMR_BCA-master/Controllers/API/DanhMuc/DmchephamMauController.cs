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
	[Route("api/dm-che-pham-mau")]
	[ApiController]
	// [SessionFilter]
	public class DmchephamMauController : ControllerBase
	{
		private IRepository<DmchephamMau> repository = null;
		public DmchephamMauController()
		{
			repository = new GenericRepository<DmchephamMau>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmchephamMau> Get([FromQuery] DmchephamMauParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaCpmau.ToLower().Contains(parameters.Search.ToLower()) || x.TenCpmau.ToLower().Contains(parameters.Search.ToLower()));
			}
			if (!string.IsNullOrEmpty(parameters.MaCpmau))
			{
				query = query.Where(x => x.MaCpmau == parameters.MaCpmau);
			}
			// if (parameters.MaChungloais.Any())
			// {
			// 	query = query.Where(x => parameters.MaChungloais.Any(m => m.Trim() == x.MaChungloai));
			// }
			// if (String.IsNullOrEmpty(parameters.MaChungloai))
			// {
			// 	query = query.Where(x => x.MaChungloai.Contains(parameters.MaChungloai));
			// }
			return QueryParamsHelper.ResultDanhMucParams<DmchephamMau>(repository, query, parameters, "MaCpmau");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmchephamMau Detail(string Ma)
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
