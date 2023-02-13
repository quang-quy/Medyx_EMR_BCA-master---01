using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnPhacDoDtDto
    {
        public decimal Idba { get; set; }
        public int? Stt { get; set; }
        public int? Sttkhoa { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
        public string MaBenh { get; set; }
        public string TenBenh { get; set; }
        public string GiaiDoan { get; set; }
        public DateTime? NgayAdphacDo { get; set; }
        public byte? GioiTinh { get; set; }
        public byte? DoTuoiTu { get; set; }
        public byte? DoTuoiDen { get; set; }
        public string VungApDung { get; set; }
        public string MoTa { get; set; }
        public string XuTri { get; set; }
        public string TruocPhacDo { get; set; }
        public string SauPhacDo { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
