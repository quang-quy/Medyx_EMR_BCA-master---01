using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhanTiensubenhBenhphoihop : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public byte Stt { get; set; }
        public string Maloaibenh { get; set; }
        public byte? TrangThai { get; set; }
        public string Mota { get; set; }
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
