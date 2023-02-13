using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BienBanKiemDiemTuVong : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Stt { get; set; }
        public DateTime? NgayTuVong { get; set; }
        public string Buong { get; set; }
        public string KhoaTuVong { get; set; }
        public DateTime? ThoiGianKiemDiem { get; set; }
        public string ChuToa { get; set; }
        public string ThuKy { get; set; }
        public string TomTatQtbenh { get; set; }
        public string KetLuan { get; set; }
        public DateTime? NgayKy { get; set; }
        public string NguoiHuy { get; set; }
        public string TinhTrangVv { get; set; }
        public string ChanDoan { get; set; }
        public string TomTatDienBien { get; set; }
        public string TiepDonBn { get; set; }
        public string ThamKham { get; set; }
        public string DieuTri { get; set; }
        public string ChamSoc { get; set; }
        public string QuanHeVoiGdbn { get; set; }
        public string YkienBoSung { get; set; }
        public string HopTai { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
    }
}
