using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
    [Route("api/quan-huyen")]
    [ApiController]
    [SessionFilter]
    public class DMQuanHuyenController : ControllerBase
    {
        private IRepository<DmquanHuyen> repository = null;
        public DMQuanHuyenController()
        {
            this.repository = new GenericRepository<DmquanHuyen>();
        }
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
        public Response<DmquanHuyen> Index([FromQuery] DMQuanHuyenParameters parameters)
        {
            var query = repository.Table.AsQueryable();
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                query = query.Where(x => x.TenQh.Contains(parameters.Search) || x.MaQh.Contains(parameters.Search));
            }
            if(!string.IsNullOrEmpty(parameters.MaTinh))
            {
                query = query.Where(x => x.Dmtinh.MaTinh == parameters.MaTinh);
            }
			
			return QueryParamsHelper.ResultDanhMucParams<DmquanHuyen>(repository, query, parameters, "MaQh");
        }


        [HttpGet("{id}")]
        public DmquanHuyen show(string id)
        {
            var model = repository.GetById(id);
            return model;
        }

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult Add(DmquanHuyen model)
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
        public ActionResult Edit(DmquanHuyen model)
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
