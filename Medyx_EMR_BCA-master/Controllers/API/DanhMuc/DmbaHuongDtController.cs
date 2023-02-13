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
	[Route("api/dm-benh-an-huong-dieu-tri")]
	[ApiController]
	// [SessionFilter]
	public class DmbaHuongDtController : ControllerBase
	{
		private IRepository<DmbaHuongDt> repository = null;
		public DmbaHuongDtController()
		{
			repository = new GenericRepository<DmbaHuongDt>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmbaHuongDt> Get([FromQuery] RequestParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaHdt.ToLower().Contains(parameters.Search.ToLower()) || x.TenHdt.ToLower().Contains(parameters.Search.ToLower()));
			}
			if (!string.IsNullOrEmpty(parameters.Ma))
			{
				query = query.Where(x => x.MaHdt == parameters.Ma);
			}

            return QueryParamsHelper.ResultDanhMucParams<DmbaHuongDt>(repository, query, parameters, "MaHDT");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmbaHuongDt Detail(string Ma)
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
