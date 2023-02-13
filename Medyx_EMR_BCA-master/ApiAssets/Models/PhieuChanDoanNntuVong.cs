using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuChanDoanNntuVong : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBn { get; set; }
        public string SoPhieu { get; set; }
        public DateTime? NgayTv { get; set; }
        public string NguyenNhanA { get; set; }
        public string ThoiGianA { get; set; }
        public string NguyenNhanB { get; set; }
        public string ThoiGianB { get; set; }
        public string NguyenNhanC { get; set; }
        public string ThoiGianC { get; set; }
        public string NguyenNhanD { get; set; }
        public string ThoiGianD { get; set; }
        public string NguyenNhan2 { get; set; }
        public string ThoiGian2 { get; set; }
        public byte? PhauThuat { get; set; }
        public DateTime? NgayPhauThuat { get; set; }
        public string LyDoPt { get; set; }
        public byte? Kntt { get; set; }
        public byte? Sdkq { get; set; }
        public byte? HinhThucTv { get; set; }
        public DateTime? NgayChanThuong { get; set; }
        public string NguyenNhanChanThuong { get; set; }
        public string MoTaNguyenNhanChanThuong { get; set; }
        public byte? NoiTuVong { get; set; }
        public string NoiTv { get; set; }
        public byte? DaThai { get; set; }
        public byte? SinhNon { get; set; }
        public string GioSongSauSinh { get; set; }
        public string CanNang { get; set; }
        public string SoTuanMangThai { get; set; }
        public string TuoiMe { get; set; }
        public string ChuSinh { get; set; }
        public byte? MangThai { get; set; }
        public byte? ThoiDiemMangThai { get; set; }
        public byte? MangThaiGayTv { get; set; }
        public bool? Tvcc { get; set; }
        public string MaNntv { get; set; }
        public string TenNntv { get; set; }
        public string MaBa { get; set; }
        public string SoGiayBaoTu { get; set; }
        public string QuyenSo { get; set; }
        public string SoGiayBaoTuLanDau { get; set; }
        public string QuyenSoLanDau { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayCap { get; set; }
        public string NguoiLap { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayLap { get; set; }
    }
}
