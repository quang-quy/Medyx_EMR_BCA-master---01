using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyx_EMR_BCA.Models.DanhMuc;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Medyx_EMR_BCA.Models;
using Medyx_EMR_BCA.Models.HSBA;
namespace Medyx_EMR_BCA.Controllers.Core
{
    public class GeneralCategoryController : BCAController
    {
        #region Khởi tạo
        // GET: Client/DMChucVu
        private IMemoryCache cache;
        //public readonly ISession session;
        public GeneralCategoryController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region combo chức vụ
        [HttpGet]
        public ActionResult GetAllChucVu()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMChucVu> dmChucVu = cache.Get<List<DMChucVu>>("DMChucVu" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmChucVu == null)
            {
                dmChucVu = db.spDMCHUCVU_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMChucVu>>("DMChucVu" + u.Pub_sNguoiSD, dmChucVu, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmChucVu = db.spDMCHUCVU_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmChucVu);
            });
        }
        #endregion
        #region combo dịch vụ
        [HttpGet]
        public ActionResult GetAllDichVu()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMDichVu> dmDichVu = cache.Get<List<DMDichVu>>("DMDichVu" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmDichVu == null)
            {
                dmDichVu = db.spDMDichVu_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMDichVu>>("DMDichVu" + u.Pub_sNguoiSD, dmDichVu, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmDichVu = db.spDMDichVu_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmDichVu);
            });
        }
        #endregion
        #region combo chủng loại dịch vụ
        [HttpGet]
        public ActionResult GetAllDichVu_ChungLoai()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMDichVu_ChungLoai> dmDichVu_ChungLoai = cache.Get<List<DMDichVu_ChungLoai>>("DMDichVu_ChungLoai" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmDichVu_ChungLoai == null)
            {
                dmDichVu_ChungLoai = db.spDMDichVu_ChungLoai_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMDichVu_ChungLoai>>("DMDichVu_ChungLoai" + u.Pub_sNguoiSD, dmDichVu_ChungLoai, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmDichVu_ChungLoai = db.spDMDichVu_ChungLoai_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmDichVu_ChungLoai);
            });
        }
        #endregion
        #region combo loại hình dịch vụ
        [HttpGet]
        public ActionResult GetAllDichVu_LoaiHinh()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMDichVu_LoaiHinh> dmDichVu_LoaiHinh = cache.Get<List<DMDichVu_LoaiHinh>>("DMDichVu_LoaiHinh" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmDichVu_LoaiHinh == null)
            {
                dmDichVu_LoaiHinh = db.spDMDichVu_LoaiHinh_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMDichVu_LoaiHinh>>("DMDichVu_LoaiHinh" + u.Pub_sNguoiSD, dmDichVu_LoaiHinh, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmDichVu_LoaiHinh = db.spDMDichVu_LoaiHinh_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmDichVu_LoaiHinh);
            });
        }
        #endregion
        #region combo nhóm dịch vụ
        [HttpGet]
        public ActionResult GetAllDichVu_Nhom()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMDichVu_Nhom> dmDichVu_Nhom = cache.Get<List<DMDichVu_Nhom>>("DMDichVu_Nhom" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmDichVu_Nhom == null)
            {
                dmDichVu_Nhom = db.spDMDichVu_Nhom_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMDichVu_Nhom>>("DMDichVu_Nhom" + u.Pub_sNguoiSD, dmDichVu_Nhom, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmDichVu_Nhom = db.spDMDichVu_Nhom_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmDichVu_Nhom);
            });
        }
        #endregion
        #region combo nhóm vật tư
        [HttpGet]
        public ActionResult GetAllVTYT_Nhom()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMVTYT_Nhom> dmVTYT_Nhom = cache.Get<List<DMVTYT_Nhom>>("DMVTYT_Nhom" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmVTYT_Nhom == null)
            {
                dmVTYT_Nhom = db.spDMVTYT_Nhom_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMVTYT_Nhom>>("DMVTYT_Nhom" + u.Pub_sNguoiSD, dmVTYT_Nhom, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmVTYT_Nhom = db.spDMVTYT_Nhom_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmVTYT_Nhom);
            });
        }
        #endregion
        #region combo đơn vị tính vật tư
        [HttpGet]
        public ActionResult GetAllVTYT_Donvitinh()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMVTYT_Donvitinh> dmVTYT_Donvitinh = cache.Get<List<DMVTYT_Donvitinh>>("DMVTYT_Donvitinh" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmVTYT_Donvitinh == null)
            {
                dmVTYT_Donvitinh = db.spDMVTYT_Donvitinh_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMVTYT_Donvitinh>>("DMVTYT_Donvitinh" + u.Pub_sNguoiSD, dmVTYT_Donvitinh, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmVTYT_Donvitinh = db.spDMVTYT_Donvitinh_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmVTYT_Donvitinh);
            });
        }
        #endregion
        #region combo phân loại PTTT dịch vụ
        [HttpGet]
        public ActionResult GetAllDichVu_PhanLoaiPTTT()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMDichVu_PhanLoaiPTTT> dmDichVu_PhanLoaiPTTT = cache.Get<List<DMDichVu_PhanLoaiPTTT>>("DMDichVu_PhanLoaiPTTT" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmDichVu_PhanLoaiPTTT == null)
            {
                dmDichVu_PhanLoaiPTTT = db.spDMDichVu_PhanLoaiPTTT_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMDichVu_PhanLoaiPTTT>>("DMDichVu_PhanLoaiPTTT" + u.Pub_sNguoiSD, dmDichVu_PhanLoaiPTTT, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmDichVu_PhanLoaiPTTT = db.spDMDichVu_PhanLoaiPTTT_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmDichVu_PhanLoaiPTTT);
            });
        }
        #endregion
        #region combo nhóm thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_Nhom()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_Nhom> dmThuoc_Nhom = cache.Get<List<DMThuoc_Nhom>>("DMThuoc_Nhom" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_Nhom == null)
            {
                dmThuoc_Nhom = db.spDMThuoc_Nhom_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_Nhom>>("DMThuoc_Nhom" + u.Pub_sNguoiSD, dmThuoc_Nhom, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_Nhom = db.spDMThuoc_Nhom_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_Nhom);
            });
        }
        #endregion
        #region combo phân loại thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_PhanLoai()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_PhanLoai> dmThuoc_PhanLoai = cache.Get<List<DMThuoc_PhanLoai>>("DMThuoc_PhanLoai" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_PhanLoai == null)
            {
                dmThuoc_PhanLoai = db.spDMThuoc_PhanLoai_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_PhanLoai>>("DMThuoc_PhanLoai" + u.Pub_sNguoiSD, dmThuoc_PhanLoai, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_PhanLoai = db.spDMThuoc_PhanLoai_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_PhanLoai);
            });
        }
        #endregion
        #region combo chủng loại thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_ChungLoai()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_ChungLoai> dmThuoc_ChungLoai = cache.Get<List<DMThuoc_ChungLoai>>("DMThuoc_ChungLoai" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_ChungLoai == null)
            {
                dmThuoc_ChungLoai = db.spDMThuoc_ChungLoai_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_ChungLoai>>("DMThuoc_ChungLoai" + u.Pub_sNguoiSD, dmThuoc_ChungLoai, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_ChungLoai = db.spDMThuoc_ChungLoai_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_ChungLoai);
            });
        }
        #endregion
        #region combo dạng bào chế thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_DangBaoChe()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_DangBaoChe> dmThuoc_DangBaoChe = cache.Get<List<DMThuoc_DangBaoChe>>("DMThuoc_DangBaoChe" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_DangBaoChe == null)
            {
                dmThuoc_DangBaoChe = db.spDMThuoc_DangBaoChe_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_DangBaoChe>>("DMThuoc_DangBaoChe" + u.Pub_sNguoiSD, dmThuoc_DangBaoChe, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_DangBaoChe = db.spDMThuoc_DangBaoChe_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_DangBaoChe);
            });
        }
        #endregion
        #region combo đơn vị tính thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_Donvitinh()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_Donvitinh> dmThuoc_Donvitinh = cache.Get<List<DMThuoc_Donvitinh>>("DMThuoc_Donvitinh" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_Donvitinh == null)
            {
                dmThuoc_Donvitinh = db.spDMThuoc_Donvitinh_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_Donvitinh>>("DMThuoc_Donvitinh" + u.Pub_sNguoiSD, dmThuoc_Donvitinh, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_Donvitinh = db.spDMThuoc_Donvitinh_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_Donvitinh);
            });
        }
        #endregion
        #region combo đường dùng thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_DuongDung()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_DuongDung> dmThuoc_DuongDung = cache.Get<List<DMThuoc_DuongDung>>("DMThuoc_DuongDung" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_DuongDung == null)
            {
                dmThuoc_DuongDung = db.spDMThuoc_DuongDung_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_DuongDung>>("DMThuoc_DuongDung" + u.Pub_sNguoiSD, dmThuoc_DuongDung, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_DuongDung = db.spDMThuoc_DuongDung_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_DuongDung);
            });
        }
        #endregion
        #region combo nhà sản xuất thuốc
        [HttpGet]
        public ActionResult GetAllThuoc_NhaSX()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMThuoc_NhaSX> dmThuoc_NhaSX = cache.Get<List<DMThuoc_NhaSX>>("DMThuoc_NhaSX" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmThuoc_NhaSX == null)
            {
                dmThuoc_NhaSX = db.spDMThuoc_NhaSX_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMThuoc_NhaSX>>("DMThuoc_NhaSX" + u.Pub_sNguoiSD, dmThuoc_NhaSX, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmThuoc_NhaSX = db.spDMThuoc_NhaSX_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmThuoc_NhaSX);
            });
        }
        #endregion
        #region combo quốc gia
        [HttpGet]
        public ActionResult GetAllQuocGia()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMQuocGia> dmQuocGia = cache.Get<List<DMQuocGia>>("DMQuocGia" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmQuocGia == null)
            {
                dmQuocGia = db.spDMQUOCGIA_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMQuocGia>>("DMQuocGia" + u.Pub_sNguoiSD, dmQuocGia, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmQuocGia = db.spDMQuocGia_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmQuocGia);
            });
        }
        #endregion
        #region combo khoa
        [HttpGet]
        public ActionResult GetAllKhoa(bool qAdmin)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMKhoa> DMKhoa = cache.Get<List<DMKhoa>>("DMKhoa" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (DMKhoa == null)
            {
                //var dk = db.DMKhoaGetAll(qAdmin);
                DMKhoa = db.DMKhoaGetAll(qAdmin).ToList();
                //DMKhoa = dk.ToList();
                //set cache 30 ngay
                cache.Set<List<DMKhoa>>("DMKhoa" + u.Pub_sNguoiSD, DMKhoa, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = db.DMKhoaGetAll(qAdmin).ToList();
            return CreateJsonJsonResult(() =>
            {
                return Json(DMKhoa);
            });
        }
        #endregion
        #region combo Buong
        [HttpGet]
        public ActionResult GetAllKhoa_Buong()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMKhoa_Buong> dmKhoa_Buong = cache.Get<List<DMKhoa_Buong>>("DMKhoa_Buong" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmKhoa_Buong == null)
            {
                dmKhoa_Buong = db.spDMKhoa_Buong_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMKhoa_Buong>>("DMKhoa_Buong" + u.Pub_sNguoiSD, dmKhoa_Buong, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmKhoa_Buong = db.spDMKhoa_Buong_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(dmKhoa_Buong);
            });
        }
        public ActionResult GetKhoa_BuongByKhoa( string makhoa)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMKhoa_Buong> dmKhoa_Buong = cache.Get<List<DMKhoa_Buong>>("DMKhoa_Buong" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (dmKhoa_Buong == null)
            {
                dmKhoa_Buong = db.spDMKhoa_Buong_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMKhoa_Buong>>("DMKhoa_Buong" + u.Pub_sNguoiSD, dmKhoa_Buong, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var dmKhoa_Buong = db.spDMKhoa_Buong_GetAll().ToList();
            var kq = dmKhoa_Buong.Where(x => x.MaKhoa == makhoa);
            return CreateJsonJsonResult(() => {
                return Json(kq);
            });
        }
        #endregion
        #region combo danh muc loai de nghi trich luc
        [HttpGet]
        public ActionResult GetAllLoaiDNTL()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMLoaiDNTL> DMLoaiDNTL = cache.Get<List<DMLoaiDNTL>>("DMLoaiDNTL" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (DMLoaiDNTL == null)
            {
                //var dk = db.DMKhoaGetAll(qAdmin);
                DMLoaiDNTL = db.DMLoaiDNTLGetAll().ToList();
                //DMKhoa = dk.ToList();
                //set cache 30 ngay
                cache.Set<List<DMLoaiDNTL>>("DMLoaiDNTL" + u.Pub_sNguoiSD, DMLoaiDNTL, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = db.DMKhoaGetAll(qAdmin).ToList();
            return CreateJsonJsonResult(() =>
            {
                return Json(DMLoaiDNTL);
            });
        }
        #endregion
        #region combo chức danh
        [HttpGet]
        public ActionResult GetAllChucDanh()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMChucDanh> DMChucDanh = cache.Get<List<DMChucDanh>>("DMChucDanh" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (DMChucDanh == null)
            {
                DMChucDanh = db.spDMCHUCDANH_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMChucDanh>>("DMChucDanh" + u.Pub_sNguoiSD, DMChucDanh, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = db.spDMCHUCDANH_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(DMChucDanh);
            });
        }
        #endregion
        #region combo chuyên môn
        [HttpGet]
        public ActionResult GetAllChuyenMon()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMChuyenMon> ChuyenMon = cache.Get<List<DMChuyenMon>>("DMChuyenMon" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (ChuyenMon == null)
            {
                ChuyenMon = db.spDMCHUYENMON_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMChuyenMon>>("DMChuyenMon" + u.Pub_sNguoiSD, ChuyenMon, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = _dMChuyenMonService.DMChuyenMongetAll();
            return CreateJsonJsonResult(() => {
                return Json(ChuyenMon);
            });
        }
        #endregion
        #region combo danh mục nhóm quyền
        [HttpGet]
        public ActionResult GetAllRole()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<DMRole> Role = cache.Get<List<DMRole>>("DMRole" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (Role == null)
            {
                Role = db.spDMRole_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<DMRole>>("DMRole" + u.Pub_sNguoiSD, Role, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = _dMChuyenMonService.DMChuyenMongetAll();
            return CreateJsonJsonResult(() => {
                return Json(Role);
            });
        }
        #endregion
        #region combo tên bảng ghi log
        [HttpGet]
        public ActionResult GetAllTraceLogTableName()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<TraceLogTableName> TraceLogTableName = cache.Get<List<TraceLogTableName>>("TraceLogTableName" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (TraceLogTableName == null)
            {
                TraceLogTableName = db.spTraceLogTableName_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<TraceLogTableName>>("TraceLogTableName" + u.Pub_sNguoiSD, TraceLogTableName, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = db.spDMCHUCDANH_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(TraceLogTableName);
            });
        }
        #endregion
        #region combo kiểu tác động ghi log
        [HttpGet]
        public ActionResult GetAllTraceLogKieuTacDong()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            List<TraceLogKieuTacDong> TraceLogKieuTacDong = cache.Get<List<TraceLogKieuTacDong>>("TraceLogKieuTacDong" + u.Pub_sNguoiSD);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            if (TraceLogKieuTacDong == null)
            {
                TraceLogKieuTacDong = db.spTraceLogKieuTacDong_GetAll().ToList();
                //set cache 30 ngay
                cache.Set<List<TraceLogKieuTacDong>>("TraceLogKieuTacDong" + u.Pub_sNguoiSD, TraceLogKieuTacDong, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
            }
            //var response = db.spDMCHUCDANH_GetAll().ToList();
            return CreateJsonJsonResult(() => {
                return Json(TraceLogKieuTacDong);
            });
        }
        #endregion
    }
}
