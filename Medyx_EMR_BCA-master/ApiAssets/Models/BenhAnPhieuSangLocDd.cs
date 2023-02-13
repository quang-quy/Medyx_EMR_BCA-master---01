using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnPhieuSangLocDd : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public DateTime? NgayDg { get; set; }
        public int LanDg { get; set; }
        public string NguoiDg { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
        public decimal? Bmi { get; set; }
        public byte? SutCan { get; set; }
        public byte? SoCanSut { get; set; }
        public decimal? ChiSoSutCan { get; set; }
        public byte? AnKem { get; set; }
        public decimal? ChiSoNgonMieng { get; set; }
        public decimal? ChiSoMst { get; set; }
        public string DanhGiaTheoMst { get; set; }
        public string CanThiepDd { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
