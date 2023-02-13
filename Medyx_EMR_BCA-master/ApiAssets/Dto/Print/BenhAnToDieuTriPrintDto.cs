using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx.ApiAssets.Dto.Print
{
	public class BenhAnToDieuTriPrintV2Dto{
		public string MaKhoa { get; set; }
		public List<string> fields { get; set; }
		public List<string> values { get; set; }
		public List<ThuocDto> Thuocs { get; set; } 
	}
	public class BenhAnToDieuTriManTinhPrintDto{
		public List<string> fields { get; set; }
		public List<string> values { get; set; }
        public List<ChiTietThuocDto> ChiTietThuocs { get; set; }
	}
	public class ChiTietThuocDto
	{
		public string ThuocSoLuong { get; set; }
		public string ThuocCachDung { get; set; }
	}
	public class ThuocDto
	{
		public string NgayYLenh { get; set; }
		public string DienBien { get; set; }
		public string BsdieuTri { get; set; }
		public string YLenhChamSoc { get; set; }
        public List<ChiTietThuocDto> ChiTietThuocs { get; set; }
	}
	public class BenhAnToDieuTriPrintDto
	{
		public string SoYTe { get; set; }
		public string BenhVien { get; set; }
		public string Khoa { get; set; }
		public string MaKhoa { get; set; }
		public string SoVV { get; set; }
		public string ChanDoan { get; set; }
		public string HoTen { get; set; }
		public string Tuoi { get; set; }
		public string GioiTinh { get; set; }
		public string Giuong { get; set; }
		public string Buong { get; set; }
		public List<ThuocDto> Thuocs { get; set; }
	}
	public class ToDieuTriManTinhPrintDto
	{
		public string SoYTe { get; set; }
		public string BenhVien { get; set; }
		public string Khoa { get; set; }
		public string SoVaoVien { get; set; }
		public string HoVaTen { get; set; }
		public string Tuoi { get; set; }
		public string GioiTinh { get; set; }
		public string Buong { get; set; }
		public string Giuong { get; set; }
		public string ChanDoan { get; set; }
		public string HAToDieuTri { get; set; }
		public string NhipTimToDieuTri { get; set; }
		public string ToDieuTriNhipTimDeu_0 { get; set; }
		public string ToDieuTriNhipTimDeu_1 { get; set; }
		public string ChiSoDuongHuyet { get; set; }
		public string ChieuCaoToDieuTri { get; set; }
		public string CanNangToDieuTri { get; set; }
		public string ChiSoBMIToDieuTri { get; set; }
		public string TrieuChungToDieuTri { get; set; }
		public string KetQuaXetNghiemMau { get; set; }
		public string KetQuaXetNghiemNuocTieu { get; set; }
		public string KetQuaChuanDoanHinhAnh { get; set; }
		public string DieuTri { get; set; }
		public string ToDieuTriHenKhamLai { get; set; }
		public string ToDieuTriHenXetNghiemLai { get; set; }
		public string NgayThangDieuTri { get; set; }
		public string BsDieuTri { get; set; }
	}
}