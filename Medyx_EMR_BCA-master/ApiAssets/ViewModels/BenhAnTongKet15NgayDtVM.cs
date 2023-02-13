using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTongKet15NgayDtVM
    {
        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự khoa phải nằm trong khoảng từ {1} đến {2}.")]
        public int Sttkhoa { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", 1, true, ErrorMessage = "Từ ngày là bắt buộc phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", 1, true, ErrorMessage = "Từ ngày là bắt buộc phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime(null, "DenNgay", ErrorMessage = "Từ ngày là bắt buộc phải nhỏ hơn hoặc bằng đến ngày {2}.")]
        public DateTime? TuNgay { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", 1, true, ErrorMessage = "Đến ngày là bắt buộc phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", 1, true, ErrorMessage = "Đến ngày là bắt buộc phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime("TuNgay", null, ErrorMessage = "Đến ngày là bắt buộc phải lớn hơn hoặc bằng từ ngày {1}.")]
        public DateTime? DenNgay { get; set; }
        public string DienBienLamSang { get; set; }
        public string XnlamSang { get; set; }
        public string QuaTrinhDt { get; set; }
        public string DanhGiaKq { get; set; }
        public string HuongDt { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", 1, true, ErrorMessage = "Ngày trưởng khoa ký phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", 1, true, ErrorMessage = "Ngày trưởng khoa ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKyTruongKhoa { get; set; }
        public string TruongKhoa { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", 1, true, ErrorMessage = "Ngày bác sĩ điều trị ký là bắt buộc và phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", 1, true, ErrorMessage = "Ngày bác sĩ điều trị ký là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKyBsdieuTri { get; set; }
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnTongKet15NgayDtCreateVM : BenhAnTongKet15NgayDtVM
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