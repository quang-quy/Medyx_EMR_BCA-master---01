using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class GiayChuyenTuyen : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int So { get; set; }
        public string SoLuuTru { get; set; }
        public string VaoSoChuyenTuyen { get; set; }
        public string MaNoiChuyenDen { get; set; }
        public string MaKhoa1 { get; set; }
        public string TuyenKhoa1 { get; set; }
        public DateTime? KhamTn1 { get; set; }
        public DateTime? KhamDn1 { get; set; }
        public string MaKhoa2 { get; set; }
        public string TuyenKhoa { get; set; }
        public DateTime? KhamTn2 { get; set; }
        public DateTime? KhamDn2 { get; set; }
        public string DauHieuLamSang { get; set; }
        public string Kqxn { get; set; }
        public string ChanDoan { get; set; }
        public string TtthuocDaSuDung { get; set; }
        public string TinhTrangBnchuyenTuyen { get; set; }
        public string LyDoChuyen { get; set; }
        public DateTime? NgayChuyen { get; set; }
        public string PhuongTien { get; set; }
        public string NguoiHoTong { get; set; }
        public string BsdieuTri { get; set; }
        public DateTime? NgayKy { get; set; }
        public string NguoiDuyet { get; set; }
        public string DiaChi { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
