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
	[SessionFilter]
	[Route("api/nghe-nghiep")]
	[ApiController]
	public class DMNgheNghiepController : Controller
	{
		private IRepository<DmngheNghiep> repository = null;
		public DMNgheNghiepController()
		{
			this.repository = new GenericRepository<DmngheNghiep>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmngheNghiep> Index([FromQuery] DMNgheNghiepParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
                    x => x.TenNn.Contains(parameters.Search)
                    || x.MaNn.Contains(parameters.Search)
                );
			}

			return QueryParamsHelper.ResultDanhMucParams<DmngheNghiep>(repository, query, parameters, "MaNn");
		}


		[HttpGet("{id}")]
		public DmngheNghiep show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmngheNghiep model)
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
		public ActionResult Edit(DmngheNghiep model)
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
