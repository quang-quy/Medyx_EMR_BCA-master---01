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
	[Route("api/doi-tuong")]
	[ApiController]
	public class DMDoiTuongController : Controller
	{
		private IRepository<DmdoiTuong> repository = null;
		public DMDoiTuongController()
		{
			this.repository = new GenericRepository<DmdoiTuong>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmdoiTuong> Index([FromQuery] DMDoiTuongParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
					x => x.TenDt.Contains(parameters.Search)
					|| x.MaDt.Contains(parameters.Search)
				);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmdoiTuong>(repository, query, parameters, "MaDt");
		}


		[HttpGet("{id}")]
		public DmdoiTuong show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmdoiTuong model)
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
		public ActionResult Edit(DmdoiTuong model)
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
