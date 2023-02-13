using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnGiayChuyenTuyen : ITrackableIDBA
    {
        public int Stt { get; set; }
        public decimal Idba { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public string SoPhieu { get; set; }
        public string SoSoChuyenTuyen { get; set; }
        public string MaNoiChuyenDen { get; set; }
        public string MaKhoa1 { get; set; }
        public string MaKhoa1TuyenKhoa { get; set; }
        public DateTime? MaKhoa1Tn { get; set; }
        public DateTime? MaKhoa1Dn { get; set; }
        public string MaKhoa2 { get; set; }
        public string MaKhoa2TuyenKhoa { get; set; }
        public DateTime? MaKhoa2Tn { get; set; }
        public DateTime? MaKhoa2Dn { get; set; }
        public string DauHieuLamSang { get; set; }
        public string Kqxn { get; set; }
        public string ChanDoan { get; set; }
        public string ThuocDaSuDung { get; set; }
        public string TinhTrangBn { get; set; }
        public byte? LyDoChuyen { get; set; }
        public DateTime? NgayChuyen { get; set; }
        public string PhuongTien { get; set; }
        public string NguoiHoTong { get; set; }
        public string BsdieuTri { get; set; }
        public string LanhDao { get; set; }
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
