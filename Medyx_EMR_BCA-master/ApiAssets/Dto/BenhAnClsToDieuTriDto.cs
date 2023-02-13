using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnClsToDieuTriDto
    {
        private byte? _CapCuuTransform;
        public int Stt { get; set; }
        public DmdichVuDto DichVu { get; set; }
        public byte? Capcuu { get { return (byte?)(_CapCuuTransform != 1 ? 0 : 1); } set { _CapCuuTransform = value; } }
        public string ThoiGian { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; } = null;
        public DmnhanVienDto NguoiHuy { get; set; } = null;
        public DmnhanVienDto NguoiSD { get; set; } = null;
    }
}
