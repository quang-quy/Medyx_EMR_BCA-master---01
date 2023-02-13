using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmchucVu
    {
        public string MaCv { get; set; }
        public string TenCv { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
    }
}
