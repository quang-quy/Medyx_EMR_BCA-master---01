using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmbaChuyenVienParameters : QueryStringParameters
    {
        public DmbaChuyenVienParameters()
        {
        }
        public string MaChuyenvien { get; set; }
        public string TenChuyenvien { get; set; }
    }
}
