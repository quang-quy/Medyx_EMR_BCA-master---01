using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTheoDoiTruyenMauCVM
    {
        [Required(ErrorMessage = "Số thứ tự truyền máu là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự truyền máu phải nằm trong khoảng từ {1} đến {2}.")]
        public int StttruyenMau { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string TocDo { get; set; }
        public string MauSacDa { get; set; }
        [Range(1, 99, ErrorMessage = "Nhịp thở phải nằm trong khoảng từ {1} đến {2}.")]
        public int? NhipTho { get; set; }
        [Range(1, 299, ErrorMessage = "Mạch phải nằm trong khoảng từ {1} đến {2}.")]
        public int? Mach { get; set; }
        [RegularExpression("^\\d{1,3}\\/\\d{1,3}$", ErrorMessage = "Huyết áp phải có dạng x/y, trong đó x, y nằm trong khoảng từ 0 - 999.")]
        public string HuyetAp { get; set; }
        [Range(34, 42, ErrorMessage = "Nhiệt độ phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? NhietDo { get; set; }
        public string DienBienKhac { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnTheoDoiTruyenMauCCreateVM : BenhAnTheoDoiTruyenMauCVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        
        //Not need in body
        public int Stt { get; set; }
    }
}