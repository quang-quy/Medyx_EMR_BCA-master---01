using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnBenhAnKhamSangLocDDParameters : QueryStringParameters
    {
        public BenhAnBenhAnKhamSangLocDDParameters()
        {
            SortBy = "Stt";
        }
        public decimal? Idba { get; set; }

    }
}
