using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class DmbaLoaiTaiLieuDichVuParameters : QueryStringParameters
    {
        [Required(ErrorMessage = "Loại tài liệu là bắt buộc.")]
        public byte LoaiTaiLieu { get; set; }
        [Required(ErrorMessage = "Idba là bắt buộc.")]
        public decimal Idba { get; set; }
    }
}
