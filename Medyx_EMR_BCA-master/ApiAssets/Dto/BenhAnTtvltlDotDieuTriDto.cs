using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnTtvltlDotDieuTriDto
    {
        private string _ngayVaoDieuTri;

        public decimal Idba { get; set; }
        public int? Stt { get; set; }
        public int? Sttkhoa { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
        public string NgayVaoDieuTri { get { return string.IsNullOrEmpty(_ngayVaoDieuTri) ? null : Convert.ToDateTime(_ngayVaoDieuTri).ToString("yyyy-MM-dd"); } set { _ngayVaoDieuTri = value; } }
        public string Ppdt { get; set; }
        public string KhamBenh { get; set; }
        public string XuTri { get; set; }
        public string Kq { get; set; }
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
