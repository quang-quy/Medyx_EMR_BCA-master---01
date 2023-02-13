using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.Models.DanhMuc;
using Medyx_EMR_BCA.Models.HSBA;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DBConText
{
    public partial class Pagination: HL7CoreDataDataContext
	{
        #region DMChucVu
        public PaginationSet<DMChucVuVM> DMChucVuGetListPaging(string MaTinh, string MaQU, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMChucVuVM>();
			var list = DMChucVuGetList(MaTinh, MaQU, maMay, ngaySD, nguoiSD, index, pageSize, add).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMChucDanh
		public PaginationSet<DMChucDanhVM> DMChucDanhGetListPaging(string maCD, string tenCD, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMChucDanhVM>();
			var list = ((IEnumerable<DMChucDanhVM>)(DMCHUCDANHGetList(maCD, tenCD, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMChephamMau
		public PaginationSet<DMChephamMauVM> DMChephamMauGetListPaging(string maCPMau, string tenCPMau, string TenDVT, string TenTat, string MaBYT, string TenBYT, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMChephamMauVM>();
			var list = ((IEnumerable<DMChephamMauVM>)(DMChephamMauGetList( maCPMau, tenCPMau, TenDVT, TenTat, MaBYT, TenBYT, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMMenu
		public PaginationSet<DMMenuVM> DMMenuGetListPaging(string MenuID, string MenuName, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, int Level, string MenuParent, int ApplicationActionID, string ActionName)
		{
			var page = new PaginationSet<DMMenuVM>();
			var list = ((IEnumerable<DMMenuVM>)(DMMenuGetList(MenuID, MenuName, maMay, ngaySD, nguoiSD, index, pageSize, add, Level, MenuParent, ApplicationActionID, ActionName))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMAction
		public PaginationSet<DMActionVM> DMActionGetListPaging(string maAction, string tenAction, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string ButtonName, int ApplicationActionID)
		{
			var page = new PaginationSet<DMActionVM>();
			var list = ((IEnumerable<DMActionVM>)(DMActionGetList(maAction, tenAction, maMay, ngaySD, nguoiSD, index, pageSize, add, ButtonName,ApplicationActionID))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region HSBA
		public PaginationSet<DeNghiTrichLucVM> DeNghiTrichLucGetListPaging(string sophieu, string tenLoaiDeNghi, string maba, string tungay, string denngay, bool Duyet, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            var page = new PaginationSet<DeNghiTrichLucVM>();
            var list = ((IEnumerable<DeNghiTrichLucVM>)(DeNghiTrichLucGetList( sophieu, tenLoaiDeNghi, maba, tungay, denngay, Duyet, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add))).ToList();
            int totalCount = list.Count();
            if (totalCount > 0)
            {
                //totalCount = list.Count();
                page.Items = list;
                //page.Count = totalCount;
                //page.TotalCounts = totalCount;
                page.TotalCounts = list[0].TotalRows;
                page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
            }
            return page;
        }
        public PaginationSet<HSBAVM> FindHSBA(string hotenbn, string tungay, string denngay, string khoa)
		{
			var page = new PaginationSet<HSBAVM>();
			var list = ((IEnumerable<HSBAVM>)(FindHSBAGetList(hotenbn, tungay, denngay, khoa))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				//page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
				page.TotalPages = 1;
			}
			return page;
		}
		public PaginationSet<HSBAVM> FindHSBAByDK(string hotenbn, string tungay, string denngay, string khoa,string dk)
		{
			var page = new PaginationSet<HSBAVM>();
			var list = ((IEnumerable<HSBAVM>)(FindHSBAGetByDK(hotenbn, tungay, denngay, khoa, dk))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				//page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
				page.TotalPages = 1;
			}
			return page;
		}
		#endregion
		#region DMNhanVien
		public PaginationSet<DMNV> spDMNhanVien_GetAll(string maNV, string iDNhanVien, string hoTen, string maChucVu, string maChuyenMon, string maKhoa, string maMay, string nguoiSD, string ngaySD, string nguoiSD1, string ngaySD1, string maQL, string maCD, string tenTat, string Matat, string maNV1, string account, string password, string tenrole, int pageIndex, int pageSize, int add)
		{
			var page = new PaginationSet<DMNV>();
			var list = ((IEnumerable<DMNV>)(DMNhanVien_GetAll(maNV, iDNhanVien, hoTen, maChucVu, maChuyenMon, maKhoa, maMay, nguoiSD, ngaySD, nguoiSD1, ngaySD1, maQL, maCD, tenTat, Matat, maNV1, account, password, tenrole, pageIndex, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (list.Count() > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDichVu_ChungLoai
		public PaginationSet<DMDichVu_ChungLoaiVM> DMDichVu_ChungLoaiGetListPaging(string maChungLoai, string tenChungLoai, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMDichVu_ChungLoaiVM>();
			var list = ((IEnumerable<DMDichVu_ChungLoaiVM>)(DMDichVu_ChungLoaiGetList(maChungLoai, tenChungLoai, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDichVu_LoaiHinh
		public PaginationSet<DMDichVu_LoaiHinhVM> DMDichVu_LoaiHinhGetListPaging(string maLH, string tenLH, string tenChungLoai, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMDichVu_LoaiHinhVM>();
			var list = ((IEnumerable<DMDichVu_LoaiHinhVM>)(DMDichVu_LoaiHinhGetList(maLH, tenLH, maMay, tenChungLoai, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDichVu_Nhom
		public PaginationSet<DMDichVu_NhomVM> DMDichVu_NhomGetListPaging(string maNhomDV, string tenNhomDV, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMDichVu_NhomVM>();
			var list = ((IEnumerable<DMDichVu_NhomVM>)(DMDichVu_NhomGetList(maNhomDV, tenNhomDV, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDichVu_PhanLoaiPTTT
		public PaginationSet<DMDichVu_PhanLoaiPTTTVM> DMDichVu_PhanLoaiPTTTGetListPaging(string MaPLPTTT, string TenPLPTTT, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMDichVu_PhanLoaiPTTTVM>();
			var list = ((IEnumerable<DMDichVu_PhanLoaiPTTTVM>)(DMDichVu_PhanLoaiPTTTGetList(MaPLPTTT, TenPLPTTT, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDichVu
		public PaginationSet<DMDichVuVM> DMDichVuGetListPaging(string maDV, string tenDV, String TenChungLoai, String TenLH, String TenPLPTTT, String TenTat, String MaBYT, String TenBYT, String TenNhomDV, String MaXN, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String Matat, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			var page = new PaginationSet<DMDichVuVM>();
			var list = ((IEnumerable<DMDichVuVM>)(DMDichVuGetList(maDV, tenDV, TenChungLoai, TenLH, TenPLPTTT, TenTat, MaBYT, TenBYT, TenNhomDV, MaXN, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, Matat, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDichVu_CS
		public PaginationSet<DMDichVu_CSVM> DMDichVu_CSGetListPaging(string maCS, string tenCS, String TenDV, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String MaXN, String Matat, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			var page = new PaginationSet<DMDichVu_CSVM>();
			var list = ((IEnumerable<DMDichVu_CSVM>)(DMDichVu_CSGetList(maCS, tenCS, TenDV, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, MaXN, Matat, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMKhoa
		public PaginationSet<DMKhoaVM> DMKhoaGetListPaging(string maKhoa, string tenKhoa, string DiaDiem, byte Loai, string MaBYT, string Matat, int SoGiuong, string TenNVTruongKhoa, string TenNVDieuDuongTruong, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMKhoaVM>();
			var list = ((IEnumerable<DMKhoaVM>)(DMKhoaGetList( maKhoa, tenKhoa, DiaDiem, Loai, MaBYT, Matat, SoGiuong, TenNVTruongKhoa, TenNVDieuDuongTruong, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMKhoa_Buong
		public PaginationSet<DMKhoa_BuongVM> DMKhoa_BuongGetListPaging(string maBuong, string tenBuong, string makhoa, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMKhoa_BuongVM>();
			var list = ((IEnumerable<DMKhoa_BuongVM>)(DMKhoa_BuongGetList(maBuong, tenBuong,makhoa, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMKhoa_Giuong
		public PaginationSet<DMKhoa_GiuongVM> DMKhoa_GiuongGetListPaging(string maGiuong, string tenGiuong, string makhoa, string maBuong, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMKhoa_GiuongVM>();
			var list = ((IEnumerable<DMKhoa_GiuongVM>)(DMKhoa_GiuongGetList(maGiuong, tenGiuong, makhoa,maBuong, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMPhauThuat
		public PaginationSet<DMPhauThuatVM> DMPhauThuatGetListPaging(string maPT, string tenPT, String TenNhomDV, String TenPLPTTT, String TenTat, String TenChungLoai, String MaBYT, String TenBYT, String Matat, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			var page = new PaginationSet<DMPhauThuatVM>();
			var list = ((IEnumerable<DMPhauThuatVM>)(DMPhauThuatGetList(maPT, tenPT, TenNhomDV, TenPLPTTT, TenTat, TenChungLoai, MaBYT, TenBYT, Matat, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_ChungLoai
		public PaginationSet<DMThuoc_ChungLoaiVM> DMThuoc_ChungLoaiGetListPaging(string maChungLoai, string tenChungLoai, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMThuoc_ChungLoaiVM>();
			var list = ((IEnumerable<DMThuoc_ChungLoaiVM>)(DMThuoc_ChungLoaiGetList(maChungLoai, tenChungLoai, maMay, ngaySD, nguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_DangBaoChe
		public PaginationSet<DMThuoc_DangBaoCheVM> DMThuoc_DangBaoCheGetListPaging(string maDangBaoChe, string tenDangBaoChe, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMThuoc_DangBaoCheVM>();
			var list = ((IEnumerable<DMThuoc_DangBaoCheVM>)(DMThuoc_DangBaoCheGetList(maDangBaoChe, tenDangBaoChe, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_Donvitinh
		public PaginationSet<DMThuoc_DonvitinhVM> DMThuoc_DonvitinhGetListPaging(string maDVT, string tenDVT, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMThuoc_DonvitinhVM>();
			var list = ((IEnumerable<DMThuoc_DonvitinhVM>)(DMThuoc_DonvitinhGetList(maDVT, tenDVT, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_DuongDung
		public PaginationSet<DMThuoc_DuongDungVM> DMThuoc_DuongDungGetListPaging(string maDuongDung, string tenDuongDung, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMThuoc_DuongDungVM>();
			var list = ((IEnumerable<DMThuoc_DuongDungVM>)(DMThuoc_DuongDungGetList(maDuongDung, tenDuongDung, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_NhaSX
		public PaginationSet<DMThuoc_NhaSXVM> DMThuoc_NhaSXGetListPaging(string maNSX, string tenNSX, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMThuoc_NhaSXVM>();
			var list = ((IEnumerable<DMThuoc_NhaSXVM>)(DMThuoc_NhaSXGetList(maNSX, tenNSX, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_Nhom
		public PaginationSet<DMThuoc_NhomVM> DMThuoc_NhomGetListPaging(string maNhom, string tenNhom, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMThuoc_NhomVM>();
			var list = ((IEnumerable<DMThuoc_NhomVM>)(DMThuoc_NhomGetList(maNhom, tenNhom, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc_PhanLoai
		public PaginationSet<DMThuoc_PhanLoaiVM> DMThuoc_PhanLoaiGetListPaging(string maPL, string tenPL, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMThuoc_PhanLoaiVM>();
			var list = ((IEnumerable<DMThuoc_PhanLoaiVM>)(DMThuoc_PhanLoaiGetList(maPL, tenPL, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMThuoc
		public PaginationSet<DMThuocVM> DMThuocGetListPaging(String MaThuoc,
		String TenNhom,
		String TenPL,
		String TenChungLoai,
		String TenDangBaoChe,
		String TenGoc,
		String TenTM,
		String HamLuong,
		String TenDVT,
		String TenNSX,
		String Matat,
		String TenQG,
		String TenDuongDung,
		String MaBYT,
		String TenBYT,
		String SoDangKy,
		String MaMay,
		String NgaySD,
		String NguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMThuocVM>();
			var list = ((IEnumerable<DMThuocVM>)(DMThuocGetList(MaThuoc, TenNhom, TenPL, TenChungLoai, TenDangBaoChe, TenGoc, TenTM, HamLuong, TenDVT, TenNSX, Matat, TenQG, TenDuongDung, MaBYT, TenBYT, SoDangKy, MaMay, NgaySD, NguoiSD, index, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMVTYT_Donvitinh
		public PaginationSet<DMVTYT_DonvitinhVM> DMVTYT_DonvitinhGetListPaging(string maDVT, string tenDVT, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMVTYT_DonvitinhVM>();
			var list = ((IEnumerable<DMVTYT_DonvitinhVM>)(DMVTYT_DonvitinhGetList(maDVT, tenDVT, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMVTYT_Nhom
		public PaginationSet<DMVTYT_NhomVM> DMVTYT_NhomGetListPaging(string maNhom, string tenNhom, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
		{
			var page = new PaginationSet<DMVTYT_NhomVM>();
			var list = ((IEnumerable<DMVTYT_NhomVM>)(DMVTYT_NhomGetList(maNhom, tenNhom, maMay, ngaySD, nguoiSD, index, pageSize, add, Matat))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMVTYT
		public PaginationSet<DMVTYTVM> DMVTYTGetListPaging(String MaVT,
		String TenNhom,
		String TenTM,
		String TenDVT,
		String Matat,
		String MaBYT,
		String TenBYT,
		String MaMay,
		String NgaySD,
		String NguoiSD, int PageIndex, int pageSize, int add)
		{
			var page = new PaginationSet<DMVTYTVM>();
			var list = ((IEnumerable<DMVTYTVM>)(DMVTYTGetList(MaVT, TenNhom, TenTM, TenDVT, Matat, MaBYT, TenBYT, MaMay, NgaySD, NguoiSD, PageIndex, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMQuocGia
		public PaginationSet<DMQuocGiaVM> DMQuocGiaGetListPaging(string maQG, string tenQG, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMQuocGiaVM>();
			var list = DMQuocGiaGetList(maQG, tenQG, maMay, ngaySD, nguoiSD, index, pageSize, add).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		#endregion
		#region DMDanToc
		public PaginationSet<DMDanTocVM> DMDanTocGetListPaging(string maDT, string tenDT, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMDanTocVM>();
			var list = DMDanTocGetList(maDT, tenDT, maMay, ngaySD, nguoiSD, index, pageSize, add).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
        #endregion
        #region DMBA_HTRaVien
        public PaginationSet<HTRaVienVM> DMBA_HTRaVienGetListPaging(string MaHTRaVien, string TenHTRaVien, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add,string ghichu, string mabyte)
        {
            var page = new PaginationSet<HTRaVienVM>();
            var list = DMBA_HTRaVienGetList(MaHTRaVien, TenHTRaVien, maMay, ngaySD, nguoiSD, index, pageSize, add, mabyte,ghichu).ToList();
            int totalCount = list.Count();
            if (totalCount > 0)
            {
                //totalCount = list.Count();
                page.Items = list;
                //page.Count = totalCount;
                //page.TotalCounts = totalCount;
                page.TotalCounts = list[0].TotalRows;
                page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
            }
            return page;
        }

        #endregion
        #region DM_Tinh
        public PaginationSet<DM_TinhVM> DM_TinhGetListPaging(string mt, string maQU, string maMay,string MaVungLT,string TenTinh,string MaBHYT,string Huy, string ngaySD, string nguoiSD, int index, int pageSize, int add, string Matat)
        {
            var page = new PaginationSet<DM_TinhVM>();
			var list = DM_TinhGetList(mt, maQU, MaVungLT, TenTinh, MaBHYT, maMay, Huy, ngaySD, nguoiSD, Matat, index, pageSize, add).ToList();
            int totalCount = list.Count();
            if (totalCount > 0)
            {
                //totalCount = list.Count();
                page.Items = list;
                //page.Count = totalCount;
                //page.TotalCounts = totalCount;
                page.TotalCounts = list[0].TotalRows;
                page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
            }
            return page;
        }
        #endregion

        #region DMRole PhanNhomQuyenDS
        public PaginationSet<DMRoleVM> DMRoleGetListPaging(string MaTinh, string MaQU, string maMay, string ngaySD, string nguoiSD, int index, int pageSize, int add)
		{
			var page = new PaginationSet<DMRoleVM>();
			var list = DMRoleGetList(MaTinh, MaQU, maMay, ngaySD, nguoiSD, index, pageSize, add).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
		public DMRole_C DMRole_CGet(string MaRole)
		{
			var DMRole_C = new DMRole_C();
			var role = spDMRole_Get(MaRole).FirstOrDefault();
			if (role != null)
			{
				DMRole_C.ApplicationRolesId = role.ApplicationRolesId;
				DMRole_C.TenRole = role.TenRole;
				DMRole_C.MaMay = role.MaMay;
				DMRole_C.NgaySD = role.NgaySD;
				DMRole_C.NguoiSD = role.NguoiSD;
				DMRole_C.Huy = role.Huy;
			}
            //DMRole_C.MenuRole = spMenu_GetByRole(MaRole);
            //DMRole_C.ActionRole = spDMAction_GetByRole(MaRole);
            var MenuRole = spMenu_GetByRole(MaRole).ToList();
            var ActionRole = spDMAction_GetByRole(MaRole).ToList();
            DMRole_C.MenuRoleC = MenuRole.Where(x => x.Chon == false).ToList();
            //DMRole_C.ActionRoleC = ActionRole.Where(x => x.Chon == false).ToList();
            DMRole_C.MenuRoleD = MenuRole.Where(x => x.Chon == true).ToList();
			//DMRole_C.ActionRoleD = ActionRole.Where(x => x.Chon == true).ToList();
			DMRole_C.ActionRole = ActionRole;
			return DMRole_C;
		}
		#endregion
		#region TraceLog
		public PaginationSet<TraceLogSQLVM> TraceLogGetListPaging(string tenbang, string mabn, string kieutacdong, string maMay, DateTime tungay, DateTime denngay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			var page = new PaginationSet<TraceLogSQLVM>();
			var list = ((IEnumerable<TraceLogSQLVM>)(TraceLogGetList(tenbang, mabn, kieutacdong, maMay,tungay,denngay, ngaySD, nguoiSD, pageIndex, pageSize, add))).ToList();
			int totalCount = list.Count();
			if (totalCount > 0)
			{
				//totalCount = list.Count();
				page.Items = list;
				//page.Count = totalCount;
				//page.TotalCounts = totalCount;
				page.TotalCounts = list[0].TotalRows;
				page.TotalPages = (int)Math.Ceiling(((double)page.TotalCounts / pageSize));
			}
			return page;
		}
        #endregion

    }
}
