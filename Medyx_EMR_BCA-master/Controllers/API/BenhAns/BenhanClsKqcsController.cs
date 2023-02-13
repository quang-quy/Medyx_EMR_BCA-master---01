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
	[Route("api/benh-an-chuan-doan-hinh-anh-ket-qua-cs")]
	[ApiController]
	[SessionFilter]
	public class BenhanClsKqcsController : ControllerBase
	{
		private IRepository<BenhanClsKqcs> repository = null;
		public BenhanClsKqcsController(IHttpContextAccessor accessor)
		{
			repository = new GenericRepository<BenhanClsKqcs>(accessor);
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhanClsKqcs> Get([FromQuery] BenhanClsKqcsParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			query = SortHelper.ApplySort(query, parameters.SortBy);
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
            query = SortHelper.ApplySort(query, parameters.SortBy);

			return Res<BenhanClsKqcs>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{id}/chi-tiet/{stt}")]
		public BenhanClsKqcs Detail(string id, string stt)
		{
			var model = repository.GetById(Convert.ToInt32(stt), Convert.ToDecimal(id));
			return model;
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		public ActionResult Post([FromBody] BenhanClsKqcs value)
		{
			// if (ModelState.IsValid)
            // {
            //     repository.Insert(value);
            // }
            return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}/chi-tiet/{stt}")]
		public ActionResult Put(int stt, decimal idba, [FromBody] BenhanClsKqcs value)
		{
			// if (ModelState.IsValid)
            // {
            //     repository.Update(value, idba, stt);
            // }
            return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
