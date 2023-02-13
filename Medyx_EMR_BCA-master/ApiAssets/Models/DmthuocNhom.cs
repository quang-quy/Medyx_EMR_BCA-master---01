using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmthuocNhom
    {
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
    }
}
