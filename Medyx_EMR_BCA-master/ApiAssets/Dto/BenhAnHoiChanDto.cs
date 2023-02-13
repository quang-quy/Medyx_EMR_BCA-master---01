using System;
using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnHoiChanDto:BenhAnHoiChan
	{
		public new DmnhanVienDto ChuToa { get; set; } = null;
		public new DmnhanVienDto ThuKy { get; set; } = null;
		public new DmnhanVienDto NguoiLap { get; set; } = null;
		public new DmnhanVienDto NguoiHuy { get; set; } = null;
		public new DmnhanVienDto NguoiSd { get; set; } = null;
		public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; } = null;
	}
}
