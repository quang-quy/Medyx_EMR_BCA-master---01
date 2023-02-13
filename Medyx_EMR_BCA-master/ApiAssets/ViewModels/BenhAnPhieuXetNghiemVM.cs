using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhieuXetNghiemVM
    {
        [Required(ErrorMessage = "Id bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        public int? Stt { get; set; }
        [Required(ErrorMessage = "Số phiếu là bắt buộc.")]
        public string SoPhieu { get; set; }
        [Required(ErrorMessage = "Số thứ tự dịch vụ là bắt buộc.")]
        public int Sttdv { get; set; }
        public string MaDv { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày tiếp nhận phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày tiếp nhận phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayTiepNhan { get; set; }
        public string MaCs { get; set; }
        public string TenCs { get; set; }
        public string Kq { get; set; }
        public string BatThuong { get; set; }
        public string MaMayThucHien { get; set; }
        public string Ktv { get; set; }
        public string NguoiDuyetKq { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày trả kết quả phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày trả kết quả phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayTraKq { get; set; }
        public string KetLuan { get; set; }
        public string MaKhoaThucHien { get; set; }
        public string LinkPacsLis { get; set; }
        public bool? Huy { get; set; }

        //No need in body
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string Idlis { get; set; } = "LIS";
    }
}