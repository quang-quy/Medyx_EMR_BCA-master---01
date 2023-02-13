using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Linq;
using System;
using System.Configuration;
using MongoDB.Driver;
using Medyx_EMR_BCA.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics;

namespace Medyx_EMR_BCA.Controllers.Client
{
    public class HomeController : BCAController
    {
        private IMemoryCache cache;
        private readonly IConfiguration _config;
        //public readonly ISession session;
        public HomeController(IMemoryCache cache, IConfiguration config)
        {
            this.cache = cache;
            _config = config;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            //var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            //if (u != null)
            //{
            //    if(u.Pub_sNguoiSD.Length == 0)
            //        return RedirectToAction("Login", "Login");
            //    else
            //    {
            //        HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            //        List<MenuUserVm> Menu = cache.Get<List<MenuUserVm>>("Menu" + u.Pub_sNguoiSD);
            //        //if (!cache.TryGetValue<IEnumerable<MenuUserVm>>("Menu" + u.Pub_sNguoiSD, out Menu))
            //        if (Menu == null)
            //        {
            //            Menu = db.GetAllMenuByUserId(u.Pub_sAccount).ToList();
            //            //set cache 30 ngay
            //            cache.Set<List<MenuUserVm>>("Menu" + u.Pub_sNguoiSD, Menu, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            //        }
            //        //else Menu = cache.Get<object>("Menu" + u.Pub_sNguoiSD);
            //        ViewData["Menu"] = Menu;
            //        ViewData["UserProfileSessionData"] = u;
            //        return View();
            //    }
            //}
            //else return RedirectToAction("Login", "Login");
            return Khoitao(cache);
        }
        public IActionResult Header()
        {
            return PartialView();
        }
        public ActionResult PagingTable()
        {
            return PartialView();
        }
        public ActionResult TableHeader()
        {
            return PartialView();
        }
        //[System.Web.Mvc.ChildActionOnly]
        //public IActionResult MenuLeft()
        //{
        //    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
        //    var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
        //    var allmn = db.GetAllMenuByUserId(u.Pub_sAccount);
        //    return PartialView(allmn);
        //    //return PartialView();
        //}
        //public PartialViewResult MenuLeft()
        //{
        //    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
        //    var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
        //    var allmn = db.GetAllMenuByUserId(u.Pub_sAccount);
        //    //return PartialView(allmn);
        //    return PartialView(allmn);
        //}
        //public async Task<IViewComponentResult> MenuLeft()
        //{
        //    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
        //    var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
        //    var model = db.GetAllMenuByUserId(u.Pub_sAccount);
        //    //return new PartialViewResult
        //    //{
        //    //    ViewData = (Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)allmn,
        //    //};
        //    return (IViewComponentResult)View(model);
        //}
        //[System.Web.Mvc.ChildActionOnly]
        public ActionResult ImportView()
        {
            return PartialView();
            //return PartialView();
        }
        //public JsonResult GetMenu()
        //{
        //    return CreateJsonJsonResult(() =>
        //    {
        //        return Json(this.GetAllMenu(), JsonRequestBehavior.AllowGet);
        //    });
        //}
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", feature?.Error);
        }
        public ActionResult LogOff()
        {
            //IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            //authenticationManager.SignOut();
            
            //clear cache
            //List<string> keys = new List<string>();
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(cache) as ICollection;
            var items = new List<string>();
            if (collection != null)
            {
                var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
                if (u != null)
                {
                    #region ghi log dang xuat
                    //string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
                    //string constr = _config.GetValue<string>("Medyx_BCADatabase:ConnectionString");
                    string constr = u.MongoDBConnectionString;
                    var client = new MongoClient(constr);
                    //IMongoDatabase db = client.GetDatabase("Medyx_BCA");
                    //IMongoDatabase dbm = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
                    //IMongoDatabase dbm = client.GetDatabase(_config.GetValue<string>("Medyx_BCADatabase:DatabaseName"));
                    IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                    IMongoCollection<TraceLogMongo> collectiondx = dbm.GetCollection<TraceLogMongo>("TraceLog");
                    string MaMay = this.GetLocalIPAddress();
                    TraceLogMongo emp = new TraceLogMongo();
                    emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                    emp.TenBang = "Đăng xuất";
                    emp.KieuTacDong = "LogOff";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = "Account: " + u.Pub_sAccount + " đăng xuất";
                    collectiondx.InsertOne(emp);
                    #endregion
                    foreach (var item in collection)
                    {
                        var methodInfo = item.GetType().GetProperty("Key");
                        var val = methodInfo.GetValue(item);
                        if (val.ToString().EndsWith(u.Pub_sNguoiSD))
                            items.Add(val.ToString());
                    }
                }
            }
            // retrieve application Cache enumerator
            //IDictionaryEnumerator enumerator = cache.GetEnumerator();

            //// copy all keys that currently exist in Cache
            //while (enumerator.MoveNext())
            //{

            //    keys.Add(enumerator.Key.ToString());
            //}

            // delete every key from cache
            //for (int i = 0; i < keys.Count; i++)
            //{
            //    cache.Remove(keys[i]);
            //}
            for (int i = 0; i < items.Count; i++)
            {
                cache.Remove(items[i]);
            }
            //clear session
            HttpContext.Session.Clear();
            //return Redirect("~/Login/Login");
            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }
        //public IEnumerable<MenuUserVm> GetAllMenuByUserId(string UserName)
        //{
        //    object[] paras =
        //    {
        //        new SqlParameter("@UserName",UserName)
        //    };
        //    return this.DbContext.Database.SqlQuery<MenuUserVm>("sp_GetAllMenuByUserID @UserName ", paras).ToList();
        //}
        public ActionResult ResetPassWord()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            if (u != null)
            {
                if (u.Pub_sNguoiSD.Length == 0)
                    return RedirectToAction("Login", "Login");
                else
                {
                    //HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    //List<MenuUserVm> Menu = cache.Get<List<MenuUserVm>>("Menu" + u.Pub_sNguoiSD);
                    ////if (!cache.TryGetValue<IEnumerable<MenuUserVm>>("Menu" + u.Pub_sNguoiSD, out Menu))
                    //if (Menu == null)
                    //{
                    //    Menu = db.GetAllMenuByUserId(u.Pub_sAccount).ToList();
                    //    //set cache 30 ngay
                    //    cache.Set<List<MenuUserVm>>("Menu" + u.Pub_sNguoiSD, Menu, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
                    //}
                    ////else Menu = cache.Get<object>("Menu" + u.Pub_sNguoiSD);
                    //ViewData["Menu"] = Menu;
                    //ViewData["UserProfileSessionData"] = u;
                    //return View();
                    ResetPassword ResetPassword = new ResetPassword();
                    ResetPassword.userName = u.Pub_sAccount;
                    ViewData["ResetPassword"] = ResetPassword;
                }
            }
            return Khoitao(cache);
            ////IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            ////authenticationManager.SignOut();

