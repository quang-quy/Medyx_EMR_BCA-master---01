 using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class DmthuocBaiThuocCDto
    {
		public string MaBthuoc { get; set; }
		public byte STT { get; set; }
        public DmthuocDto Thuoc { get; set; }
        public decimal? Soluong { get; set; }
        public string LieuDung { get; set; }
        public string CachDung { get; set; }
    }
}
