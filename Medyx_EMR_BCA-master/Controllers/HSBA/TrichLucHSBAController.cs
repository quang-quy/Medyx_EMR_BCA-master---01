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
using Microsoft.Extensions.Configuration;
using System.Linq;
namespace Medyx_EMR_BCA.Controllers.HSBA
{
    public class TrichLucHSBAController : BCAController
    {
        private readonly IConfiguration _config;
        #region Khởi tạo
        private IMemoryCache cache;
        //public readonly ISession session;
        public TrichLucHSBAController(IMemoryCache cache, IConfiguration config)
        {
            this.cache = cache;
            _config = config;
            //this.session = HttpContext.Session;
        }
        public ActionResult DeNghiTrichLuc()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region Load danh sách benh nhan

        [HttpGet]
        public JsonResult FindHSBA(string hotenbn, string tungay, string denngay, string khoa)
        {
            //var response = _chucDanhService.DMChucDanhGetListPaging(maCD, tenCD, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(hotenbn))
                hotenbn = "";
            if (string.IsNullOrEmpty(tungay))
                tungay = "";
            if (string.IsNullOrEmpty(denngay))
                denngay = "";
            if (string.IsNullOrEmpty(khoa))
                khoa = "";
            var response = db.FindHSBA(hotenbn, tungay, denngay, khoa);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion
        #region Load danh sách đề nghị trích lục paging

        [HttpGet]
        public JsonResult LoadData(string sophieu, string tenLoaiDeNghi, string maba, string tungay, string denngay, bool Duyet, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            //var response = _chucDanhService.DMChucDanhGetListPaging(maCD, tenCD, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(sophieu))
                sophieu = "0";
            if (string.IsNullOrEmpty(tenLoaiDeNghi))
                tenLoaiDeNghi = "";
            if (string.IsNullOrEmpty(maba))
                maba = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            var response = db.DeNghiTrichLucGetListPaging( sophieu, tenLoaiDeNghi, maba, tungay, denngay, Duyet, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion
        #region View thêm mới đề nghị trích lục
        [HttpPost]
        public ActionResult CreateOrUpdateDN(string LoaiDeNghi, string MaBA, string HoTenNguoiDeNghi, string NgaySinhNguoiDN, string SoCMT, string NgayCapCMT, string NoiCapCMT, string QHBN, string HoTenBN, string DiaChi, string TGVQ, string MaKhoaDT, string TuNgayDT, string DenNgayDT, string LyDo, decimal sophieu, bool Duyet, string ngayduyet, bool huy, string dvct, string NhamLan, string CMNhamLan, string MatRach)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/trichlucHSBA/DeNghiTrichLuc/Create").Count() > 0;
            if (Quyen)
            {
                byte loaidn = 0;
                if (!string.IsNullOrEmpty(LoaiDeNghi))
                    loaidn = byte.Parse(LoaiDeNghi);
                if (string.IsNullOrEmpty(MaBA))
                    MaBA = "";
                if (string.IsNullOrEmpty(HoTenNguoiDeNghi))
                    HoTenNguoiDeNghi = "";
                if (string.IsNullOrEmpty(NgaySinhNguoiDN))
                    NgaySinhNguoiDN = "";
                if (string.IsNullOrEmpty(SoCMT))
                    SoCMT = "";
                if (string.IsNullOrEmpty(NgayCapCMT))
                    NgayCapCMT = "";
                if (string.IsNullOrEmpty(NoiCapCMT))
                    NoiCapCMT = "";
                if (string.IsNullOrEmpty(QHBN))
                    QHBN = "";
                if (string.IsNullOrEmpty(HoTenBN))
                    HoTenBN = "";
                if (string.IsNullOrEmpty(DiaChi))
                    DiaChi = "";
                if (string.IsNullOrEmpty(TGVQ))
                    TGVQ = "";
                if (string.IsNullOrEmpty(MaKhoaDT))
                    MaKhoaDT = "";
                if (string.IsNullOrEmpty(LyDo))
                    LyDo = "";
                if (string.IsNullOrEmpty(ngayduyet))
                    ngayduyet = "";
                if (string.IsNullOrEmpty(dvct))
                    dvct = "";
                if (string.IsNullOrEmpty(NhamLan))
                    NhamLan = "";
                if (string.IsNullOrEmpty(CMNhamLan))
                    CMNhamLan = "";
                if (string.IsNullOrEmpty(MatRach))
                    MatRach = "";
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                decimal sp= db.spBenhAn_DeNghiTrichLuc_CREATEOrUpdate(loaidn, MaBA, HoTenNguoiDeNghi, NgaySinhNguoiDN, SoCMT, NgayCapCMT, NoiCapCMT, QHBN, HoTenBN, DiaChi, TGVQ, MaKhoaDT, TuNgayDT, DenNgayDT, LyDo, MaMay, u.Pub_sNguoiSD, sophieu, Duyet, ngayduyet,huy,dvct, NhamLan, CMNhamLan, MatRach);
                return RedirectToAction("DeNghiTrichLuc");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới !", status = 500 });
        }
        [HttpGet]
        public ActionResult CreateOrUpdateDNPrint(string LoaiDeNghi, string MaBA, string HoTenNguoiDeNghi, string NgaySinhNguoiDN, string SoCMT, string NgayCapCMT, string NoiCapCMT, string QHBN, string HoTenBN, string DiaChi, string TGVQ, string MaKhoaDT, string TuNgayDT, string DenNgayDT, string LyDo, decimal sophieu, bool Duyet, string ngayduyet, bool huy, string dvct, string NhamLan, string CMNhamLan, string MatRach)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/trichlucHSBA/DeNghiTrichLuc/Create").Count() > 0;
            if (Quyen)
            {
                byte loaidn = 0;
                if (!string.IsNullOrEmpty(LoaiDeNghi))
                    loaidn = byte.Parse(LoaiDeNghi);
                if (string.IsNullOrEmpty(MaBA))
                    MaBA = "";
                if (string.IsNullOrEmpty(HoTenNguoiDeNghi))
                    HoTenNguoiDeNghi = "";
                if (string.IsNullOrEmpty(NgaySinhNguoiDN))
                    NgaySinhNguoiDN = "";
                if (string.IsNullOrEmpty(SoCMT))
                    SoCMT = "";
                if (string.IsNullOrEmpty(NgayCapCMT))
                    NgayCapCMT = "";
                if (string.IsNullOrEmpty(NoiCapCMT))
                    NoiCapCMT = "";
                if (string.IsNullOrEmpty(QHBN))
                    QHBN = "";
                if (string.IsNullOrEmpty(HoTenBN))
                    HoTenBN = "";
                if (string.IsNullOrEmpty(DiaChi))
                    DiaChi = "";
                if (string.IsNullOrEmpty(TGVQ))
                    TGVQ = "";
                if (string.IsNullOrEmpty(MaKhoaDT))
                    MaKhoaDT = "";
                if (string.IsNullOrEmpty(LyDo))
                    LyDo = "";
                if (string.IsNullOrEmpty(ngayduyet))
                    ngayduyet = "";
                if (string.IsNullOrEmpty(dvct))
                    dvct = "";
                if (string.IsNullOrEmpty(NhamLan))
                    NhamLan = "";
                if (string.IsNullOrEmpty(CMNhamLan))
                    CMNhamLan = "";
                if (string.IsNullOrEmpty(MatRach))
                    MatRach = "";
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                decimal sp = db.spBenhAn_DeNghiTrichLuc_CREATEOrUpdate(loaidn, MaBA, HoTenNguoiDeNghi, NgaySinhNguoiDN, SoCMT, NgayCapCMT, NoiCapCMT, QHBN, HoTenBN, DiaChi, TGVQ, MaKhoaDT, TuNgayDT, DenNgayDT, LyDo, MaMay, u.Pub_sNguoiSD, sophieu, Duyet, ngayduyet==null?"": ngayduyet, huy,dvct, NhamLan==null?"": NhamLan, CMNhamLan==null?"": CMNhamLan, MatRach==null?"": MatRach);
                string reportfile = "\\Report\\CRDeNghiTrichLuc.rpt";
                string fileName = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "DonXinTrichLuc.pdf";
                DataTable dt = db.spBenhAn_DeNghiTrichLuc_Print(sp.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    //string filepath = 
                    try
                    {
                        return PrintPDF(reportfile, fileName, dt, _config);
                    }
                    catch (Exception ex)
                    {
                        return Json(new { success = false, message = "Error: " + ex.ToString() + "!", status = 500 });
                    }

                    //return RedirectToAction("DeNghiTrichLuc");
                    //return Json(new { success = true, message = filepath, status = 200 });
                    //return RedirectToAction("GetReport?ReportURL=" + filepath);
                }
                else
                    return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới !", status = 500 });
        }
        [HttpGet]
        public ActionResult DNPrint(string sophieulist)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/trichlucHSBA/DeNghiTrichLuc/ExportExcel").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string reportfile = "\\Report\\CRDeNghiTrichLuc.rpt";
                string fileName = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "DonXinTrichLuc.pdf";
                DataTable dt = db.spBenhAn_DeNghiTrichLuc_Print(sophieulist);
                if (dt != null && dt.Rows.Count > 0)
                {
                    try
                    {
                        //string filepath = 
                        return PrintPDF(reportfile, fileName, dt, _config);
                        //return RedirectToAction("DeNghiTrichLuc");
                        //return Json(new { success = true, message = filepath, status = 200 });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { success = false, message = "Error: " + ex.ToString(), status = 500 });
                    }

                }
                else
                    return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới !", status = 500 });
        }
        [HttpGet]
        public ActionResult PrintHSBA(string sophieulist)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/trichlucHSBA/DeNghiTrichLuc/ExportExcel").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string reportfile = "\\Report\\CRTrichLucHSBA.rpt";
                string fileName = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "TrichLucHSBA.pdf";
                DataTable dt = db.spBenhAn_DeNghiTrichLuc_PrintHSBA(sophieulist);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //string filepath = 
                    DataRow[] contains = dt.Select("LoaiDeNghi = 1");
                    if (contains != null && contains.Count() > 0)
                        return PrintZip(reportfile, fileName, dt, _config);
                    else
                        return PrintPDF(reportfile, fileName, dt, _config);
                    //return RedirectToAction("DeNghiTrichLuc");
                    //return Json(new { success = true, message = filepath, status = 200 });
                }
                else
                    return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới !", status = 500 });
        }
        #endregion
        #region View delete de nghi trich luc

        [HttpPost]
        public ActionResult DeleteDN(string sophieu)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/trichlucHSBA/DeNghiTrichLuc/Delete").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string MaMay = this.GetLocalIPAddress();
                db.spBenhAn_DeNghiTrichLuc_DELETED(sophieu, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("DeNghiTrichLuc");
            }
            else
                return Json(new { success = false, message = "Không có quyền phiếu!", status = 500 });
        }

        #endregion 
        [HttpGet]
        public FileResult GetReport(string ReportURL)
        {
            //string ReportURL = "{Your File Path}";
            byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);
            return File(FileBytes, "application/pdf");
        }
    }
}
