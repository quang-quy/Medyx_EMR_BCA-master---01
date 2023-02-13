using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class BenhAnKhamYhct : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
        public string HinhThaiVongChan { get; set; }
        public string ThanVongChan { get; set; }
        public string SacVongChan { get; set; }
        public string TrachVongChan { get; set; }
        public string HinhThaiLuoi { get; set; }
        public string ChatLuoi { get; set; }
        public string ReuLuoi { get; set; }
        public string MoTaVongChan { get; set; }
        public string GiongNoi { get; set; }
        public string HoiTho { get; set; }
        public byte? CoHo { get; set; }
        public string Ho { get; set; }
        public byte? OamThanh { get; set; }
        public byte? NacAmThanh { get; set; }
        public byte? CoMui { get; set; }
        public string KieuMui { get; set; }
        public byte? CoChatThaiBenhLy { get; set; }
        public string KieuChatThai { get; set; }
        public string MoTaVanChan { get; set; }
        public byte? BhhanNhiet { get; set; }
        public string Hannhiet { get; set; }
        public string MoHoi { get; set; }
        public byte? BhdauMatCo { get; set; }
        public string DauDau { get; set; }
        public byte? HoaMat { get; set; }
        public string Mat { get; set; }
        public string Tai { get; set; }
        public string Mui { get; set; }
        public string Hong { get; set; }
        public string CoVai { get; set; }
        public byte? Bhlung { get; set; }
        public string Lung { get; set; }
        public byte? Bhnguc { get; set; }
        public string Nguc { get; set; }
        public byte? Bhbung { get; set; }
        public string Bung { get; set; }
        public byte? BhchanTay { get; set; }
        public string ChanTay { get; set; }
        public byte? Bhan { get; set; }
        public string An { get; set; }
        public byte? Bhuong { get; set; }
        public string Uong { get; set; }
        public byte? BhdaiTieuTien { get; set; }
        public string TieuTien { get; set; }
        public string DaiTien { get; set; }
        public byte? Bhngu { get; set; }
        public string Ngu { get; set; }
        public byte? RlknsinhDuc { get; set; }
        public string Rlnam { get; set; }
        public string Rlnu { get; set; }
        public byte? Bhkn { get; set; }
        public string Rlkinhnguyet { get; set; }
        public string ThongKinh { get; set; }
        public byte? BhdoiHa { get; set; }
        public string DoiHa { get; set; }
        public byte? Dkxhbenh { get; set; }
        public string MtvaanChan { get; set; }
        public byte? BhxucChan { get; set; }
        public string XucChanDa { get; set; }
        public byte? BhcoXuongKhop { get; set; }
        public string XucChanCoXuongKhop { get; set; }
        public byte? BhbungXucChan { get; set; }
        public string XucChanBung { get; set; }
        public byte? BhmoHoi { get; set; }
        public string XucChanMoHoi { get; set; }
        public string MoTaXucChan { get; set; }
        public string MachChan { get; set; }
        public string TongKhanPhai { get; set; }
        public string TongKhanTrai { get; set; }
        public string ViKhanTraiThon { get; set; }
        public string ViKhanTraiQuan { get; set; }
        public string ViKhanTraiXich { get; set; }
        public string ViKhanPhaiThon { get; set; }
        public string ViKhanPhaiQuan { get; set; }
        public string ViKhanPhaiXich { get; set; }
        public string MachTrai { get; set; }
        public string MachPhai { get; set; }
        public string MtthietChan { get; set; }
        public string TomTatTuChan { get; set; }
        public string BienChungLuanTri { get; set; }
        public string MaBenhDanhTheoYhct { get; set; }
        public string BatCuong { get; set; }
        public string BhbatCuong { get; set; }
        public string NguyenNhan { get; set; }
        public string MoTaNguyenNhan { get; set; }
        public string TangPhu { get; set; }
        public string MoTaTangPhu { get; set; }
        public string KinhMach { get; set; }
        public string MoTaKinhMach { get; set; }
        public string DinhViBenhTheo { get; set; }
        public string MoTaDinhViBenhTheo { get; set; }
        public byte? DtdonThuanYhct { get; set; }
        public string Ppdtyhct { get; set; }
        public string PhuongDuoc { get; set; }
        public string PpdtkhongDungThuoc { get; set; }
        public string Ppkhac { get; set; }
        public string PhuongHuyet { get; set; }
        public string XoaBopBamHuyet { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual DmbenhTatYhct DmBenhDanhTheoYHCT { get; set; }
    }
}
