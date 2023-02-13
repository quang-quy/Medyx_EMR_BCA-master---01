using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnTheodoiTruyenMauCParameters : QueryStringParameters
    {
        public BenhAnTheodoiTruyenMauCParameters()
        {
        }
        public decimal? Idba { get; set; }
        public int? StttruyenMau { get; set; }
    }
}
