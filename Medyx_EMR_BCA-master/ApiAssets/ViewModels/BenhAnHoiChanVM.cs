using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnHoiChanVM
    {
        [Required(ErrorMessage = "Stt khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày hội chẩn là bắt buộc và phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày hội chẩn là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayHoiChan { get; set; }
        public string TenBienBanHoiChan { get; set; }
        public string ChuToa { get; set; }
        public string ThuKy { get; set; }
        public string ThanhVien { get; set; }
        public string TomTatDienBienBenh { get; set; }
        public string KetLuan { get; set; }
        public string HuongDt { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnHoiChanCreateVM : BenhAnHoiChanVM
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