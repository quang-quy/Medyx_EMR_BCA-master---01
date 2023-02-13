using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DotDieuTri : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string SoPhieu { get; set; }
        public string DoiTuong { get; set; }
        public byte LoaiBa { get; set; }
        public string Ppdt { get; set; }
        public string KhamBenh { get; set; }
        public string XuTri { get; set; }
        public string Kq { get; set; }
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
