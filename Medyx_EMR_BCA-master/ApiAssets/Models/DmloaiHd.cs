using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmloaiHd
    {
        public string MaLoaiHd { get; set; }
        public string TenLoaiHd { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string GhiChu { get; set; }
    }
}
