using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DMKhoaGiuongParameters : QueryStringParameters
    {
        [Required]
        public string MaBuong { get; set; }
        [Required]
        public string MaKhoa { get; set; }
    }
}
