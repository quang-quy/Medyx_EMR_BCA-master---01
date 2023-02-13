using Medyx_EMR_BCA.ApiAssets.Models;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnToDieuTriDetailDto
	{
		public BenhAnToDieuTriDetailThongTinBenhNhanDto BenhNhan { get; set; }
		public BenhAnToDieuTriDetailDmnhanVienDto BsdieuTri { get; set; }
		public BenhAnToDieuTriDetailKhoaDieuTriDto KhoaDieuTri { get; set; }
        public int? Sttkhoa { get; set; }
		public DateTime? NgayYLenh { get; set; }
		public string DienBienBenh { get; set; }
		public string Ylenh { get; set; }
        public string MaKhoa { get; set; }
		public string HuyetAp { get; set; }
		public int? NhipTho { get; set; }
		public decimal? CanNang { get; set; }
		public decimal? ChieuCao { get; set; }
		public decimal? Bmi { get; set; }
		public string TrieuChung { get; set; }
		public int? NhipTim { get; set; }
		public byte? NhipTimDeu { get; set; }
		public string Kqxnmau { get; set; }
		public string KqxnnuocTieu { get; set; }
		public string Kqcdha { get; set; }
		public string CsduongHuyet { get; set; }
		public string DieuTri { get; set; }
		public DateTime? NgayHenKhamLai { get; set; }
		public DateTime? NgayHenXnlai { get; set; }
		public bool? Huy { get; set; }
	}

	public class BenhAnToDieuTriDetailThongTinBenhNhanDto
	{
		public string MaBn { get; set; }
		public string HoTen { get; set; }
		public string GioiTinh { get; set; }
	}

	public class BenhAnToDieuTriDetailKhoaDieuTriDto
	{
		public string TenKhoa { get; set; }
		public string MaKhoa { get; set; }
		public string MaBenhChinhVk {get; set;}
		public DateTime? NgayVaoKhoa { get; set; }
		public DmkhoaBuongDto Buong { get; set; }
		public DmkhoaGiuongDto Giuong { get; set; }
		public DmbenhTatDto BenhChinh { get; set; }
	}

	public sealed class BenhAnToDieuTriDetailDmnhanVienDto
	{
		public string MaNv { get; set; }
		public string HoTen { get; set; }
		public DmkhoaDto Khoa { get; set; }
	}
}
