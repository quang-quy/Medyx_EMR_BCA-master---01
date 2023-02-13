using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class Dmkhoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DiaDiem { get; set; }
        public byte Loai { get; set; }
        public string MaByt { get; set; }
        public string Ghichu { get; set; }
        public decimal? Sogiuong { get; set; }
        public string MaNvtruongKhoa { get; set; }
        public string MaNvdieuDuongTruong { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public ICollection<BenhAn> BenhAns { get; set; }
        public ICollection<BenhAnKhamVaoVien> BenhAnKhamVaoViens { get; set; }
        public ICollection<BenhAnKhamVaoVien> BenhAnKhamVaoVienKhoaKhams { get; set; }
        public ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        public ICollection<DmkhoaBuong> DmkhoaBuongs { get; set; }
        public ICollection<BenhAnToDieuTri> BenhAnToDieuTris { get; set; }
        public ICollection<DmnhanVien> DmnhanViens { get; set; }
        public ICollection<BenhAnPhieuChamSoc> BenhAnPhieuChamSocs { get; set; }
        public ICollection<BenhanClsKqcs> BenhanClsKqcss { get; set; }
    }
}
