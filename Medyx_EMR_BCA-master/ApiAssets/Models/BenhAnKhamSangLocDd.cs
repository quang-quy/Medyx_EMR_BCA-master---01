using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx.ApiAssets.Models.Interface;
using System.Web;
using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnKhamSangLocDd : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public int Sttkhoa { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string SoPhieu { get; set; }
        public DateTime? NgayDg { get; set; }
        public string NguoiDg { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
        public decimal? Bmi { get; set; }
        public byte? CoSutCan { get; set; }
        public byte? DiemSutCan { get; set; }
        public byte? DiemNgonMieng { get; set; }
        public byte? ChiSoMst { get; set; }
        public string DanhGiaTheoMst { get; set; }
        public string CanThiepDd { get; set; }
        public string Bsdieutri { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiDg { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBsdieuTri { get; set; }
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
