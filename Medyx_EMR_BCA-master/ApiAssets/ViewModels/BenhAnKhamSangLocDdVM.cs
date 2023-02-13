using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnKhamSangLocDdVM
    {
        [Required(ErrorMessage = "Khoa là bắt buộc.")]
        [RegularExpression(@"[\d]+$", ErrorMessage = "STT Khoa phải là số nguyên.")]
        [Range(1, int.MaxValue, ErrorMessage = "STT Khoa phải nằm trong khoảng từ {1} đến {2}.")]
        public int? Sttkhoa { get; set; }

        [Required(ErrorMessage = "Số phiếu là bắt buộc.")]
        // [Range(1, int.MaxValue, ErrorMessage = "Số phiếu phải nằm trong khoảng từ {1} đến {2}.")]
        public string SoPhieu { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày đánh giá phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày đánh giá phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayDg { get; set; }
        public string NguoiDg { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
        public decimal? Bmi { get; set; }
        public byte? CoSutCan { get; set; }
        public byte? DiemSutCan { get; set; }
        public byte? DiemNgonMieng { get; set; }
        public byte? ChiSoMst { get; set; }
        public string DanhGiaTheoMst { get; set; }
        public string CanThiepDd { get; set; }
        public string Bsdieutri { get; set; }
        public bool? Huy { get; set; }
    }
    public class BenhAnKhamSangLocDdCreateVM : BenhAnKhamSangLocDdVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}