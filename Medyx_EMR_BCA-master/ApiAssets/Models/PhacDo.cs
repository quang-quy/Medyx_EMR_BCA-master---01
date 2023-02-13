using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhacDo
    {
        public string MaPhacDo { get; set; }
        public string MaBenh { get; set; }
        public string GiaiDoan { get; set; }
        public byte? GioiTinh { get; set; }
        public byte? DoTuoiTu { get; set; }
        public byte? DoTuoiDen { get; set; }
        public string VungApDung { get; set; }
        public string MoTa { get; set; }
        public string XuTri { get; set; }
        public string TruocPhacDo { get; set; }
        public string SauPhacDo { get; set; }
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
