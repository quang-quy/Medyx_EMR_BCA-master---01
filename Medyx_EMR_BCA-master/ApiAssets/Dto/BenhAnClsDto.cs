using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnClsDto
    {
        private byte? _CapCuuTransform;
        public decimal Idba { get; set; }
        public int Stt { get; set; }
        public DmdichVuDto DichVu { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public int? Sttkhoa { get; set; }
        public string DoiTuong { get; set; }
        public DateTime? NgayYlenh { get; set; }
        public string MaDv { get; set; }
        public string ViTri { get; set; }
        public byte? Capcuu { get { return (byte?)(_CapCuuTransform != 1 ? 0 : 1); } set { _CapCuuTransform = value; } }
        public string ThoiGian { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; } = null;
        public DmnhanVienDto NguoiLap { get; set; } = null;
        public DmnhanVienDto NguoiHuy { get; set; } = null;
        public DmnhanVienDto NguoiSD { get; set; } = null;
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; } = null;
        public BenhAnKhoaDieuTriV2Dto KhoaDieuTriV2 { get; set; } = null;
        public BenhAnClsKqDto BenhAnClsKq { get; set; }
        public List<BenhAnClsKqcsDto> BenhanClsKqcs { get; set; }
        public bool IsHasKq
        {
            get
            {
                if (BenhAnClsKq != null && (!String.IsNullOrEmpty(BenhAnClsKq.SoPhieu) && !String.IsNullOrEmpty(BenhAnClsKq.MaKhoaThucHien)))
                {
                    return true;
                }
                if (BenhanClsKqcs != null && BenhanClsKqcs.Count > 0 && !String.IsNullOrEmpty(BenhanClsKqcs[0].SoPhieu))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
