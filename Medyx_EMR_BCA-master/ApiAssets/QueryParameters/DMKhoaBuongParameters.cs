using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DMKhoaBuongParameters : QueryStringParameters
    {
        [Required]
        public string MaKhoa { get; set; }
    }
}
