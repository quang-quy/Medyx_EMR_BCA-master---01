using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuChamSoc : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaKhoa { get; set; }
        public string SoPhieu { get; set; }
        public string ChanDoan { get; set; }
        public DateTime? NgayChamSoc { get; set; }
        public int? Mach { get; set; }
        public decimal? NhietDo { get; set; }
        public string HuyetAp { get; set; }
        public decimal? CanNang { get; set; }
        public int? NhipTho { get; set; }
        public string DienBien { get; set; }
        public string Ylenh { get; set; }
        public string Ythuc { get; set; }
        public string TiepXuc { get; set; }
        public string TheRrang { get; set; }
        public string Phu { get; set; }
        public string DaNiemMac { get; set; }
        public string TonThuongDa { get; set; }
        public string TieuHoa { get; set; }
        public string DauBung { get; set; }
        public string ViTriDauBung { get; set; }
        public string DaiTien { get; set; }
        public int? SoLanTieuChay { get; set; }
        public string MauSacTieuChay { get; set; }
        public byte? SoLuongSondeDd { get; set; }
        public string MauSacSondeDd { get; set; }
        public string TietNieu { get; set; }
        public string MauSacSondeTieu { get; set; }
        public int? SoLuongSondeTieu { get; set; }
        public string HoHap { get; set; }
        public decimal? SpO2 { get; set; }
        public string Ho { get; set; }
        public string TanSoHo { get; set; }
        public string Sot { get; set; }
        public string DauNguc { get; set; }
        public string TimMach { get; set; }
        public string TchatTim { get; set; }
        public string CoXuongKhop { get; set; }
        public string Ngu { get; set; }
        public string DinhDuong { get; set; }
        public string MoTaVetThuong { get; set; }
        public string VetThuong { get; set; }
        public string VetThuongKhac { get; set; }
        public string MoTaDanLuu { get; set; }
        public string DanLuu { get; set; }
        public string ChanDanLuu { get; set; }
        public string ThanKinhVanDong { get; set; }
        public string TinhChatTkvd { get; set; }
        public string VanDong { get; set; }
        public string DienBienKhac { get; set; }
        public byte? CapCs { get; set; }
        public byte? HuongDanNoiQuy { get; set; }
        public byte? TheoDoiDhst { get; set; }
        public string ThucHienYlenh { get; set; }
        public string ChuyenKhoa { get; set; }
        public string ThuThuat { get; set; }
        public int? Sloxy { get; set; }
        public int? SlkhiDung { get; set; }
        public int? SltestMm { get; set; }
        public int? SltiemInsulin { get; set; }
        public string ThylenhKhac { get; set; }
        public string AnUong { get; set; }
        public string Ddkhac { get; set; }
        public string VeSinhCaNhan { get; set; }
        public string Gdsk { get; set; }
        public string ChamSocKhac { get; set; }
        public string DdthucHien { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
