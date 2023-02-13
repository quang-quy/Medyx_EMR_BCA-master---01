using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmquocGia
    {
        public string MaQg { get; set; }
        public string TenQg { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
        public virtual ICollection<Dmthuoc> Dmthuocs { get; set; }
    }
}
