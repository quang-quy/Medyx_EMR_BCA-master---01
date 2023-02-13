using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMDichVu
    {
        public String MaDV { get; set; }
        public String TenDV { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaLH { get; set; }
        public String TenLH { get; set; }
        public String MaPLPTTT { get; set; }
        public String TenPLPTTT { get; set; }
        public String TenTat { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String MaNhomDV { get; set; }
        public String TenNhomDV { get; set; }
        public String MaXN { get; set; }
        public String ChisocaoNu { get; set; }
        public String ChisocaoNam { get; set; }
        public String ChisothapNu { get; set; }
        public String ChisothapNam { get; set; }
        public String DonViDo { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMDichVuVM
    {
        public String MaDV { get; set; }
        public String TenDV { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaLH { get; set; }
        public String TenLH { get; set; }
        public String MaPLPTTT { get; set; }
        public String TenPLPTTT { get; set; }
        public String TenTat { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String MaNhomDV { get; set; }
        public String TenNhomDV { get; set; }
        public String MaXN { get; set; }
        public String ChisocaoNu { get; set; }
        public String ChisocaoNam { get; set; }
        public String ChisothapNu { get; set; }
        public String ChisothapNam { get; set; }
        public String DonViDo { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMDichVu_ChungLoaiVM
    {
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMDichVu_ChungLoai
    {
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMDichVu_LoaiHinhVM
    {
        public String MaLH { get; set; }
        public String TenLH { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMDichVu_LoaiHinh
    {
        public String MaLH { get; set; }
        public String TenLH { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMDichVu_NhomVM
    {
        public String MaNhomDV { get; set; }
        public String TenNhomDV { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMDichVu_Nhom
    {
        public String MaNhomDV { get; set; }
        public String TenNhomDV { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMDichVu_PhanLoaiPTTTVM
    {
        public String MaPLPTTT { get; set; }
        public String TenPLPTTT { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMDichVu_PhanLoaiPTTT
    {
        public String MaPLPTTT { get; set; }
        public String TenPLPTTT { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMDichVu_CS
    {
        public String MaCS { get; set; }
        public String TenCS { get; set; }
        public String MaDV { get; set; }
        public String TenDV { get; set; }
        public String ChisocaoNu { get; set; }
        public String ChisocaoNam { get; set; }
        public String ChisothapNu { get; set; }
        public String ChisothapNam { get; set; }
        public String DonViDo { get; set; }
        public String MaXN { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMDichVu_CSVM
    {
        public String MaCS { get; set; }
        public String TenCS { get; set; }
        public String MaDV { get; set; }
        public String TenDV { get; set; }
        public String ChisocaoNu { get; set; }
        public String ChisocaoNam { get; set; }
        public String ChisothapNu { get; set; }
        public String ChisothapNam { get; set; }
        public String DonViDo { get; set; }
        public String MaXN { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMPhauThuat
    {
        public String MaPT { get; set; }
        public String TenPT { get; set; }
        public String MaNhomDV { get; set; }
        public String TenNhomDV { get; set; }
        public String MaPLPTTT { get; set; }
        public String TenPLPTTT { get; set; }
        public String TenTat { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMPhauThuatVM
    {
        public String MaPT { get; set; }
        public String TenPT { get; set; }
        public String MaNhomDV { get; set; }
        public String TenNhomDV { get; set; }
        public String MaPLPTTT { get; set; }
        public String TenPLPTTT { get; set; }
        public String TenTat { get; set; }
        public String MaChungLoai { get; set; }
        public String TenChungLoai { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
}
