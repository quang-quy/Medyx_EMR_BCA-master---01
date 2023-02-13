using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DMbenhVienParameters : QueryStringParameters
    {
        public DMbenhVienParameters()
        {
        }
        public string MaBv { get; set; }
        public string TenBv { get; set; }
    }
}
