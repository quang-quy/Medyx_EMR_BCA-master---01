using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnToDieuTriVM
    {
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày giờ y lệnh là bắt buộc và phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày giờ y lệnh là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayYlenh { get; set; }
        [Required(ErrorMessage = "STT khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        [Required(ErrorMessage = "Bác sĩ điều trị là bắt buộc.")]
        public string BsdieuTri { get; set; }
        public string DienBienBenh { get; set; }
        public string Ylenh { get; set; }
        [RegularExpression("^\\d{1,3}\\/\\d{1,3}$", ErrorMessage = "Huyết áp phải có dạng x/y, trong đó x, y nằm trong khoảng từ 0 - 999.")]
        public string HuyetAp { get; set; }
        public int? NhipTho { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
        public string TrieuChung { get; set; }
        public int? NhipTim { get; set; }
        public byte? NhipTimDeu { get; set; }
        public string Kqxnmau { get; set; }
        public string KqxnnuocTieu { get; set; }
        public string Kqcdha { get; set; }
        public string CsduongHuyet { get; set; }
        public string DieuTri { get; set; }
        public DateTime? NgayHenKhamLai { get; set; }
        public DateTime? NgayHenXnlai { get; set; }
        public bool? Huy { get; set; }

        //No need in body
        public string MaKhoa { get; set; }
    }

    public class BenhAnToDieuTriCreateVM : BenhAnToDieuTriVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }

    public class BenhAnToDieuTriSaoChepVM : BenhAnToDieuTriVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Không thể sao chép tờ điều trị không có ngày y lệnh.")]
        [CheckExists("Idba", "NgayYlenh", ErrorMessage = "Ngày muốn sao chép đã tồn tại trong hệ thống. Vui lòng chọn ngày muốn sao chép khác.")]
        public DateTime? NgaySaoChep { get; set; }
        public bool HasDienBienBenh { get; set; } = false;
        public bool HasBenhAnThuocTayY { get; set; } = false;
        public bool HasBenhAnThuocYhct { get; set; } = false;
        public bool HasBenhAnTtvltl { get; set; } = false;
        public bool HasBenhAnCls { get; set; } = false;
        public bool HasBenhAnPhauThuat { get; set; } = false;
        public bool HasBenhAnCpm { get; set; } = false;
    }

    public class CheckExistsAttribute : ValidationAttribute
    {
        private string _firstPropertyName { get; set; }
        private string _secondPropertyName { get; set; }

        public CheckExistsAttribute(string firstPropertyName, string secondPropertyName)
        {
            _firstPropertyName = firstPropertyName;
            _secondPropertyName = secondPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var firstValue = context.ObjectInstance.GetType().GetProperty(_firstPropertyName)?.GetValue(context.ObjectInstance, null);
            var secondValue = context.ObjectInstance.GetType().GetProperty(_secondPropertyName)?.GetValue(context.ObjectInstance, null);

            var repository = new GenericRepository<BenhAnToDieuTri>();
            var benhAnToDieuTri = repository.Table.Where(x => (bool)!x.Huy).FirstOrDefault(x => x.Idba == Convert.ToDecimal(firstValue) && x.NgayYlenh == (DateTime)secondValue);

            if (benhAnToDieuTri != null)
            {
                return new ValidationResult(FormatErrorMessage(context.DisplayName), new[] { context.MemberName });
            }
            return ValidationResult.Success;
        }
    }
}