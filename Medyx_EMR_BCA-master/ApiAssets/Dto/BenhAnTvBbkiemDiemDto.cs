using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnTvBbkiemDiemDto
    {
        public decimal Idba { get; set; }
        public DmkhoaDto Khoa { get; set; }
        public string SoPhieu { get; set; }
        public DateTime? ThoiGianKiemDiem { get; set; }
        public int? Sttkhoa { get; set; }
        public string NoiHop { get; set; }
        public DateTime? NgayTuVong { get; set; }
        public string NguyenNhanTv { get; set; }
        public string TomTatQtbenh { get; set; }
        public string TinhTrangVv { get; set; }
        public string ChanDoan { get; set; }
        public string TomTatDienBien { get; set; }
        public string TiepDonBn { get; set; }
        public string ThamKham { get; set; }
        public string DieuTri { get; set; }
        public string ChamSoc { get; set; }
        public string QuanHeVoiGdbn { get; set; }
        public string YkienBoSung { get; set; }
        public string KetLuan { get; set; }
        public DmnhanVienDto ChuToa { get; set; }
        public DmnhanVienDto ThuKy { get; set; }
        public IEnumerable<BenhAnTvBbkiemDiemTvDto> ThanhVienThamGias { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
    }
}
