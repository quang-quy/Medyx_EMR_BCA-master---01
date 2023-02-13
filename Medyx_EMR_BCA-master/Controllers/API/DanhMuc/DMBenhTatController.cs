using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
    [Route("api/dm-benh-tat")]
    [ApiController]
    //[SessionFilter]
    public class DMBenhTatController : ControllerBase
    {
        private IRepository<DmbenhTat> repository = null;
        public DMBenhTatController()
        {
            this.repository = new GenericRepository<DmbenhTat>();
        }
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
		[SetCacheContextItem]
        public Response<DmbenhTat> Index([FromQuery] RequestParameters parameters)
        {
            var query = repository.Table.AsQueryable();

            if (!string.IsNullOrEmpty(parameters.Search))
            {
                query = query.Where(x => x.TenBenh.Contains(parameters.Search) || x.MaBenh.Contains(parameters.Search));
            }

            return QueryParamsHelper.ResultDanhMucParams<DmbenhTat>(repository, query, parameters, "MaBenh");
        }


        [HttpGet("{id}")]
        public DmbenhTat show(string id)
        {
            var model = repository.GetById(id);
            return model;
        }

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult Add(DmbenhTat model)
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
        public ActionResult Edit(DmbenhTat model)
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
