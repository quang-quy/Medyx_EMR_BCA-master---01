using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuDienTim : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int So { get; set; }
        public int LanThu { get; set; }
        public string YeuCau { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public string BschiDinh { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string ChuyenDaoMau { get; set; }
        public string NhipTanSo { get; set; }
        public string Goc { get; set; }
        public string Truc { get; set; }
        public string TuTheTim { get; set; }
        public string P { get; set; }
        public string Pq { get; set; }
        public string Qrs { get; set; }
        public string St { get; set; }
        public string T { get; set; }
        public string Qt { get; set; }
        public string Di { get; set; }
        public string Dii { get; set; }
        public string Diii { get; set; }
        public string AVr { get; set; }
        public string AVl { get; set; }
        public string AVf { get; set; }
        public string Mcl1 { get; set; }
        public string Mcl2 { get; set; }
        public string V1 { get; set; }
        public string V2 { get; set; }
        public string V3 { get; set; }
        public string V4 { get; set; }
        public string V5 { get; set; }
        public string V6 { get; set; }
        public string V4r { get; set; }
        public string KetLuan { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayKy { get; set; }
        public string BschuyenKhoa { get; set; }
        public string MaMayThucHien { get; set; }
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
