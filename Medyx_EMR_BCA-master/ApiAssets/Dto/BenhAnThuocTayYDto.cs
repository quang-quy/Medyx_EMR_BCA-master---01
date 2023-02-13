using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnThuocTayYDto
	{
		public int Stt { get; set; }
        public string MaThuoc { get; set; }
		public string TenThuoc { get; set; }
		public string SoDangKi { get; set; }
		public DateTime? NgayYLenh { get; set; }
		public DmthuocDto Thuoc { get; set; }
		public decimal? SoLuong { get; set; }
		public string Lieudung { get; set; }
		public string CachDung { get; set; }
		public bool? Huy { get; set; }
		public DateTime? NgayLap { get; set; }
		public DateTime? NgaySd { get; set; }
		public DateTime? NgayHuy { get; set; }
		public DmnhanVienDto NguoiLap { get; set; }
		public DmnhanVienDto NguoiHuy { get; set; }
		public DmnhanVienDto NguoiSD { get; set; }
		public DmnhanVienDto BsChiDinh { get; set; }
	}
}
