using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using System;
using Microsoft.EntityFrameworkCore;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/thuoc")]
	[ApiController]
	[SessionFilter]
	public class DMThuocController : ControllerBase
	{
		private IRepository<Dmthuoc> repository = null;
		public DMThuocController()
		{
			this.repository = new GenericRepository<Dmthuoc>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public ActionResult Index([FromQuery] DMThuocParameters parameters)
		{
			var query = repository.Table.AsQueryable();
			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x =>
					x.TenGoc.Contains(parameters.Search)
					|| x.TenTm.Contains(parameters.Search)
					|| x.MaThuoc.Contains(parameters.Search)
				);
			}
			if (parameters.MaChungLoais.Any())
			{
				query = query.Where(x => parameters.MaChungLoais.Any(m => m.Trim() == x.MaChungLoai));
			}
			if (!string.IsNullOrEmpty(parameters.MaChungLoai))
			{
				query = query.Where(x => x.MaChungLoai.Contains(parameters.MaChungLoai));
			}
			if (parameters.IsWithRelation.HasValue && (bool)parameters.IsWithRelation)
			{
				var querySelect = DmthuocDtoQuery();
				var new_query = query.Select(querySelect);
				return Ok(QueryParamsHelper.ResultDanhMucDTOParams<Dmthuoc, DmthuocDto>(repository, new_query, parameters, querySelect, "MaThuoc"));
			}

			return Ok(QueryParamsHelper.ResultDanhMucParams<Dmthuoc>(repository, query, parameters, "MaThuoc"));
		}

		private Expression<Func<Dmthuoc, DmthuocDto>> DmthuocDtoQuery()
        {
			return Dmthuoc => new DmthuocDto()
			{
				MaThuoc = Dmthuoc.MaThuoc,
				MaNhom = Dmthuoc.MaNhom,
				MaPl = Dmthuoc.MaPl,
				MaChungLoai = Dmthuoc.MaChungLoai,
				MaDangBaoChe = Dmthuoc.MaDangBaoChe,
				TenGoc = Dmthuoc.TenGoc,
				TenTm = Dmthuoc.TenTm,
				HamLuong = Dmthuoc.HamLuong,
				MaDvt = Dmthuoc.MaDvt,
				MaNsx = Dmthuoc.MaNsx,
				Ghichu = Dmthuoc.Ghichu,
				MaQg = Dmthuoc.MaQg,
				MaDuongDung = Dmthuoc.MaDuongDung,
				MaByt = Dmthuoc.MaByt,
				TenByt = Dmthuoc.TenByt,
				SoDangKy = Dmthuoc.SoDangKy,
				MaMay = Dmthuoc.MaMay,
				DonViTinh = !String.IsNullOrEmpty(Dmthuoc.MaDvt) ?  new DmthuocDonvitinhDto()
				{
					MaDvt = Dmthuoc.DmthuocDonvitinh.MaDvt,
					TenDvt = Dmthuoc.DmthuocDonvitinh.TenDvt
				} : new DmthuocDonvitinhDto(),
				ThuocDuongDung = !String.IsNullOrEmpty(Dmthuoc.MaDuongDung) ? new DmthuocDuongDungDto()
				{
					MaDuongDung = Dmthuoc.DmthuocDuongDung.MaDuongDung,
					TenDuongDung = Dmthuoc.DmthuocDuongDung.TenDuongDung
				} : new DmthuocDuongDungDto(),
				QuocGia = !String.IsNullOrEmpty(Dmthuoc.MaQg) ? new DmquocGiaDto()
				{
					MaQg = Dmthuoc.DmquocGia.MaQg,
					TenQg = Dmthuoc.DmquocGia.TenQg
				} : new DmquocGiaDto()
            };
		}

		[HttpGet("{id}")]
		public Dmthuoc show(string id)
		{
			var model = repository.GetById(id);
			return model;
		}

		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		public ActionResult Add(Dmthuoc model)
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
		public ActionResult Edit(Dmthuoc model)
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
