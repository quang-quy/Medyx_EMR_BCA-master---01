using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTaiBienPtttVM
    {
        [Required(ErrorMessage = "Stt khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        public byte? Loai { get; set; }
        public string NguyenNhanTaiBien { get; set; }
        [CompareWithNgayVv("Idba", 1, true, ErrorMessage = "Ngày thực hiện là bắt buộc và phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", 1, true, ErrorMessage = "Ngày thực hiện là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayThucHien { get; set; }
        [CompareWithNgayVv("Idba", 1, true, ErrorMessage = "Ngày tai biến là bắt buộc và phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", 1, true, ErrorMessage = "Ngày tai biến là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayTaiBien { get; set; }
        public string GhiChu { get; set; }
        public string TinhTrang { get; set; }
        public string Xutri { get; set; }
        public string KetQua { get; set; }

        public bool? Huy { get; set; }
    }

    public class BenhAnTaiBienPtttCreateVM : BenhAnTaiBienPtttVM
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