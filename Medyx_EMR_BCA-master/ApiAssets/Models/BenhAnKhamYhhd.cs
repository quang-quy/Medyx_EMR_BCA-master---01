using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
	public partial class BenhAnKhamYhhd : ITrackableIDBA
	{
		public decimal Idba { get; set; }
		public string MaBa { get; set; }
		public string MaBn { get; set; }
		public string LyDoVv { get; set; }
		public string BenhSu { get; set; }
		public string ToanThan { get; set; }
		public int? Mach { get; set; }
		public decimal? NhietDo { get; set; }
		public string HuyetAp { get; set; }
		public int? NhipTho { get; set; }
		public decimal? CanNang { get; set; }
		public decimal? ChieuCao { get; set; }
		public decimal? Bmi { get; set; }
		public string SpO2 { get; set; }
		public string TuanHoan { get; set; }
		public string HoHap { get; set; }
		public string TieuHoa { get; set; }
		public string ThanTnieuSduc { get; set; }
		public string ThanKinh { get; set; }
		public string XuongKhop { get; set; }
		public string TaiMuiHong { get; set; }
		public string RangHamMat { get; set; }
		public string Mat { get; set; }
		public string NoiTietDd { get; set; }
		public string CanLamSang { get; set; }
		public string TomTatBenhAn { get; set; }
		public string TenBenhPhanBiet { get; set; }
		public int? NhipTim { get; set; }
		public byte? NhipTimDeu { get; set; }
		public string TrieuChung { get; set; }
		public string Kqxnmau { get; set; }
		public string KqxnnuocTieu { get; set; }
		public string Kqcdha { get; set; }
		public byte? DtketHopYhhd { get; set; }
		public string Ppdtyhhd { get; set; }
		public string Kqdt { get; set; }
		public string HuongDtyhhd { get; set; }
		public DateTime? NgayHenKhamLai { get; set; }
		public DateTime? NgayHenXnlai { get; set; }
		public string CddinhDuong { get; set; }
		public string CdchamSoc { get; set; }
		public string TienLuong { get; set; }
		public DateTime? NgayKham { get; set; }
		public string Bskham { get; set; }
		public bool? Huy { get; set; }
		public string MaMay { get; set; }
		public DateTime? NgayLap { get; set; }
		public string NguoiLap { get; set; }
		public DateTime? NgaySd { get; set; }
		public string NguoiSd { get; set; }
		public DateTime? NgayHuy { get; set; }
		public string NguoiHuy { get; set; }
		[JsonIgnore]
		public virtual DmnhanVien DmBskham { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhPhanBiet { get; set; }
    }
}
