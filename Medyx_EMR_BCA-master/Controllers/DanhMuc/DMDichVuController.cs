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
    public class DMDichVuController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMDichVuController(IMemoryCache cache)
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
        public JsonResult LoadData(string maDV, string tenDV,
String TenChungLoai,
String TenLH,
String TenPLPTTT,
String TenTat,
String MaBYT,
String TenBYT,
String TenNhomDV,
String MaXN,
String ChisocaoNu,
String ChisocaoNam,
String ChisothapNu,
String ChisothapNam,
String DonViDo,
String GhiChu, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            //var response = _DichVuService.DMDichVuGetListPaging(maDV, tenDV, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(maDV))
                maDV = "";
            if (string.IsNullOrEmpty(tenDV))
                tenDV = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            if (string.IsNullOrEmpty(TenChungLoai))
                TenChungLoai = "";
            if (string.IsNullOrEmpty(TenLH))
                TenLH = "";
            if (string.IsNullOrEmpty(TenPLPTTT))
                TenPLPTTT = "";
            if (string.IsNullOrEmpty(TenTat))
                TenTat = "";
            if (string.IsNullOrEmpty(MaBYT))
                MaBYT = "";
            if (string.IsNullOrEmpty(TenBYT))
                TenBYT = "";
            if (string.IsNullOrEmpty(TenNhomDV))
                TenNhomDV = "";
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
            var response = db.DMDichVuGetListPaging(maDV, tenDV,TenChungLoai,TenLH,TenPLPTTT,TenTat,MaBYT,TenBYT,TenNhomDV,MaXN,ChisocaoNu,ChisocaoNam,ChisothapNu,ChisothapNam,DonViDo,GhiChu, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion

        #region View thực hiện update chủng loại dịch vụ

        [HttpPost]
        public ActionResult Modify(DMDichVu DMDichVu)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu/Index/Modify").Count() > 0;
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
                emp.TenBang = "DMDichVu";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(DMDichVu);
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_UPDATE(DMDichVu.MaDV, DMDichVu.TenDV, DMDichVu.MaChungLoai, DMDichVu.MaLH, DMDichVu.MaPLPTTT, DMDichVu.TenTat, DMDichVu.MaBYT, DMDichVu.TenBYT, DMDichVu.MaNhomDV, DMDichVu.MaXN, DMDichVu.ChisocaoNu, DMDichVu.ChisocaoNam, DMDichVu.ChisothapNu, DMDichVu.ChisothapNam, DMDichVu.DonViDo, DMDichVu.GhiChu, MaMay, u.Pub_sNguoiSD, DMDichVu.Huy);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa chủng loại dịch vụ!", status = 500 });

        }

        #endregion 

        #region View delete chủng loại dịch vụ

        [HttpPost]
        public ActionResult DeleteDichVu(string maDV)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu/Index/Delete").Count() > 0;
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
                emp.TenBang = "DMDichVu";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete maDV: " + maDV;
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_DELETED(maDV, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 

        #region View thêm mới chủng loại dịch vụ
        [HttpPost]
        public ActionResult CreateDichVu(String TenDV,String MaChungLoai,String MaLH,String MaPLPTTT,String TenTat,String MaBYT,String TenBYT,String MaNhomDV,String MaXN,String ChisocaoNu,String ChisocaoNam,String ChisothapNu,String ChisothapNam,String DonViDo,String GhiChu)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu/Index/Create").Count() > 0;
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
                emp.TenBang = "DMDichVu";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create TenDV: " + TenDV + ", MaChungLoai: " + MaChungLoai + ", MaLH: " + MaLH + ", MaPLPTTT: " + MaPLPTTT + ", TenTat: " + TenTat + ", MaBYT: " + MaBYT + ", TenBYT: " + TenBYT + ", MaNhomDV: " + MaNhomDV + ", MaXN: " + MaXN + ", ChisocaoNu: " + ChisocaoNu + ", ChisocaoNam: " + ChisocaoNam + ", ChisothapNu: " + ChisothapNu + ", ChisothapNam: " + ChisothapNam + ", DonViDo: " + DonViDo + ", GhiChu: " + GhiChu;
                collection.InsertOne(emp);
                #endregion
                db.spDMDichVu_CREATE(TenDV,MaChungLoai,MaLH,MaPLPTTT,TenTat,MaBYT,TenBYT,MaNhomDV,MaXN,ChisocaoNu,ChisocaoNam,ChisothapNu,ChisothapNam,DonViDo,GhiChu, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới chủng loại dịch vụ!", status = 500 });
        }
        #endregion

        //#region Load danh mục chủng loại dịch vụ get all
        //public JsonResult DMDichVuGetAll()
        //{
        //    var response = _DichVuService.DMDichVuGetAll();
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
            var dataSource = db.ExportDMDichVu(key, columns);
            string filename = "DMDichVu " + DateTime.Now.ToString() + ".xlsx";
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
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMDichVu/Index/ImportDanhMuc").Count() > 0;
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
                    result.Tables[0].TableName = "DMDichVu";
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
                    emp.TenBang = "DMDichVu";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMDichVu(result.Tables[0], insert);
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