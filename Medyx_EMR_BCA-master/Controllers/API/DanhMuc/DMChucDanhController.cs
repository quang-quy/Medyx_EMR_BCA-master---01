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
	[Route("api/dm-chuc-danh")]
	[SessionFilter]
	[ApiController]
	public class DMChucDanhController : Controller
	{
		private IRepository<DmchucDanh> repository = null;
		public DMChucDanhController()
		{
			this.repository = new GenericRepository<DmchucDanh>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmchucDanh> Index(RequestParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.MaCd.ToLower().Contains(parameters.Search.ToLower()) || x.TenCd.ToLower().Contains(parameters.Search.ToLower()));
			}
		
			return QueryParamsHelper.ResultDanhMucParams<DmchucDanh>(repository, query, parameters, "MaCd");
		}


		[HttpGet("{id}")]
		public DmchucDanh show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmchucDanh model)
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
		public ActionResult Edit(DmchucDanh model)
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
