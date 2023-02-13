using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class TongKet15Ngay : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Stt { get; set; }
        public string DienBienLamSang { get; set; }
        public string XnlamSang { get; set; }
        public string QuaTrinhDt { get; set; }
        public string DanhGiaKq { get; set; }
        public string HuongDt { get; set; }
        public DateTime? NgayKyTruongKhoa { get; set; }
        public string TruongKhoa { get; set; }
        public DateTime? NgayKyBsdieuTri { get; set; }
        public string BsdieuTri { get; set; }
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
