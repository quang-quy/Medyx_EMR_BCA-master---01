using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnTvBbkiemDiemTvDto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public DmnhanVienDto ThanhVien { get; set; }
        public string VaiTro { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
    }
}
