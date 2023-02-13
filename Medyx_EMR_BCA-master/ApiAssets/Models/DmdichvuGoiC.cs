using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichvuGoiC
    {
        public string MaGoi { get; set; }
        public byte Stt { get; set; }
        public string MaDv { get; set; }
        public decimal? Soluong { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
    }
}
