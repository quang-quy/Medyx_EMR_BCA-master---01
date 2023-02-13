using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhanClsKqcs : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string SoPhieu { get; set; }
        public string Idlis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Sttdv { get; set; }
        public string MaDv { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string MaCs { get; set; }
        public string TenCs { get; set; }
        public string Kq { get; set; }
        public string DonViDo { get; set; }
        public string ChiSoBinhThuongNam { get; set; }
        public string ChiSoBinhThuongNu { get; set; }
        public string ChiSoBinhThuongNhi { get; set; }
        public string BatThuong { get; set; }
        public string MaMayThucHien { get; set; }
        public string KetLuan { get; set; }
        public string Ktv { get; set; }
        public DateTime? NgayTraKq { get; set; }
        public DateTime? NgayKyKq { get; set; }
        public string NguoiDuyetKq { get; set; }
        public string MaKhoaThucHien { get; set; }
        public string LinkPacsLis { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmKtv { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiDuyetKq { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual Dmkhoa DmKhoaThucHien { get; set; }
        [JsonIgnore]
        public virtual BenhanCls BenhanCls { get; set; }
        [JsonIgnore]
        public virtual DmdichVuCs DmdichVuCs { get; set; }
    }
}
