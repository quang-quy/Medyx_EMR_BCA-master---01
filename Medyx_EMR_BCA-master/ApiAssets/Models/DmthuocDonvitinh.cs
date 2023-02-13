using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmthuocDonvitinh
    {
        public string MaDvt { get; set; }
        public string TenDvt { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public virtual ICollection<Dmthuoc> Dmthuocs { get; set; }
    }
}
