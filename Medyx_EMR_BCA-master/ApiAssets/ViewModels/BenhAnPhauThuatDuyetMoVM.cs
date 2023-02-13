using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhauThuatDuyetMoVM
    {
        public string LyDoVv { get; set; }
        public string TienSuNgoaiKhoa { get; set; }
        public string TienSuNoiKhoa { get; set; }
        public string TienSuDiUng { get; set; }
        public string TienSuKhac { get; set; }
        public string BenhSu { get; set; }
        public int? Mach { get; set; }
        [RegularExpression("^\\d{1,3}\\/\\d{1,3}$", ErrorMessage = "Huyết áp phải có dạng x/y, trong đó x, y nằm trong khoảng từ 0 - 999.")]
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
        public string PhuongPhapPhauThuat { get; set; }
        public string PhuongPhapVoCam { get; set; }
        public string KipPhauThuat { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày phẫu thuật phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày phẫu thuật phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayPt { get; set; }
        public string DuTruMau { get; set; }
        public string KhoKhan { get; set; }
        public string VanDeKhac { get; set; }
        public string MaBenh { get; set; }
        public string Bspt { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày bác sĩ phẫu thuật ký phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày bác sĩ phẫu thuật ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKyBspt { get; set; }
        public string BsgayMe { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày bác sĩ gây mê ký phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày bác sĩ gây mê ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKyBsgm { get; set; }
        public string TruongKhoa { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày lãnh đạo khoa ký phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày lãnh đạo khoa ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKyBsldkhoa { get; set; }
        public string LanhDaoBv { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày lãnh đạo bệnh viện ký phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày lãnh đạo bệnh viện ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKyLdbv { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnPhauThuatDuyetMoCreateVM : BenhAnPhauThuatDuyetMoVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Số thứ tự phẫu thuật là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự phẫu thuật phải nằm trong khoảng từ {1} đến {2}.")]
        public int Sttpt { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}