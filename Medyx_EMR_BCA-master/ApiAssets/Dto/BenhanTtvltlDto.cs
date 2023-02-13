using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhanTtvltlDto
	{
		public int Stt { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public DmdichVuDto DichVu { get; set; }
		public byte? SoLuong { get; set; }
		public string ViTri { get; set; }
		public string ThoiGian { get; set; }
		public bool? Huy { get; set; }
		public DateTime? NgayLap { get; set; }
		public DateTime? NgaySd { get; set; }
		public DateTime? NgayHuy { get; set; }
		public DmnhanVienDto NguoiLap { get; set; } = null;
		public DmnhanVienDto NguoiHuy { get; set; } = null;
		public DmnhanVienDto NguoiSD { get; set; } = null;
	}
}
