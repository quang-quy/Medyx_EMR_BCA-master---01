using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnDetailDto
    {
        public decimal? Idba { get; set; }
        [Required(ErrorMessage = "Mã bệnh án là bắt buộc.")]
        public string MaBa { get; set; }
        public string TenDvcq { get; set; }
        public string MaBv { get; set; }
        public string TenBv { get; set; }
        [Required(ErrorMessage = "Số vào viện là bắt buộc.")]
        public string SoVaoVien { get; set; }
        public string MaKhoaVv { get; set; }
        public string SoLuuTru { get; set; }
        [Required(ErrorMessage = "Mã y tế là bắt buộc.", AllowEmptyStrings = true)]
        public string MaYt { get; set; }
        public string MaBvChuyenDen { get; set; }
        public string GiaiPhauBenh { get; set; }
        [RangeDateTime(null, "DateTime.Now", ErrorMessage = "Ngày vào viện là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ hiện tại.")]
        public DateTime NgayVv { get; set; }
        [RangeDateTime("NgayVv", "DateTime.Now", ErrorMessage = "Ngày ra viện phải lớn hơn hoặc bằng ngày vào viện {1} và nhỏ hơn hoặc bằng ngày giờ hiện tại.")]
        public DateTime? NgayRv { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayKy { get; set; }
        public DateTime? NgayTuVong { get; set; }
        public string NguyenNhanTuVong { get; set; }
        public byte? KhamNghiemTuThi { get; set; }
        public BenhAnDetailThongTinBnDto BenhNhan { get; set; }
        public DmbaLoaiBaDto LoaiBenhAn { get; set; }
        public DmkhoaDto Khoa { get; set; }
        public DmkhoaBuongDto Buong { get; set; }
        public DmkhoaGiuongDto Giuong { get; set; }
        public string TrucTiepVao { get; set; }
        public string NoiGt { get; set; }
        public string ChuyenVien { get; set; }
        public DmbenhVienDto benhVienChuyenDen { get; set; }
        public string HtraVien { get; set; }
        public int? TongSoNgayDt { get; set; }
        public DmbenhTatDto BenhTatNoiChuyenDen { get; set; }
        public string MaBenhChinhVv { get; set; }
        public string TenBenhChinhVv { get; set; }
        public DmbenhTatDto BenhChinhVv { get; set; }
        public DmbenhTatDto BenhKemVV1 { get; set; }
        public DmbenhTatDto BenhKKBYHHD { get; set; }
        public DmbenhTatYhctDto BenhKKBYHCT { get; set; }
        public DmbenhTatDto BenhKemVV2 { get; set; }
        public DmbenhTatDto BenhKemVV3 { get; set; }
        public byte? ThuThuatYhhd { get; set; }
        public byte? PhauThuatYhhd { get; set; }
        public string MaBenhChinhRv { get; set; }
        public string TenBenhChinhRv { get; set; }
        public DmbenhTatDto BenhChinhRv { get; set; }
        public DmbenhTatDto BenhKemRV1 { get; set; }
        public DmbenhTatDto BenhKemRV2 { get; set; }
        public DmbenhTatDto BenhKemRV3 { get; set; }
        public byte? TaiBienYhhd { get; set; }
        public byte? BienChungYhhd { get; set; }
        public DmbenhTatYhctDto BenhNoiChuyenDenYHCT { get; set; }
        public string MaBenhChinhVvyhct { get; set; }
        public string TenBenhChinhVvyhct { get; set; }
        public DmbenhTatYhctDto BenhChinhVvyhct{ get; set; }
        public DmbenhTatYhctDto BenhKemVV1YHCT { get; set; }
        public DmbenhTatYhctDto BenhKemVV2YHCT { get; set; }
        public DmbenhTatYhctDto BenhKemVV3YHCT { get; set; }
        public string MaBenhChinhRvyhct { get; set; }
        public string TenBenhChinhRvyhct { get; set; }
        public DmbenhTatYhctDto BenhKemRv1yhct { get; set; }
        public DmbenhTatYhctDto BenhKemRv2yhct { get; set; }
        public DmbenhTatYhctDto BenhKemRv3yhct { get; set; }
        public byte? ThuThuatYhct { get; set; }
        public byte? PhauThuatYhct { get; set; }
        public byte? TaiBienYhct { get; set; }
        public byte? BienChungYhct { get; set; }
        public string Kqdt { get; set; }
        public string TinhTrangTuVong { get; set; }
        public DmnhanVienDto Giamdoc { get; set; }
        public DmnhanVienDto TruongKhoa { get; set; }
        public DmnhanVienDto BsDieutri { get; set; }
        public DmbenhTatDto BenhGPTuThis { get; set; }
        public int? Vvlan { get; set; }
        public string NguoiXacNhanKetThucHs { get; set; }
        public byte? XacNhanKetThucHs { get; set; }
        public DateTime? NgayXacNhanKetThucHs { get; set; }
        public DateTime? NgayTruongKhoaKy { get; set; }
    }

    public class BenhAnDetailThongTinBnDto
    {
        public string MaBn { get; set; }
        public decimal? Idba { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public byte? Tuoi { get; set; }
        public byte GioiTinh { get; set; }
        public DmngheNghiepDto NgheNghiep { get; set; }
        public DmdanTocDto DanToc { get; set; }
        public DmquocGiaDto QuocGia { get; set; }
        public DmtinhDto Tinh { get; set; }
        public DmquanHuyenDto QuanHuyen { get; set; }
        public DmphuongXaDto PhuongXa { get; set; }
        public DmdoiTuongDto DoiTuong { get; set; }
        public string SoNha { get; set; }
        public string Thon { get; set; }
        public string NoiLamViec { get; set; }
        public DateTime? Gtbhytdn { get; set; }
        public string SoTheBhyt { get; set; }
        public string LienHe { get; set; }
        public string SoDienThoai { get; set; }
        public string HoTenCha { get; set; }
        public string HoTenMe { get; set; }
        public string NguoiGiamHo { get; set; }
        public string Cmnd { get; set; }
        public string NoiCapCmnd { get; set; }
        public string NgheNghiepNguoiGiamHo { get; set; }
        public string QuanHeNguoiGiamHo { get; set; }
        public string GiayCnkhuyetTat { get; set; }
        public string DangKhuyetTat { get; set; }
        public string MucDoKhuyetTat { get; set; }
        public DateTime? NgayCapCmnd { get; set; }
    }
}
