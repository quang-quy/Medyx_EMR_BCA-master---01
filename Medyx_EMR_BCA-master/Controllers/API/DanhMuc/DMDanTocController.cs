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
	[Route("api/dan-toc")]
	//[SessionFilter]
	[ApiController]
	public class DMDanTocController : Controller
	{
		private IRepository<DmdanToc> repository = null;
		public DMDanTocController()
		{
			this.repository = new GenericRepository<DmdanToc>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmdanToc> Index([FromQuery] DMDanTocParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.TenDanToc.Contains(parameters.Search) || x.MaDanToc.ToLower().Contains(parameters.Search.ToLower()));
			}
			
			return QueryParamsHelper.ResultDanhMucParams<DmdanToc>(repository, query, parameters, "MaDanToc");
		}


		[HttpGet("{id}")]
		public DmdanToc show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmdanToc model)
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
		public ActionResult Edit(DmdanToc model)
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
