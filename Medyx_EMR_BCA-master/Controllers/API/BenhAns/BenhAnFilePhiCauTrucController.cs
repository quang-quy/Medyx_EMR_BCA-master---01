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
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
	[Route("api/benh-an-file-phi-cau-truc")]
	[ApiController]
	[SessionFilter]
	public class BenhAnFilePhiCauTrucController : ControllerBase
	{
		private IRepository<BenhAnFilePhiCauTruc> repository = null;
		private UploadFileRespository _uploadFileRespository = null;
		private BenhAnFilePhiCauTrucService _benhAnFilePhiCauTrucService;

		public BenhAnFilePhiCauTrucController(BenhAnFilePhiCauTrucService benhAnFilePhiCauTrucService, IHttpContextAccessor accessor, UploadFileRespository uploadFileRespository = null)
		{
			repository = new GenericRepository<BenhAnFilePhiCauTruc>(accessor);
			_uploadFileRespository = uploadFileRespository;
			_benhAnFilePhiCauTrucService = benhAnFilePhiCauTrucService;
		}

		// GET: api/<BenhAnFilePhiCauTrucController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnFilePhiCauTrucDto> Get([FromQuery] BenhAnFilePhiCauTrucParameters parameters)
		{
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhAnFilePhiCauTrucDto> query = _benhAnFilePhiCauTrucService.Get(parameters, user);

            return Res<BenhAnFilePhiCauTrucDto>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

		// GET api/<BenhAnFilePhiCauTrucController>/5
		[HttpGet("{id}/chi-tiet/{stt}/{LoaiTaiLieu}")]
		public BenhAnFilePhiCauTruc Detail(string id, string stt, string LoaiTaiLieu)
		{
			var model = repository.GetById(Convert.ToInt32(stt), Convert.ToDecimal(id), Convert.ToByte(LoaiTaiLieu));
			return model;
		}

		// POST api/<BenhAnFilePhiCauTrucController>
		[HttpPost]
		[SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/TepDinhKem/import")]
		public ActionResult Post([FromForm] BenhAnFilePhiCauTrucVM info)
		{
			if (ModelState.IsValid)
			{
				_benhAnFilePhiCauTrucService.Store(info);
			}
			return Ok();
		}
		// PUT api/<BenhAnFilePhiCauTrucController>/5
		[HttpPut("{idba}/chi-tiet/{stt}")]
		public void Put(int id, [FromBody] string value)
		{
			/*if (ModelState.IsValid)
			{
				_benhAnFilePhiCauTrucService.Update(info);
			}
			return Ok();*/
		}

		// DELETE api/<BenhAnFilePhiCauTrucController>/5
		[HttpDelete("{idba}/chi-tiet/{stt}")]
		[SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/TepDinhKem/delete")]
		public ActionResult Delete(decimal idba, int stt)
		{
			if(ModelState.IsValid)
            {
				_benhAnFilePhiCauTrucService.Destroy(idba, stt);
			}
			/*repository.Delete((model) =>
			{
				uploadFileRespository.RemoveFile(model.Link);
			}, idba, stt);*/
			return Ok();
		}
		[HttpGet("{id}/download-ba-file/{stt}")]
		[SessionMiddlewareFilter("HSBA/TepDinhKem/export")]
		public IActionResult Download(decimal id, int stt)
		{
			var model = repository.GetById(id, stt);
			if (model == null)
			{
				throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy tài liệu");
			}
			DownloadFileResult downloadFileResult = _uploadFileRespository.Download(model.Link);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType, downloadFileResult.FileName);
		}
	}
}
