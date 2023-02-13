using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Http;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
	public class BenhAnFilePhiCauTrucVM : BenhAnFilePhiCauTruc
	{
		[Required]
		public IFormFile File { get; set; }
		[Required]
		public new byte LoaiTaiLieu { get; set; }
        [Required]
		public new decimal Idba { get; set; }
	}
}