using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class Pttt : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Stt { get; set; }
        public DateTime? NgayPt { get; set; }
        public string ChanDoanTruocPt { get; set; }
        public string ChanDoanSauPt { get; set; }
        public string PhuongPhap { get; set; }
        public string Loai { get; set; }
        public string PhuongPhapVoCam { get; set; }
        public string Bspt { get; set; }
        public string BsgayMe { get; set; }
        public string LuocDoPt { get; set; }
        public string DanLuu { get; set; }
        public string Bac { get; set; }
        public DateTime? NgayRutChi { get; set; }
        public DateTime? NgayCatChi { get; set; }
        public string Khac { get; set; }
        public string TrinhTuPt { get; set; }
        public DateTime? NgayKy { get; set; }
        public string Ptvien { get; set; }
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
