using System;
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
    public class DMDichVu_ChungLoaiController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMDichVu_ChungLoaiController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo

        #region Load danh sách chủng loại thuốc paging

        [HttpGet]
        public JsonResult LoadData(string maChungLoai, string tenChungLoai, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            //var response = _DichVu_ChungLoaiService.DMDichVu_ChungLoaiGetListPaging(maChungLoai, tenChungLoai, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(maChungLoai))
                maChungLoai = "";
            if (string.IsNullOrEmpty(tenChungLoai))
                tenChungLoai = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            var response = db.DMDichVu_ChungLoaiGetListPaging(maChungLoai, tenChungLoai, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion

        #region View thực hiện update chủng loại thuốc

        [HttpPost]
        public ActionResult Modify(DMDichVu_ChungLoai DichVu_ChungLoai)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_ChungLoai/Index/Modify").Count() > 0;
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
                emp.TenBang = "DMDichVu_ChungLoai";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(DichVu_ChungLoai);
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_ChungLoai_UPDATE(DichVu_ChungLoai.MaChungLoai, DichVu_ChungLoai.TenChungLoai, MaMay, u.Pub_sNguoiSD, DichVu_ChungLoai.Huy);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa chủng loại thuốc!", status = 500 });

        }

        #endregion 

        #region View delete chủng loại thuốc

        [HttpPost]
        public ActionResult DeleteDichVu_ChungLoai(string maChungLoai)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_ChungLoai/Index/Delete").Count() > 0;
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
                emp.TenBang = "DMDichVu_ChungLoai";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete maChungLoai: " + maChungLoai;
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_ChungLoai_DELETED(maChungLoai, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 

        #region View thêm mới chủng loại thuốc
        [HttpPost]
        public ActionResult CreateDichVu_ChungLoai(string tenChungLoai)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_ChungLoai/Index/Create").Count() > 0;
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
                emp.TenBang = "DMDichVu_ChungLoai";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create tenChungLoai: " + tenChungLoai;
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_ChungLoai_CREATE(tenChungLoai, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới chủng loại thuốc!", status = 500 });
        }
        #endregion

        //#region Load danh mục chủng loại thuốc get all
        //public JsonResult DMDichVu_ChungLoaiGetAll()
        //{
        //    var response = _DichVu_ChungLoaiService.DMDichVu_ChungLoaiGetAll();
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
            var dataSource = db.ExportDMDichVu_ChungLoai(key, columns);
            string filename = "DMDichVu_ChungLoai " + DateTime.Now.ToString() + ".xlsx";
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
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_ChungLoai/Index/ImportDanhMuc").Count() > 0;
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
                    result.Tables[0].TableName = "DMDichVu_ChungLoai";
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
                    emp.TenBang = "DMDichVu_ChungLoai";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMDichVu_ChungLoai(result.Tables[0], insert);
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
                return Json(new { success = false, message = "Không có quyền thêm mới chủng loại thuốc!", status = 500 });
        }
        #endregion
    }
}