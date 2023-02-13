using System;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Medyx_EMR_BCA.Controllers.API
{
    [Route("api/thong-tin-benh-nhan")]
    [ApiController]
    [SessionFilter]
    public class ThongTinBNController : ControllerBase
    {
        private IRepository<ThongTinBn> repository = null;
        public ThongTinBNController()
        {
            this.repository = new GenericRepository<ThongTinBn>();
        }

        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<ThongTinBn> Index([FromQuery] ThongTinBNParameters parameters)
        {
            var query = repository.Table.AsQueryable();
            
            if (parameters.Idba.HasValue)
            {
                query.Where(x => x.Idba == parameters.Idba);
            }

            return Res<ThongTinBn>.Get(query, parameters.PageNumber, parameters.PageSize);
        }
        [HttpGet("{maNv}/{acc1}")]
        public ThongTinBn show(string maNv, string acc1)
        {
            var model = repository.GetById(maNv, acc1);
            return model;
        }

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult AddAccount(ThongTinBn model)
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
        public ActionResult Edit(ThongTinBn model)
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
