using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnThongTinTuVongDto
	{
		public decimal Idba { get; set; }
		public string MaBa { get; set; }
		public ThongTinBnDto BenhNhan { get; set; }
		public DmkhoaDto Khoa { get; set; }
		public DateTime NgayVv { get; set; }
		public DateTime? NgayTuVong { get; set; }
		public BenhAnTvBbkiemDiemDto PhieuKiemDiemTuVong { get; set; }
		public BenhAnTvPhieuCdnguyenNhanDto PhieuChanDoanNguyenNhanTuVong { get; set; }
	}
}
