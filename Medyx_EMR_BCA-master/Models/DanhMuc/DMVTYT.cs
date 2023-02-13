using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMVTYT
    {
        public String MaVT { get; set; }
        public String TenTM { get; set; }
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMVTYTVM
    {
        public String MaVT { get; set; }
        public String TenTM { get; set; }
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String MaBYT { get; set; }
        public String TenBYT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMVTYT_DonvitinhVM
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
    public class DMVTYT_Donvitinh
    {
        public String MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMVTYT_NhomVM
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
    public class DMVTYT_Nhom
    {
        public String MaNhom { get; set; }
        public String TenNhom { get; set; }
        public String GhiChu { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
}
