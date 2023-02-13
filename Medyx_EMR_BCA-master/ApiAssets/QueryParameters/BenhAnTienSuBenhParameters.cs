using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnTienSuBenhParameters : QueryStringParameters
    {
        public BenhAnTienSuBenhParameters()
        {
        }
        public decimal? Idba { get; set; }
        public bool? getModelNull { get; set; }
    }
}
