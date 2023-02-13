using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaHtraVien
    {
        public string MaHtraVien { get; set; }
        public string TenHtraVien { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string GhiChu { get; set; }
        public string Mabyte { get; set; }
        public virtual ICollection<BenhAn> BenhAns { get; set; }
    }
}
