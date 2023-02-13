using System;
using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
	public sealed class BenhAnTongKetBenhAnDto : BenhAnTongKetBenhAn
	{
        public new DmnhanVienDto DmBsDieutri { get; set; }
        public new DmnhanVienDto DmNguoiGiao { get; set; }
        public new DmnhanVienDto DmNguoiNhan { get; set; }
	}
}
