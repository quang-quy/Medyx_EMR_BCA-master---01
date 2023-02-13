using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanTtvltlParameters : QueryStringParameters
    {
        public BenhanTtvltlParameters()
        {
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
        public string NgayVaoDieuTri { get; set; }
        public int? Sttkhoa { get; set; }
    }
}
