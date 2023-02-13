using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuHoiChan : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string MaKhoaDt { get; set; }
        public string So { get; set; }
        public string BienBanHoiChan { get; set; }
        public DateTime? NgayHoiChan { get; set; }
        public string ChuToa { get; set; }
        public string ThuKy { get; set; }
        public string TomTatDienBienBenh { get; set; }
        public string KetLuan { get; set; }
        public string HuongDttiep { get; set; }
        public DateTime? NgayKy { get; set; }
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
