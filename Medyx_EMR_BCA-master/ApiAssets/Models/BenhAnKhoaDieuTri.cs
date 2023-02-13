using Medyx.ApiAssets.Models;
using Medyx.ApiAssets.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnKhoaDieuTri : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string MaKhoa { get; set; }
        public DateTime NgayVaoKhoa { get; set; }
        public string Buong { get; set; }
        public string Giuong { get; set; }
        public string MaBenhChinhVk { get; set; }
        public string MaBenhKemVk1 { get; set; }
        public string MaBenhKemVk2 { get; set; }
        public string MaBenhKemVk3 { get; set; }
        public int? SoNgayDt { get; set; }
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual BenhAn BenhAn { get; set; }
        [JsonIgnore]
        public virtual ThongTinBn ThongTinBn { get; set; }
        [JsonIgnore]
        public virtual Dmkhoa Dmkhoa { get; set; }
        [JsonIgnore]
        public virtual DmkhoaBuong DmkhoaBuong { get; set; }
        [JsonIgnore]
        public virtual DmkhoaGiuong DmkhoaGiuong { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat BenhChinh { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat BenhKem1 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat BenhKem2 { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat BenhKem3 { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmnhanVien { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUngs { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDts { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnHoiChan> BenhAnHoiChans { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanCls> BenhanClss { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnKhamSangLocDd> BenhAnKhamSangLocDds { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnToDieuTri> BenhAnToDieuTris { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDiches { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuats { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocs { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiems { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTrucs { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanTtvltl> BenhanTtvltls { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanCpm> BenhanCpms { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnTaiBienPttt> BenhAnTaiBienPttts { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnPhacDoDt> BenhAnPhacDoDts { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanTtvltlDotDieuTri> BenhanTtvltlDotDieuTris { get; set; }
    }
}
