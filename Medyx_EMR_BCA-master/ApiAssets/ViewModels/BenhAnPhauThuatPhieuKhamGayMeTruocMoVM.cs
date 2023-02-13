using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhauThuatPhieuKhamGayMeTruocMoVM
    {
        public string NhomMau { get; set; }
        [Required(ErrorMessage = "Chiều cao là bắt buộc.")]
        [Range(1, 299, ErrorMessage = "Chiều cao phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal ChieuCao { get; set; }
        [Range(1, 299, ErrorMessage = "Cân nặng phải nằm trong khoảng từ {1} đến {2}.")]
        public decimal? CanNang { get; set; }
        public byte? Asa { get; set; }
        public string Mallampati { get; set; }
        public decimal? KhoangCachCamGiap { get; set; }
        public decimal? HaMieng { get; set; }
        public byte? RangGia { get; set; }
        public decimal? BuaAnCuoiTruocMo { get; set; }
        public byte? CapCuu { get; set; }
        public byte? DaDayDay { get; set; }
        public string ChanDoan { get; set; }
        public string HuongXuTri { get; set; }
        public string TienSuNoiKhoa { get; set; }
        public string TienSuNgoaiKhoa { get; set; }
        public string TienSuGayMe { get; set; }
        public string DiUng { get; set; }
        public byte? NghienThuocLa { get; set; }
        public byte? NghienRuou { get; set; }
        public byte? NghienMaTuy { get; set; }
        public string ThuocDt { get; set; }
        public string KhamLamSang { get; set; }
        public string TuanHoan { get; set; }
        [Range(1, 199, ErrorMessage = "Mạch phải nằm trong khoảng từ {1} đến {2}.")]
        public int? Mach { get; set; }
        [RegularExpression("^\\d{1,3}\\/\\d{1,3}$", ErrorMessage = "Huyết áp phải có dạng x/y, trong đó x, y nằm trong khoảng từ 0 - 999.")]
        public string HuyetAp { get; set; }
        public string HoHap { get; set; }
        public string ThanKinh { get; set; }
        public string CotSong { get; set; }
        public string XnbatThuong { get; set; }
        public string YeuCauBoSung { get; set; }
        public string DuKienCachVoCam { get; set; }
        public string DuKienGiamDauSauMo { get; set; }
        public string YlenhTruocMo { get; set; }
        public string DieuDuong { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày khám phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày khám phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayKham { get; set; }
        public string BsgayMeKham { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày thăm lại trước mổ phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày thăm lại trước mổ phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayThamLaiTruocMo { get; set; }
        public string BsgayMeThamLaiTruocMo { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnPhauThuatPhieuKhamGayMeTruocMoCreateVM : BenhAnPhauThuatPhieuKhamGayMeTruocMoVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Số thứ tự phẫu thuật là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số thứ tự phẫu thuật phải nằm trong khoảng từ {1} đến {2}.")]
        public int Sttpt { get; set; }
        public string MaBa { get; set; }
    }
}