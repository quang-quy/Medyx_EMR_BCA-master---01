using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class PrintParameters : QueryStringParameters
    {
        public bool ShouldReturnPath { get; set; } = false;
        [FromQuery(Name = "Stt[]")]
        public List<int> Stt { get; set; } = new List<int>();
    }
}
