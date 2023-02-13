using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnKhoaDieuTriDto
    {
        public decimal? Idba { get; set; }
        public int? Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string MaKhoa { get; set; }
        public DateTime? NgayVaoKhoa { get; set; }
        public int? SoNgayDt { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public string MaBsDieutri { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmkhoaDto Khoa { get; set; } = null;
        public DmkhoaBuongDto Buong { get; set; } = null;
        public DmkhoaGiuongDto Giuong { get; set; } = null;

        public DmbenhTatDto BenhChinh { get; set; } = null;
        public DmbenhTatDto BenhKem1 { get; set; } = null;
        public DmbenhTatDto BenhKem2 { get; set; } = null;
        public DmbenhTatDto BenhKem3 { get; set; } = null;

        public DmnhanVienDto BsdieuTri { get; set; } = null;
        public DmnhanVienDto NguoiHuy { get; set; } = null;
        public DmnhanVienDto NguoiLap { get; set; } = null;
        public DmnhanVienDto NguoiSD { get; set; } = null;
    }
    public sealed class BenhAnKhoaDieuTriV2Dto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string MaKhoa { get; set; }
        public DateTime? NgayVaoKhoa { get; set; }
        public int? SoNgayDt { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public string MaBsDieutri { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmkhoaDto Khoa { get; set; } = null;
        public DmkhoaBuongDto Buong { get; set; } = null;
        public DmkhoaGiuongDto Giuong { get; set; } = null;
        public DmbenhTatDto BenhChinh { get; set; } = null;
        public DmbenhTatDto BenhKem1 { get; set; } = null;
        public DmbenhTatDto BenhKem2 { get; set; } = null;
        public DmbenhTatDto BenhKem3 { get; set; } = null;

        public DmnhanVienDto BsdieuTri { get; set; } = null;
        public DmnhanVienDto NguoiHuy { get; set; } = null;
        public DmnhanVienDto NguoiLap { get; set; } = null;
        public DmnhanVienDto NguoiSD { get; set; } = null;
    }
}
