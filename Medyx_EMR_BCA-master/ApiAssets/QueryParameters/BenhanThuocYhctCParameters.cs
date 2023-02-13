using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanThuocYhctCParameters : QueryStringParameters
    {
        public BenhanThuocYhctCParameters()
        {
        }
        public decimal? Idba { get; set; }
        public int? Sttthuoc { get; set; }
        public DateTime? NgayYlenh { get; set; }
    }
}
