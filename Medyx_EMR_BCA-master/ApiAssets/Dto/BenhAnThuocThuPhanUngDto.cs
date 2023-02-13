using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnThuocThuPhanUngDto
	{
		public decimal Idba { get; set; }
		public int Stt { get; set; }
		public string Idhis { get; set; }
		public string MaBa { get; set; }
		public string MaBn { get; set; }
		public int? Sttkhoa { get; set; }
		public DateTime? NgayBatDau { get; set; }
		public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
		public string PhuongPhapThu { get; set; }
		public DateTime? NgayDocKq { get; set; }
        public string KetQua { get; set; }
		public bool? Huy { get; set; }
		public string MaMay { get; set; }
		public DateTime? NgayLap { get; set; }
		public DateTime? NgaySd { get; set; }
		public DateTime? NgayHuy { get; set; }
		public DmnhanVienDto NguoiThu { get; set; } = null;
		public DmnhanVienDto BschiDinh { get; set; } = null;
		public DmnhanVienDto BsdocKq { get; set; } = null;
		public DmnhanVienDto NguoiLap { get; set; } = null;
		public DmnhanVienDto NguoiHuy { get; set; } = null;
		public DmnhanVienDto NguoiSD { get; set; } = null;
		public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; } = null;
	}
}
