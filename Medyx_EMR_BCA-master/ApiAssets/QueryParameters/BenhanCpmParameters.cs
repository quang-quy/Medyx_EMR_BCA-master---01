using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanCpmParameters : QueryStringParameters
    {
        public BenhanCpmParameters()
        {
            SortBy = "NgayYlenh";
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
    }
}
