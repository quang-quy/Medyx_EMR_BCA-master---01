using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnKhamVaoVienVM
    {
        [CompareWithNgayVv("Idba", -1, ErrorMessage = "Thời gian khám là bắt buộc và nhỏ hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Thời gian khám là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKham { get; set; }
        public string MaBenhNoiChuyenDen { get; set; }
        public string LyDoVv { get; set; }
        public string QuaTrinhBenhLy { get; set; }
        public string TienSuBanThan { get; set; }
        public string TienSuGiaDinh { get; set; }
        public string KhamToanThan { get; set; }
        [Range(1, 299, ErrorMessage = "Mạch phải nằm trong khoảng từ {1} đến {2}.")]
        public int? Mach { get; set; }
        [Range(34, 42, ErrorMessage = "Nhiệt độ phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? NhietDo { get; set; }
        [RegularExpression("^\\d{1,3}\\/\\d{1,3}$", ErrorMessage = "Huyết áp phải có dạng x/y, trong đó x, y nằm trong khoảng từ 0 - 999.")]
        public string HuyetAp { get; set; }
        [Range(1, 99, ErrorMessage = "Nhịp thở nằm trong khoảng từ {1} đến {2}.")]
        public int? NhipTho { get; set; }
        public string CacBoPhan { get; set; }
        public string TomTatKqcls { get; set; }
        public string ChanDoanKkb { get; set; }
        public string DaXuLy { get; set; }
        public string MaKhoaVv { get; set; }
        public string ChuY { get; set; }
        [CompareWithNgayVv("Idba", -1, ErrorMessage = "Ngày ký phải nhỏ hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày ký phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKy { get; set; }
        public string Bskham { get; set; }
        public string MaKhoaKham { get; set; }
        public bool? Huy { get; set; }
    }
    public class BenhAnKhamVaoVienCreateVM : BenhAnKhamVaoVienVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //No need in body
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}