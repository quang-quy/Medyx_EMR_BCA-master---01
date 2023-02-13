﻿using System;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.Models.DanhMuc;
using Excel;
using MongoDB.Driver;
using Medyx_EMR_BCA.Models;
using Newtonsoft.Json;
namespace HTC.WEB.NIOEH.Areas.Client.DanhMuc
{
    public class DMThuoc_NhaSXController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMThuoc_NhaSXController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo

        #region Load danh sách nhà sản xuất thuốc paging

        [HttpGet]
        public JsonResult LoadData(string maNSX, string tenNSX, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add, string GhiChu)
        {
            //var response = _Thuoc_NhaSXService.DMThuoc_NhaSXGetListPaging(maNSX, tenNSX, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(maNSX))
                maNSX = "";
            if (string.IsNullOrEmpty(tenNSX))
                tenNSX = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            if (string.IsNullOrEmpty(GhiChu))
                GhiChu = "";
            var response = db.DMThuoc_NhaSXGetListPaging(maNSX, tenNSX, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add, GhiChu);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion

        #region View thực hiện update nhà sản xuất thuốc

        [HttpPost]
        public ActionResult Modify(DMThuoc_NhaSX Thuoc_NhaSX)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMThuoc_NhaSX/Index/Modify").Count() > 0;
            if (Quyen)
            {
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMThuoc_NhaSX";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(Thuoc_NhaSX);
                collection.InsertOne(emp);
                #endregion
                db.spDMThuoc_NhaSX_UPDATE(Thuoc_NhaSX.MaNSX, Thuoc_NhaSX.TenNSX, MaMay, u.Pub_sNguoiSD, Thuoc_NhaSX.Huy,Thuoc_NhaSX.GhiChu);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa nhà sản xuất thuốc!", status = 500 });

        }

        #endregion 

        #region View delete nhà sản xuất thuốc

        [HttpPost]
        public ActionResult DeleteThuoc_NhaSX(string maNSX)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMThuoc_NhaSX/Index/Delete").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string MaMay = this.GetLocalIPAddress();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMThuoc_NhaSX";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete maNSX: " + maNSX;
                collection.InsertOne(emp);
                #endregion
                db.spDMThuoc_NhaSX_DELETED(maNSX, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa nhà sản xuất thuốc!", status = 500 });
        }

        #endregion 

        #region View thêm mới nhà sản xuất thuốc
        [HttpPost]
        public ActionResult CreateThuoc_NhaSX(string tenNSX, string GhiChu)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMThuoc_NhaSX/Index/Create").Count() > 0;
            if (Quyen)
            {
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMThuoc_NhaSX";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create tenNSX: " + tenNSX + ", GhiChu: " + GhiChu;
                collection.InsertOne(emp);
                #endregion
                db.spDMThuoc_NhaSX_CREATE(tenNSX, MaMay, u.Pub_sNguoiSD, GhiChu);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới nhà sản xuất thuốc!", status = 500 });
        }
        #endregion

        //#region Load danh mục nhà sản xuất thuốc get all
        //public JsonResult DMThuoc_NhaSXGetAll()
        //{
        //    var response = _Thuoc_NhaSXService.DMThuoc_NhaSXGetAll();
        //    return CreateJsonJsonResult(() =>
        //    {
        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    });
        //}
        //#endregion

        #region Export dữ liệu theo các cột được chọn
        [HttpGet]
        public ActionResult ExportExcel(string obj)
        {
            dynamic data = JObject.Parse(obj);
            string key = data.key;
            string columns = data.columns;
            //HttpContext.Server.ScriptTimeout = 90;
            //var dataSource = _chucVuService.ExportDMChucVu(key, columns);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            var dataSource = db.ExportDMThuoc_NhaSX(key, columns);
            string filename = "DMThuoc_NhaSX " + DateTime.Now.ToString() + ".xlsx";
            //MVC4 mVC4 = new MVC4();
            //mVC4.
            ExportToExcel(filename, dataSource);
            return RedirectToAction("/Index");
        }
        #endregion

        #region Import data
        [HttpPost]
        public ActionResult ImportDanhMuc()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMThuoc_NhaSX/Index/ImportDanhMuc").Count() > 0;
            if (Quyen)
            {
                var file = Request.Form.Files[0];
                //HttpPostedFileBase fileName = (HttpPostedFileBase)Request.Form.Files[0];
                string ins = Request.Form["insert"];
                bool insert = Convert.ToBoolean(ins);
                //if (ModelState.IsValid)
                //{
                if (file != null && file.Length > 0)
                {
                    //ExcelDataReader works on binary excel file
                    Stream stream = file.OpenReadStream();
                    //We need to written the Interface.
                    IExcelDataReader reader = null;
                    if (file.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        return RedirectToAction("Index");
                    }
                    //treats the first row of excel file as Coluymn Names
                    reader.IsFirstRowAsColumnNames = true;
                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();
                    reader.Close();
                    result.Tables[0].TableName = "DMThuoc_NhaSX";
                    for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    {
                        if (i == 5)
                        {
                            DataColumn newcolumn = new DataColumn("temporary", typeof(DateTime));
                            result.Tables[0].Columns.Add(newcolumn);
                            foreach (DataRow row in result.Tables[0].Rows)
                            {
                                try
                                {
                                    row["temporary"] = Convert.ChangeType(row[i], typeof(DateTime));
                                }
                                catch
                                {
                                }
                            }
                            result.Tables[0].Columns.Remove("NgaySD");
                            newcolumn.ColumnName = "NgaySD";
                        }
                        else
                            result.Tables[0].Columns[i].DataType = typeof(String);
                    }
                    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    #region ghi log
                    string MaMay = this.GetLocalIPAddress();
                    string constr = u.MongoDBConnectionString;
                    var client = new MongoClient(constr);
                    IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                    IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                    TraceLogMongo emp = new TraceLogMongo();
                    emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                    emp.TenBang = "DMThuoc_NhaSX";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMThuoc_NhaSX(result.Tables[0], insert);
                    //_chucVuService.ImportDMChucVu(result.Tables[0], insert);
                    return RedirectToAction("Index");
                }
                //}
                //else
                //{
                //    ModelState.AddModelError("File", "Please upload your file");
                //}
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới nhà sản xuất thuốc!", status = 500 });
        }
        #endregion
    }
}