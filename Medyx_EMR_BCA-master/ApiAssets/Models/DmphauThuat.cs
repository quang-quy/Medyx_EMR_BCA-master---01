using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmphauThuat
    {
        public string MaPt { get; set; }
        public string TenPt { get; set; }
        public string MaNhomdv { get; set; }
        public string MaPlpttt { get; set; }
        public string TenTat { get; set; }
        public string MaChungloai { get; set; }
        public string MaByt { get; set; }
        public string TenByt { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? Huy { get; set; }

        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuats { get; set; }
    }
}
