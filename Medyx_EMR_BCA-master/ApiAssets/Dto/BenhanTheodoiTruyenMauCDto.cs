using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhanTheodoiTruyenMauCDto
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
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
