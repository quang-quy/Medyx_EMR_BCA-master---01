using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMKhoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DiaDiem { get; set; }
        public byte Loai { get; set; }
        public string MaBYT { get; set; }
        public string Ghichu { get; set; }
        public decimal? Sogiuong { get; set; }
        public string MaNVTruongKhoa { get; set; }
        public string TenNVTruongKhoa { get; set; }
        public string MaNVDieuDuongTruong { get; set; }
        public string TenNVDieuDuongTruong { get; set; }
        //public byte Cap { get; set; }
        //public string Machuyenkhoa { get; set; }
        public string MaMay { get; set; }
        public bool Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public string NguoiSD { get; set; }
        //public bool KhongHD { get; set; }
        //public string MaNhom { get; set; }
        //public string MaKhoaBC { get; set; }
        //public string KhoaNT { get; set; }
        //public string MaKhoaQL { get; set; }
        //public string MaDV { get; set; }
        //public string MaBYTe { get; set; }
        //public string TenTA { get; set; }
    }
    public class DMKhoaVM
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DiaDiem { get; set; }
        public byte Loai { get; set; }
        public string MaBYT { get; set; }
        public string Ghichu { get; set; }
        public decimal? Sogiuong { get; set; }
        public string MaNVTruongKhoa { get; set; }
        public string TenNVTruongKhoa { get; set; }
        public string MaNVDieuDuongTruong { get; set; }
        public string TenNVDieuDuongTruong { get; set; }
        //public byte Cap { get; set; }
        //public string Machuyenkhoa { get; set; }
        public string MaMay { get; set; }
        public bool Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public string NguoiSD { get; set; }
        //public bool KhongHD { get; set; }
        //public string MaNhom { get; set; }
        //public string MaKhoaBC { get; set; }
        //public string KhoaNT { get; set; }
        //public string MaKhoaQL { get; set; }
        //public string MaDV { get; set; }
        //public string MaBYTe { get; set; }
        //public string TenTA { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMKhoaVm
    {
        public DMKhoaVm()
        {
            this.nodes = new List<DMKhoaVm>();
        }

        public String MaKhoa { get; set; }
        //[JsonProperty(PropertyName = "text")]
        public String TenKhoa { get; set; }
        public string text
        {
            get { return this.TenKhoa; }
            set { this.TenKhoa = value; }
        }
        public String TenTA { get; set; }
        public String DiaDiem { get; set; }
        public Byte? Loai { get; set; }
        public Byte? Cap { get; set; }
        public String Machuyenkhoa { get; set; }
        public String MaMay { get; set; }
        public Boolean? Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String Ghichu { get; set; }
        public Boolean? KhongHD { get; set; }
        public Decimal? Sogiuong { get; set; }
        public String MaNhom { get; set; }
        public String MAKHOABC { get; set; }
        public String MaDV { get; set; }
        public String mabyte { get; set; }
        public String MaKhoaQL { get; set; }
        public String idparent { get; set; }
        public String HOTEN { get; set; }
        public String TENNHOM { get; set; }
        public String TenCK { get; set; }
        //[JsonProperty(PropertyName = "nodes")]
        public List<DMKhoaVm> nodes { get; set; }
    }
    public class DMKhoa_BuongVM
    {
        public String MaBuong { get; set; }
        public String TenBuong { get; set; }
        public String MaKhoa { get; set; }
        public String TenKhoa { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMKhoa_Buong
    {
        public String MaBuong { get; set; }
        public String TenBuong { get; set; }
        public String MaKhoa { get; set; }
        public String TenKhoa { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMKhoa_GiuongVM
    {
        public String MaGiuong { get; set; }
        public String TenGiuong { get; set; }
        public String MaKhoa { get; set; }
        public String TenKhoa { get; set; }
        public String MaBuong { get; set; }
        public String TenBuong { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMKhoa_Giuong
    {
        public String MaGiuong { get; set; }
        public String TenGiuong { get; set; }
        public String MaBuong { get; set; }
        public String TenBuong { get; set; }
        public String MaKhoa { get; set; }
        public String TenKhoa { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
}
