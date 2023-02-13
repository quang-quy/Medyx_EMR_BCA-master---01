using System.Collections.Generic;
namespace Medyx_EMR_BCA.ApiAssets.Dto.Print
{
    public class ChiTietBenhAnChamSocPrintDto
    {
        public string NgayGio { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string DieuDuong { get; set; }
        public string NgayChamSocThu { get; set; }
        public string HtmlYThuc { get; set; }
        public string HtmlTheTrang { get; set; }
        public string CanNang { get; set; }
        public string ChieuCao { get; set; }
        public string ViTriPhu { get; set; }
        public string TinhChatPhu { get; set; }
        public string CoChuong { get; set; }
        public string HtmlPhu { get; set; }
        public string HtmlDaNiemMac { get; set; }
        public string HtmlTuanHoan { get; set; }
        public string HuyetAp { get; set; }
        public string NhietDo { get; set; }
        public string HtmlHoHap { get; set; }
        public string TinhChatDom { get; set; }
        public string HoHapDanLuu { get; set; }
        public string HtmlTieuHoa { get; set; }
        public string ViTriDau { get; set; }
        public string HtmlDaiTien { get; set; }
        public string SoLan { get; set; }
        public string TieuHoaMauSac { get; set; }
        public string HtmlThanTietNieu { get; set; }
        public string ThanMauSac { get; set; }
        public string SoLuong { get; set; }
        public string HtmlTamThanKinh { get; set; }
        public string TamThanKinhKhac { get; set; }
        public string HtmlTamLyNguoiBenh { get; set; }
        public string HtmlNgu { get; set; }
        public string NguNgayGio { get; set; }
        public string HtmlVanDong { get; set; }
        public string TinhChatLiet { get; set; }
        public string HtmlCoXuongKhop { get; set; }
        public string VetThuongMoViTri { get; set; }
        public string HtmlVetThuongMo { get; set; }
        public string VetThuongMoKhac { get; set; }
        public string HtmlDanLuu { get; set; }
        public string ChanDanLuu { get; set; }
        public string NhanDinhKhac { get; set; }
        public string HtmlCapChamSoc { get; set; }
        public string ChanDoanChamSoc { get; set; }
        public string HtmlHuongDanNoiQuyThuTucNhapVien { get; set; }
        public string HtmlTheoDoiDauHieuSinhTon { get; set; }
        public string HtmlThucHienYLenhThuoc { get; set; }
        public string ThucHienYLenhXN { get; set; }
        public string HtmlTayY { get; set; }
        public string GioTruyenDich { get; set; }
        public string GioKetThucTruyenDich { get; set; }
        public string TruyenDich { get; set; }
        public string GioTest { get; set; }
        public string SoLanTruyenDich { get; set; }
        public string HtmlDongY { get; set; }
        public string ViTriThayBang { get; set; }
        public string HtmlThayBang { get; set; }
        public string HtmlVeSinhCaNhan { get; set; }
        public string DinhDuong { get; set; }
        public string HtmlGDSK { get; set; }
        public string ThucHienYLenhKhac { get; set; }
        public string XuTri { get; set; }
        public string DDThucHien { get; set; }

    }
    public class BenhAnChamSocPrintDto
    {
        public string BenhVien { get; set; }
        public string Khoa { get; set; }
        public string MaSoVV { get; set; }
        public string CapTitle { get; set; }
        public string MaQL { get; set; }
        public string NgaySinh { get; set; }
        public string NgayVaoKhoa { get; set; }
        public string GioiTinh { get; set; }
        public string HoTen { get; set; }
        public string TenKhoa { get; set; }
        public string TenDoiTuong { get; set; }
        public string ChanDoan { get; set; }
        public string TienSuBanThan { get; set; }
        public string DiUng { get; set; }
        public string Thuoc { get; set; }
        public string TienSuGiaDinh { get; set; }
        public List<ChiTietBenhAnChamSocPrintDto> ChiTietBenhAnChamSocs { get; set; }
    }
}