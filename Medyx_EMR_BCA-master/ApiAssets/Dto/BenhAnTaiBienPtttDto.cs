using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnTaiBienPtttDto
    {
        public decimal Idba { get; set; }
        public int? Stt { get; set; }
        public int? Sttkhoa { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
        public DmbenhTatDto BenhTat { get; set; }
        public byte? Loai { get; set; }
        public DateTime? NgayThucHien { get; set; }
        public DateTime? NgayTaiBien { get; set; }
        public string NguyenNhanTaiBien { get; set; }
        public string GhiChu { get; set; }
        public string TinhTrang { get; set; }
        public string Xutri { get; set; }
        public string KetQua { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto BsdieuTri { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
