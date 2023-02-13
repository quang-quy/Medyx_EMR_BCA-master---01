using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmthuocBaiThuocC
    {
        public string MaBthuoc { get; set; }
        public byte Stt { get; set; }
        public string MaThuoc { get; set; }
        public decimal? Soluong { get; set; }
        public string LieuDung { get; set; }
        public string CachDung { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }

        public virtual Dmthuoc Dmthuoc { get; set; }
    }
}
