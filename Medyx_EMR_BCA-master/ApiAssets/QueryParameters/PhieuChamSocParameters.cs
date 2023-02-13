using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class PhieuChamSocParameters : QueryStringParameters
    {
        public PhieuChamSocParameters()
        {
        }
        public decimal? Idba { get; set; }
    }
}
