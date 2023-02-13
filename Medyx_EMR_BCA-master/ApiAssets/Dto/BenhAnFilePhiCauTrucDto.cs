using System;
using System.Linq;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnFilePhiCauTrucDto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public byte LoaiTaiLieu { get; set; }
        public int? Sttdv { get; set; }
        public string TaiLiieuDinhKem { get; set; }
        public string Ten { get { return Link.Split('\\').Last(); } }
        public string Link { get; set; }
        public byte? Loai { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiSd { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto DichVu { get; set; }
    }
}
