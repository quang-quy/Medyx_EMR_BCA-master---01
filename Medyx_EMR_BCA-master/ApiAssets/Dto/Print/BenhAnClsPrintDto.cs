using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx.ApiAssets.Dto.Print
{
    public class XetNghiemItemDto{
        public int Stt { get; set; }
        public string TenXetNgiem { get; set; }
        public string KetQua { get; set; }
        public string DonVi { get; set; }
        public string GiaTriThemChieuNam { get; set; }
        public string GiaTriThemChieuNu { get; set; }
        public string MayXN { get; set; }

    }
    public class XetNghiemDto{
        public string LoaiXetNghiem { get; set; }
        public List<XetNghiemItemDto> XetNghiemItemDto { get; set; }
    }
    public class BenhanClsFileDinhKemDto{
        public string ImageFile { get; set;}
    }
    public class BenhAnClsPrintDto{
        public string SoYTe { get; set; }
        public string BenhVien { get; set; }
        public string DiaChiBenhVien { get; set; }
        public string DienThoaiBV { get; set; }
        public string HotlineBV { get; set; }
        public string Khoa { get; set; }
        public string SoVaoVien { get; set; }
        public string ChanDoan { get; set; }
        public string HoTen { get; set; }
        public string Tuoi { get; set; }
        public string NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string MaBenhICDX { get; set; }
        public string BSChiDinh { get; set; }
        public string GioiTinh { get; set; }
        public string YeuCau { get; set; }
        public string Giuong { get; set; }
        public string Buong { get; set; }
        public string YeuCauKiemTra { get; set; }
        public string BsChuyenKhoa { get; set; }
        public string BsDieuTri { get; set; }
        public string KyThuat { get; set; }
        public string HtmlMota { get; set; }
        public string HtmlKetLuan { get; set; }
        public string NgayGio { get; set; }
        public string NgayKham { get; set; }
        public string NgayChiDinh { get; set; }
        public string Capcuu { get; set; }
        public string Thuong { get; set; }
        public string SoPhieu { get; set; }
        public string IDXetNghiem { get; set; }
        public string MaICD { get; set; }
        public string NoiChiDinh { get; set; }
        public string NguoiThucHien { get; set; }
        public string NguoiDuyetKQ { get; set; }
        public string TheBHYT { get; set; }
        public string TenDichVu { get; set; }
        public string DoiTuong_0 { get; set; }
        public string DoiTuong_1 { get; set; }
        public string DoiTuong_2 { get; set; }
        public List<XetNghiemDto> XetNghiemDto { get; set;}
        public List<BenhanClsFileDinhKemDto> BenhanClsFileDinhKemDto { get; set; }
    }
}