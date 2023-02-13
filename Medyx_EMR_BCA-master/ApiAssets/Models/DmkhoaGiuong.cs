using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmkhoaGiuong
    {
        public string MaGiuong { get; set; }
        public string TenGiuong { get; set; }
        public string MaKhoa { get; set; }
        public string MaBuong { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        public ICollection<BenhAn> BenhAns { get; set; }
        public virtual DmkhoaBuong DmkhoaBuong { get; set; } = new DmkhoaBuong();
    }
}
