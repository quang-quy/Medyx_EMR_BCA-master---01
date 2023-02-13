using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhanPhauThuatPhieuPtttDto
	{
		public int Sttpt { get; set; }
		public decimal Idba { get; set; }
		public DmkhoaDto Khoa { get; set; }
		public DmkhoaBuongDto Buong { get; set; }
		public DmkhoaGiuongDto Giuong { get; set; }
        public DmbenhTatDto ChanDoan { get; set; }
		public DmphauThuatDto PhauThuat { get; set; }
		public DmnhanVienDto BsChiDinh { get; set; }
		public DateTime? NgayChiDinh { get; set; }
		public string MaBa { get; set; }
		public string MaBn { get; set; }
		public DateTime? NgayPt { get; set; }
		public DmbenhTatDto ChanDoanTruocPt { get; set; }
		public DmbenhTatDto ChanDoanSauPt { get; set; }
		public string PhuongPhap { get; set; }
		public DmdichvuPhanLoaiPtttDto LoaiPhauThuat { get; set; }
		public string PhuongPhapVoCam { get; set; }
		public string LuocDoPt { get; set; }
		public string DanLuu { get; set; }
		public string Bac { get; set; }
		public DateTime? NgayRutChi { get; set; }
		public DateTime? NgayCatChi { get; set; }
		public string Khac { get; set; }
		public string TrinhTuPt { get; set; }
		public string PhuongThucPt { get; set; }
		public string ViTriPt { get; set; }
		public string CachThucPt { get; set; }
		public DateTime? NgayKy { get; set; }
		public bool? Huy { get; set; }
		public string MaMay { get; set; }
		public DateTime? NgayLap { get; set; }
		public DateTime? NgaySd { get; set; }
		public DateTime? NgayHuy { get; set; }
		public DmnhanVienDto Bspt { get; set; }
		public DmnhanVienDto BsgayMe { get; set; }
		public DmnhanVienDto BsphuMo { get; set; }
		public DmnhanVienDto NguoiLap { get; set; }
		public DmnhanVienDto NguoiHuy { get; set; }
		public DmnhanVienDto NguoiSD { get; set; }
	}
}
