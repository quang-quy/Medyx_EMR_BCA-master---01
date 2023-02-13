using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanClsKqParameters : QueryStringParameters
    {
        public BenhanClsKqParameters()
        {
        }
        public decimal? Idba { get; set; }
        public int? Sttdv { get; set; }

    }
}
