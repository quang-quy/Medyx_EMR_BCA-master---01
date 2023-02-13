using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnDto
	{
		public decimal Idba { get; set; }
		public string MaBa { get; set; }
		public string TenDvcq { get; set; }
		public string SoVaoVien { get; set; }
		public string MaYt { get; set; }
		public string SoLuuTru { get; set; }
		public string MaBv { get; set; }
        public byte LoaiBa { get; set; }
		public string TenBv { get; set; }
        public string MaBvChuyenDen { get; set; }
        public byte? XacNhanLuuTru { get; set; }
        public DateTime? NgayLuuTru { get; set; }
        public byte? XacNhanKetThucHs { get; set; }
        public DateTime? NgayXacNhanKetThucHs { get; set; }
        public DateTime NgayVv { get; set; }
		public DateTime? NgayRv { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayHuy { get; set; }
		public bool? Huy { get; set; }
		public ThongTinBnDto BenhNhan { get; set; }
		public DmbaLoaiBaDto LoaiBenhAn { get; set; }
		public DmkhoaDto Khoa { get; set; }
		public DmkhoaBuongDto Buong { get; set; }
		public DmkhoaGiuongDto Giuong { get; set; }
		public DmnhanVienDto NguoiHuy { get; set; }
		public DmnhanVienDto NguoiLap { get; set; }
		public DmnhanVienDto Giamdoc { get; set; }
		public DmnhanVienDto TruongKhoa { get; set; }
	}
}
