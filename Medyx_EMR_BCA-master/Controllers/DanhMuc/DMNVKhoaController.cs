using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Medyx_EMR_BCA.Models.DanhMuc;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Medyx_EMR_BCA.Controllers.DanhMuc
{
    public class DMNVKhoaController : BCAController
    {
        #region Khởi tạo
        // GET: Client/DMChucVu
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMNVKhoaController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            //string marole = Request.Path.Value.Split('/').LastOrDefault();
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region Load danh sách paging
        [HttpGet]
        public JsonResult LoadData(string MaNV)
        {
            //Pagination db = new Pagination();
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (MaNV == null)
                MaNV = "";
            List<DMNVKhoa> r = db.spDMNVKhoa_GetByMaNV(MaNV).ToList();
            return CreateJsonJsonResult(() =>
            {
                //return Json(response);
                return Json(r);
            });
        }
        #endregion
        #region View Sửa nhóm quyền
        [HttpPost]
        [AllowAnonymous]
        //public IActionResult Modify(string ApplicationRolesId, string TenRole, bool Huy, List<MenuRole> MenuRole, List<ActionRole> ActionRole)
        public IActionResult Modify([FromBody] sendNVKhoa sendRole)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMNV/DMNV/Modify").Count() > 0;
            if (Quyen)
            {
                //string ApplicationRolesId = sendRole.ApplicationRolesId;
                //string TenRole = sendRole.TenRole;
                //bool Huy = sendRole.Huy;
                List<DMNVKhoa> MenuRole = sendRole.MenuRole;
                string manv = sendRole.MaNV;
                //List<ActionRole> ActionRole = sendRole.ActionRole;
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                DataTable dMenuRole = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(MenuRole));
                //DataTable dActionRole = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(ActionRole));
                db.spDMNVKhoa_UPDATE(manv, MaMay, u.Pub_sNguoiSD, dMenuRole);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa nhóm quyền!", status = 500 });
        }
        #endregion
    }
}
