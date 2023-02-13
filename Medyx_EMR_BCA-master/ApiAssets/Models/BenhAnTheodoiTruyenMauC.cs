using System;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTheodoiTruyenMauC : ITrackableIDBA, ITrackable
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public int StttruyenMau { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string TocDo { get; set; }
        public string MauSacDa { get; set; }
        public int? NhipTho { get; set; }
        public int? Mach { get; set; }
        public string HuyetAp { get; set; }
        public decimal? NhietDo { get; set; }
        public string DienBienKhac { get; set; }
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

    }
}
