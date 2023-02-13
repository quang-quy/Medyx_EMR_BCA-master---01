using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmbaCombodsParameters : QueryStringParameters
    {
        public DmbaCombodsParameters()
        {
        }
        public string Ma { get; set; }
        public string MaParent { get; set; }
        public string TenParent { get; set; }

    }
}
