using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAn : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string TenDvcq { get; set; }
        public string MaBv { get; set; }
        public string TenBv { get; set; }
        public string MaKhoaVv { get; set; }
        public string Buong { get; set; }
        public string Giuong { get; set; }
        public string SoVaoVien { get; set; }
        public string SoLuuTru { get; set; }
        public string MaBn { get; set; }
        public string MaYt { get; set; }
        public byte LoaiBa { get; set; }
        public DateTime NgayVv { get; set; }
        public DateTime? NgayRv { get; set; }
        public string TrucTiepVao { get; set; }
        public string NoiGt { get; set; }
        public int? Vvlan { get; set; }
        public string ChuyenVien { get; set; }
        public string MaBvChuyenDen { get; set; }
        public string HtraVien { get; set; }
        public int? TongSoNgayDt { get; set; }
        public string MaBenhNoiChuyenDenYhhd { get; set; }
        public string MaBenhKkbyhhd { get; set; }
        public string MaBenhChinhVv { get; set; }
        public string TenBenhChinhVv { get; set; }
        public string MaBenhKemVv1 { get; set; }
        public string MaBenhKemVv2 { get; set; }
        public string MaBenhKemVv3 { get; set; }
        public string MaBenhChinhRv { get; set; }
        public string TenBenhChinhRv { get; set; }
        public string MaBenhKemRv1 { get; set; }
        public string MaBenhKemRv2 { get; set; }
        public string MaBenhKemRv3 { get; set; }
        public byte? ThuThuatYhhd { get; set; }
        public byte? PhauThuatYhhd { get; set; }
        public byte? TaiBienYhhd { get; set; }
        public byte? BienChungYhhd { get; set; }
        public string MaBenhNoiChuyenDenYhct { get; set; }
        public string MaBenhKkbyhct { get; set; }
        public string MaBenhChinhVvyhct { get; set; }
        public string TenBenhChinhVvyhct { get; set; }
        public string MaBenhKemVv1yhct { get; set; }
        public string MaBenhKemVv2yhct { get; set; }
        public string MaBenhKemVv3yhct { get; set; }
        public string MaBenhChinhRvyhct { get; set; }
        public string TenBenhChinhRvyhct { get; set; }
        public string MaBenhKemRv1yhct { get; set; }
        public string MaBenhKemRv2yhct { get; set; }
        public string MaBenhKemRv3yhct { get; set; }
        public byte? ThuThuatYhct { get; set; }
        public byte? PhauThuatYhct { get; set; }
        public byte? TaiBienYhct { get; set; }
        public byte? BienChungYhct { get; set; }
        public string Kqdt { get; set; }
        public string GiaiPhauBenh { get; set; }
        public DateTime? NgayTuVong { get; set; }
        public string TinhTrangTuVong { get; set; }
        public string NguyenNhanTuVong { get; set; }
        public byte? KhamNghiemTuThi { get; set; }
        public string MaBenhGptuThi { get; set; }
        public string BsdieuTri { get; set; }
        public DateTime? NgayKy { get; set; }
        public string GiamDoc { get; set; }
        public string TruongKhoa { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayTruongKhoaKy { get; set; }
        public DateTime? NgayBatDauNghiViecHuongBhxh { get; set; }
        public DateTime? NgayKetThucNghiViecHuongBhxh { get; set; }
        public DateTime? NgayCapGiayCnnvhuongBhxh { get; set; }
        public string NguoiXacnhanKetThucHs { get; set; }
        public byte? XacNhanKetThucHs { get; set; }
        public DateTime? NgayXacNhanKetThucHs { get; set; }
        public string NguoiLuuTru { get; set; }
        public byte? XacNhanLuuTru { get; set; }
        public DateTime? NgayLuuTru { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual ThongTinBn ThongTinBn { get; set; }
        [JsonIgnore]
        public virtual DmbaLoaiBa DmbaLoaiBa { get; set; }
        [JsonIgnore]
        public virtual Dmkhoa Dmkhoa { get; set; }
        [JsonIgnore]
        public virtual DmkhoaBuong DmkhoaBuong { get; set; }
        [JsonIgnore]
        public virtual DmkhoaGiuong DmkhoaGiuong { get; set; }
        [JsonIgnore]
        public virtual DmbaNoiKham DmbaNoiKham { get; set; }
        [JsonIgnore]
        public virtual DmbaNoiGt DmbaNoiGt { get; set; }
        [JsonIgnore]
        public virtual DmbaChuyenVien DmbaChuyenVien { get; set; }
        [JsonIgnore]
        public virtual DmbenhVien DmbenhVien { get; set; }
        [JsonIgnore]
        public virtual DmbaHtraVien DmbaHtraVien { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhTatNoiChuyenDen { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKKBYHHD { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhChinhVV { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKemVV1 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKemVV2 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKemVV3 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhChinhRV { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKemRV1 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKemRV2 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhKemRV3 { get; set; }
        // public virtual DmbenhTat DmBenhGptuThi { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhNoiChuyenDenYHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKKBYHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhChinhVVYHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKemVV1YHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKemVV2YHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKemVV3YHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhChinhRVYHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKemRV1YHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKemRV2YHCT { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhKemRV3YHCT { get; set; }
        [JsonIgnore]
        public virtual DmbaLdtvong DmbaLdtvong { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhGPTuThi { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBsDieutri { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmGiamdoc { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmTruongKhoa { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual BenhAnTvBbkiemDiem BenhAnTvBbkiemDiem { get; set; }
        [JsonIgnore]
        public virtual BenhAnTvPhieuCdnguyenNhan BenhAnTvPhieuCdnguyenNhan { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnKhamVaoVien> BenhAnKhamVaoViens { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocs { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnTvBbkiemDiemTv> BenhAnTvBbkiemDiemTvs { get; set; }
    }
}
