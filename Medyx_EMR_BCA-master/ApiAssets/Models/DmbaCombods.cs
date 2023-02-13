using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbaCombods
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MaParent { get; set; }
        public string TenParent { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
    }
}
