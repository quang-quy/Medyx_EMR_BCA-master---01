using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdoiTuong
    {
        public string MaDt { get; set; }
        public string TenDt { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
        public virtual ICollection<BenhAnKhamVaoVien> BenhAnKhamVaoViens { get; set; }
    }
}
