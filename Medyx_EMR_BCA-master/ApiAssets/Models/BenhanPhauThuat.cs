using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhanPhauThuat : ITrackable, ITrackableIDBA

    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public string DoiTuong { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public string MaPt { get; set; }
        public string ViTri { get; set; }
        public bool? Huy { get; set; }
        public string Bschidinh { get; set; }
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
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
        [JsonIgnore]
        public virtual BenhAnToDieuTri BenhAnToDieuTri { get; set; }
        [JsonIgnore]
        public virtual DmphauThuat DmphauThuat { get; set; }
        [JsonIgnore]
        public virtual BenhAnPhauThuatDuyetMo BenhAnPhauThuatDuyetMo { get; set; }
        [JsonIgnore]
        public virtual BenhanPhauThuatPhieuKhamGayMeTruocMo BenhanPhauThuatPhieuKhamGayMeTruocMo { get; set; }
        [JsonIgnore]
        public virtual BenhanPhauThuatPhieuPttt BenhanPhauThuatPhieuPttt { get; set; }
        [JsonIgnore]
        public virtual BenhAnKhoaDieuTri BenhAnKhoaDieuTri { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTrucs { get; set; }

    }
}
