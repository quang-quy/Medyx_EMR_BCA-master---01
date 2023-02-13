using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanPhauThuatPhieuKhamGayMeTruocMoParameters : QueryStringParameters
    {
        public BenhanPhauThuatPhieuKhamGayMeTruocMoParameters()
        {
        }
        public decimal? Idba { get; set; }
        public int? Stt { get; set; }


    }
}
