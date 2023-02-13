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
using Microsoft.Extensions.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace Medyx_EMR_BCA.Controllers.BaoCao
{
    public class BaoCaoController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        private readonly IConfiguration _config;
        //public readonly ISession session;
        public BaoCaoController(IMemoryCache cache, IConfiguration config)
        {
            this.cache = cache;
            _config = config;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region Load danh sách benh nhan

        [HttpGet]
        public ActionResult FindHSBA(string tungay, string denngay, string khoa, string dk, string loaibc)
        //public ActionResult FindHSBA(string tungay, string denngay, string khoa, string dk)
        {
            //var response = _chucDanhService.DMChucDanhGetListPaging(maCD, tenCD, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            string rf = "";
            try
            {
                if (string.IsNullOrEmpty(tungay))
                    tungay = "";
                if (string.IsNullOrEmpty(denngay))
                    denngay = "";
                if (string.IsNullOrEmpty(khoa))
                    khoa = "";
                if (string.IsNullOrEmpty(dk))
                    dk = "";
                if (string.IsNullOrEmpty(loaibc))
                    loaibc = "";
                if (loaibc == "1")
                {
                    //var response = db.FindHSBAByDK("", tungay, denngay, khoa, dk);
                    //var dt = CreateDataTable(response.Items);
                    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    //DataTable dt = db.spBenhAn_DeNghiTrichLuc_Print(sophieulist);
                    DataTable dt = db.spBenhAn_HauKiem("", tungay, denngay, khoa, dk);
                    string reportfile = "\\Report\\CRBenhAn_HauKiem.rpt";
                    string fn = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "CRBenhAn_HauKiem.pdf";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //return PrintPDF(reportfile, fileName, dt, _config);
                        string webRootPath = _config.GetValue<string>("ReportDirectory");
                        ReportDocument rpt = new ReportDocument();
                        string reportfilename = webRootPath + reportfile;
                        rf = reportfilename;
                        rpt.Load(reportfilename);//Crystal Report Path
                        FormulaFieldDefinitions Myformulas = rpt.DataDefinition.FormulaFields;
                        Myformulas["TenBV"].Text = "'" + _config.GetValue<string>("PrintSetting:BenhVien") + "'";
                        Myformulas["TenKhoa"].Text = "'BỘ PHẬN LƯU TRỮ HỒ SƠ'";
                        //Myformulas["Ngay"].Text = "'" + "Ngày in: " + DateTime.Now.ToShortDateString().Substring(0, 2) + "/" + DateTime.Now.ToShortDateString().Substring(3, 2) + "/" + DateTime.Now.ToShortDateString().Substring(6, 4) + "'";
                        Myformulas["Ngay"].Text = "'" + "Ngày in: " + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy") + "'";
                        rpt.SetDataSource(dt);//Get data source. All the data can be read in SQL.
                        return PrintReportPDF(reportfile, fn, rpt, _config);
                    }
                    else
                        return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
                }
                else if (loaibc == "2")
                {

                    //var response = db.FindHSBAByDK("", tungay, denngay, khoa, dk);
                    //var dt = CreateDataTable(response.Items);
                    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    //DataTable dt = db.spBenhAn_DeNghiTrichLuc_Print(sophieulist);
                    DataTable dt = db.spBenhAn_InLuuTru("", tungay, denngay, khoa, dk);
                    //string reportfile = "\\Report\\CRBenhAn_InLuuTru.rpt";
                    //string fn = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "CRBenhAn_InLuuTru.pdf";
                    string reportfile = "\\Report\\CRBenhAn_InChiTiet.rpt";
                    string fn = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "CRBenhAn_InChiTiet.pdf";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //return PrintPDF(reportfile, fileName, dt, _config);
                        string webRootPath = _config.GetValue<string>("ReportDirectory");
                        ReportDocument rpt = new ReportDocument();
                        string reportfilename = webRootPath + reportfile;
                        rf = reportfilename;
                        rpt.Load(reportfilename);//Crystal Report Path
                        FormulaFieldDefinitions Myformulas = rpt.DataDefinition.FormulaFields;
                        Myformulas["TenBV"].Text = "'" + _config.GetValue<string>("PrintSetting:BenhVien") + "'";
                        //Myformulas["MaICDIn"].Text = "'MÃ ICD: " + ((_BenhAn_QLHSBAList.Count == 0) ? "" : _BenhAn_QLHSBAList[0].MAICD) + "'";
                        Myformulas["MaICDIn"].Text = "''";
                        Myformulas["TenKhoa"].Text = "'BỘ PHẬN LƯU TRỮ HỒ SƠ'";
                        //Myformulas["Ngay"].Text = "'" + "Ngày in: " + DateTime.Now.ToShortDateString().Substring(0, 2) + "/" + DateTime.Now.ToShortDateString().Substring(3, 2) + "/" + DateTime.Now.ToShortDateString().Substring(6, 4) + "'";
                        Myformulas["Ngay"].Text = "'" + "Ngày in: " + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy") + "'";
                        rpt.SetDataSource(dt);//Get data source. All the data can be read in SQL.
                        return PrintReportPDF(reportfile, fn, rpt, _config);
                    }
                    else
                        return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
                }
                else
                {
                    Pagination db = new Pagination();
                    var response = db.FindHSBAByDK("", tungay, denngay, khoa, dk);
                    var dt = CreateDataTable(response.Items);
                    string reportfile = "\\Report\\CRBaoCao.rpt";
                    string fileName = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "CRBaoCao.pdf";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        return PrintPDF(reportfile, fileName, dt, _config);
                    }
                    else
                        return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi: " + ex.ToString() + " path: " + rf, status = 500 });
            }
        }

        #endregion
    }
}
