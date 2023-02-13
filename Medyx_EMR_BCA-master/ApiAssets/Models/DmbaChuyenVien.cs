using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaChuyenVien
    {
        public string MaChuyenvien { get; set; }
        public string TenChuyenvien { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string Ghichu { get; set; }
        public string MaByte { get; set; }
        public virtual ICollection<BenhAn> BenhAns { get; set; }
    }
}
