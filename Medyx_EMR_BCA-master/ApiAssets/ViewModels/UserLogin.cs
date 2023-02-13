using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class UserLogin
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
