using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/dm-benhtat-yhct")]
	[ApiController]
	[SessionFilter]
	public class DMBenhTatYHCTController : ControllerBase
	{
		private IRepository<DmbenhTatYhct> repository = null;
		public DMBenhTatYHCTController()
		{
			this.repository = new GenericRepository<DmbenhTatYhct>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmbenhTatYhct> Index([FromQuery] DMbenhTatYhctParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				var search = parameters.Search.ToLower();
				query = query.Where(x => x.TenBenh.ToLower().Contains(search)
					|| x.MaBenhIcd.ToLower().Contains(search)
					|| x.TenBenhIcd.ToLower().Contains(search)
					|| x.MaBenh.ToLower().Contains(search)
				);
			}
			if (!string.IsNullOrEmpty(parameters.MaBenhIcd))
			{
				query = query.Where(x => x.MaBenhIcd == parameters.MaBenhIcd);
			}
			if (!string.IsNullOrEmpty(parameters.TenBenhIcd))
			{
				query = query.Where(x => x.TenBenhIcd == parameters.TenBenhIcd);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmbenhTatYhct>(repository, query, parameters, "MaBenh", "maBenhIcd");
		}


		[HttpGet("{id}")]
		public DmbenhTatYhct show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmbenhTatYhct model)
		{
			if (ModelState.IsValid)
			{
				repository.Insert(model);
				repository.Save();
			}
			return Ok();
		}
		[HttpPatch]
		[SetActionContextItem(ActionType.Update)]
		public ActionResult Edit(DmbenhTatYhct model)
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
