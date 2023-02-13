using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx.ApiAssets.Dto.Print
{
    public class ThuocThuPhanUngDetailPrintDto{
        public string NgayBatDau { get; set; }
        public string TenThuoc { get; set; }
        public string PhuongPhapThu { get; set; }
        public string BsChiDinh { get; set; }
        public string NguoiThu { get; set; }
        public string BsDocKQ { get; set; }
        public string NgayDocKQ { get; set; }
        public string KetQua { get; set; }
    }

    public class BenhAnThuocThuPhanUngPrintDto
    {
        public string SoYTe { get; set; }
        public string SoVaoVien { get; set; }
        public string BenhVien { get; set; }
        public string HoTen { get; set; }
        public string Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Khoa { get; set; }
        public string Buong { get; set; }
        public string Giuong { get; set; }
        public string ChanDoan { get; set; }
        public List<ThuocThuPhanUngDetailPrintDto> Detail { get; set; }
    }
}