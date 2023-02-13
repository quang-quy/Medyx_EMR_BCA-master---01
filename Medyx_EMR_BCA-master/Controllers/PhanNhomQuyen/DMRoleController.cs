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

namespace Medyx_EMR_BCA.Controllers.PhanQuyen
{
    public class DMRoleController : BCAController
    {
        #region Khởi tạo
        // GET: Client/DMChucVu
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMRoleController(IMemoryCache cache)
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
        public ActionResult LoadData(string MaRole)
        {
            Pagination db = new Pagination();
            if (MaRole == null)
                MaRole = "";
            DMRole_C r = db.DMRole_CGet(MaRole);
            //var MenuRole = r.MenuRole;
            //var ActionRole = r.ActionRole;
            //var response = new
            //{
            //    ApplicationRolesId = r.ApplicationRolesId,
            //    TenRole = r.TenRole,
            //    MaMay = r.MaMay,
            //    Huy = r.Huy,
            //    NgaySD = r.NgaySD,
            //    NguoiSD = r.NguoiSD,
            //    MenuRoleC = MenuRole.Where(x => x.Chon == false),
            //    ActionRoleC = ActionRole.Where(x => x.Chon == false),
            //    MenuRoleD = MenuRole.Where(x => x.Chon == true),
            //    ActionRoleD = ActionRole.Where(x => x.Chon == true)
            //};
            return CreateJsonJsonResult(() =>
            {
                //return Json(response);
                return Json(r);
            });
        }
        #endregion
        #region View thêm mới nhóm quyền
        [HttpPost]
        [AllowAnonymous]
        //public IActionResult CreateRole(string ApplicationRolesId, string TenRole, bool Huy, List<MenuRole> MenuRole, List<ActionRole> ActionRole)
        public IActionResult CreateRole([FromBody] sendRole sendRole)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMRole/Index/Create").Count() > 0;
            if (Quyen)
            {
                string ApplicationRolesId = sendRole.ApplicationRolesId;
                string TenRole = sendRole.TenRole;
                bool Huy = sendRole.Huy;
                List<MenuRole> MenuRole = sendRole.MenuRole;
                List<ActionRole> ActionRole = sendRole.ActionRole;
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                DataTable dMenuRole =  Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(MenuRole));
                DataTable dActionRole = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(ActionRole));
                db.spDMRole_CREATE(TenRole, MaMay, u.Pub_sNguoiSD, dMenuRole, dActionRole);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới nhóm quyền!", status = 500 });
        }
        #endregion
        #region View Sửa nhóm quyền
        [HttpPost]
        [AllowAnonymous]
        //public IActionResult Modify(string ApplicationRolesId, string TenRole, bool Huy, List<MenuRole> MenuRole, List<ActionRole> ActionRole)
        public IActionResult Modify([FromBody]sendRole sendRole)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMRole/Index/Modify").Count() > 0;
            if (Quyen)
            {
                string ApplicationRolesId = sendRole.ApplicationRolesId;
                string TenRole = sendRole.TenRole;
                bool Huy = sendRole.Huy;
                List<MenuRole> MenuRole = sendRole.MenuRole;
                List<ActionRole> ActionRole = sendRole.ActionRole;
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                DataTable dMenuRole = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(MenuRole));
                DataTable dActionRole = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(ActionRole));
                db.spDMRole_UPDATE(ApplicationRolesId,TenRole, Huy, MaMay, u.Pub_sNguoiSD, dMenuRole, dActionRole);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa nhóm quyền!", status = 500 });
        }
        #endregion
        
    }
    public class DMRoleDSController : BCAController
    {
        #region Khởi tạo
        // GET: Client/DMChucVu
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMRoleDSController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region Load danh sách paging
        [HttpGet]
        public ActionResult LoadData(string ApplicationRoleId, string TenRole, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
        {
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(ApplicationRoleId))
                ApplicationRoleId = "";
            if (string.IsNullOrEmpty(TenRole))
                TenRole = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            var response = db.DMRoleGetListPaging(ApplicationRoleId, TenRole, maMay, ngaySD, nguoiSD, index, pageSize, add);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }
        #endregion
        [HttpPost]
        public ActionResult Delete(string ApplicationRolesId)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMRole/Index/Delete").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string MaMay = this.GetLocalIPAddress();
                db.spDMRole_DELETED(ApplicationRolesId, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa nhóm quyền!", status = 500 });
        }
    }
}
