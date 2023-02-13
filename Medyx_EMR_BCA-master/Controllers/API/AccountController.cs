using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [SessionFilter]
    public class AccountController : ControllerBase
    {
        private IRepository<Account> repository = null;
        public AccountController()
        {
            this.repository = new GenericRepository<Account>();
        }
        //public AccountController(IRepository<Account> repository)
        //{
        //    this.repository = repository;
        //}
        [HttpGet]
        [SetActionContextItem(ActionType.List)]
        public IEnumerable<Account> Index()
        {
            var model = repository.GetAll();
            return model;
        }
        [HttpGet("{maNv}/{acc1}")]
        public Account show(string maNv, string acc1)
        {
            var model = repository.GetById(maNv, acc1);
            return model;
        }

        [HttpPost]
        [SetActionContextItem(ActionType.Create)]
        public ActionResult AddAccount(Account model)
        {
            if (ModelState.IsValid)
            {
                // repository.Insert(model);
                // repository.Save();
            }
            return Ok(new { message = "Add Account Success!" });
        }
        [HttpPost]
        [SetActionContextItem(ActionType.Update)]
        public ActionResult Edit(Account model)
        {
            if (ModelState.IsValid)
            {
                // repository.Update(model);
                // repository.Save();
            }
            return Ok(new { message = "Update Account Success!" });
        }
        [HttpDelete("{id}")]
        [SetActionContextItem(ActionType.Delete)]
        public ActionResult Delete(int id)
        {
            // repository.Delete(id);
            // repository.Save();
            return Ok(new { message = "Delete Account Success!" });
        }
    }
}
