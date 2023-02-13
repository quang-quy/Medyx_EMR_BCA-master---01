using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhanTheodoiTruyenDichDto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public int Sttkhoa { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string MaDichTruyen { get; set; }
        public string TenDichTruyen { get; set; }
        public int? SoLuong { get; set; }
        public string SoLo { get; set; }
        public string TocDo { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto BschiDinh { get; set; }
        public DmnhanVienDto DieuDuong { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
