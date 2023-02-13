using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
	public partial class DmngheNghiep
	{
		public string MaNn { get; set; }
		public string TenNn { get; set; }
		public string TenTat { get; set; }
		public string MaMay { get; set; }
		public bool? Huy { get; set; }
		public DateTime NgaySd { get; set; }
		public string NguoiSd { get; set; }
		public virtual ICollection<ThongTinBn> ThongTinBns { get; set; }
	}
}
