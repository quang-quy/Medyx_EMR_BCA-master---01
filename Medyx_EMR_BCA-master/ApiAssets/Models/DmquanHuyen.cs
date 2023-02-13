using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmquanHuyen
    {
        public string MaQh { get; set; }
        public string MaTinh { get; set; }
        public string TenQh { get; set; }
        public string MaBhxh { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string MaKhth { get; set; }
        public string Matat { get; set; }

        public virtual Dmtinh Dmtinh { get; set; } = new Dmtinh();
        public virtual ICollection<DmphuongXa> DmphuongXas { get; set; }
        public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
    }
}
