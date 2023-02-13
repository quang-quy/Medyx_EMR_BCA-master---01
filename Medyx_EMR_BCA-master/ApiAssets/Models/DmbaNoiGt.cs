using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaNoiGt
    {
        public string MaNoiGt { get; set; }
        public string TenNoiGt { get; set; }
        public string MaMay { get; set; }
        public bool Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public virtual ICollection<BenhAn> BenhAns { get; set; }
    }
}
