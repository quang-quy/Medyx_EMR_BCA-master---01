using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-loai-tai-lieu")]
	[ApiController]
	// [SessionFilter]
	public class DmbaLoaiTaiLieuController : ControllerBase
	{
		private readonly DmbaLoaiTaiLieuService _dmbaLoaiTaiLieuService;
		public DmbaLoaiTaiLieuController(DmbaLoaiTaiLieuService dmbaLoaiTaiLieuService)
		{
			_dmbaLoaiTaiLieuService = dmbaLoaiTaiLieuService;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<DmbaLoaiTaiLieu> Get([FromQuery] DmbaLoaiTaiLieuParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");

			return _dmbaLoaiTaiLieuService.Get(parameters, user);
		}

		[HttpGet("dich-vu")]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto> GetDichVu([FromQuery] DmbaLoaiTaiLieuDichVuParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto> query = _dmbaLoaiTaiLieuService.GetDichVu(parameters, user);

			return Res<BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{Ma}")]
		public void Detail(byte Ma)
		{
			
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
