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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
	[Route("api/benh-an-ttvlt-thuc-hien")]
	[ApiController]
	[SessionFilter]
	public class BenhAnTtvltlThuchienController : ControllerBase
	{
        private readonly BenhAnTtvltlThuchienService _benhAnTtvltlThuchienService;
        public BenhAnTtvltlThuchienController(BenhAnTtvltlThuchienService benhAnTtvltlThuchienService)
        {
            _benhAnTtvltlThuchienService = benhAnTtvltlThuchienService;
        }

        // GET: api/<BenhAnKhoaDieuTriController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhAnTtvltlThuchienDto> Get([FromQuery] BenhAnTtvltlThuchienParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            IQueryable<BenhAnTtvltlThuchienDto> query = _benhAnTtvltlThuchienService.Get(parameters, user);

            return Res<BenhAnTtvltlThuchienDto>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<BenhAnKhoaDieuTriController>/5
        [HttpGet("{idba}/chi-tiet/{stt}")]
        public BenhAnTtvltlThuchienDto Detail(decimal idba, int stt)
        {
            return _benhAnTtvltlThuchienService.Detail(idba, stt);
        }

        // POST api/<BenhAnKhoaDieuTriController>
        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        [SessionMiddlewareFilter("HSBA/ThucHienVatLyTriLieu/ThucHien/create")]
        public ActionResult Post([FromBody] BenhAnTtvltlThuchienCreateVM info)
        {

            if (ModelState.IsValid)
            {
                _benhAnTtvltlThuchienService.Store(info);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{id}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Update)]
        [SessionMiddlewareFilter("HSBA/ThucHienVatLyTriLieu/ThucHien/modify")]
        public void Put(decimal id, int stt, [FromBody] BenhAnTtvltlThuchienVM info)
        {
            if (ModelState.IsValid)
            {
                _benhAnTtvltlThuchienService.Update(id, stt, info);
            }
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{id}/chi-tiet/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
        [SessionMiddlewareFilter("HSBA/ThucHienVatLyTriLieu/ThucHien/delete")]
        public void Delete(decimal id, int stt)
        {
            if (ModelState.IsValid)
            {
                _benhAnTtvltlThuchienService.Destroy(id, stt);
            }
        }
    }
}
