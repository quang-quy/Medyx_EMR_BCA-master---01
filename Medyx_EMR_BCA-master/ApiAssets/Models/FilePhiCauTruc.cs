using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class FilePhiCauTruc : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public byte LoaiTaiLieu { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string TaiLiieuDinhKem { get; set; }
        public string Link { get; set; }
        public int Stt { get; set; }
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
