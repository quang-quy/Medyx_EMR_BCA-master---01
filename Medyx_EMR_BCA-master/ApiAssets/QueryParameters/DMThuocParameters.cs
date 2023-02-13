using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DMThuocParameters : QueryStringParameters
    {
        public string MaChungLoai { get; set; }
        [FromQuery(Name = "MaChungLoais[]")]
        public List<string> MaChungLoais { get; set; } = new List<string>();
        public bool? IsWithRelation { get; set; }
    }
}