            ////clear cache
            //List<string> keys = new List<string>();
            //var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            //var collection = field.GetValue(cache) as ICollection;
            //var items = new List<string>();
            //if (collection != null)
            //{
            //    var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            //    if (u != null)
            //    {
            //        foreach (var item in collection)
            //        {
            //            var methodInfo = item.GetType().GetProperty("Key");
            //            var val = methodInfo.GetValue(item);
            //            if (val.ToString().EndsWith(u.Pub_sNguoiSD))
            //                items.Add(val.ToString());
            //        }
            //    }
            //}
            //// retrieve application Cache enumerator
            ////IDictionaryEnumerator enumerator = cache.GetEnumerator();

            ////// copy all keys that currently exist in Cache
            ////while (enumerator.MoveNext())
            ////{

            ////    keys.Add(enumerator.Key.ToString());
            ////}

            //// delete every key from cache
            //for (int i = 0; i < keys.Count; i++)
            //{
            //    cache.Remove(keys[i]);
            //}
            ////clear session
            //HttpContext.Session.Clear();
            ////return Redirect("~/Login/Login");
            //return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        public ActionResult ResetPassWord(ResetPassword ResetPassWord)
        {
            if (ModelState.IsValid)
            {
                if (ResetPassWord.PasswordMoi != ResetPassWord.PasswordNhapLai)
                {
                    ViewBag.Message = "Mật khẩu mới không trùng mật khẩu nhập lại.";
                    return Khoitao(cache);
                }
                else 
                {
                    System.Data.Linq.ISingleResult<spACCOUNT_Get> _Account = null;
                    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    _Account = db.spACCOUNT_Get(ResetPassWord.userName);
                    foreach (var item in _Account)
                    {
                        if (item.Password == ResetPassWord.PasswordCu)
                        {
                            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
                            string MaMay = this.GetLocalIPAddress();
                            #region ghi log doi mat khau
                            string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
                            var client = new MongoClient(constr);
                            //IMongoDatabase db = client.GetDatabase("Medyx_BCA");
                            IMongoDatabase dbm = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
                            IMongoCollection<TraceLogMongo> collectiondx = dbm.GetCollection<TraceLogMongo>("TraceLog");
                            TraceLogMongo emp = new TraceLogMongo();
                            emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                            emp.TenBang = "Account";
                            emp.KieuTacDong = "Update";
                            emp.NguoiSD = u.Pub_sNguoiSD;
                            emp.MaMay = MaMay;
                            emp.NoiDungSD = "Account: " + u.Pub_sAccount + " đổi mật khẩu từ: "+ ResetPassWord.PasswordCu+" thành: "+ ResetPassWord.PasswordMoi;
                            collectiondx.InsertOne(emp);
                            #endregion
                            db.spACCOUNT_ResetPassWord(u.Pub_sNguoiSD, ResetPassWord.userName, ResetPassWord.PasswordCu, ResetPassWord.PasswordMoi, MaMay, u.Pub_sNguoiSD);
                            //clear cache
                            List<string> keys = new List<string>();
                            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
                            var collection = field.GetValue(cache) as ICollection;
                            var items = new List<string>();
                            if (collection != null)
                            {
                                if (u != null)
                                {
                                    foreach (var item1 in collection)
                                    {
                                        var methodInfo = item1.GetType().GetProperty("Key");
                                        var val = methodInfo.GetValue(item1);
                                        if (val.ToString().EndsWith(u.Pub_sNguoiSD))
                                            items.Add(val.ToString());
                                    }
                                }
                            }
                            // delete every key from cache
                            for (int i = 0; i < keys.Count; i++)
                            {
                                cache.Remove(keys[i]);
                            }
                            //clear session
                            HttpContext.Session.Clear();
                            return RedirectToAction("Login", "Login");
                        }
                    }
                    return Khoitao(cache);
                }
            }
            else
            {
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return Khoitao(cache);
            }
        }
    }
}
