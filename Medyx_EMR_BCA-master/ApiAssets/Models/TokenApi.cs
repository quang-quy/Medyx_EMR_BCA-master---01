using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class TokenApi
    {
        public decimal Id { get; set; }
        public string Token { get; set; }
        public string Account { get; set; }
        public DateTime? NgayCap { get; set; }
    }
}
