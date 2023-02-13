using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.HSBA
{
    public class TrichLucHSBA
    {
    }
    public class HSBAVM
    {
        public Decimal ID { get; set; }
        public String MaBA { get; set; }
        public String MABN { get; set; }
        public String HoTen { get; set; }
        public String GT { get; set; }
        public DateTime? NgaySinh { get; set; }
        public String KhoaDT { get; set; }
        public String MaKhoaDT { get; set; }
        public String TenBenh { get; set; }
        public DateTime? NgayVV { get; set; }
        public DateTime? NgayRV { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class HSBA
    {
        public Decimal ID { get; set; }
        public String MaBA { get; set; }
        public String MABN { get; set; }
        public String HoTen { get; set; }
        public String GT { get; set; }
        public DateTime? NgaySinh { get; set; }
        public String KhoaDT { get; set; }
        public String MaKhoaDT { get; set; }
        public String TenBenh { get; set; }
        public DateTime? NgayVV { get; set; }
        public DateTime? NgayRV { get; set; }
    }
    public class DeNghiTrichLuc
    {
        public Decimal SoPhieu { get; set; }
        public String MaBA { get; set; }
        public Byte LoaiDeNghi { get; set; }
        public String TenLoaiDeNghi { get; set; }
        public Boolean Duyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public String HoTenNguoiDeNghi { get; set; }
        public DateTime? NgaySinhNguoiDN { get; set; }
        public String SoCMT { get; set; }
        public DateTime? NgayCapCMT { get; set; }
        public String NoiCapCMT { get; set; }
        public String QHBN { get; set; }
        public String HoTenBN { get; set; }
        public String DiaChi { get; set; }
        public String TGVQ { get; set; }
        public String MaKhoaDT { get; set; }
        public String TenKhoaDT { get; set; }
        public DateTime TuNgayDT { get; set; }
        public DateTime DenNgayDT { get; set; }
        public String LyDo { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String TenNguoiSD { get; set; }
        public DateTime? NgayLap { get; set; }
        public String NguoiLap { get; set; }
        public String DVCT { get; set; }
        public String NhamLan { get; set; }
        public String CMNhamLan { get; set; }
        public String MatRach { get; set; }
    }
    public class DeNghiTrichLucVM
    {
        public Decimal SoPhieu { get; set; }
        public String MaBA { get; set; }
        public Byte LoaiDeNghi { get; set; }
        public String TenLoaiDeNghi { get; set; }
        public Boolean Duyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public String HoTenNguoiDeNghi { get; set; }
        public DateTime? NgaySinhNguoiDN { get; set; }
        public String SoCMT { get; set; }
        public DateTime? NgayCapCMT { get; set; }
        public String NoiCapCMT { get; set; }
        public String QHBN { get; set; }
        public String HoTenBN { get; set; }
        public String DiaChi { get; set; }
        public String TGVQ { get; set; }
        public String MaKhoaDT { get; set; }
        public String TenKhoaDT { get; set; }
        public DateTime TuNgayDT { get; set; }
        public DateTime DenNgayDT { get; set; }
        public String LyDo { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String TenNguoiSD { get; set; }
        public DateTime? NgayLap { get; set; }
        public String NguoiLap { get; set; }
        public String DVCT { get; set; }
        public String NhamLan { get; set; }
        public String CMNhamLan { get; set; }
        public String MatRach { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMLoaiDNTL
    {
        public Byte LoaiDN { get; set; }
        public String TenLoaiDN { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public DateTime? NgayLap { get; set; }
        public String NguoiLap { get; set; }
    }
}
