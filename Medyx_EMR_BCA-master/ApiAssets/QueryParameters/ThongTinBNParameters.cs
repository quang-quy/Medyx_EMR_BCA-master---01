using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class ThongTinBNParameters : QueryStringParameters
    {
        public ThongTinBNParameters()
        {
            SortBy = "Stt";
        }
        public decimal? Idba { get; set; }

    }
}
