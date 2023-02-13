using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnThuocYhctCDto
    {
        public int Stt { get; set; }
        public DmthuocDto Thuoc { get; set; }
        public string DonVi { get; set; }
        public decimal? SoLuong { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; } = null;
        public DmnhanVienDto NguoiHuy { get; set; } = null;
        public DmnhanVienDto NguoiSD { get; set; } = null;
    }
}
