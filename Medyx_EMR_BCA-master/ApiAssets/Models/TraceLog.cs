using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class TraceLog
    {
        public decimal Id { get; set; }
        public string TenBang { get; set; }
        public string MaBn { get; set; }
        public string KieuTacDong { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string NoiDungSd { get; set; }
        public string MaMay { get; set; }
    }
}
