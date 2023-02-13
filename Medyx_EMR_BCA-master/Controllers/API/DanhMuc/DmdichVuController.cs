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
	[Route("api/dm-dich-vu")]
	[ApiController]
	// [SessionFilter]
	public class DmdichVuController : ControllerBase
	{
		private IRepository<DmdichVu> repository = null;
		public DmdichVuController()
		{
			repository = new GenericRepository<DmdichVu>();
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmdichVu> Get([FromQuery] DmdichVuParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaDv.ToLower().Contains(parameters.Search.ToLower()) || x.TenDv.ToLower().Contains(parameters.Search.ToLower()));
			}
			if (!string.IsNullOrEmpty(parameters.MaDv))
			{
				query = query.Where(x => x.MaDv == parameters.MaDv);
			}
			if (parameters.MaChungloais.Any())
			{
				query = query.Where(x => parameters.MaChungloais.Any(m => m.Trim() == x.MaChungloai));
			}
			if(!String.IsNullOrEmpty(parameters.MaChungloai)){
				query = query.Where(x => x.MaChungloai.Contains(parameters.MaChungloai));
			}
			if(!string.IsNullOrEmpty(parameters.ExcludeMaChungLoai))
            {
				query = query.Where(x => x.MaChungloai != parameters.ExcludeMaChungLoai);
            }
			return QueryParamsHelper.ResultDanhMucParams<DmdichVu>(repository, query, parameters, "MaDv");
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public DmdichVu Detail(string Ma)
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
