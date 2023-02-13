using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnThuocYhctCVM
    {
        [RequiredIf("Thuocs", null, ErrorMessage = "Mã thuốc là bắt buộc.")]
        public string MaThuoc { get; set; }
        public string DonVi { get; set; }
        [RequiredIf("Thuocs", null, ErrorMessage = "Số lượng thuốc là bắt buộc.")]
        [Range(1, 999.998, ErrorMessage = "Số lượng thuốc phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? SoLuong { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnThuocYhctCCreateVM : BenhAnThuocYhctCVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "STT khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        [Required(ErrorMessage = "Chưa tạo bài thuốc.")] // STT thuốc là bắt buộc.
        public int Sttthuoc { get; set; }
        public List<BenhAnThuocYhctCVM> Thuocs { get; set; } = new List<BenhAnThuocYhctCVM>();

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}