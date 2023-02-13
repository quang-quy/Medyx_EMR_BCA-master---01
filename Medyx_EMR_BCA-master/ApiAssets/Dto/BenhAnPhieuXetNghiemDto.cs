using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public class BenhAnPhieuXetNghiemDto
    {
        private byte? _CapCuuTransform;
        public decimal Idba { get; set; }
        public int? Stt { get; set; }
        public int Sttdv { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public string Idhis { get; set; }
        public string MaCs { get; set; }
        public string uuid {get; set;}
        public string MaPhieu { get; set; }
        public string TenPhieu { get; set; }
        public decimal? Sttin { get; set; }
        public byte? Capcuu { get { return (byte?)(_CapCuuTransform != 1 ? 0 : 1); } set { _CapCuuTransform = value; } }
        public DateTime? NgayTiepNhan { get; set; }
        public string SoPhieu { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri {get; set;}
        public DmdichVuDto DichVu {get; set;}
        public DmdichVuCsDto DichVuCs { get; set; }
        public string Kq { get; set; }
        public string BatThuong { get; set; }
        public string MaMayThucHien { get; set; }
        public DmnhanVienDto Ktv { get; set; }
        public DmnhanVienDto NguoiDuyetKq { get; set; }
        public DateTime? NgayTraKq { get; set; }
        public string KetLuan { get; set; }
        public DmkhoaDto KhoaThucHien { get; set; }
        public DmnhanVienDto BschiDinh { get; set; }
        public string Idlis { get; set; }
        public string LinkPacsLis { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto NguoiLap { get; set; }
        public DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
