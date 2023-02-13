using System;
using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnTongKet15NgayDtDto:BenhAnTongKet15NgayDt
	{
		public new DmnhanVienDto TruongKhoa { get; set; } = null;
		public new DmnhanVienDto BsdieuTri { get; set; } = null;
		public new DmnhanVienDto NguoiLap { get; set; } = null;
		public new DmnhanVienDto NguoiHuy { get; set; } = null;
		public new DmnhanVienDto NguoiSd { get; set; } = null;
		public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; } = null;
	}
}
