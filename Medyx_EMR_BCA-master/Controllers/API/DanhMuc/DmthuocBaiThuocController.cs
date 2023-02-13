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
	[Route("api/thuoc-bai-thuoc")]
	[ApiController]
	public class DmthuocBaiThuocController : Controller
	{
		private IRepository<DmthuocBaiThuoc> repository = null;
		public DmthuocBaiThuocController()
		{
			this.repository = new GenericRepository<DmthuocBaiThuoc>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmthuocBaiThuoc> Index([FromQuery] DmthuocBaiThuocParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
					x => x.TenBthuoc.Contains(parameters.Search)
					|| x.MaBthuoc.Contains(parameters.Search)
				);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmthuocBaiThuoc>(repository, query, parameters, "MaBthuoc");
		}


		[HttpGet("{id}")]
		public DmthuocBaiThuoc show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmthuocBaiThuoc model)
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
		public ActionResult Edit(DmthuocBaiThuoc model)
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
