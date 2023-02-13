using System;
using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnClsKqDto : BenhAnClsKq
	{
		public new DmnhanVienDto BschuyenKhoa { get; set; }
		public new DmnhanVienDto NgayLap { get; set; }
		public new DmnhanVienDto NguoiSd { get; set; }
		public new DmnhanVienDto NguoiHuy { get; set; }
	}
}
