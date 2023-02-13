using System;
using System.ComponentModel.DataAnnotations;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnPhieuXetNghiemParameters : QueryStringParameters
    {
        public BenhAnPhieuXetNghiemParameters()
        {
        }
        [Required(ErrorMessage = "Id bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Số thứ tự dịch vụ là bắt buộc.")]
        public int Sttdv { get; set; }
    }
}
