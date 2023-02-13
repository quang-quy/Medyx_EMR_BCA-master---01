using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.StoreProcedureModels;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Medyx_EMR_BCA.Controllers.API.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var db = new Medyx_EMR_BCAContextProcedures(new Medyx_EMR_BCAContext());

                var account = db.spACCOUNT_GetAsync(model.userName).Result;
                foreach (var item in account)
                {
                    if (item.Password == model.password)
                    {
                        UserSession user = new UserSession();
                        user.Pub_sNguoiSD = item.MaNV;
                        user.Pub_sAccount = model.userName;
                        user.Pub_sTenNguoiSD = item.hoten;
                        user.Pub_sQuay = item.ghichu;
                        user.Pub_bQadmin = item.Qadmin;
                        user.Pub_bSgia = item.Qsgia;
                        user.ListRoleSession = db.sp_GetAllActionByRoleIDAsync(user.Pub_sAccount).Result;
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "UserProfileSessionData", user);
                        return Ok();
                    }
                }
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Sai tài khoản hoặc mật khẩu");
        }
        [Route("me")]
        [HttpGet]
        [SessionFilter]
        public UserSession Me()
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            return user;
        }
        [Route("logout")]
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("UserProfileSessionData");
            return Ok();
        }
    }
}
