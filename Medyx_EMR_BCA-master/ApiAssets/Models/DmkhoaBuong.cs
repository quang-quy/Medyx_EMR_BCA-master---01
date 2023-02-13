using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmkhoaBuong
    {
        public string MaBuong { get; set; }
        public string TenBuong { get; set; }
        public string MaKhoa { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public virtual Dmkhoa Dmkhoa { get; set; } = new Dmkhoa();
        public ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        public ICollection<BenhAn> BenhAns { get; set; }
        public ICollection<DmkhoaGiuong> DmkhoaGiuongs { get; set; }
    }
}
