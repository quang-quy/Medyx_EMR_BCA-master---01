using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichvuPhanLoaiPttt
    {
        public string MaPlpttt { get; set; }
        public string TenPlpttt { get; set; }
        public bool? Huy { get; set; }

        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPttts { get; set; }
    }
}
