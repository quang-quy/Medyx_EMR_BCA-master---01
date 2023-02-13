using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhanTtvltlDotDieuTri : ITrackableIDBA, ITrackableCreate, ITrackableUpdate, ITrackableHuy
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public byte LoaiBa { get; set; }
        public string Ppdt { get; set; }
        public string KhamBenh { get; set; }
        public string XuTri { get; set; }
        public string Kq { get; set; }
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }

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
        [JsonIgnore]
        public virtual ICollection<BenhAnTtvltlThuchien> BenhAnTtvltlThuchiens { get; set; }

    }
}
