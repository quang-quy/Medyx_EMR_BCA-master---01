namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DMNhanVienParameters : QueryStringParameters
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public bool HasAdmin { get; set; } = false;
    }
}
