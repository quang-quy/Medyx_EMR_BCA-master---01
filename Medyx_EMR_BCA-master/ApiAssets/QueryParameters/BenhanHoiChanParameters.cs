using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanHoiChanParameters : QueryStringParameters
    {
        public BenhanHoiChanParameters()
        {
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
    }
}
