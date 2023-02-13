using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmthuocNhaSx
    {
        public string MaNsx { get; set; }
        public string TenNsx { get; set; }
        public string MaQg { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
    }
}
