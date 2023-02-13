using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuDienNao : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int So { get; set; }
        public int LanThu { get; set; }
        public string YeuCau { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string BschiDinh { get; set; }
        public DateTime? NgayHenGhiDienNao { get; set; }
        public string Ttbn { get; set; }
        public string Kq { get; set; }
        public string MoTa { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayKyKq { get; set; }
        public string BschuyenKhoa { get; set; }
        public string MaMayThucHien { get; set; }
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
