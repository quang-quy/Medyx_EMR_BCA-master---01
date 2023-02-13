using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnTvPhieuCdnguyenNhanDto
    {
        public decimal Idba { get; set; }
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
        public string HinhThucTv { get; set; }
        public DateTime? NgayChanThuong { get; set; }
        public string NguyenNhanChanThuong { get; set; }
        public string MoTaNguyenNhanChanThuong { get; set; }
        public string NoiTuVong { get; set; }
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
        public byte? Tvcc { get; set; }
        public DmbenhTatDto ChanDoan { get; set; }
        public string TenNntv { get; set; }
        public DmnhanVienDto NguoiLapPhieu { get; set; }
        public DmnhanVienDto Thutruong { get; set; }
        public DateTime? NgayKy { get; set; }
    }
}
