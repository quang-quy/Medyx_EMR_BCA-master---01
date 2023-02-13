using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnPhieuChamSocDetailDto
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public int? Sttkhoa { get; set; }
        public DmkhoaDto Khoa { get; set; }
        public string ChanDoan { get; set; }
        public byte? DiUng { get; set; }
        public string DiUngMota { get; set; }
        public string Thuoc { get; set; }
        public string TienSuGiaDinh { get; set; }
        public DateTime? NgayChamSoc { get; set; }
        public decimal? NgayChamSocLan { get; set; }
        public DateTime? NgayChamSocBd { get; set; }
        public DateTime? NgayChamSocKt { get; set; }
        public int? Mach { get; set; }
        public decimal? NhietDo { get; set; }
        public string HuyetAp { get; set; }
        public decimal? CanNang { get; set; }
        public int? NhipTho { get; set; }
        public decimal? ChieuCao { get; set; }
        public decimal? SpO2 { get; set; }
        public string DienBien { get; set; }
        public string Ylenh { get; set; }
        public string Ythuc { get; set; }
        public string TheTrang { get; set; }
        public string Phu { get; set; }
        public string PhuVitri { get; set; }
        public string PhuTinhChat { get; set; }
        public string DaNiemMac { get; set; }
        public string TuanHoan { get; set; }
        public string TuanHoanTchatDauNguc { get; set; }
        public string HoHap { get; set; }
        public byte? HoHapSloxy { get; set; }
        public string HoHapTchatDom { get; set; }
        public string HoHapDanLuu { get; set; }
        public string TieuHoa { get; set; }
        public string TieuHoaVitriDauBung { get; set; }
        public string DaiTien { get; set; }
        public byte? SoLanTieuChay { get; set; }
        public string MauSacTieuChay { get; set; }
        public string TietNieu { get; set; }
        public string TieuTien { get; set; }
        public string TieuTienMauSac { get; set; }
        public byte? TieuTienSoLuong { get; set; }
        public string TamThanKinh { get; set; }
        public string TamThanKinhKhac { get; set; }
        public string TamLyNguoiBenh { get; set; }
        public string Ngu { get; set; }
        public byte? NguThoiGian { get; set; }
        public string VanDong { get; set; }
        public string VanDongTchatLiet { get; set; }
        public string CoXuongKhop { get; set; }
        public string VetThuongViTri { get; set; }
        public string VetThuong { get; set; }
        public string VetThuongKhac { get; set; }
        public string VetThuongMotaDanLuu { get; set; }
        public string VetThuongDanLuu { get; set; }
        public string VetThuongChanDanLuu { get; set; }
        public string NhanDinhKhac { get; set; }
        public byte? CapCs { get; set; }
        public string ChanDoanChamSoc { get; set; }
        public byte? HuongDanNoiQuy { get; set; }
        public byte? TheoDoiDhst { get; set; }
        public string VeSinhThanThe { get; set; }
        public string ThucHienYlenh { get; set; }
        public string ThuThuatTayY { get; set; }
        public DateTime? GioTruyenDichBd { get; set; }
        public DateTime? GioTruyenDichKt { get; set; }
        public byte? KhiDungTanSo { get; set; }
        public DateTime? TestDhmmGio { get; set; }
        public byte? TestDhmmSoLan { get; set; }
        public string ThuThuatDy { get; set; }
        public string ThuThuatDyVltl { get; set; }
        public string ThuThuatDyThuoc { get; set; }
        public string ThayBang { get; set; }
        public string ThayBangViTriThay { get; set; }
        public string VeSinhCaNhan { get; set; }
        public string Gdsk { get; set; }
        public string ThucHienYlenhKhac { get; set; }
        public string XuTri { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto DieuDuong { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
		public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; } = null;
    }
}
