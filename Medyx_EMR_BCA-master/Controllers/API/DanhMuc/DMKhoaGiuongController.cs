using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
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
	[Route("api/dm-khoa-giuong")]
	[ApiController]
	public class DMKhoaGiuongController : ControllerBase
	{
		private IRepository<DmkhoaGiuong> repository = null;
		public DMKhoaGiuongController()
		{
			this.repository = new GenericRepository<DmkhoaGiuong>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmkhoaGiuong> Index([FromQuery] DMKhoaGiuongParameters parameters)
		{
			var query = repository.Table.Where(x => x.MaBuong == parameters.MaBuong).Where(x => x.MaKhoa == parameters.MaKhoa);
			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(
					x => x.TenGiuong.Contains(parameters.Search)
					|| x.MaBuong.Contains(parameters.Search)
				);
			}

			return QueryParamsHelper.ResultDanhMucParams<DmkhoaGiuong>(repository, query, parameters, "MaBuong");
		}


		[HttpGet("{id}")]
		public DmkhoaGiuong show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(DmkhoaGiuong model)
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
		public ActionResult Edit(DmkhoaGiuong model)
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
