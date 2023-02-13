using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhanThuocYhct : ITrackable, ITrackableIDBA
    {
        public int Stt { get; set; }
        public decimal Idba { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public string DoiTuong { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public string TenBaiThuoc { get; set; }
        public string DuongDung { get; set; }
        public string CachDung { get; set; }
        public int? SoLuongThang { get; set; }
        public string CachSacThuoc { get; set; }
        public string BschiDinh { get; set; }
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
        public virtual ICollection<BenhanThuocYhctC> BenhanThuocYhctCs { get; set; }
        [JsonIgnore]
        public virtual BenhAnToDieuTri BenhAnToDieuTri { get; set; }
    }
}
