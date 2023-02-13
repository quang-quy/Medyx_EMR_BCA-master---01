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
	[Route("api/benh-an-kham-yhhd")]
	[ApiController]
	[SessionFilter]
	public class BenhAnKhamYhhdController : ControllerBase
	{
		private IRepository<BenhAnKhamYhhd> repository = null;
		public BenhAnKhamYhhdController(IHttpContextAccessor accessor)
		{
			repository = new GenericRepository<BenhAnKhamYhhd>(accessor);
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnKhamYhhd> Get([FromQuery] BenhAnKhamYhhdParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			query = SortHelper.ApplySort(query, parameters.SortBy);

			return Res<BenhAnKhamYhhd>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Idba}")]
		public BenhAnKhamYhhd Detail(string Idba)
		{
			var model = repository.GetById(Convert.ToDecimal(Idba));
			return model;
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		public ActionResult Post([FromBody] BenhAnKhamYhhd Info)
		{
			if (ModelState.IsValid)
			{
				repository.Insert(Info);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] BenhAnKhamYhhd Info)
		{
			if (ModelState.IsValid)
			{
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
