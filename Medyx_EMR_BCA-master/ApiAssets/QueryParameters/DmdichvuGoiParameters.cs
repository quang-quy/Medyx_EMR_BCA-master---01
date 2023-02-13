using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmdichvuGoiParameters : QueryStringParameters
    {
        public byte? ExcludeLoai { get; set;}
        public byte? Loai { get; set;}
    }
}
