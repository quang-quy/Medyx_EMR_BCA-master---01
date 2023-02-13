using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
	public partial class Dmthuoc
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
		public bool? Huy { get; set; }
		public DateTime? NgaySd { get; set; }
		public string NguoiSd { get; set; }
		public DateTime? NgaySd1 { get; set; }
		public string NguoiSd1 { get; set; }
		public DateTime? NgayLap { get; set; }
		public string NguoiLap { get; set; }
		public DateTime? NgayHuy { get; set; }
		public string NguoiHuy { get; set; }
		public virtual DmthuocDonvitinh DmthuocDonvitinh { get; set; }
		public virtual DmthuocDuongDung DmthuocDuongDung { get; set; }
		public virtual DmquocGia DmquocGia { get; set; }
		public virtual DmnhanVien DmNguoiLap { get; set; }
		public virtual DmnhanVien DmNguoiHuy { get; set; }
		public virtual DmnhanVien DmNguoiSD { get; set; }
		public virtual ICollection<BenhanThuocTayY> BenhanThuocTayYs { get; set; }
		public virtual ICollection<BenhanThuocYhctC> BenhanThuocYhctCs { get; set; }
		public virtual ICollection<DmthuocBaiThuocC> DmthuocBaiThuocCs { get; set; }

	}
}
