using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanTheodoiTruyenDichParameters : QueryStringParameters
    {
        public BenhanTheodoiTruyenDichParameters()
        {
            SortBy = "ThoiGianBatDau";
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set; }
    }
}
