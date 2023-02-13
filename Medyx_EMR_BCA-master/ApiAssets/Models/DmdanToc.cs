using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdanToc
    {
        public string MaDanToc { get; set; }
        public string TenDanToc { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string MaQl { get; set; }
        public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
    }
}
