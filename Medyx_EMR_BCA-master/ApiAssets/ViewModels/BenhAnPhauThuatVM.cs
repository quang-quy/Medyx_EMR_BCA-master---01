using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhauThuatVM
    {
        public string DoiTuong { get; set; }
        [Required(ErrorMessage = "Mã phẫu thuật là bắt buộc.")]
        public string MaPt { get; set; }
        public string ViTri { get; set; }
        public bool? Huy { get; set; }
        public string Bschidinh { get; set; }
    }

    public class BenhAnPhauThuatCreateVM : BenhAnPhauThuatVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
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