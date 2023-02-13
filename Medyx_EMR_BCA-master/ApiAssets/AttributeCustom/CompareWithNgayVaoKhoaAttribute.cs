using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
    public class CompareWithNgayVaoKhoaAttribute : ValidationAttribute
    {
        private string _firstPropertyName { get; set; }
        private string _secondPropertyName { get; set; }
        private readonly RequiredAttribute _innerAttribute;
        private object _ngayVaoKhoa;
        private int _coefficient;
        private bool _compareDateOnly = false;
        public CompareWithNgayVaoKhoaAttribute(string firstPropertyName, string secondPropertyName, int coefficient = 1, bool compareDateOnly = false)
        {
            _firstPropertyName = firstPropertyName;
            _secondPropertyName = secondPropertyName;
            _innerAttribute = new RequiredAttribute();
            _coefficient = coefficient;
            _compareDateOnly = compareDateOnly;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var firstValue = context.ObjectInstance.GetType().GetProperty(_firstPropertyName)?.GetValue(context.ObjectInstance, null);
            var secondValue = context.ObjectInstance.GetType().GetProperty(_secondPropertyName)?.GetValue(context.ObjectInstance, null);

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

            var repository = new GenericRepository<BenhAnKhoaDieuTri>();
            var benhAnKhoaDieuTri = repository.GetById(firstValue, secondValue);

            if (benhAnKhoaDieuTri != null && benhAnKhoaDieuTri.NgayVaoKhoa != null && value != null && (_coefficient * DateTime.Compare(_compareDateOnly ? (DateTime)benhAnKhoaDieuTri.NgayVaoKhoa.Date : (DateTime)benhAnKhoaDieuTri.NgayVaoKhoa, _compareDateOnly ? ((DateTime)value).Date : (DateTime)value)) > 0)
            {
                _ngayVaoKhoa = benhAnKhoaDieuTri.NgayVaoKhoa;
                return new ValidationResult(FormatErrorMessage(context.DisplayName), new[] { context.MemberName });
            }
            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[2] { name, ((DateTime)_ngayVaoKhoa).ToString(_compareDateOnly ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm:ss") });
        }
    }
}
