using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnPhieuChamSocParameters : QueryStringParameters
    {
        public BenhAnPhieuChamSocParameters()
        {
        }
        public decimal? Idba { get; set; }
        public int? Stt { get; set; }


    }
}
