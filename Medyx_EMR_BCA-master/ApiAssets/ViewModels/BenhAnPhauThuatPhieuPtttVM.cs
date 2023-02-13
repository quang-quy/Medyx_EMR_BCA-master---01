using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhauThuatPhieuPtttVM
    {
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày phẫu thuật phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày phẫu thuật phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayPt { get; set; }
        public string ChanDoanTruocPt { get; set; }
        public string ChanDoanSauPt { get; set; }
        public string PhuongPhap { get; set; }
        public string PhanLoaiPt { get; set; }
        public string PhuongPhapVoCam { get; set; }
        public string Bspt { get; set; }
        public string BsphuMo { get; set; }
        public string BsgayMe { get; set; }
        public string LuocDoPt { get; set; }
        public string DanLuu { get; set; }
        public string Bac { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày rút chỉ phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày rút chỉ phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayRutChi { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày cắt chỉ phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày cắt chỉ phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayCatChi { get; set; }
        public string Khac { get; set; }
        public string TrinhTuPt { get; set; }
        public string PhuongThucPt { get; set; }
        public string ViTriPt { get; set; }
        public string CachThucPt { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày ký phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKy { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnPhauThuatPhieuPtttCreateVM : BenhAnPhauThuatPhieuPtttVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Số thứ tự phẫu thuật là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự phẫu thuật phải nằm trong khoảng từ {1} đến {2}.")]
        public int Sttpt { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}