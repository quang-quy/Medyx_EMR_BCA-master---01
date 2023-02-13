using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichVuCs
    {
        public string MaCs { get; set; }
        public string MaDv { get; set; }
        public string TenCs { get; set; }
        public string ChisocaoNam { get; set; }
        public string ChisocaoNu { get; set; }
        public string ChisothapNu { get; set; }
        public string ChisothapNam { get; set; }
        public string DonViDo { get; set; }
        public string Maxn { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? Huy { get; set; }

        public virtual ICollection<BenhanClsKqcs> BenhanClsKqcses { get; set; }
        public virtual DmdichVu DmdichVu { get; set; }
    }
}
