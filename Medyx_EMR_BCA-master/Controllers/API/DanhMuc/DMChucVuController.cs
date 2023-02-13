using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/dm-chuc-vu")]
	[ApiController]
	[SessionFilter]
	public class DMChucVuController : ControllerBase
	{
		private IRepository<DmchucVu> repository = null;
		public DMChucVuController()
		{
			this.repository = new GenericRepository<DmchucVu>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.List)]
		[SetCacheContextItem]
		public Response<DmchucVu> Index(RequestParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaCv.ToLower().Contains(parameters.Search.ToLower()) || x.TenCv.ToLower().Contains(parameters.Search.ToLower()));
			}

			return QueryParamsHelper.ResultDanhMucParams<DmchucVu>(repository, query, parameters, "MaCv");
		}


		[HttpGet("{id}")]
		public DmchucVu show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmchucVu model)
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
		public ActionResult Edit(DmchucVu model)
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
