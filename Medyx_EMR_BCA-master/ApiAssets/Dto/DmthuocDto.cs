 using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class DmthuocDto
    {
		public string MaThuoc { get; set; }
		public string MaNhom { get; set; }
		public string MaPl { get; set; }
		public string MaChungLoai { get; set; }
		public string MaDangBaoChe { get; set; }
		public string TenGoc { get; set; }
		public string TenTm { get; set; }
		public string HamLuong { get; set; }
		public string MaDvt { get; set; }
		public string MaNsx { get; set; }
		public string Ghichu { get; set; }
		public string MaQg { get; set; }
		public string MaDuongDung { get; set; }
		public string MaByt { get; set; }
		public string TenByt { get; set; }
		public string SoDangKy { get; set; }
		public string MaMay { get; set; }
		public DmthuocDonvitinhDto DonViTinh { get; set; }
		public DmthuocDuongDungDto ThuocDuongDung { get; set; }
		public DmquocGiaDto QuocGia { get; set; }
	}
}
