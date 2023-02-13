using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaTgtvong
    {
        public string MaTgtvong { get; set; }
        public string TenTgtvong { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string GhiChu { get; set; }
    }
}
