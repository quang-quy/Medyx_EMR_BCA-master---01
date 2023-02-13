using Medyx.ApiAssets.Models;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmnhanVien
    {
        public string MaNv { get; set; }
        public string HoTen { get; set; }
        public string MaChucVu { get; set; }
        public string MaLoaiHd { get; set; }
        public string MaChuyenMon { get; set; }
        public string MaKhoa { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? KhongSd { get; set; }
        public string NguoiSd1 { get; set; }
        public DateTime? NgaySd1 { get; set; }
        public int? MaQl { get; set; }
        public string MaCd { get; set; }
        public string TenTat { get; set; }
        public string GhiChu { get; set; }
        public string Idnhanvien { get; set; }
        public string Manv1 { get; set; }
        public string DienThoai { get; set; }
        public string MaChungChiHanhNghe { get; set; }
        public string NguoiGiamHo { get; set; }
        public string DienThoaiKhoa { get; set; }
        public string Chuky { get; set; }
        public string Manvtruongkhoa { get; set; }
        public virtual Dmkhoa Dmkhoa { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTriNguoiLaps { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTriNguoiHuys { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTriNguoiSDs { get; set; }

        public virtual ICollection<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDichBschiDinhs { get; set; }
        public virtual ICollection<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDichDieuDuongs { get; set; }
        public virtual ICollection<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDichNguoiLaps { get; set; }
        public virtual ICollection<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDichNguoiHuys { get; set; }
        public virtual ICollection<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDichNguoiSDs { get; set; }
        public virtual ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocDieuDuongs { get; set; }
        public virtual ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocNguoiLaps { get; set; }
        public virtual ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocNguoiHuys { get; set; }
        public virtual ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiemNguoiLaps { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiemNguoiHuys { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiemNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiemChuToas { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiemThuKys { get; set; }
        public virtual ICollection<BenhanClsKqcs> BenhanClsKqcsNguoiDuyetKqs { get; set; }
        public virtual ICollection<BenhanClsKqcs> BenhanClsKqcsKtvs { get; set; }
        public virtual ICollection<BenhanClsKqcs> BenhanClsKqcsNguoiLaps { get; set; }
        public virtual ICollection<BenhanClsKqcs> BenhanClsKqcsNguoiHuys { get; set; }
        public virtual ICollection<BenhanClsKqcs> BenhanClsKqcsNguoiSDs { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoBspts { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoBsgayMes { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoTruongKhoas { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoLanhDaoBvs { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoNguoiLaps { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoNguoiHuys { get; set; }
        public virtual ICollection<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMoNguoiSDs { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttBspts { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttBsgayMes { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttBsphuMos { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttNguoiLaps { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttNguoiHuys { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttNguoiSDs { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMoDieuDuongs { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMoBsgayMeKhams { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMoBsgayMeThamLaiTruocMos { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMoNguoiLaps { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMoNguoiHuys { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMoNguoiSDs { get; set; }

        public virtual ICollection<BenhanCls> BenhanClsBsChiDinhs { get; set; }
        public virtual ICollection<BenhanCls> BenhanClsNguoiLaps { get; set; }
        public virtual ICollection<BenhanCls> BenhanClsNguoiHuys { get; set; }
        public virtual ICollection<BenhanCls> BenhanClsNguoiSDs { get; set; }
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngNguoiThus { get; set; }
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngBschiDinhs { get; set; }
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngBsdocKqs { get; set; }
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngNguoiLaps { get; set; }
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngNguoiHuys { get; set; }
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngNguoiSDs { get; set; }
        public virtual ICollection<BenhAn> BenhAnBsDieuTris { get; set; }
        public virtual ICollection<BenhAn> BenhAnGiamdocs { get; set; }
        public virtual ICollection<BenhAn> BenhAnTruongKhoas { get; set; }
        public virtual ICollection<BenhAn> BenhAnNguoiLaps { get; set; }
        public virtual ICollection<BenhAn> BenhAnNguoiHuys { get; set; }
        public virtual ICollection<BenhAnKhamVaoVien> BenhAnKhamVaoVienBsKhams { get; set; }
        public virtual ICollection<BenhAnToDieuTri> BenhAnToDieuTris { get; set; }
        public virtual ICollection<BenhAnToDieuTri> BenhAnToDieuTriNguoiLaps { get; set; }
        public virtual ICollection<BenhAnToDieuTri> BenhAnToDieuTriNguoiHuys { get; set; }
        public virtual ICollection<BenhAnToDieuTri> BenhAnToDieuTriNguoiSDs { get; set; }
        public virtual ICollection<BenhanThuocTayY> BenhanThuocTayYs { get; set; }
        public virtual ICollection<BenhanThuocTayY> BenhanThuocTayYNguoiLaps { get; set; }
        public virtual ICollection<BenhanThuocTayY> BenhanThuocTayYNguoiHuys { get; set; }
        public virtual ICollection<BenhanThuocTayY> BenhanThuocTayYNguoiSDs { get; set; }
        public virtual ICollection<BenhanThuocYhct> BenhanThuocYhcts { get; set; }
        public virtual ICollection<BenhanThuocYhct> BenhanThuocYhctNguoiLaps { get; set; }
        public virtual ICollection<BenhanThuocYhct> BenhanThuocYhctNguoiHuys { get; set; }
        public virtual ICollection<BenhanThuocYhct> BenhanThuocYhctNguoiSDs { get; set; }
        public virtual ICollection<BenhanThuocYhctC> BenhanThuocYhctCNguoiLaps { get; set; }
        public virtual ICollection<BenhanThuocYhctC> BenhanThuocYhctCNguoiHuys { get; set; }
        public virtual ICollection<BenhanThuocYhctC> BenhanThuocYhctCNguoiSDs { get; set; }
        public virtual ICollection<BenhanTtvltl> BenhanTtvltls { get; set; }
        public virtual ICollection<BenhanTtvltl> BenhanTtvltlNguoiLaps { get; set; }
        public virtual ICollection<BenhanTtvltl> BenhanTtvltlNguoiHuys { get; set; }
        public virtual ICollection<BenhanTtvltl> BenhanTtvltlNguoiSDs { get; set; }
        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuatBsDieuTris { get; set; }
        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuatNguoiLaps { get; set; }
        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuatNguoiHuys { get; set; }
        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuatNguoiSDs { get; set; }
        public virtual ICollection<BenhanCpm> BenhanCpmBsDieuTris { get; set; }
        public virtual ICollection<BenhanCpm> BenhanCpmNguoiLaps { get; set; }
        public virtual ICollection<BenhanCpm> BenhanCpmNguoiHuys { get; set; }
        public virtual ICollection<BenhanCpm> BenhanCpmNguoiSDs { get; set; }
        public virtual ICollection<Dmthuoc> DmthuocNguoiSDs { get; set; }
        public virtual ICollection<Dmthuoc> DmthuocNguoiHuys { get; set; }
        public virtual ICollection<Dmthuoc> DmthuocNguoiLaps { get; set; }
        public virtual ICollection<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDtTruongKhoas { get; set; }
        public virtual ICollection<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDtBsdieuTris { get; set; }
        public virtual ICollection<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDtNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDtNguoiHuys { get; set; }
        public virtual ICollection<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDtNguoiLaps { get; set; }
        public virtual ICollection<BenhAnHoiChan> BenhAnHoiChanChuToas { get; set; }
        public virtual ICollection<BenhAnHoiChan> BenhAnHoiChanThuKys { get; set; }
        public virtual ICollection<BenhAnHoiChan> BenhAnHoiChanNguoiSDs { get; set; }
        public virtual ICollection<BenhAnHoiChan> BenhAnHoiChanNguoiHuys { get; set; }
        public virtual ICollection<BenhAnHoiChan> BenhAnHoiChanNguoiLaps { get; set; }
        public virtual ICollection<BenhAnClsKq> BenhAnClsKqs { get; set; }
        public virtual ICollection<BenhAnClsKq> BenhAnClsKqSDs { get; set; }
        public virtual ICollection<BenhAnClsKq> BenhAnClsKqHuys { get; set; }
        public virtual ICollection<BenhAnClsKq> BenhAnClsKqNguoiLaps { get; set; }
        public virtual ICollection<BenhAnKhamSangLocDd> BenhAnKhamSangLocDdNguoiDgs { get; set; }
        public virtual ICollection<BenhAnKhamSangLocDd> BenhAnKhamSangLocDdBsdieuTris { get; set; }
        public virtual ICollection<BenhAnKhamSangLocDd> BenhAnKhamSangLocDdNguoiSDs { get; set; }
        public virtual ICollection<BenhAnKhamSangLocDd> BenhAnKhamSangLocDdNguoiHuys { get; set; }
        public virtual ICollection<BenhAnKhamSangLocDd> BenhAnKhamSangLocDdNguoiLaps { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiemTv> BenhAnTvBbkiemDiemTvThanhViens { get; set; }
        public virtual ICollection<BenhAnTvBbkiemDiemTv> BenhAnTvBbkiemDiemTvNguoiHuys { get; set; }
        public virtual ICollection<BenhAnTongKetBenhAn> BenhAnTongKetBsDieuTris { get; set; }
        public virtual ICollection<BenhAnTongKetBenhAn> BenhAnTongKetNguoiGiaos { get; set; }
        public virtual ICollection<BenhAnTongKetBenhAn> BenhAnTongKetNguoiNhans { get; set; }
        public virtual ICollection<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTrucNguoiLaps { get; set; }
        public virtual ICollection<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTrucNguoiHuys { get; set; }
        public virtual ICollection<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTrucNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTvPhieuCdnguyenNhan> BenhAnTvPhieuCdnguyenNhanNguoiLapPhieus { get; set; }
        public virtual ICollection<BenhAnTvPhieuCdnguyenNhan> BenhAnTvPhieuCdnguyenNhanThutruongs { get; set; }
        public virtual ICollection<BenhAnKhamYhhd> BenhAnKhamYhhdBskhams { get; set; }
        public virtual ICollection<BenhAnTheoDoiTruyenMau> BenhAnTheoDoiTruyenMauDieuDuongs { get; set; }
        public virtual ICollection<BenhAnTheoDoiTruyenMau> BenhAnTheoDoiTruyenMauBsTheoDois { get; set; }
        public virtual ICollection<BenhAnTheodoiTruyenMauC> BenhAnTheodoiTruyenMauCNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTheodoiTruyenMauC> BenhAnTheodoiTruyenMauCNguoiHuys { get; set; }
        public virtual ICollection<BenhAnTheodoiTruyenMauC> BenhAnTheodoiTruyenMauCNguoiLaps { get; set; }
        public virtual ICollection<BenhAnTaiBienPttt> BenhAnTaiBienPtttNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTaiBienPttt> BenhAnTaiBienPtttNguoiHuys { get; set; }
        public virtual ICollection<BenhAnTaiBienPttt> BenhAnTaiBienPtttNguoiLaps { get; set; }
        public virtual ICollection<BenhAnPhacDoDt> BenhAnPhacDoDtNguoiSDs { get; set; }
        public virtual ICollection<BenhAnPhacDoDt> BenhAnPhacDoDtNguoiHuys { get; set; }
        public virtual ICollection<BenhAnPhacDoDt> BenhAnPhacDoDtNguoiLaps { get; set; }
        public virtual ICollection<BenhanTtvltlDotDieuTri> BenhanTtvltlDotDieuTriNguoiSDs { get; set; }
        public virtual ICollection<BenhanTtvltlDotDieuTri> BenhanTtvltlDotDieuTriNguoiHuys { get; set; }
        public virtual ICollection<BenhanTtvltlDotDieuTri> BenhanTtvltlDotDieuTriNguoiLaps { get; set; }
        public virtual ICollection<BenhanTtvltlDotDieuTri> BenhanTtvltlDotDieuTriBsDieuTris { get; set; }
        public virtual ICollection<BenhAnTtvltlThuchien> BenhAnTtvltlThuchienNguoiSDs { get; set; }
        public virtual ICollection<BenhAnTtvltlThuchien> BenhAnTtvltlThuchienNguoiHuys { get; set; }
        public virtual ICollection<BenhAnTtvltlThuchien> BenhAnTtvltlThuchienNguoiLaps { get; set; }
    }
}
