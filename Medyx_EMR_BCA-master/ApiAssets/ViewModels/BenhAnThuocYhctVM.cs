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
    public class BenhAnThuocYhctVM
    {
        public string DoiTuong { get; set; }
        [Required(ErrorMessage = "Tên bài thuốc là bắt buộc.")]
        public string TenBaiThuoc { get; set; }
        public string DuongDung { get; set; }
        public string CachDung { get; set; }
        [Required(ErrorMessage = "Số lượng thang là bắt buộc.")]
        [Range(1, 14, ErrorMessage = "Số lượng thang phải nằm trong khoảng từ {1} đến {2}.")]
        public int? SoLuongThang { get; set; }
        public string CachSacThuoc { get; set; }
        public string BschiDinh { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnThuocYhctCreateVM : BenhAnThuocYhctVM
    {
        [BindRequired]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "STT Khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }

        [Required(ErrorMessage = "Ngày y lệnh là bắt buộc.")]
        public DateTime? NgayYlenh { get; set; }

        public List<BenhAnThuocYhctCVM> ThuocYhctCs { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}