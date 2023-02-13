using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhanCpmDto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
        public DmchephamMauDto ChePhamMau { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; }
        public TruyenMauDto TruyenMau { get; set; }
        public string DonVi { get; set; }
        public int? SoLuong { get; set; }
        public string Nhommau { get; set; }
        public string Rh { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; } = null;
        public DmnhanVienDto NguoiHuy { get; set; } = null;
        public DmnhanVienDto NguoiSD { get; set; } = null;
    }

    public class TruyenMauDto
    {
        public decimal? TheTich { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
    }
}
