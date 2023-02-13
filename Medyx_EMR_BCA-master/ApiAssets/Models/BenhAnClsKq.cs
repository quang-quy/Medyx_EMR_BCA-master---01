using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnClsKq : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string SoPhieu { get; set; }
        public string IdpacsLis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Sttdv { get; set; }
        public string MaDv { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string CoDiVatKimLoai { get; set; }
        public string DiUng { get; set; }
        public string TinhTrangNguoiBenh { get; set; }
        public string KqcdhadaCo { get; set; }
        public string ViTri { get; set; }
        public string KyThuat { get; set; }
        public string MoTa { get; set; }
        public string KetLuan { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayKq { get; set; }
        public string BschuyenKhoa { get; set; }
        public string MaKhoaThucHien { get; set; }
        public string MaMayThucHien { get; set; }
        public string LinkPacsLis { get; set; }
        public byte? CapCuu { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhanCls> BenhanClss { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmBschuyenKhoa { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiLap { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmnhanVien DmNguoiSD { get; set; }
    }
}
