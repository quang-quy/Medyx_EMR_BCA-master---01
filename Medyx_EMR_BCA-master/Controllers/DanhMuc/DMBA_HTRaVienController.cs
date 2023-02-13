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
    public class DMBA_HTRaVienController : BCAController
    {
        #region Khởi tạo
        // GET: Client/DMBA_HTRaVien
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMBA_HTRaVienController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;

        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region Load danh sách chức vụ paging
        [HttpGet]
        public ActionResult LoadData(string MaHTRaVien, string TenHTRaVien, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string ghichu, string mabyte)
        {
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(MaHTRaVien))
                MaHTRaVien = "";
            if (string.IsNullOrEmpty(TenHTRaVien))
                TenHTRaVien = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            if (string.IsNullOrEmpty(ghichu))
                ghichu = "";
            if (string.IsNullOrEmpty(mabyte))
                mabyte = "";
            var response = db.DMBA_HTRaVienGetListPaging(MaHTRaVien, TenHTRaVien, maMay, ngaySD, nguoiSD, index, pageSize, add, ghichu, mabyte);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }
        #endregion

        #region View thực hiện update chức vụ

        [HttpPost]
        public ActionResult Modify(HTRaVien HTRaVien)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMBA_HTRaVien/Index/Modify").Count() > 0;
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
                emp.TenBang = "DMBA_HTRaVien";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(HTRaVien);
                collection.InsertOne(emp);
                #endregion
                db.spDMBA_HTRaVien_UPDATE(HTRaVien.MaHTRaVien, HTRaVien.TenHTRaVien, MaMay, u.Pub_sNguoiSD, HTRaVien.Huy, HTRaVien.GhiChu, HTRaVien.mabyte);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa chức vụ!", status = 500 });

        }

        #endregion 

        #region View delete chức vụ

        [HttpPost]
        public ActionResult DeleteHTRaVien(string MaHTRaVien)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMBA_HTRaVien/Index/Delete").Count() > 0;
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
                emp.TenBang = "DMBA_HTRaVien";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete MaHTRaVien: " + MaHTRaVien;
                collection.InsertOne(emp);
                #endregion
                db.spDMBA_HTRaVien_DELETED(MaHTRaVien, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 

        #region View thêm mới hình thức
        [HttpPost]
        public ActionResult CreateHTRaVien(string TenHTRaVien, string ghichu, string mabyte)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMBA_HTRaVien/Index/Create").Count() > 0;
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
                emp.TenBang = "DMBA_HTRaVien";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create TenHTRaVien: " + TenHTRaVien;
                collection.InsertOne(emp);
                #endregion
                db.spDMBA_HTRaVien_CREATE(TenHTRaVien, MaMay, u.Pub_sNguoiSD, ghichu, mabyte);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới chức vụ!", status = 500 });
        }
        #endregion

        //#region Load danh mục chúc vụ get all
        //public JsonResult DMBA_HTRaVienGetAll()
        //{
        //    var response = _HTRaVienService.DMBA_HTRaVienGetAll();
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
            //var dataSource = _HTRaVienService.ExportDMBA_HTRaVien(key, columns);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            var dataSource = db.ExportDMBA_HTRaVien(key, columns);
            string filename = "DMBA_HTRaVien " + DateTime.Now.ToString() + ".xlsx";
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
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMBA_HTRaVien/Index/ImportDanhMuc").Count() > 0;
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
                    result.Tables[0].TableName = "DMBA_HTRaVien";
                    //for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    //{
                    //    if (i == 5)
                    //    {
                    //        DataColumn newcolumn = new DataColumn("temporary", typeof(DateTime));
                    //        result.Tables[0].Columns.Add(newcolumn);
                    //        foreach (DataRow row in result.Tables[0].Rows)
                    //        {
                    //            try
                    //            {
                    //                row["temporary"] = Convert.ChangeType(row[i], typeof(DateTime));
                    //            }
                    //            catch
                    //            {
                    //            }
                    //        }
                    //        result.Tables[0].Columns.Remove("NgaySD");
                    //        newcolumn.ColumnName = "NgaySD";
                    //    }
                    //    else
                    //        result.Tables[0].Columns[i].DataType = typeof(String);
                    //}
                    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    #region ghi log
                    string MaMay = this.GetLocalIPAddress();
                    string constr = u.MongoDBConnectionString;
                    var client = new MongoClient(constr);
                    IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                    IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                    TraceLogMongo emp = new TraceLogMongo();
                    emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                    emp.TenBang = "DMBA_HTRaVien";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMBA_HTRaVien(result.Tables[0], insert);
                    //_HTRaVienService.ImportDMBA_HTRaVien(result.Tables[0], insert);
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
                return Json(new { success = false, message = "Không có quyền thêm mới chức vụ!", status = 500 });
        }
        #endregion
    }
}