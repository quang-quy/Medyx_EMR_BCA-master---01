using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.StoreProcedureModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Medyx_EMR_BCA.Controllers.API.DanhMuc
{
    [Route("api/[controller]")]
    [ApiController]
    [SessionFilter]
    public class MenuController : ControllerBase
    {
        private IRepository<Menu> repository = null;
        public MenuController()
        {
            this.repository = new GenericRepository<Menu>();
        }
        [HttpGet]
        [SetActionContextItem(ActionType.List)]
        public IEnumerable<Menu> Index()
        {
            var model = repository.Table.Where(x => x.MenuParent == null).Include(x => x.Children).ThenInclude(x => x.Children).ToList();
            //var model = repository.GetAll();
            //var model = repository.Table.Where(x => x.MenuParent == null).Select(x => new { x.MenuId, x.MenuParent, x.Children }).ToList();
            return model;
        }

        [HttpGet("by-user")]
        public IEnumerable<sp_GetAllMenuByUserIDResult> MenuUser()
        {
            var db = new Medyx_EMR_BCAContextProcedures(new Medyx_EMR_BCAContext());
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            var model = db.sp_GetAllMenuByUserIDAsync(user.Pub_sAccount).Result;
            model = FillRecursive(model, null);
            return model;
        }
        private List<sp_GetAllMenuByUserIDResult> FillRecursive(List<sp_GetAllMenuByUserIDResult> flatObjects, string parentId)
        {
            List<sp_GetAllMenuByUserIDResult> recursiveObjects = new List<sp_GetAllMenuByUserIDResult>();
            foreach (var item in flatObjects.Where(x => x.MenuParent == parentId))
            {
                recursiveObjects.Add(new sp_GetAllMenuByUserIDResult
                {
                    MenuID = item.MenuID,
                    MenuName = item.MenuName,
                    ControllerName = item.ControllerName,
                    MenuParent = item.MenuParent,
                    Level = item.Level,
                    Children = FillRecursive(flatObjects, item.MenuID)
                });
            }
            return recursiveObjects;
        }

        [HttpGet("{id}")]
        public Menu show(string id)
        {
            var model = repository.GetById(id);
            return model;
        }

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult Add(Menu model)
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
        public ActionResult Edit(Menu model)
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
