using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/dm-khoa-buong")]
	[ApiController]
	public class DMKhoaBuongController : ControllerBase
	{
		private IRepository<DmkhoaBuong> repository = null;
		public DMKhoaBuongController()
		{
			this.repository = new GenericRepository<DmkhoaBuong>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmkhoaBuong> Index([FromQuery] DMKhoaBuongParameters parameters)
		{
			var query = repository.Table.Where(x => x.Dmkhoa.MaKhoa == parameters.MaKhoa);

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
					x => x.TenBuong.Contains(parameters.Search)
					|| x.MaBuong.Contains(parameters.Search)
				);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmkhoaBuong>(repository, query, parameters, "MaBuong");
			
		}


		[HttpGet("{id}")]
		public DmkhoaBuong show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmkhoaBuong model)
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
		public ActionResult Edit(DmkhoaBuong model)
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
