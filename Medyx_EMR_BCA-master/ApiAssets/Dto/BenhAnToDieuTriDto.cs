using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnToDieuTriDto
    {
        public int Stt { get; set; }
        public decimal Idba { get; set; }
        public int? Sttkhoa { get; set; }
        public DateTime? NgayYLenh { get; set; }
        public BenhAnToDieuTriDetailKhoaDieuTriDto KhoaDieuTri { get; set; }
        public DmnhanVienDto BsdieuTri { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DmnhanVienDto NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
    }
}
