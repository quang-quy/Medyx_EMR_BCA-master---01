using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTvBbkiemDiem : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public string MaKhoa { get; set; }
        public string SoPhieu { get; set; }
        public DateTime? NgayTuVong { get; set; }
        public DateTime? ThoiGianKiemDiem { get; set; }
        public string ChuToa { get; set; }
        public string ThuKy { get; set; }
        public string NoiHop { get; set; }
        public string NguyenNhanTv { get; set; }
        public string TomTatQtbenh { get; set; }
        public string KetLuan { get; set; }
        public DateTime? NgayKy { get; set; }
        public string NguoiHuy { get; set; }
        public string TinhTrangVv { get; set; }
        public string ChanDoan { get; set; }
        public string TomTatDienBien { get; set; }
        public string TiepDonBn { get; set; }
        public string ThamKham { get; set; }
        public string DieuTri { get; set; }
        public string ChamSoc { get; set; }
        public string QuanHeVoiGdbn { get; set; }
        public string YkienBoSung { get; set; }
        public string HopTai { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmChuToa { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmThuKy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual BenhAn BenhAn { get; set; }
        [JsonIgnore]
        public virtual BenhAnKhoaDieuTri BenhAnKhoaDieuTri { get; set; }
    }
}
