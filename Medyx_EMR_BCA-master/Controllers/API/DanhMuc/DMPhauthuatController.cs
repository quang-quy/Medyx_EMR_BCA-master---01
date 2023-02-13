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
	[Route("api/dm-phau-thuat")]
	[ApiController]
	// [SessionFilter]
	public class DMPhauthuatController : ControllerBase
	{
		private IRepository<DmphauThuat> repository = null;
		public DMPhauthuatController()
		{
			repository = new GenericRepository<DmphauThuat>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmphauThuat> Get([FromQuery] DmphauthuatiParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaPt.ToLower().Contains(parameters.Search.ToLower()) || x.TenPt.ToLower().Contains(parameters.Search.ToLower()));
			}
			if (parameters.MaChungloais.Any())
			{
				query = query.Where(x => parameters.MaChungloais.Any(m => m.Trim() == x.MaChungloai));
			}
			if(!String.IsNullOrEmpty(parameters.MaChungloai)){
				query = query.Where(x => x.MaChungloai.Contains(parameters.MaChungloai));
			}
			return QueryParamsHelper.ResultDanhMucParams<DmphauThuat>(repository, query, parameters, "MaPt");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmphauThuat Detail(string Ma)
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
