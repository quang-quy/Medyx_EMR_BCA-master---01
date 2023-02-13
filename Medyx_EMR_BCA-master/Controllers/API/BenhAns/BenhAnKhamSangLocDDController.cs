using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Services;
using Microsoft.AspNetCore.Http;
using Medyx.ApiAssets.Models.Configure;
using Microsoft.Extensions.Options;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Medyx.ApiAssets.Dto.Print;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
	[Route("api/benh-an-kham-sang-loc-dd")]
	[ApiController]
    [SessionFilter]
    public class BenhAnKhamSangLocDDController : ControllerBase
	{
		private IRepository<BenhAnKhamSangLocDd> repository = null;
		private BenhAnKhamSangLocDDService _benhAnKhamSangLocDDService;
		private PrintSetting PrintSetting { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;
		private UploadFileRespository uploadFileRespository = null;
		public BenhAnKhamSangLocDDController(HostingEnvironment hostingEnvironment, IHttpContextAccessor accessor, IOptions<PrintSetting> options)
		{
			repository = new GenericRepository<BenhAnKhamSangLocDd>(accessor);
			_benhAnKhamSangLocDDService = new BenhAnKhamSangLocDDService(accessor, options, hostingEnvironment);
			PrintSetting = options.Value;
			_hostingEnvironment = hostingEnvironment;
			uploadFileRespository = new UploadFileRespository();
		}

        // GET: api/<BenhAnController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhAnKhamSangLocDdDto> Get([FromQuery] BenhAnBenhAnKhamSangLocDDParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhAnKhamSangLocDdDto> query = _benhAnKhamSangLocDDService.Get(parameters, user);

            return Res<BenhAnKhamSangLocDdDto>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<BenhAnController>/5
        [HttpGet("{id}")]
        public BenhAnKhamSangLocDd Detail(decimal id)
        {
            var model = repository.GetById(id);
            return model;
        }
        public ActionResult CreateOrEdit(BenhAnKhamSangLocDd info)
        {

            if (ModelState.IsValid)
            {
                var model = repository.GetById(info.Idba);
                if (model != null)
                {
                    repository.Update(info, info.Idba);
                }
                else
                {
                    repository.Insert(info);
                }
            }
            return Ok();
        }

        // POST api/<BenhAnController>

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/phieudinhduong/create")]
        public ActionResult Post([FromBody] BenhAnKhamSangLocDdCreateVM benhAnKhamSangLocDd)
        {
            if (ModelState.IsValid)
            {
                _benhAnKhamSangLocDDService.Store(benhAnKhamSangLocDd);
            }
            return Ok();
        }

        // PUT api/<BenhAnController>/5
        [HttpPut("{idba}/chi-tiet/{stt}/{sttkhoa}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/phieudinhduong/modify")]
        public ActionResult Put(decimal idba, int stt, int sttKhoa, [FromBody] BenhAnKhamSangLocDdVM benhAnKhamSangLocDd)
        {
            if (ModelState.IsValid)
            {
                _benhAnKhamSangLocDDService.Update(idba, stt, sttKhoa, benhAnKhamSangLocDd);
            }
            return Ok();
        }

        // DELETE api/<BenhAnController>/5
        [HttpDelete("{idba}/chi-tiet/{stt}/{sttkhoa}")]
        [SetActionContextItem(ActionType.Delete)]
        [SessionMiddlewareFilter("HSBA/phieudinhduong/delete")]
        public ActionResult Delete(decimal idba, int stt, int sttKhoa)
        {
            if (ModelState.IsValid)
            {
                _benhAnKhamSangLocDDService.Destroy(idba, stt, sttKhoa);
            }
			return Ok();
		}
		[HttpGet("{idba}/print-ba-file/{stt}/{sttKhoa}/{maba}.pdf")]
        [SessionMiddlewareFilter("HSBA/phieudinhduong/export")]
		public ActionResult Print(decimal idba, int stt, int sttKhoa, [FromQuery] PrintParameters parameters)
        {
			string path = _benhAnKhamSangLocDDService.Print(idba, stt, sttKhoa);
            if (parameters.ShouldReturnPath)
                return new JsonResult(new { path });
			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
	}

}
