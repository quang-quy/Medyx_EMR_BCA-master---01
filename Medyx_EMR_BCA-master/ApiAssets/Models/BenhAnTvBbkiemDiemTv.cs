using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTvBbkiemDiemTv : ITrackableHuy, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public byte Stt { get; set; }
        public string MaNv { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public string VaiTro { get; set; }
        [JsonIgnore]
        public DmnhanVien DmThanhVien { get; set; }
        [JsonIgnore]
        public DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual BenhAn BenhAn { get; set; }
    }
}
