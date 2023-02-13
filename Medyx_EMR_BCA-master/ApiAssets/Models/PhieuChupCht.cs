using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuChupCht : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int So { get; set; }
        public int LanThu { get; set; }
        public string YeuCau { get; set; }
        public string CoDiVatKimLoai { get; set; }
        public string KqcdhadaCo { get; set; }
        public string ViTri { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string BschiDinh { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string KyThuat { get; set; }
        public string MoTa { get; set; }
        public string KetLuan { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayKq { get; set; }
        public string BschuyenKhoa { get; set; }
        public string MaMayThucHien { get; set; }
        public string LinkPacs { get; set; }
        public byte? CapCuu { get; set; }
        public string DoiTuong { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
