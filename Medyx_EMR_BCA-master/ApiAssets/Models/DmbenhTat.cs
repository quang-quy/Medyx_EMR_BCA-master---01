using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbenhTat
    {
        public string Sttchuong { get; set; }
        public string MaChuong { get; set; }
        public string ChapterName { get; set; }
        public string TenChuong { get; set; }
        public string MaNhomChinh { get; set; }
        public string MainGroupName1 { get; set; }
        public string TenNhomChinh { get; set; }
        public string MaNhomPhu1 { get; set; }
        public string SubGroupName1 { get; set; }
        public string TenNhomPhu1 { get; set; }
        public string MaNhomPhu2 { get; set; }
        public string SubGroupName2 { get; set; }
        public string TenNhomPhu2 { get; set; }
        public string MaLoai { get; set; }
        public string TypeName { get; set; }
        public string TenLoai { get; set; }
        public string MaBenh { get; set; }
        public string MaBenhKhongdau { get; set; }
        public string DiseaseName { get; set; }
        public string TenBenh { get; set; }
        public string MaNhomBcbyt { get; set; }
        public string MaNhomCoChiTiet { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris1 { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris2 { get; set; }
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris3 { get; set; }
        public virtual ICollection<BenhAn> BenhAnNoiChuyenDens { get; set; }
        public virtual ICollection<BenhAn> BenhAnKKBYHHDs { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhChinhVVs { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhKemVV1s { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhKemVV2s { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhKemVV3s { get; set; }
        public virtual ICollection<BenhAn> BenhBenhChinhRVs { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhKemRV1s { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhKemRV2s { get; set; }
        public virtual ICollection<BenhAn> BenhAnBenhKemRV3s { get; set; }
        public virtual ICollection<BenhAn> BenhGPTuThis { get; set; }
        public virtual ICollection<BenhAnKhamVaoVien> ChanDoanKkbs { get; set; }
        public virtual ICollection<BenhAnKhamVaoVien> BenhNoiChuyenDens { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttChanDoanTruocPts { get; set; }
        public virtual ICollection<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPtttChanDoanSauPts { get; set; }
        public virtual ICollection<BenhAnTvPhieuCdnguyenNhan> BenhAnTvPhieuCdnguyenNhans { get; set; }
        public virtual ICollection<BenhAnKhamYhhd> BenhAnKhamYhhds { get; set; }
    }
}
