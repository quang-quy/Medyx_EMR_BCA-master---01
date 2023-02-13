using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnPhauThuatDuyetMo : ITrackable, ITrackableIDBA
    {
        public int Sttpt { get; set; }
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string LyDoVv { get; set; }
        public string TienSuNgoaiKhoa { get; set; }
        public string TienSuNoiKhoa { get; set; }
        public string TienSuDiUng { get; set; }
        public string TienSuKhac { get; set; }
        public string BenhSu { get; set; }
        public int? Mach { get; set; }
        public string HuyetAp { get; set; }
        public decimal? NhietDo { get; set; }
        public string MoTaHienTaiKhac { get; set; }
        public string NhomMau { get; set; }
        public string Hc { get; set; }
        public string Hct { get; set; }
        public string Bc { get; set; }
        public string Tc { get; set; }
        public string Pt { get; set; }
        public string Apt { get; set; }
        public string Kqhhkhac { get; set; }
        public string Kqsh { get; set; }
        public string Kqcdha { get; set; }
        public string Kqxnkhac { get; set; }
        public string MaBenh { get; set; }
        public string PhuongPhapPhauThuat { get; set; }
        public string PhuongPhapVoCam { get; set; }
        public string KipPhauThuat { get; set; }
        public DateTime? NgayPt { get; set; }
        public string DuTruMau { get; set; }
        public string KhoKhan { get; set; }
        public string VanDeKhac { get; set; }
        public string Bspt { get; set; }
        public DateTime? NgayKyBspt { get; set; }
        public string BsgayMe { get; set; }
        public DateTime? NgayKyBsgm { get; set; }
        public string TruongKhoa { get; set; }
        public DateTime? NgayKyBsldkhoa { get; set; }
        public string LanhDaoBv { get; set; }
        public DateTime? NgayKyLdbv { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBspt { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBsgayMe { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmTruongKhoa { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmLanhDaoBv { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual BenhanPhauThuat BenhanPhauThuat { get; set; }

    }
}
