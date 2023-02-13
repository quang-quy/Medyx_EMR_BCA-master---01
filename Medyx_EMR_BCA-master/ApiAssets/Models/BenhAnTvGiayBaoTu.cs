using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTvGiayBaoTu : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string MaBn { get; set; }
        public string MaBa { get; set; }
        public string SoGiayBaoTu { get; set; }
        public string QuyenSo { get; set; }
        public string SoGiayBaoTuLanDau { get; set; }
        public string QuyenSoLanDau { get; set; }
        public DateTime? NgayCap { get; set; }
        public bool? Huy { get; set; }
        public string NguoiLap { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayLap { get; set; }
    }
}
