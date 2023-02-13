using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmchuyenMon
    {
        public string MaChuyenMon { get; set; }
        public string TenChuyenMon { get; set; }
        public string MaMay { get; set; }
        public byte? Cap { get; set; }
        public string Loai { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string GhiChu { get; set; }
    }
}
