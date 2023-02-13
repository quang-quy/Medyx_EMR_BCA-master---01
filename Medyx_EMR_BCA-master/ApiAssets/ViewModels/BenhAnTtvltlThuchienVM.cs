using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTtvltlThuchienVM
    {
        [Required(ErrorMessage = "STT đợt điều trị là bắt buộc.")]
        public int SttdotDt { get; set; }
        [Required(ErrorMessage = "STT chỉ định là bắt buộc.")]
        public int SttchiDinh { get; set; }
        [CompareWithNgayVaoDieuTri("Idba", "SttchiDinh", ErrorMessage = "Ngày thực hiện phải lớn hơn hoặc bằng ngày vào điêu trị {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày thực hiện phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayThucHien { get; set; }
        public string MaDv { get; set; }
        public string ThoiGian { get; set; }
        public string LieuLuong { get; set; }
        public string GhiChu { get; set; }
        public string NguoiThucHien { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnTtvltlThuchienCreateVM : BenhAnTtvltlThuchienVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
    }

    public class CompareWithNgayVaoDieuTriAttribute : ValidationAttribute
    {
        private string _idba { get; set; }
        private string _sttchiDinh { get; set; }
        private readonly RequiredAttribute _innerAttribute;
        private object _ngayVaoDieuTri;

        public CompareWithNgayVaoDieuTriAttribute(string idba, string sttchiDinh)
        {
            _idba = idba;
            _sttchiDinh = sttchiDinh;
            _innerAttribute = new RequiredAttribute();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var idba = context.ObjectInstance.GetType().GetProperty(_idba)?.GetValue(context.ObjectInstance, null);
            var sttchiDinh = context.ObjectInstance.GetType().GetProperty(_sttchiDinh)?.GetValue(context.ObjectInstance, null);

            if (idba is null || decimal.Parse(idba.ToString()) == 0)
            {
                var httpContextAccessor = (IHttpContextAccessor)context.GetService(typeof(IHttpContextAccessor));
                var path = httpContextAccessor.HttpContext?.Request.Path.Value;
                foreach (var segment in path.Split('/'))
                {
                    decimal tempIdba = 0;
                    decimal.TryParse(segment, out tempIdba);
                    if (tempIdba > 0)
                    {
                        idba = tempIdba;
                        break;
                    }
                }
            }

            var repository = new GenericRepository<BenhanTtvltl>();
            var benhanTtvltl = repository.GetById(idba, sttchiDinh);
            if (benhanTtvltl != null && value != null && DateTime.Compare(((DateTime)benhanTtvltl.NgayYlenh).Date, (DateTime)value) > 0)
            {
                _ngayVaoDieuTri = benhanTtvltl.NgayYlenh;
                return new ValidationResult(FormatErrorMessage(context.DisplayName), new[] { context.MemberName });
            }
            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[2] { name, ((DateTime)_ngayVaoDieuTri).ToString("dd/MM/yyyy") });
        }
    }
}