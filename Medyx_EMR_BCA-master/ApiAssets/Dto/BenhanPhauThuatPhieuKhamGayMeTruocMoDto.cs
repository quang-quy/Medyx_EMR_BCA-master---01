using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhanPhauThuatPhieuKhamGayMeTruocMoDto
    {
        public int Sttpt { get; set; }
        public decimal Idba { get; set; }
        public DmkhoaDto Khoa { get; set; }
        public DmphauThuatDto PhauThuat { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string MaBa { get; set; }
        public string NhomMau { get; set; }
        public string Rh { get; set; }
        public decimal? CanNang { get; set; }
        public decimal ChieuCao { get; set; }
        public byte? Asa { get; set; }
        public string Mallampati { get; set; }
        public decimal? KhoangCachCamGiap { get; set; }
        public decimal? HaMieng { get; set; }
        public byte? RangGia { get; set; }
        public decimal? BuaAnCuoiTruocMo { get; set; }
        public byte? CapCuu { get; set; }
        public byte? DaDayDay { get; set; }
        public string ChanDoan { get; set; }
        public string HuongXuTri { get; set; }
        public string TienSuNoiKhoa { get; set; }
        public string TienSuNgoaiKhoa { get; set; }
        public string TienSuGayMe { get; set; }
        public string DiUng { get; set; }

        public byte? NghienThuocLa { get; set; }
        public byte? NghienRuou { get; set; }
        public byte? NghienMaTuy { get; set; }
        public string ThuocDt { get; set; }
        public string KhamLamSang { get; set; }
        public string TuanHoan { get; set; }
        public int? Mach { get; set; }
        public string HuyetAp { get; set; }
        public string HoHap { get; set; }
        public string ThanKinh { get; set; }
        public string CotSong { get; set; }
        public string XnbatThuong { get; set; }
        public string YeuCauBoSung { get; set; }
        public string DuKienCachVoCam { get; set; }
        public string DuKienGiamDauSauMo { get; set; }
        public string YlenhTruocMo { get; set; }
        public string DieuDuong { get; set; }
        public DateTime? NgayKham { get; set; }
        public string BsgayMeKham { get; set; }
        public DateTime? NgayThamLaiTruocMo { get; set; }
        public string BsgayMeThamLaiTruocMo { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto DmDieuDuong { get; set; }
        public DmnhanVienDto DmBsgayMeKham { get; set; }
        public DmnhanVienDto DmBsgayMeThamLaiTruocMo { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
