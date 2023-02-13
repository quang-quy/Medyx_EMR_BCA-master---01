using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Dto;
using System.Linq.Expressions;
using System;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
    [Route("api/dm-nhan-vien")]
    [ApiController]
    //[SessionFilter]
    public class DMNhanVienController : ControllerBase
    {
        private IRepository<DmnhanVien> repository = null;
        public DMNhanVienController()
        {
            repository = new GenericRepository<DmnhanVien>();
        }
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        [SetCacheContextItem]
        public ActionResult Index([FromQuery] DMNhanVienParameters parameters)
        {
            var query = repository.Table.AsQueryable();
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                var search = parameters.Search.ToLower();
                query = query.Where(
                    x => x.HoTen.ToLower().Contains(search)
                    || x.MaNv.ToLower().Contains(search)
                    || x.Dmkhoa.TenKhoa.ToLower().Contains(search)
                    || x.Dmkhoa.MaKhoa.ToLower().Contains(search)
                );
            }
            if (!string.IsNullOrEmpty(parameters.MaKhoa))
            {
                query = query.Where(x => x.MaKhoa == parameters.MaKhoa);
            }
            if (!string.IsNullOrEmpty(parameters.TenKhoa))
            {
                query = query.Where(x => x.Dmkhoa.TenKhoa.ToLower().Contains(parameters.TenKhoa.ToLower()));
            }
            if (!parameters.HasAdmin)
            {
                query = query.Where(x => x.MaNv != "000000");
            }
            var querySelect = DmnhanVienDtoQuery();
            return Ok(QueryParamsHelper.ResultDanhMucDTOParams<DmnhanVien, DmnhanVienDto>(repository, query.Select(querySelect), parameters, querySelect, "MaNV"));
        }

        private Expression<Func<DmnhanVien, DmnhanVienDto>> DmnhanVienDtoQuery()
        {
            return DmnhanVien => new DmnhanVienDto()
            {
                HoTen = DmnhanVien.HoTen,
                MaNv = DmnhanVien.MaNv,
                Khoa = new DmkhoaDto()
                {
                    MaKhoa = DmnhanVien.Dmkhoa.MaKhoa,
                    TenKhoa = DmnhanVien.Dmkhoa.TenKhoa
                }
            };
        }

        [HttpGet("{id}")]
        public DmnhanVien show(string id)
        {
            var model = repository.GetById(id);
            return model;
        }

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult Add(DmnhanVien model)
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
        public ActionResult Edit(DmnhanVien model)
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
