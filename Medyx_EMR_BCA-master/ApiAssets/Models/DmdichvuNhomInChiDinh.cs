using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichvuNhomInChiDinh
    {
        public decimal Stt { get; set; }
        public string MaPhieu { get; set; }
        public string TenPhieu { get; set; }
        public string MaDv { get; set; }
        public decimal? Sttin { get; set; }
        public bool? Huy { get; set; }
        public DateTime? Ngayhuy { get; set; }
        public string NguoiHuy { get; set; }

        [JsonIgnore]
        public virtual ICollection<BenhanCls> BenhanClss { get; set; }
    }
}
