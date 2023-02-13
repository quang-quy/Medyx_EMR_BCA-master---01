using System;
using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnKhamSangLocDdDto : BenhAnKhamSangLocDd
    {
        public new DmnhanVienDto Bsdieutri { get; set; }
        public new DmnhanVienDto NguoiDg { get; set; }
        public new DmnhanVienDto NguoiLap { get; set; }
        public new DmnhanVienDto NguoiHuy { get; set; }
        public new DmnhanVienDto NguoiSd { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
    }
}
