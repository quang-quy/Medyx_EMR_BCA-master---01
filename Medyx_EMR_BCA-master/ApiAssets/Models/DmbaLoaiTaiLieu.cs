using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
	public partial class DmbaLoaiTaiLieu
	{
		public byte MaLoaiTaiLieu { get; set; }
		public string TableName { get; set; }
		public string TenLoaiTaiLieu { get; set; }
		public string NhomTaiLieu { get; set; }
		public byte? MaNhomTaiLieu { get; set; }
		public byte? OrderBy { get; set; }
		public bool? Huy { get; set; }
		public string MaMay { get; set; }
		public DateTime? NgaySd { get; set; }
		public string NguoiSd { get; set; }

		public virtual ICollection<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTrucs { get; set; }
	}
}
