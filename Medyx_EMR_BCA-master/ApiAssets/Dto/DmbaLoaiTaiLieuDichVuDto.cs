using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class DmbaLoaiTaiLieuDichVuDto
    {
        public decimal Idba { get; set; }
        public int SttDv { get; set; }
        public int? SttKhoa { get; set; }
        public byte LoaiTaiLieu { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string TenDichVu { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; } 
        public DmnhanVienDto NguoiSD { get; set; }
    }

    public sealed class BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto
    {
        public int Stt { get; set; }
        public int? SttKhoa { get; set; }
        public DmkhoaDto KhoaDieuTri { get; set; } = new DmkhoaDto();
        public DateTime? NgayChiDinh { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; } = new DmnhanVienDto();
        public bool? Huy { get; set; }
    }
}
