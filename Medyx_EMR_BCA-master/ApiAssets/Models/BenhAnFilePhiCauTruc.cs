using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnFilePhiCauTruc : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public byte LoaiTaiLieu { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttdv { get; set; }
        public string TaiLiieuDinhKem { get; set; }
        public string Link { get; set; }
        public byte? Loai { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual DmbaLoaiTaiLieu DmbaLoaiTaiLieu { get; set; }
        [JsonIgnore]
        public virtual BenhAnKhoaDieuTri BenhAnKhoaDieuTri { get; set; }
        [JsonIgnore]
        public virtual BenhanCls BenhanCls { get; set; }
        [JsonIgnore]
        public virtual BenhanTtvltl BenhanTtvltl { get; set; }
        [JsonIgnore]
        public virtual BenhanPhauThuat BenhanPhauThuat { get; set; }
        [JsonIgnore]
        public virtual BenhanCpm BenhanCpm { get; set; }
    }
}
