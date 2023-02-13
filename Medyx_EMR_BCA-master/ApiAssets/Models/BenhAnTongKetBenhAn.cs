using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnTongKetBenhAn : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string LyDoVv { get; set; }
        public string QuaTrinhBenhLy { get; set; }
        public string TomTatKetQuaCls { get; set; }
        public string PpdttheoYhhd { get; set; }
        public string PpdttheoYhct { get; set; }
        public string Kqdt { get; set; }
        public string TinhTrangBnrv { get; set; }
        public string HuongDt { get; set; }
        public int? SoToXquang { get; set; }
        public int? SoToCt { get; set; }
        public int? SoToMri { get; set; }
        public int? SoToSa { get; set; }
        public int? SoToXn { get; set; }
        public string Khac { get; set; }
        public int? SoToKhac { get; set; }
        public int? SoToToanBoHs { get; set; }
        public string NguoiGiaoHs { get; set; }
        public string NguoiNhanHs { get; set; }
        public DateTime? NgayKy { get; set; }
        public string BsdieuTri { get; set; }
        public string VanDong { get; set; }
        public string ChucNangShhangNgay { get; set; }
        public string NhanThuc { get; set; }
        public string ChucNangKhac { get; set; }
        public string ThamGiaHoatDong { get; set; }
        public string YeuToMoiTruong { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBsDieutri { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiGiao { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiNhan { get; set; }
    }
}
