using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnKhoaDieuTriVM
    {
        [Required(ErrorMessage = "Mã khoa là bắt buộc.")]
        public string MaKhoa { get; set; }
        [RangeDateTime(null, "DateTime.Now", ErrorMessage = "Ngày giờ vào khoa là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ hiện tại.")]
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày giờ vào khoa phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày giờ vào khoa phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime NgayVaoKhoa { get; set; }
        public string Buong { get; set; }
        public string Giuong { get; set; }
        [Required(ErrorMessage = "Mã bệnh chính là bắt buộc.")]
        public string MaBenhChinhVk { get; set; }
        public string MaBenhKemVk1 { get; set; }
        public string MaBenhKemVk2 { get; set; }
        public string MaBenhKemVk3 { get; set; }
        [Required(ErrorMessage = "Bác sĩ điều trị là bắt buộc.")]
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnKhoaDieuTriCreateVM : BenhAnKhoaDieuTriVM
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