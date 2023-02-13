using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmbaHtraVienParameters : QueryStringParameters
    {
        public DmbaHtraVienParameters()
        {
        }
        public string MaHtraVien { get; set; }
        public string TenHtraVien { get; set; }
    }
}
