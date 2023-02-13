using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
    [Route("api/benh-an-theo-doi-truyen-mau-c")]
	[ApiController]
	//[SessionFilter]
	public class BenhAnTheodoiTruyenMauCController : ControllerBase
	{
		private readonly BenhAnTheoDoiTruyenMauCService _benhAnTheoDoiTruyenMauCService;
		public BenhAnTheodoiTruyenMauCController(BenhAnTheoDoiTruyenMauCService benhAnTheoDoiTruyenMauCService)
		{
			_benhAnTheoDoiTruyenMauCService = benhAnTheoDoiTruyenMauCService;
		}

		// GET: api/<BenhAnKhoaDieuTriController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhanTheodoiTruyenMauCDto> Get([FromQuery] BenhAnTheodoiTruyenMauCParameters parameters)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
			IQueryable<BenhanTheodoiTruyenMauCDto> query = _benhAnTheoDoiTruyenMauCService.Get(parameters, user);

			return Res<BenhanTheodoiTruyenMauCDto>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnKhoaDieuTriController>/5
		[HttpGet("{id}/chi-tiet/{stt}")]
		public BenhanTheodoiTruyenMauCDto Detail(decimal id, int stt)
		{
			return _benhAnTheoDoiTruyenMauCService.Detail(id, stt);
		}

		// POST api/<BenhAnKhoaDieuTriController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/ChePhamMau/TheoDoiTruyenMau/create")]
		public ActionResult Post([FromBody] BenhAnTheoDoiTruyenMauCCreateVM parameters)
		{
			if (ModelState.IsValid)
			{
				_benhAnTheoDoiTruyenMauCService.Store(parameters);
			}
			return Ok();
		}

		// PUT api/<BenhAnKhoaDieuTriController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/ChePhamMau/TheoDoiTruyenMau/modify")]
		public ActionResult Put(decimal idba, int stt, [FromBody] BenhAnTheoDoiTruyenMauCVM parameters)
		{
			if (ModelState.IsValid)
			{
				_benhAnTheoDoiTruyenMauCService.Update(idba, stt, parameters);
			}
			return Ok();
		}

		// DELETE api/<BenhAnKhoaDieuTriController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/ChePhamMau/TheoDoiTruyenMau/delete")]
		public ActionResult Delete(decimal idba, int stt)
		{
			if (ModelState.IsValid)
			{
				_benhAnTheoDoiTruyenMauCService.Destroy(idba, stt);
			}
			return Ok();
		}
	}
}
