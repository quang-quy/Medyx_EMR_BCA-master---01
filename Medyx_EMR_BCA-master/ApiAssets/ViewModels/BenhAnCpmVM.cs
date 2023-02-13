using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnCpmVM
    {
        public string DoiTuong { get; set; }
        [Required(ErrorMessage = "Mã chế phẩm máu là bắt buộc.")]
        public string MaCPM { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng thuốc phải nằm trong khoảng từ {1} đến {2}.")]
        public string DonVi { get; set; }
        public int? SoLuong { get; set; }
        public string Nhommau { get; set; }
        public string Rh { get; set; }
        public string BschiDinh { get; set; }
        public bool? Huy { get; set; }
    }
    public class BenhAnCpmCreateVM : BenhAnCpmVM
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