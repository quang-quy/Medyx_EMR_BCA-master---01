using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnThuocThuPhanUng : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string PhuongPhapThu { get; set; }
        public string BschiDinh { get; set; }
        public string NguoiThu { get; set; }
        public string BsdocKq { get; set; }
        public DateTime? NgayDocKq { get; set; }
        public string KetQua { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiThu { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBschiDinh { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBsdocKq { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual BenhAnKhoaDieuTri BenhAnKhoaDieuTri { get; set; }
    }
}
