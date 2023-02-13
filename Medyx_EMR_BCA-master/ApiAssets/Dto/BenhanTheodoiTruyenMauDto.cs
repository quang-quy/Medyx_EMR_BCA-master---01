using System;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhanTheodoiTruyenMauDto
    {
        public decimal Idba { get; set; }
        public string Idhis { get; set; }
        public int Stt { get; set; }
        public int? Sttkhoa { get; set; }
        public BenhAnKhoaDieuTriDto KhoaDieuTri { get; set; }
        public DateTime? NgayChiDinh { get; set; }
        public DmnhanVienDto BsChiDinh { get; set; }
        public DmchephamMauDto ChePhamMau { get; set; }
        public decimal? TheTich { get; set; }
        public string MaSoCmp { get; set; }
        public DateTime? NgayDieuChe { get; set; }
        public DateTime? HanSd { get; set; }
        public string Rh { get; set; }
        public string KqpuhoaHopMuoiOng1 { get; set; }
        public string KqpuhoaHopMuoiOng2 { get; set; }
        public string KqpuhoaHop37doOng1 { get; set; }
        public string KqpuhoaHop37doOng2 { get; set; }
        public string KqpuhoaHop { get; set; }
        public string TenKqxnkhac { get; set; }
        public DateTime? NgayXnhoaHop { get; set; }
        public string HoTenTruongKhoaXn { get; set; }
        public string HoTenNguoiXn1 { get; set; }
        public string HoTenNguoiXn2 { get; set; }
        public byte? LanTruyenMau { get; set; }
        public string NhomMau { get; set; }
        public string NhomMauCpm { get; set; }
        public string Kqxncheo { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public decimal? Sltruyen { get; set; }
        public string NhanXet { get; set; }
        public DmnhanVienDto DieuDuong { get; set; }
        public DmnhanVienDto BstheoDoi { get; set; }
    }
}
