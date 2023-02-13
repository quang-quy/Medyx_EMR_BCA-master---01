using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhanPhauThuatDto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public DmkhoaDto Khoa { get; set; }
        public DmphauThuatDto PhauThuat { get; set; }
        public string ViTri { get; set; }
        public string DoiTuong { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public string MaPt { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto BschiDinh { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
        public DmphauThuatDto Phauthuat { get; set; }

    }
}
