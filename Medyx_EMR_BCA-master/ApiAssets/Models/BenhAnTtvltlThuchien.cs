using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTtvltlThuchien : ITrackableIDBA, ITrackableCreate, ITrackableUpdate, ITrackableHuy
    {
        public int Stt { get; set; }
        public decimal Idba { get; set; }
        public string Idhis { get; set; }
        public int SttdotDt { get; set; }
        public int SttchiDinh { get; set; }
        public DateTime? NgayThucHien { get; set; }
        public string MaDv { get; set; }
        public string ThoiGian { get; set; }
        public string LieuLuong { get; set; }
        public string GhiChu { get; set; }
        public string NguoiThucHien { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }

        [JsonIgnore]
        public virtual BenhanTtvltlDotDieuTri BenhanTtvltlDotDieuTri { get; set; }
        [JsonIgnore]
        public virtual BenhanTtvltl BenhanTtvltl { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual DmdichVu DmdichVu { get; set; }
    }
}
