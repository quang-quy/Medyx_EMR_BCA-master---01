using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanPhauThuatParameters : QueryStringParameters
    {
        public BenhanPhauThuatParameters()
        {
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
    }
}
