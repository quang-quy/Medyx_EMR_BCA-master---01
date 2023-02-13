using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichVuLoaiHinh
    {
        public string MaLh { get; set; }
        public string TenLh { get; set; }
        public string MaChungLoai { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
    }
}
