using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmbaLdtvongParameters : QueryStringParameters
    {
        public DmbaLdtvongParameters()
        {
        }
        public string MaLdtvong { get; set; }
        public string TenLdtvong { get; set; }
    }
}
