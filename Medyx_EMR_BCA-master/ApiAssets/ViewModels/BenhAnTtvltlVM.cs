using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTtvltlVM
    {
        [RequiredIf("MaGoi", null, ErrorMessage = "Mã dịch vụ là bắt buộc.")]
        public string MaDv { get; set; }
        public string DoiTuong { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải nằm trong khoảng từ {1} đến {2}.")]
        public byte? SoLuong { get; set; }
        public string ViTri { get; set; }
        public string ThoiGian { get; set; }
        public string Bschidinh { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnTtvltlCreateVM : BenhAnTtvltlVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        public string MaGoi { get; set; }
        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }

        [Required(ErrorMessage = "Ngày y lệnh là bắt buộc.")]
        public DateTime? NgayYlenh { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}