using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using System.Linq;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/phuong-xa")]
	[ApiController]
	[SessionFilter]
	public class DMPhuongXaController : ControllerBase
	{
		private IRepository<DmphuongXa> repository = null;
		public DMPhuongXaController()
		{
			this.repository = new GenericRepository<DmphuongXa>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmphuongXa> Index([FromQuery] DMPhuongXaParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.TenPxa.Contains(parameters.Search) || x.MaPxa.Contains(parameters.Search));
			}
			if (!string.IsNullOrEmpty(parameters.MaQuanHuyen))
			{
				query = query.Where(x => x.DmquanHuyen.MaQh == parameters.MaQuanHuyen);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmphuongXa>(repository, query, parameters, "MaPxa");
		}


		[HttpGet("{id}")]
		public DmphuongXa show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmphuongXa model)
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
		public ActionResult Edit(DmphuongXa model)
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
