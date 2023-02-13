using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnPhauThuatDuyetMoDto
    {
        public int Sttpt { get; set; }
        public decimal Idba { get; set; }
        public DmkhoaDto Khoa { get; set; }
        public DmkhoaBuongDto Buong { get; set; }
        public DmkhoaGiuongDto Giuong { get; set; }
        public DmphauThuatDto PhauThuat { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; }
        public DmbenhTatDto BenhChinh { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string LyDoVv { get; set; }
        public string TienSuNgoaiKhoa { get; set; }
        public string TienSuNoiKhoa { get; set; }
        public string TienSuDiUng { get; set; }
        public string TienSuKhac { get; set; }
        public string BenhSu { get; set; }
        public int? Mach { get; set; }
        public string HuyetAp { get; set; }
        public decimal? NhietDo { get; set; }
        public string MoTaHienTaiKhac { get; set; }
        public string NhomMau { get; set; }
        public string Hc { get; set; }
        public string Hct { get; set; }
        public string Bc { get; set; }
        public string Tc { get; set; }
        public string Pt { get; set; }
        public string Apt { get; set; }
        public string Kqhhkhac { get; set; }
        public string Kqsh { get; set; }
        public string Kqcdha { get; set; }
        public string Kqxnkhac { get; set; }
        public string MaBenh { get; set; }
        public string PhuongPhapPhauThuat { get; set; }
        public string PhuongPhapVoCam { get; set; }
        public string KipPhauThuat { get; set; }
        public DateTime? NgayPt { get; set; }
        public string DuTruMau { get; set; }
        public string KhoKhan { get; set; }
        public string VanDeKhac { get; set; }
        public DateTime? NgayKyBspt { get; set; }
        public DateTime? NgayKyBsgm { get; set; }
        public DateTime? NgayKyBsldkhoa { get; set; }
        public DateTime? NgayKyLdbv { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto Bspt { get; set; }
        public DmnhanVienDto BsgayMe { get; set; }
        public DmnhanVienDto TruongKhoa { get; set; }
        public DmnhanVienDto LanhDaoBv { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
