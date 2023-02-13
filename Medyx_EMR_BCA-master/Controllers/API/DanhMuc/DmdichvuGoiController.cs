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
	[Route("api/dm-dich-vu-goi")]
	[ApiController]
	// [SessionFilter]
	public class DmdichvuGoiController : ControllerBase
	{
		private IRepository<DmdichvuGoi> repository = null;
		public DmdichvuGoiController()
		{
			repository = new GenericRepository<DmdichvuGoi>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmdichvuGoi> Get([FromQuery] DmdichvuGoiParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaGoi.ToLower().Contains(parameters.Search.ToLower()) || x.TenGoi.ToLower().Contains(parameters.Search.ToLower()));
			}
			if(parameters.ExcludeLoai.HasValue){
				query = query.Where(x => x.Loai != parameters.ExcludeLoai);
			}
			if (parameters.Loai.HasValue) {
				query = query.Where(x => x.Loai == parameters.Loai);
			}
			return QueryParamsHelper.ResultDanhMucParams<DmdichvuGoi>(repository, query, parameters, "MaGoi");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmdichvuGoi Detail(string Ma)
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
