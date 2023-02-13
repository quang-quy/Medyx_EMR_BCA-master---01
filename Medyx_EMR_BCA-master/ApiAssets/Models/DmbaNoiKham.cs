using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaNoiKham
    {
        public string MaNoiKham { get; set; }
        public string TenNoiKham { get; set; }
        public string GhiChu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public virtual ICollection<BenhAn> BenhAns { get; set; }
    }
}
