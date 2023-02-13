using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class ThongTinBnDto
	{
		public string MaBn { get; set; }
		public decimal Idba { get; set; }
		public string HoTen { get; set; }
		public DateTime NgaySinh { get; set; }
		public byte? Tuoi { get; set; }
		public byte GioiTinh { get; set; }
		public string SoNha { get; set; }
		public string Thon { get; set; }
		public string SoTheBhyt { get; set; }
		public string NoiLamViec { get; set; }
		public DateTime? Gtbhytdn { get; set; }
		public string LienHe { get; set; }
		public string SoDienThoai { get; set; }
		public string NgheNghiepNguoiGiamHo { get; set; }
		public string QuanHeNguoiGiamHo { get; set; }
		public DmkhoaDto Khoa { get; set; }
		public DmkhoaBuongDto Buong { get; set; }
		public DmkhoaGiuongDto Giuong { get; set; }
		public DmtinhDto Tinh { get; set; }
		public DmquanHuyenDto QuanHuyen { get; set; }
		public DmphuongXaDto PhuongXa { get; set; }
		public DmquocGiaDto QuocGia { get; set; }
		public DmdoiTuongDto DoiTuong { get; set; }
		public DmngheNghiepDto NgheNghiep { get; set; }
		public DmdanTocDto DanToc { get; set; }
	}
}
