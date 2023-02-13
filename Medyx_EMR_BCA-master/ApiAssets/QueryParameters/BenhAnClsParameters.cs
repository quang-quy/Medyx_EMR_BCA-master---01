using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnClsParameters : QueryStringParameters
    {
        public BenhAnClsParameters()
        {
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
        public string MaChungLoai { get; set; }
        public string ExcludeMaChungLoai { get; set; }
        public bool WithKq { get; set; } = true;
        public bool WithKqCls { get; set; } = false;
        public bool ForPhieuXetNghiem { get; set; } = false;

    }
}
