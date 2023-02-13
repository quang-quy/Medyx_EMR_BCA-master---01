using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class KetQuaXetNghiem : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int Stt { get; set; }
        public int Sttkq { get; set; }
        public string Kqxn { get; set; }
        public DateTime? NgayLayMau { get; set; }
        public string MaCs { get; set; }
        public string TenCs { get; set; }
        public string Kq { get; set; }
        public string DonVi { get; set; }
        public string Csbt { get; set; }
        public DateTime? NgayTraKq { get; set; }
        public string BsdieuTri { get; set; }
        public DateTime? NgayKyKq { get; set; }
        public string TruongKhoaXn { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string BatThuong { get; set; }
        public string MayTh { get; set; }
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
