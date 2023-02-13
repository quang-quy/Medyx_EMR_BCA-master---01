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
    public class DMDichVu_CSController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMDichVu_CSController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo

        #region Load danh sách chủng loại dịch vụ paging

        [HttpGet]
        public JsonResult LoadData(string maCS, string tenCS,String TenDV,String ChisocaoNu,String ChisocaoNam,String ChisothapNu,String ChisothapNam,String DonViDo, String MaXN,String GhiChu, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            //var response = _DichVu_CSService.DMDichVu_CSGetListPaging(maDV, tenDV, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(maCS))
                maCS = "";
            if (string.IsNullOrEmpty(tenCS))
                tenCS = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            if (string.IsNullOrEmpty(TenDV))
                TenDV = "";
            if (string.IsNullOrEmpty(MaXN))
                MaXN = "";
            if (string.IsNullOrEmpty(ChisocaoNu))
                ChisocaoNu = "";
            if (string.IsNullOrEmpty(ChisocaoNam))
                ChisocaoNam = "";
            if (string.IsNullOrEmpty(ChisothapNu))
                ChisothapNu = "";
            if (string.IsNullOrEmpty(ChisothapNam))
                ChisothapNam = "";
            if (string.IsNullOrEmpty(DonViDo))
                DonViDo = "";
            if (string.IsNullOrEmpty(GhiChu))
                GhiChu = "";
            var response = db.DMDichVu_CSGetListPaging(maCS, tenCS, TenDV, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, MaXN, GhiChu, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion

        #region View thực hiện update chủng loại dịch vụ

        [HttpPost]
        public ActionResult Modify(DMDichVu_CS DMDichVu_CS)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_CS/Index/Modify").Count() > 0;
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
                emp.TenBang = "DMDichVu_CS";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(DMDichVu_CS);
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_CS_UPDATE(DMDichVu_CS.MaCS, DMDichVu_CS.TenCS, DMDichVu_CS.MaDV, DMDichVu_CS.ChisocaoNu, DMDichVu_CS.ChisocaoNam, DMDichVu_CS.ChisothapNu, DMDichVu_CS.ChisothapNam, DMDichVu_CS.DonViDo, DMDichVu_CS.MaXN, DMDichVu_CS.GhiChu, MaMay, u.Pub_sNguoiSD, DMDichVu_CS.Huy);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa chủng loại dịch vụ!", status = 500 });

        }

        #endregion 

        #region View delete chủng loại dịch vụ

        [HttpPost]
        public ActionResult DeleteDichVu_CS(string maCS)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_CS/Index/Delete").Count() > 0;
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
                emp.TenBang = "DMDichVu_CS";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete maCS: " + maCS;
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_CS_DELETED(maCS, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 

        #region View thêm mới chủng loại dịch vụ
        [HttpPost]
        public ActionResult CreateDichVu_CS(String TenCS, String MaDV, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String MaXN, String GhiChu)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_CS/Index/Create").Count() > 0;
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
                emp.TenBang = "DMDichVu_CS";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create TenCS: " + TenCS + ", MaDV: " + MaDV + ", ChisocaoNu: " + ChisocaoNu + ", ChisocaoNam: " + ChisocaoNam + ", ChisothapNu: " + ChisothapNu + ", ChisothapNam: " + ChisothapNam + ", GhiChu: " + GhiChu + ", DonViDo: " + DonViDo + ", MaXN: " + MaXN;
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_CS_CREATE(TenCS, MaDV, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, MaXN, GhiChu, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới chủng loại dịch vụ!", status = 500 });
        }
        #endregion

        //#region Load danh mục chủng loại dịch vụ get all
        //public JsonResult DMDichVu_CSGetAll()
        //{
        //    var response = _DichVu_CSService.DMDichVu_CSGetAll();
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
            var dataSource = db.ExportDMDichVu_CS(key, columns);
            string filename = "DMDichVu_CS " + DateTime.Now.ToString() + ".xlsx";
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
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu_CS/Index/ImportDanhMuc").Count() > 0;
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
                    result.Tables[0].TableName = "DMDichVu_CS";
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
                    emp.TenBang = "DMDichVu_CS";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMDichVu_CS(result.Tables[0], insert);
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
                return Json(new { success = false, message = "Không có quyền thêm mới chủng loại dịch vụ!", status = 500 });
        }
        #endregion
    }
}