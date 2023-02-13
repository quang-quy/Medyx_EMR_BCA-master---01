using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnKhamVaoVien : ITrackable, ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string DoiTuong { get; set; }
        public DateTime? Gtbhyttn { get; set; }
        public DateTime? Gtbhytdn { get; set; }
        public string SoTheBhyt { get; set; }
        public DateTime? NgayKham { get; set; }
        public string MaKhoaKham { get; set; }
        public string MaBenhNoiChuyenDen { get; set; }
        public string LyDoVv { get; set; }
        public string QuaTrinhBenhLy { get; set; }
        public string TienSuBanThan { get; set; }
        public string TienSuGiaDinh { get; set; }
        public string KhamToanThan { get; set; }
        public int? Mach { get; set; }
        public decimal? NhietDo { get; set; }
        public string HuyetAp { get; set; }
        public int? NhipTho { get; set; }
        public string CacBoPhan { get; set; }
        public string TomTatKqcls { get; set; }
        public string ChanDoanKkb { get; set; }
        public string DaXuLy { get; set; }
        public string MaKhoaVv { get; set; }
        public string ChuY { get; set; }
        public DateTime? NgayKy { get; set; }
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
        public virtual DmnhanVien DmBsKham { get; set; }
        [JsonIgnore]
        public virtual ThongTinBn ThongTinBn { get; set; }
        [JsonIgnore]
        public virtual BenhAn BenhAn { get; set; }
        [JsonIgnore]
        public virtual DmdoiTuong DmDoiTuong { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmChanDoanKkb { get; set; }
        [JsonIgnore]
        public virtual DmbenhTat DmBenhNoiChuyenDen { get; set; }
        [JsonIgnore]
        public virtual Dmkhoa Dmkhoa { get; set; }
        [JsonIgnore]
        public virtual Dmkhoa DmKhoaKham { get; set; }
    }
}
