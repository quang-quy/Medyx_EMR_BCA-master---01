using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Microsoft.Extensions.Caching.Memory;
using Medyx_EMR_BCA.Models.DBConText;
using System.Collections.Generic;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
	[Route("api/khoa")]
	[ApiController]
	public class DMKhoaController : ControllerBase
	{
		private IMemoryCache cache;
		private IRepository<Dmkhoa> repository = null;
		//public DMKhoaController()
		public DMKhoaController(IMemoryCache cache)
		{
			repository = new GenericRepository<Dmkhoa>();
			this.cache = cache;
		}

		// GET: api/<DMKhoaController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
		public Response<Dmkhoa> Get([FromQuery] DMKhoaParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (!string.IsNullOrEmpty(parameters.Search))
			{
				query = query.Where(x => x.TenKhoa.Contains(parameters.Search) || x.MaKhoa.ToLower().Contains(parameters.Search.ToLower()));
			}
			if (parameters.Loai.HasValue)
			{
				query = query.Where(x => x.Loai == parameters.Loai);
			}
			if(parameters.Huy.HasValue)
            {
				query = query.Where(x => x.Huy == parameters.Huy);
			}
			
            return QueryParamsHelper.ResultDanhMucParams<Dmkhoa>(repository, query, parameters, "MaKhoa");
		}
        [HttpGet("GetByAccount")]
        //[Route("api/khoa/GetByAccount")]
        [SetActionContextItem(ActionType.PagedList)]
        [SetCacheContextItem]
        public Response<Dmkhoa> GetByAccount()
        {
            Response<Dmkhoa> response = new Response<Dmkhoa>();
            var u = Models.DBConText.SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            if (u != null)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                List<Dmkhoa> DMKhoaAcc = cache.Get<List<Dmkhoa>>("DMKhoaAcc" + u.Pub_sNguoiSD);
                if (DMKhoaAcc == null)
                {
                    DMKhoaAcc = db.GetDMNVKhoaByAcc(u.Pub_sNguoiSD).ToList();
                    //set cache 30 ngay
                    cache.Set<List<Dmkhoa>>("DMKhoaAcc" + u.Pub_sNguoiSD, DMKhoaAcc, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
                }
                response.data = DMKhoaAcc;
            }
            return response;
        }
        // GET api/<DMKhoaController>/5
        [HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<DMKhoaController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<DMKhoaController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<DMKhoaController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
