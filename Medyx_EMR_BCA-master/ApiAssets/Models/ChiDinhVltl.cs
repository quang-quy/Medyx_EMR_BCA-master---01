using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class ChiDinhVltl : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Stt { get; set; }
        public int Sttdv { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public DateTime? NgayThucHien { get; set; }
        public string DienBien { get; set; }
        public string MaDv { get; set; }
        public string LanLam { get; set; }
        public string ViTri { get; set; }
        public string Kq { get; set; }
        public string MaThuoc { get; set; }
        public string HamLuong { get; set; }
        public string DonVi { get; set; }
        public string CachDung { get; set; }
        public int? SoLuong { get; set; }
        public int? SoThang { get; set; }
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
