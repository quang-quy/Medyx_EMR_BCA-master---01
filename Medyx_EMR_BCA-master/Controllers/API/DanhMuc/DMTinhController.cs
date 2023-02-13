using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/tinh")]
	[ApiController]
	[SessionFilter]
	public class DMTinhController : ControllerBase
	{
		private IRepository<Dmtinh> repository = null;
		public DMTinhController()
		{
			this.repository = new GenericRepository<Dmtinh>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<Dmtinh> Index([FromQuery] DMTinhParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
                    x => x.TenTinh.Contains(parameters.Search)
                    || x.MaTinh.Contains(parameters.Search)
                );
			}

			return QueryParamsHelper.ResultDanhMucParams<Dmtinh>(repository, query, parameters, "MaTinh");
		}


		[HttpGet("{id}")]
		public Dmtinh show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(Dmtinh model)
		{
			if (ModelState.IsValid)
			{
				repository.Insert(model);
				repository.Save();
			}
			return Ok();
		}
		[HttpPost]
		[SetActionContextItem(ActionType.Update)]
		public ActionResult Edit(Dmtinh model)
		{
			if (ModelState.IsValid)
			{
				repository.Update(model);
				repository.Save();
			}
			return Ok();
		}
		[HttpDelete("{id}")]
		[SetActionContextItem(ActionType.Delete)]
		public ActionResult Delete(int id)
		{
			repository.Delete(id);
			repository.Save();
			return Ok();
		}
	}
}
