using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhanThuocTayYParameters : QueryStringParameters
    {
        public BenhanThuocTayYParameters()
        {
        }
        public decimal? Idba { get; set; }
        public DateTime? NgayYlenh { get; set;}
        public int? Sttkhoa { get; set; }
        public bool? ForFilter { get; set; }
    }
}
