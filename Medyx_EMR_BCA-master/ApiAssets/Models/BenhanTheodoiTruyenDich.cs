using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
	public partial class BenhanTheodoiTruyenDich : ITrackable, ITrackableIDBA
	{
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Sttkhoa { get; set; }
        public DateTime? NgayTheoDoi { get; set; }
        public string MaDichTruyen { get; set; }
        public string TenDichTruyen { get; set; }
        public int? SoLuong { get; set; }
        public string SoLo { get; set; }
        public string HamLuong { get; set; }
        public string TocDo { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string BschiDinh { get; set; }
        public string DieuDuong { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
		public virtual DmnhanVien DmBschiDinh { get; set; }
		[JsonIgnore]
		public virtual DmnhanVien DmDieuDuong { get; set; }
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
