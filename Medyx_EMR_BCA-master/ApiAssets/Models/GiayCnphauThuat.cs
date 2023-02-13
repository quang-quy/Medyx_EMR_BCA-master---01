using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class GiayCnphauThuat : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Stt { get; set; }
        public string DaPt { get; set; }
        public string ViTriPt { get; set; }
        public string CachThucPt { get; set; }
        public string NhomMau { get; set; }
        public string Rh { get; set; }
        public DateTime? NgayKy { get; set; }
        public string TruongKhoa { get; set; }
        public string GiamDoc { get; set; }
        public string NgayKhamThu { get; set; }
        public string NoiKhamThu { get; set; }
        public string Kqthu { get; set; }
        public string BskhamThu { get; set; }
        public string VaoNgayThu { get; set; }
        public string RaNgayThu { get; set; }
        public string BenhVienThu { get; set; }
        public string GhiChuThu { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
