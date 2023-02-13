using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmbaGtParameters : QueryStringParameters
    {
        public DmbaGtParameters()
        {
        }
        public string MaNoiGt { get; set; }
        public string TenNoiGt { get; set; }
    }
}
