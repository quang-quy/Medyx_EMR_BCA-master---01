using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Excel;
using Medyx_EMR_BCA.Models.DanhMuc;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using MongoDB.Driver;
using Medyx_EMR_BCA.Models;
using Newtonsoft.Json;
namespace Medyx_EMR_BCA.Controllers.DanhMuc
{
    public class DMNVController : BCAController
    {
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMNVController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        // GET: DMNVController
        public ActionResult DMNV()
        {
            return Khoitao(cache);
        }
        #region Load danh sách nhân viên paging

        [HttpGet]
        public ActionResult LoadData(string maNV, string iDNhanVien, string hoTen, string maChucVu, string maChuyenMon, string maKhoa, string maMay, string nguoiSD, string ngaySD, string nguoiSD1, string ngaySD1, string maQL, string maCD, string tenTat, string ghiChu, string maNV1, string account, string password, string tenrole, int pageDMNV, int pageSize, int add)
        {
            //var response = _chucVuService.DMChucVuGetListPaging(maCV, tenCV, maMay, ngaySD, nguoiSD, DMNV, pageSize, add);
            if (maNV == null) maNV = "";
            if (iDNhanVien == null) iDNhanVien = "";
            if (hoTen == null) hoTen = "";
            if (maChucVu == null) maChucVu = "";
            if (maChuyenMon == null) maChuyenMon = "";
            if (maKhoa == null) maKhoa = "";
            if (maMay == null) maMay = "";
            if (nguoiSD == null) nguoiSD = "";
            if (ngaySD == null) ngaySD = "";
            if (nguoiSD1 == null) nguoiSD1 = "";
            if (ngaySD1 == null) ngaySD1 = "";
            if (maQL == null) maQL = "";
            if (maCD == null) maCD = "";
            if (tenTat == null) tenTat = "";
            if (ghiChu == null) ghiChu = "";
            if (maNV1 == null) maNV1 = "";
            if (account == null) account = "";
            if (password == null) password = "";
            if (tenrole == null) tenrole = "";
            var U = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            if (U != null)
            {
                Pagination db = new Pagination();
                var response = db.spDMNhanVien_GetAll( maNV, iDNhanVien, hoTen, maChucVu, maChuyenMon, maKhoa, maMay, nguoiSD, ngaySD, nguoiSD1, ngaySD1, maQL, maCD, tenTat, ghiChu, maNV1, account, password, tenrole, pageDMNV, pageSize, add);
                return CreateJsonJsonResult(() =>
                {
                    return Json(response);
                });
            }
            else return null;
        }

        #endregion
        #region View delete nhân viên

        [HttpPost]
        public ActionResult DeleteNhanVien(string manv)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMNV/DMNV/Delete").Count() > 0;
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
                emp.TenBang = "DMNV";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete manv: " + manv;
                collection.InsertOne(emp);
                #endregion
                db.spDMNhanVien_DELETED(manv, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("DMNV");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 
        #region View thực hiện update nhan vien

        [HttpPost]
        public ActionResult Modify(DMNV nhanvien)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMNV/DMNV/Modify").Count() > 0;
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
                emp.TenBang = "DMNV";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(nhanvien);
                collection.InsertOne(emp);
                #endregion
                db.spDMNhanVien_Update(nhanvien.MaNV, nhanvien.HoTen, nhanvien.MaChucVu, nhanvien.MaChuyenMon, nhanvien.MaKhoa, MaMay, u.Pub_sNguoiSD, nhanvien.MaQL, nhanvien.MaCD, nhanvien.tentat, nhanvien.ghichu, nhanvien.idnhanvien, nhanvien.MaNV1, nhanvien.MaRole, nhanvien.Account, nhanvien.Password, nhanvien.QAdmin, nhanvien.Huy);
                return RedirectToAction("DMNV");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa nhân viên!", status = 500 });

        }
        #endregion 
        #region View thêm mới nhan vien
        [HttpPost]
        public ActionResult CreateNhanVien(string HoTen, string MaChucVu, string MaChuyenMon, string MaKhoa, int MaQL, string MaCD, string TenTat, string GhiChu, string idnhanvien, string manv1, string maRole, string Account, string password, bool qadmin)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMNV/DMNV/Create").Count() > 0;
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
                emp.TenBang = "DMNV";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create HoTen: " + HoTen + ", MaChucVu: " + MaChucVu + ", MaChuyenMon: " + MaChuyenMon + ", MaKhoa: " + MaKhoa + ", MaQL: " + MaQL.ToString() + ", MaCD: " + MaCD + ", TenTat: " + TenTat + ", GhiChu: " + GhiChu + ", idnhanvien: " + idnhanvien + ", manv1: " + manv1 + ", maRole: " + maRole + ", Account: " + Account + ", password: " + password + ", qadmin: " + qadmin.ToString();
                collection.InsertOne(emp);
                #endregion
                db.spDMNhanVien_Create(HoTen, MaChucVu, MaChuyenMon, MaKhoa, MaMay, u.Pub_sNguoiSD, MaQL, MaCD, TenTat, GhiChu, idnhanvien, manv1, maRole, Account, password, qadmin);

                return RedirectToAction("DMNV");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới nhân viên!", status = 500 });
        }
        #endregion
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
            var dataSource = db.ExportDMNhanVien(key, columns);
            string filename = "DMNhanVien " + DateTime.Now.ToString() + ".xlsx";
            //MVC4 mVC4 = new MVC4();
            //mVC4.
            ExportToExcel(filename, dataSource);
            return RedirectToAction("/DMNV");
        }
        #endregion

        #region Import data
        [HttpPost]
        public ActionResult ImportDMNV()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMNV/DMNV/ImportDanhMuc").Count() > 0;
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
                        return RedirectToAction("DMNV");
                    }
                    //treats the first row of excel file as Coluymn Names
                    reader.IsFirstRowAsColumnNames = true;
                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();
                    reader.Close();
                    result.Tables[0].TableName = "DMNhanVien";
                    for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    {
                        var dtt = result.Tables[0].Columns[i].DataType;
                        if (i == 10)
                        {
                            //DataColumn newcolumn = new DataColumn("temporary", typeof(DateTime));
                            //result.Tables[0].Columns.Add(newcolumn);
                            //foreach (DataRow row in result.Tables[0].Rows)
                            //{
                            //    try
                            //    {
                            //        row["temporary"] = Convert.ChangeType(row[i], typeof(DateTime));
                            //    }
                            //    catch
                            //    {
                            //    }
                            //}
                            result.Tables[0].Columns.Remove("NgaySD");
                            //newcolumn.ColumnName = "NgaySD";
                        }
                        else if (result.Tables[0].Columns[i].DataType!=typeof(DateTime))
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
                    emp.TenBang = "DMNV";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMNhanVien(result.Tables[0], insert);
                    //_chucVuService.ImportDMChucVu(result.Tables[0], insert);
                    return RedirectToAction("DMNV");
                }
                //}
                //else
                //{
                //    ModelState.AddModelError("File", "Please upload your file");
                //}
                return RedirectToAction("DMNV");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới nhân viên!", status = 500 });
        }
        #endregion
    }
}
