using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnKhoaDieuTriParameters : QueryStringParameters
    {
        public BenhAnKhoaDieuTriParameters()
        {
            SortBy = "Stt";
        }
        public DateTime? NgayGioVaoKhoa { get; set; }
        public decimal? Idba { get; set; }
        public string KhoaDieuTri { get; set; }
        public string Giuong { get; set; }
        public string Buong { get; set; }
        public string BenhChinh { get; set; }
        public string BenhKem1 { get; set; }
        public string BenhKem2 { get; set; }
        public string BenhKem3 { get; set; }
        public string bsDieuTri { get; set; }
        public string nguoiLap { get; set; }
        public string nguoiHuy { get; set; }
        public Boolean? forSelect { get; set; }
    }
}
