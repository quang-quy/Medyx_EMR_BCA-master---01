using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTheoDoiTruyenMau : ITrackableIDBA, ITrackable
    {
        public int Stt { get; set; }
        public decimal Idba { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public int? Sttcpm { get; set; }
        public DateTime? NgayXnhoaHop { get; set; }
        public string MaCpm { get; set; }
        public decimal? TheTich { get; set; }
        public string MaSoCmp { get; set; }
        public DateTime? NgayDieuChe { get; set; }
        public DateTime? HanSd { get; set; }
        public string NhomMau { get; set; }
        public string Rh { get; set; }
        public string NhomMauCpm { get; set; }
        public string KqpuhoaHopMuoiOng1 { get; set; }
        public string KqpuhoaHopMuoiOng2 { get; set; }
        public string KqpuhoaHop37doOng1 { get; set; }
        public string KqpuhoaHop37doOng2 { get; set; }
        public string TenKqxnkhac { get; set; }
        public string KqpuhoaHop { get; set; }
        public string HoTenTruongKhoaXn { get; set; }
        public string HoTenNguoiXn1 { get; set; }
        public string HoTenNguoiXn2 { get; set; }
        public string Kqxncheo { get; set; }
        public byte? LanTruyenMau { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public decimal? Sltruyen { get; set; }
        public string NhanXet { get; set; }
        public string BstheoDoi { get; set; }
        public string DieuDuong { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual BenhanCpm BenhanCpm { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmDieuDuong { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBsTheoDoi { get; set; }
    }
}
