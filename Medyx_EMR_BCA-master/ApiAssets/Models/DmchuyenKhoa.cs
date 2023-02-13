using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmchuyenKhoa
    {
        public string MaCk { get; set; }
        public string TenCk { get; set; }
        public string MaMay { get; set; }
        public string MaByt { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
    }
}
