using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanThuocYhctParameters : QueryStringParameters
    {
        public BenhanThuocYhctParameters()
        {
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
    }
}
