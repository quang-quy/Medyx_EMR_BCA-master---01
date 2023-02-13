using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaHuongDt
    {
        public string MaHdt { get; set; }
        public string TenHdt { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public byte? Loai { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
    }
}
