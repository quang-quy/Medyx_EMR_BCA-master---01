using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class Dmtinh
    {
        public string MaTinh { get; set; }
        public string MaQu { get; set; }
        public string MaVungLt { get; set; }
        public string TenTinh { get; set; }
        public string MaBhyt { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string Matat { get; set; }

        public virtual ICollection<DmquanHuyen> DmquanHuyens { get; set; }
        public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
    }
}
