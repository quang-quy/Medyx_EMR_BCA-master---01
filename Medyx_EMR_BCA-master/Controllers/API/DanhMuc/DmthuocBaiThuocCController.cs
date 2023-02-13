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
using Medyx_EMR_BCA.ApiAssets.Dto;
using System.Linq.Expressions;
using System;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	//[SessionFilter]
	[Route("api/thuoc-bai-thuoc-c")]
	[ApiController]
	public class DmthuocBaiThuocCController : Controller
	{
		private IRepository<DmthuocBaiThuocC> repository = null;
		public DmthuocBaiThuocCController()
		{
			this.repository = new GenericRepository<DmthuocBaiThuocC>();
		}
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public ActionResult Index([FromQuery] DmthuocBaiThuocCParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.MaBthuoc))
			{
				query = query.Where(x => x.MaBthuoc == parameters.MaBthuoc);
			}

            var querySelect = DmthuocBaiThuocCDtoQuery();
            return Ok(QueryParamsHelper.ResultDanhMucDTOParams<DmthuocBaiThuocC, DmthuocBaiThuocCDto>(repository, query.Select(querySelect), parameters, querySelect, "MaBthuoc"));
		}

        private Expression<Func<DmthuocBaiThuocC, DmthuocBaiThuocCDto>> DmthuocBaiThuocCDtoQuery()
        {
			return DmthuocBaiThuocC => new DmthuocBaiThuocCDto()
			{
				MaBthuoc = DmthuocBaiThuocC.MaBthuoc,
				STT = DmthuocBaiThuocC.Stt,
				Thuoc = new DmthuocDto()
				{
					MaThuoc = DmthuocBaiThuocC.Dmthuoc.MaThuoc,
                    MaPl = DmthuocBaiThuocC.Dmthuoc.MaPl,
                    TenGoc = DmthuocBaiThuocC.Dmthuoc.TenGoc,
                    TenTm = DmthuocBaiThuocC.Dmthuoc.TenTm,
                    HamLuong = DmthuocBaiThuocC.Dmthuoc.HamLuong,
                    DonViTinh = new DmthuocDonvitinhDto()
                    {
                        MaDvt = DmthuocBaiThuocC.Dmthuoc.DmthuocDonvitinh.MaDvt,
                        TenDvt = DmthuocBaiThuocC.Dmthuoc.DmthuocDonvitinh.TenDvt
                    },
                },
				Soluong = DmthuocBaiThuocC.Soluong,
				LieuDung = DmthuocBaiThuocC.LieuDung,
				CachDung = DmthuocBaiThuocC.CachDung,
            };
        }
    }
}
