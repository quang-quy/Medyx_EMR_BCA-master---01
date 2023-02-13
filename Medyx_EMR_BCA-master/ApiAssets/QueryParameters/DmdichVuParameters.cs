using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmdichVuParameters : QueryStringParameters
    {
        public string MaDv { get; set;}
        public string MaChungloai { get; set; }
        [FromQuery(Name = "MaChungLoais[]")]
        public List<string> MaChungloais { get; set; } = new List<string>();
        public string ExcludeMaChungLoai { get; set; }
    }
}
