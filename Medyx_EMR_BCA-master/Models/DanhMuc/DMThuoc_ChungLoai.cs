using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMThuoc_ChungLoaiVM
    {
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_ChungLoai
    {
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuoc_DangBaoCheVM
    {
        public String MaDangBaoChe { get; set; }
        public String TenDangBaoChe { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_DangBaoChe
    {
        public String MaDangBaoChe { get; set; }
        public String TenDangBaoChe { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuoc_DonvitinhVM
    {
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_Donvitinh
    {
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuoc_DuongDungVM
    {
        public String MaDuongDung { get; set; }
        public String TenDuongDung { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_DuongDung
    {
        public String MaDuongDung { get; set; }
        public String TenDuongDung { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuoc_NhaSXVM
    {
        public String MaNSX { get; set; }
        public String TenNSX { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_NhaSX
    {
        public String MaNSX { get; set; }
        public String TenNSX { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuoc_NhomVM
    {
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_Nhom
    {
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuoc_PhanLoaiVM
    {
        public String MaPL { get; set; }
        public String TenPL { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc_PhanLoai
    {
        public String MaPL { get; set; }
        public String TenPL { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMThuocVM
    {
        public String MaThuoc { get; set; }
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String MaPL { get; set; }
        public String TenPL { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaDangBaoChe { get; set; }
        public String TenDangBaoChe { get; set; }
        public String TenGoc { get; set; }
        public String TenTM { get; set; }
        public String HamLuong { get; set; }
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String MaNSX { get; set; }
        public String TenNSX { get; set; }
        public String GhiChu { get; set; }
        public String MaQG { get; set; }
        public String TenQG { get; set; }
        public String MaDuongDung { get; set; }
        public String TenDuongDung { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String SoDangKy { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMThuoc
    {
        public String MaThuoc { get; set; }
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String MaPL { get; set; }
        public String TenPL { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaDangBaoChe { get; set; }
        public String TenDangBaoChe { get; set; }
        public String TenGoc { get; set; }
        public String TenTM { get; set; }
        public String HamLuong { get; set; }
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String MaNSX { get; set; }
        public String TenNSX { get; set; }
        public String GhiChu { get; set; }
        public String MaQG { get; set; }
        public String TenQG { get; set; }
        public String MaDuongDung { get; set; }
        public String TenDuongDung { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String SoDangKy { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
}
