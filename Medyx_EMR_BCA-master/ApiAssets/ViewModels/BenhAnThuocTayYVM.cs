using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnThuocTayYVM
    {
        [Required(ErrorMessage = "Mã thuốc là bắt buộc.")]
        public string MaThuoc { get; set; }

        [Required(ErrorMessage = "Số lượng thuốc là bắt buộc.")]
        [Range(1, 999.998, ErrorMessage = "Số lượng thuốc phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? SoLuong { get; set; }
        public string Lieudung { get; set; }
        public string CachDung { get; set; }
        public bool? Huy { get; set; }

        //No need in body
        public string TenThuoc { get; set; }
    }

    public class BenhAnThuocTayYCreateVM : BenhAnThuocTayYVM
    {
        [BindRequired]
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