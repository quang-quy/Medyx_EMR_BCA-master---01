using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
    public class RangeDateTimeAttribute : ValidationAttribute
    {
        private object _min { get; set; }
        private object _max { get; set; }
        private object _minValue { get; set; }
        private object _maxValue { get; set; }  
        private readonly RequiredAttribute _innerAttribute;

        public RangeDateTimeAttribute(object min, object max)
        {
            _min = min;
            _max = max;
            _innerAttribute = new RequiredAttribute();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            //Check min is not null
            if (_min is null) _minValue = DateTime.Now.AddYears(-100);
            else
            {
                if (_min.ToString().ToUpper() == "DATETIME.NOW")
                {
                    _minValue = DateTime.Now.ToString();
                }
                else
                {
                    _minValue = context.ObjectInstance.GetType().GetProperty(_min.ToString())?.GetValue(context.ObjectInstance, null);
                    if(_minValue is null) _minValue = DateTime.Now.AddYears(-100);
                }
            }

            if (_max is null) _maxValue = DateTime.Now.AddYears(100).ToString();
            else
            {
                if (_max.ToString().ToUpper() == "DATETIME.NOW")
                {
                    _maxValue = DateTime.Now.ToString();
                }
                else
                {
                    _maxValue = context.ObjectInstance.GetType().GetProperty(_max.ToString())?.GetValue(context.ObjectInstance, null);
                    if (_maxValue is null) _maxValue = DateTime.Now.AddYears(100);
                }
            }
            if (_innerAttribute.IsValid(value))
            {
                if (DateTime.Compare((DateTime)value, Convert.ToDateTime(_minValue)) < 0 || DateTime.Compare((DateTime)value, Convert.ToDateTime(_maxValue)) > 0)
                {
                    return new ValidationResult(FormatErrorMessage(context.DisplayName), new[] { context.MemberName });
                }
            }
            return ValidationResult.Success;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[3] { name, (Convert.ToDateTime(_minValue)).ToString("dd/MM/yyyy HH:mm:ss"), (Convert.ToDateTime(_maxValue)).ToString("dd/MM/yyyy HH:mm:ss") });
        }
    }
}
