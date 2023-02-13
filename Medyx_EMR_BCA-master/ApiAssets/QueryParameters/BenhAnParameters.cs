using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
	public class BenhAnParameters : QueryStringParameters, IValidatableObject
	{
		public BenhAnParameters()
		{
			SortBy = "MaBA";
		}

		public string MaBa { get; set; }
		public string MaBv { get; set; }
		public string TenBv { get; set; }
		public string TenBenhNhan { get; set; }
		public byte? Tuoi { get; set; }
		public byte? GioiTinh { get; set; }
		public string NamSinh { get; set; }
		public string SoBuong { get; set; }
		public string SoGiuong { get; set; }
		public string SoLuuTru { get; set; }
		public string SoVaoVien { get; set; }
		public DateTime? TuNgayVaoVien { get; set; }
		public DateTime? DenNgayVaoVien { get; set; }
		public DateTime? TuNgayRaVien { get; set; }
		public DateTime? DenNgayRaVien { get; set; }

		[FromQuery(Name = "ngayVaoVien[]")]
		public List<DateTime?> ngayVaoVien { get; set; } = new List<DateTime?>();
		[FromQuery(Name = "ngayRaVien[]")]
		public List<DateTime?> ngayRaVien { get; set; } = new List<DateTime?>();
		[FromQuery(Name = "maKhoa[]")]
		public List<string> MaKhoa { get; set; } = new List<string>();
		[FromQuery(Name = "loaiBenhAn[]")]
		public List<string> LoaiBenhAn { get; set; } = new List<string>();
        public byte? XacNhanLuuTru { get; set; }
        public byte? XacNhanKetThucHs { get; set; }
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Convert.ToBoolean(ngayVaoVien.Count) && (ngayVaoVien[0] > DateTime.Now || ngayVaoVien[1] > DateTime.Now))
			{
				yield return new ValidationResult($"Thời gian vào viện phải nhỏ hơn thời gian hiện tại.", new[] { nameof(ngayVaoVien) });
			}
			if (Convert.ToBoolean(ngayRaVien.Count) && (ngayRaVien[1] > DateTime.Now || ngayRaVien[1] > DateTime.Now))
			{
				yield return new ValidationResult($"Thời gian ra viện phải nhỏ hơn thời gian hiện tại.", new[] { nameof(ngayRaVien) });
			}
			/*if (TuNgayVaoVien > DateTime.Now)
			{
				yield return new ValidationResult($"Thời gian vào viện phải nhỏ hơn thời gian hiện tại.", new[] { nameof(TuNgayVaoVien) });
			}
			if (DenNgayVaoVien > DateTime.Now)
			{
				yield return new ValidationResult($"Thời gian vào viện phải nhỏ hơn thời gian hiện tại.", new[] { nameof(DenNgayVaoVien) });
			}
			if (TuNgayRaVien > DateTime.Now)
			{
				yield return new ValidationResult($"Thời gian ra viện phải nhỏ hơn thời gian hiện tại.", new[] { nameof(TuNgayRaVien) });
			}
			if (DenNgayRaVien > DateTime.Now)
			{
				yield return new ValidationResult($"Thời gian ra viện phải nhỏ hơn thời gian hiện tại.", new[] { nameof(DenNgayRaVien) });
			}*/
		}
	}
}
