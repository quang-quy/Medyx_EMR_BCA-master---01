using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmphuongXa
    {
        public string MaPxa { get; set; }
        public string MaQh { get; set; }
        public string TenPxa { get; set; }
        public string MaBhxh { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string MaKhth { get; set; }
        public string Matat { get; set; }

        public virtual DmquanHuyen DmquanHuyen { get; set; } = new DmquanHuyen();
        public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
    }
}
