using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaLdchuyenVien
    {
        public string MaLdchuyenvien { get; set; }
        public string TenLdchuyenvien { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string Ghichu { get; set; }
        public string MaByte { get; set; }
    }
}
