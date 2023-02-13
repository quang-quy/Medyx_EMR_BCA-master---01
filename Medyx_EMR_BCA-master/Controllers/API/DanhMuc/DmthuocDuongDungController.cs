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
	//[SessionFilter]
	[Route("api/thuoc-duong-dung")]
	[ApiController]
	public class DmthuocDuongDungController : Controller
	{
		private IRepository<DmthuocDuongDung> repository = null;
		public DmthuocDuongDungController()
		{
			this.repository = new GenericRepository<DmthuocDuongDung>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmthuocDuongDung> Index([FromQuery] DmthuocDuongDungParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
					x => x.TenDuongDung.Contains(parameters.Search)
					|| x.MaDuongDung.Contains(parameters.Search)
				);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmthuocDuongDung>(repository, query, parameters, "MaDuongDung");
		}


		[HttpGet("{id}")]
		public DmthuocDuongDung show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmthuocDuongDung model)
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
		public ActionResult Edit(DmthuocDuongDung model)
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
