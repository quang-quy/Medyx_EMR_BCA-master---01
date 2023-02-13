using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichvuGoi
    {
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public byte? Loai { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string MaBs { get; set; }
        public string Ghichu { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
    }
}
