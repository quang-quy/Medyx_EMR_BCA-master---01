using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class ThucHienVltl : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string SoPhieu { get; set; }
        public DateTime? NgayTh { get; set; }
        public string MaDv { get; set; }
        public int? LanThucHien { get; set; }
        public int? ThoiGianThucHien { get; set; }
        public string ViTri { get; set; }
        public string MaThuoc { get; set; }
        public string HamLuong { get; set; }
        public string DonVi { get; set; }
        public string CachDung { get; set; }
        public int? SoLuongThuoc { get; set; }
        public string NguoiThucHien { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
