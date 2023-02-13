using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTheoDoiTruyenDichVM
    {
        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự khoa phải nằm trong khoảng từ {1} đến {2}.")]
        public int Sttkhoa { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày truyền dịch phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày truyền dịch phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime(null, "ThoiGianKetThuc", ErrorMessage = "Ngày truyền dịch phải nhỏ hơn hoặc bằng ngày kết thúc {2}.")]
        public DateTime? ThoiGianBatDau { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày kết thúc phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày kết thúc phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime("ThoiGianBatDau", null, ErrorMessage = "Ngày kết thúc phải lớn hơn hoặc bằng ngày truyền dịch {1}.")]
        public DateTime? ThoiGianKetThuc { get; set; }
        public string MaDichTruyen { get; set; }
        [Required(ErrorMessage = "Tên thuốc là bắt buộc.")]
        public string TenDichTruyen { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải nằm trong khoảng từ {1} đến {2}.")]
        public int? SoLuong { get; set; }
        public string SoLo { get; set; }
        public string HamLuong { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Tốc độ phải nằm trong khoảng từ {1} đến {2}.")]
        public string TocDo { get; set; }
        public string BschiDinh { get; set; }
        public string DieuDuong { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnTheoDoiTruyenDichCreateVM : BenhAnTheoDoiTruyenDichVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        
        //Not need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        
    }
}