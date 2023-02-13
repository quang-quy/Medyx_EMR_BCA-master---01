using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTheoDoiTruyenMauVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự khoa phải nằm trong khoảng từ {1} đến {2}.")]
        public int Sttkhoa { get; set; }
        [Required(ErrorMessage = "Số thứ tự chế phẩm máu là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự chế phẩm máu phải nằm trong khoảng từ {1} đến {2}.")]
        public int? Sttcpm { get; set; }
        public decimal? TheTich { get; set; }
        public string MaSoCmp { get; set; }
        public DateTime? NgayDieuChe { get; set; }
        public DateTime? HanSd { get; set; }
        [Required(ErrorMessage = "Định nhóm máu chế phẩm tại giường là bắt buộc.")]
        public string NhomMau { get; set; }
        public string Rh { get; set; }
        public string NhomMauCpm { get; set; }
        public string KqpuhoaHopMuoiOng1 { get; set; }
        public string KqpuhoaHopMuoiOng2 { get; set; }
        public string KqpuhoaHop37doOng1 { get; set; }
        public string KqpuhoaHop37doOng2 { get; set; }
        public string KqpuhoaHop { get; set; }
        public string TenKqxnkhac { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày xét nghiệm phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày xét nghiệm phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayXnhoaHop { get; set; }
        public string HoTenTruongKhoaXn { get; set; }
        public string HoTenNguoiXn1 { get; set; }
        public string HoTenNguoiXn2 { get; set; }
        [Range(1, byte.MaxValue, ErrorMessage = "Lần truyền máu phải nằm trong khoảng từ {1} đến {2}.")]
        public byte? LanTruyenMau { get; set; }
        public string Kqxncheo { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày bắt đầu truyền máu phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày bắt đầu truyền máu phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime(null, "ThoiGianKt", ErrorMessage = "Ngày bắt đầu truyền máu phải nhỏ hơn hoặc bằng ngày kết thúc truyền máu {2}.")]
        public DateTime? ThoiGianBd { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày kết thúc truyền máu phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày kết thúc truyền máu phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime("ThoiGianBd", null, ErrorMessage = "Ngày kết thúc truyền máu phải lớn hơn hoặc bằng ngày bắt đầu truyền máu {1}.")]
        public DateTime? ThoiGianKt { get; set; }
        [Range(0, 9999999.99, ErrorMessage = "Số lượng máu truyền phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? Sltruyen { get; set; }
        public string NhanXet { get; set; }
        public string BstheoDoi { get; set; }
        public string DieuDuong { get; set; }
        public bool? Huy { get; set; }

        //Not need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}