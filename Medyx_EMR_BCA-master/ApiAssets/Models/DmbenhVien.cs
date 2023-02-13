using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbenhVien
    {
        public string MaBv { get; set; }
        public string TenBv { get; set; }
        public string TenTa { get; set; }
        public string MaBhxh { get; set; }
        public string Matinh { get; set; }
        public string Diachi { get; set; }
        public string Tel { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public virtual ICollection<BenhAn> BenhAns { get; set; }
    }
}
