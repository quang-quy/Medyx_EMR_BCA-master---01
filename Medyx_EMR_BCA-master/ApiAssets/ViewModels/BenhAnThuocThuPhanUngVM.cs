using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnThuocThuPhanUngVM
    {
        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày bắt đầu phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayBatDau { get; set; }
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string PhuongPhapThu { get; set; }
        public string BschiDinh { get; set; }
        public string NguoiThu { get; set; }
        public string BsdocKq { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày đọc kết quả phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày đọc kết quả phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayDocKq { get; set; }
        public string KetQua { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnThuocThuPhanUngCreateVM : BenhAnThuocThuPhanUngVM
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