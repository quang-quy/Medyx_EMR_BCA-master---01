using System;
using Medyx.ApiAssets.Models.Interface;
using Medyx_EMR_BCA.ApiAssets.Models;
using Newtonsoft.Json;

namespace Medyx.ApiAssets.Models
{
	public class BenhAnPhacDoDt: ITrackableIDBA, ITrackable
	{
		public decimal Idba { get; set; }
		public int Stt { get; set; }
		public string Idhis { get; set; }
		public string MaBa { get; set; }
		public string MaBn { get; set; }
		public int? Sttkhoa { get; set; }
		public string MaBenh { get; set; }
		public string TenBenh { get; set; }
		public string GiaiDoan { get; set; }
		public DateTime? NgayAdphacDo { get; set; }
		public byte? GioiTinh { get; set; }
		public byte? DoTuoiTu { get; set; }
		public byte? DoTuoiDen { get; set; }
		public string VungApDung { get; set; }
		public string MoTa { get; set; }
		public string XuTri { get; set; }
		public string TruocPhacDo { get; set; }
		public string SauPhacDo { get; set; }
		public bool? Huy { get; set; }
		public string MaMay { get; set; }
		public DateTime? NgayLap { get; set; }
		public string NguoiLap { get; set; }
		public DateTime? NgaySd { get; set; }
		public string NguoiSd { get; set; }
		public DateTime? NgayHuy { get; set; }
		public string NguoiHuy { get; set; }

		[JsonIgnore]
		public virtual DmnhanVien DmNguoiLap { get; set; }
		[JsonIgnore]
		public virtual DmnhanVien DmNguoiHuy { get; set; }
		[JsonIgnore]
		public virtual DmnhanVien DmNguoiSD { get; set; }
		[JsonIgnore]
		public virtual BenhAnKhoaDieuTri BenhAnKhoaDieuTri { get; set; }
	}
}