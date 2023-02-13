using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhieuChamSocVM
    {
        [Required(ErrorMessage = "STT khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày bắt đầu chăm sóc phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày bắt đầu chăm sóc phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime(null, "NgayChamSocKt", ErrorMessage = "Ngày bắt đầu chăm sóc phải nhỏ hơn hoặc bằng ngày kết thúc chăm sóc {2}.")]
        public DateTime? NgayChamSocBd { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày kết thúc chăm sóc phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày kết thúc chăm sóc phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime("NgayChamSocBd", "DateTime.Now", ErrorMessage = "Ngày kết thúc chăm sóc phải lớn hơn hoặc bằng ngày bắt đầu chăm sóc {1}.")]
        public DateTime? NgayChamSocKt { get; set; }
        public decimal? NgayChamSocLan { get; set; }

        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày giờ chăm sóc là bắt buộc và phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày giờ chăm sóc là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayChamSoc { get; set; }

        [Required(ErrorMessage = "Điều dưỡng là bắt buộc.")]
        public string DieuDuong { get; set; }
        public byte? DiUng { get; set; }
        public string DiUngMota { get; set; }
        public string Thuoc { get; set; }
        public string TienSuGiaDinh { get; set; }
        public byte? CapCs { get; set; }
        [Range(1, 500, ErrorMessage = "Mạch phải nằm trong khoảng từ {1} đến {2}.")]
        public int? Mach { get; set; }

        [Range(35, 41, ErrorMessage = "Nhiệt độ phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? NhietDo { get; set; }

        [RegularExpression("^\\d{1,3}\\/\\d{1,3}$", ErrorMessage = "Huyết áp phải có dạng x/y, trong đó x, y nằm trong khoảng từ 0 - 999.")]
        public string HuyetAp { get; set; }
        public decimal? CanNang { get; set; }

        [Range(1, 100, ErrorMessage = "Nhịp thở phải nằm trong khoảng từ {1} đến {2}.")]
        public int? NhipTho { get; set; }
        public decimal? SpO2 { get; set; }
        public string Ythuc { get; set; }
        public string TheTrang { get; set; }
        public string Phu { get; set; }
        public string PhuVitri { get; set; }
        public string PhuTinhChat { get; set; }
        public string DaNiemMac { get; set; }
        public string TuanHoan { get; set; }
        public string TuanHoanTchatDauNguc { get; set; }
        public string HoHap { get; set; }
        [Range(1, byte.MaxValue, ErrorMessage = "Số lần thở oxy phải nằm trong khoảng từ {1} đến {2}.")]
        public byte? HoHapSloxy { get; set; }
        public string HoHapTchatDom { get; set; }
        public string HoHapDanLuu { get; set; }
        public string TieuHoa { get; set; }
        public string TieuHoaVitriDauBung { get; set; }
        public string DaiTien { get; set; }
        [Range(0, byte.MaxValue, ErrorMessage = "Số lần đại tiện phải nằm trong khoảng từ {1} đến {2}.")]
        public byte? SoLanTieuChay { get; set; }
        public string MauSacTieuChay { get; set; }
        public string TietNieu { get; set; }
        public string TieuTien { get; set; }
        public string TieuTienMauSac { get; set; }
        [Range(0, byte.MaxValue, ErrorMessage = "Số lần tiểu tiện phải nằm trong khoảng từ {1} đến {2}.")]
        public byte? TieuTienSoLuong { get; set; }
        public string TamThanKinh { get; set; }
        public string TamThanKinhKhac { get; set; }
        public string TamLyNguoiBenh { get; set; }
        public string Ngu { get; set; }
        [Range(0, 24, ErrorMessage = "Thời gian ngủ phải nằm trong khoảng từ {1} đến {2}.")]
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
        public string ChanDoanChamSoc { get; set; }
        public byte? HuongDanNoiQuy { get; set; }
        public byte? TheoDoiDhst { get; set; }
        public string VeSinhThanThe { get; set; }
        public string ThucHienYlenh { get; set; }
        public string ThuThuatTayY { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày giờ bắt đầu truyền dịch phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày giờ bắt đầu truyền dịch phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime(null, "GioTruyenDichKt", ErrorMessage = "Ngày giờ bắt đầu truyền dịch phải nhỏ hơn hoặc bằng ngày giờ kết thúc truyền dịch {2}.")]
        public DateTime? GioTruyenDichBd { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày giờ kết thúc truyền dịch phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày giờ kết thúc truyền dịch phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime("GioTruyenDichBd", "DateTime.Now", ErrorMessage = "Ngày giờ kết thúc truyền dịch phải lớn hơn hoặc bằng ngày giờ bắt đầu truyền dịch {1}.")]
        public DateTime? GioTruyenDichKt { get; set; }
        public byte? KhiDungTanSo { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Thời gian test đường huyết mao mạch phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Thời gian test đường huyết mao mạch phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? TestDhmmGio { get; set; }
        public byte? TestDhmmSoLan { get; set; }
        public string ThuThuatDy { get; set; }
        public string ThuThuatDyVltl { get; set; }
        public string ThuThuatDyThuoc { get; set; }
        public string ThayBang { get; set; }
        public string ThayBangViTriThay { get; set; }
        // [Required(ErrorMessage = "Vệ sinh cá nhân là bắt buộc.")]
        public string VeSinhCaNhan { get; set; }
        public string Gdsk { get; set; }
        public string ThucHienYlenhKhac { get; set; }
        public string XuTri { get; set; }
        public bool? Huy { get; set; }

        //Not need in body
        public string MaKhoa { get; set; }

    }

    public class BenhAnPhieuChamSocCreateVM : BenhAnPhieuChamSocVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //Not need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
    }

    public class BenhAnPhieuChamSocSaoChepVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Ngày sao chép là bắt buộc.")]
        [CheckExists("Idba", "NgayChamSoc", ErrorMessage = "Ngày chăm soc đã tồn tại. Vui lòng chọn ngày chăm sóc khác.")]
        public DateTime? NgaySaoChep { get; set; }
        public DateTime? NgayChamSoc { get; set; }
    }
}