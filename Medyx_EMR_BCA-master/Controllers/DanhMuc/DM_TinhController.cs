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
    public class DM_TinhController : BCAController
    {
        #region Khởi tạo
        // GET: Client/DMBA_DM_Tinh
        private IMemoryCache cache;
        //public readonly ISession session;
        public DM_TinhController(IMemoryCache cache)
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
        public ActionResult LoadData(string MaTinh, string MaQU, string MaVungLT, string TenTinh,string MaBHYT,string MaMay, string Huy, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
        {
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(MaTinh))
                MaTinh = "";
            if (string.IsNullOrEmpty(MaQU))
                MaQU = "";
            if (string.IsNullOrEmpty(MaVungLT))
                MaVungLT = "";
            if (string.IsNullOrEmpty(TenTinh))
                TenTinh = "";
            if (string.IsNullOrEmpty(MaBHYT))
                MaBHYT = "";
            if (string.IsNullOrEmpty(MaMay))
                MaMay = "";
            if (string.IsNullOrEmpty(Huy))
                Huy = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            if (string.IsNullOrEmpty(Matat))
                Matat = "";
            var response = db.DM_TinhGetListPaging(MaTinh, MaQU,MaMay, MaVungLT,TenTinh,MaBHYT,Huy, ngaySD, nguoiSD, index, pageSize, add,  Matat);
            
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }
        #endregion

        #region View thực hiện update Tỉnh

        [HttpPost]
        public ActionResult Modify(DM_Tinh DM_Tinh)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DM_Tinh/Index/Modify").Count() > 0;
            if (Quyen)
            {
                string MaVungLT = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMTinh";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaVungLT = MaVungLT;
                emp.NoiDungSD = JsonConvert.SerializeObject(DM_Tinh);
                collection.InsertOne(emp);
                #endregion
                string MaMay = this.GetLocalIPAddress();
                db.spDM_Tinh_UPDATE(DM_Tinh.MaTinh, DM_Tinh.MaQU, DM_Tinh.MaVungLT, DM_Tinh.TenTinh, "", MaMay, u.Pub_sNguoiSD, DM_Tinh.Huy);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa chức vụ!", status = 500 });

        }

        #endregion 

        #region View delete Tỉnh

        [HttpPost]
        public ActionResult DeleteDM_Tinh(string MaTinh, string MaMay)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DM_Tinh/Index/Delete").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string MaVungLT = this.GetLocalIPAddress();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMBA_DM_Tinh";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaVungLT = MaVungLT;
                emp.NoiDungSD = "Delete MaTinh: " + MaTinh;
                collection.InsertOne(emp);
                #endregion
                db.spDM_Tinh_DELETED(MaTinh, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 

        #region View thêm mới hình thức
        [HttpPost]
        public ActionResult CreateDM_Tinh(string MaTinh,string MaQU, string MaVungLT, string TenTinh,string MaBHYT,string MaMay,string Huy, string NgaySD,string nguoiSD,string Matat,int PageIndex,int PageSize, int add)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DM_Tinh/Index/Create").Count() > 0;
            if (Quyen)
            {
                 MaMay = this.GetLocalIPAddress();
                nguoiSD= u.Pub_sNguoiSD;
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMBA_DM_Tinh";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaVungLT = MaVungLT;
                emp.NoiDungSD = "Create MaQU: " + MaQU;
                collection.InsertOne(emp);
                #endregion
                db.spDM_Tinh_CREATE(MaQU, MaVungLT, TenTinh, MaBHYT, MaMay, nguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm tỉnh mới", status = 500 });
        }
        #endregion

        //#region Load danh mục chúc vụ get all
        //public JsonResult DMBA_DM_TinhGetAll()
        //{
        //    var response = _DM_TinhService.DMBA_DM_TinhGetAll();
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
            //var dataSource = _DM_TinhService.ExportDMBA_DM_Tinh(key, columns);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();

            var dataSource = db.ExportDM_Tinh(key, columns);
            string filename = "DMBA_DM_Tinh " + DateTime.Now.ToString() + ".xlsx";
            //MVC4 mVC4 = new MVC4();
            //mVC4.
            ExportToExcel(filename, (DataTable)dataSource);
            return RedirectToAction("/Index");
        }
        #endregion

        #region Import data
        [HttpPost]
        public ActionResult ImportDanhMuc()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DM_Tinh/Index/ImportDanhMuc").Count() > 0;
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
                    result.Tables[0].TableName = "DMBA_DM_Tinh";
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
                    string MaVungLT = this.GetLocalIPAddress();
                    string constr = u.MongoDBConnectionString;
                    var client = new MongoClient(constr);
                    IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                    IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                    TraceLogMongo emp = new TraceLogMongo();
                    emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                    emp.TenBang = "DMBA_DM_Tinh";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaVungLT = MaVungLT;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                  
                    db.ImportDM_Tinh(result.Tables[0], insert);
                    
                    //_DM_TinhService.ImportDMBA_DM_Tinh(result.Tables[0], insert);
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