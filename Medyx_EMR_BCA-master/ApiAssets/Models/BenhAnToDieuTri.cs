using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnToDieuTri : ITrackable, ITrackableIDBA
    {
        public int Stt { get; set; }
        public decimal Idba { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string MaKhoa { get; set; }
        public int? Sttkhoa { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public string DienBienBenh { get; set; }
        public string Ylenh { get; set; }
        public string HuyetAp { get; set; }
        public int? NhipTho { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
        public decimal? Bmi { get; set; }
        public string TrieuChung { get; set; }
        public int? NhipTim { get; set; }
        public byte? NhipTimDeu { get; set; }
        public string Kqxnmau { get; set; }
        public string KqxnnuocTieu { get; set; }
        public string Kqcdha { get; set; }
        public string CsduongHuyet { get; set; }
        public string DieuTri { get; set; }
        public DateTime? NgayHenKhamLai { get; set; }
        public DateTime? NgayHenXnlai { get; set; }
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmnhanVien { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual Dmkhoa Dmkhoa { get; set; }
        [JsonIgnore]
        public virtual ThongTinBn ThongTinBn { get; set; }
        [JsonIgnore]
        public virtual BenhAnKhoaDieuTri BenhAnKhoaDieuTri { get; set; }
        [JsonIgnore]
        public virtual BenhanThuocYhct BenhanThuocYhct { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanThuocTayY> BenhanThuocTayYs { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanTtvltl> BenhanTtvltls { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanCls> BenhanClses { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanPhauThuat> BenhanPhauThuats { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanCpm> BenhanCpms { get; set; }
    }
}
