using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.Models;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Medyx_EMR_BCA.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        protected string GetLocalIPAddress()
        {
            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        return ip.ToString();
            //    }
            //}
            //throw new Exception("Local IP Address Not Found!");
            //string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //if (string.IsNullOrEmpty(ip))
            //{
            //    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //}
            //return ip;
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
        public IActionResult Login()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            if (u != null)
            {
                if (u.Pub_sNguoiSD.Length == 0)
                    return View();
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Client" });
                }
            }
            else
                return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                System.Data.Linq.ISingleResult<spACCOUNT_Get> _Account = null;
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                _Account = db.spACCOUNT_Get(model.userName);
                foreach (var item in _Account)
                {
                    if (item.Password == model.Password)
                    {
                        UserProfileSessionData u = new UserProfileSessionData();
                        u.Pub_sNguoiSD = item.MaNV;
                        u.Pub_sAccount = model.userName;
                        u.Pub_sTenNguoiSD = item.HoTen;
                        u.Pub_sQuay = item.GhiChu;
                        u.Pub_bQadmin = item.Qadmin;
                        u.Pub_bSgia = item.Qsgia;
                        u.ListRoleSession = db.GetActionByRoleID(u.Pub_sAccount);
                        u.MongoDBConnectionString = _config.GetValue<string>("Medyx_BCADatabase:ConnectionString");
                        u.MongoDBDataBaseName = _config.GetValue<string>("Medyx_BCADatabase:DatabaseName");
                        List<Dmkhoa> DMKhoaAcc = db.GetDMNVKhoaByAcc(u.Pub_sNguoiSD).ToList();
                        u.DMKhoaAcc = DMKhoaAcc;
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "UserProfileSessionData", u);
                        #region ghi log dang nhap
                        //string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
                        //string constr = _config.GetValue<string>("Medyx_BCADatabase:ConnectionString");
                        string constr = u.MongoDBConnectionString;
                        var client = new MongoClient(constr);
                        //IMongoDatabase db = client.GetDatabase("Medyx_BCA");
                        //IMongoDatabase dbm = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
                        //IMongoDatabase dbm = client.GetDatabase(_config.GetValue<string>("Medyx_BCADatabase:DatabaseName"));
                        IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                        IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                        string MaMay = this.GetLocalIPAddress();
                        TraceLogMongo emp = new TraceLogMongo();
                        emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                        emp.TenBang = "Đăng nhập";
                        emp.KieuTacDong = "Login";
                        emp.NguoiSD = u.Pub_sNguoiSD;
                        emp.MaMay = MaMay;
                        emp.NoiDungSD = "Account: " + u.Pub_sAccount + " đăng nhập";
                        collection.InsertOne(emp);
                        #endregion
                        return RedirectToAction("Index", "Home", new { area = "Client" });
                    }
                }
            }
            else
            {
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
            return View(model);
        }
    }
}
