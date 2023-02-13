using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
    public class CompareWithNgayRvAttribute : ValidationAttribute
    {
        private string _firstPropertyName { get; set; }
        private readonly RequiredAttribute _innerAttribute;
        private object _ngayRaVien;
        private int _coefficient;
        private bool _compareDateOnly = false;
        public CompareWithNgayRvAttribute(string firstPropertyName, int coefficient = 1, bool compareDateOnly = false)
        {
            _firstPropertyName = firstPropertyName;
            _innerAttribute = new RequiredAttribute();
            _coefficient = coefficient;
            _compareDateOnly = compareDateOnly;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var firstValue = context.ObjectInstance.GetType().GetProperty(_firstPropertyName)?.GetValue(context.ObjectInstance, null);
            if (firstValue is null || decimal.Parse(firstValue.ToString()) == 0)
            {
                var httpContextAccessor = (IHttpContextAccessor)context.GetService(typeof(IHttpContextAccessor));
                var path = httpContextAccessor.HttpContext?.Request.Path.Value;
                foreach (var segment in path.Split('/'))
                {
                    decimal idba = 0;
                    decimal.TryParse(segment, out idba);
                    if (idba > 0)
                    {
                        firstValue = idba;
                        break;
                    }
                }
            }

            var repository = new GenericRepository<BenhAn>();
            var benhAn = repository.GetById(firstValue);

            if (value != null && benhAn != null && benhAn.NgayRv != null && (_coefficient * DateTime.Compare(_compareDateOnly ? ((DateTime)benhAn.NgayRv).Date : (DateTime)benhAn.NgayRv, _compareDateOnly ? ((DateTime)value).Date : (DateTime)value)) < 0)
            {
                _ngayRaVien = benhAn.NgayRv;
                return new ValidationResult(FormatErrorMessage(context.DisplayName), new[] { context.MemberName });
            }
            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[2] { name, ((DateTime)_ngayRaVien).ToString(_compareDateOnly ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm:ss") });
        }
    }
}
