using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmchephamMau
    {
        public string MaCpmau { get; set; }
        public string TenCpmau { get; set; }
        public string TenDvt { get; set; }
        public string TenTat { get; set; }
        public string MaByt { get; set; }
        public string TenByt { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public virtual ICollection<BenhanCpm> BenhanCpms { get; set; }               
    }
}
