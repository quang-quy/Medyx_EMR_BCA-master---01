using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnTtvltlThuchienDto
    {
        public decimal Idba { get; set; }
        public int? Stt { get; set; }
        public int SttdotDt { get; set; }
        public int SttchiDinh { get; set; }
        public DateTime? NgayThucHien { get; set; }
        public DmdichVuDto PhuongPhap { get; set; }
        public string ThoiGian { get; set; }
        public string LieuLuong { get; set; }
        public string GhiChu { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
