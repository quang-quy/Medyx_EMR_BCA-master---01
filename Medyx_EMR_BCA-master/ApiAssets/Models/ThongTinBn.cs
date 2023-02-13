using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;
using Newtonsoft.Json;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class ThongTinBn : ITrackableIDBA
    {
        public string MaBn { get; set; }
        public decimal Idba { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public byte? Tuoi { get; set; }
        public byte GioiTinh { get; set; }
        public string MaNgheNghiep { get; set; }
        public string MaDanToc { get; set; }
        public string MaQuocTich { get; set; }
        public string SoNha { get; set; }
        public string Thon { get; set; }
        public string MaPxa { get; set; }
        public string MaHuyen { get; set; }
        public string MaTinh { get; set; }
        public string NoiLamViec { get; set; }
        public string DoiTuong { get; set; }
        public DateTime? Gtbhyttn { get; set; }
        public DateTime? Gtbhytdn { get; set; }
        public string SoTheBhyt { get; set; }
        public string MaNoiDkbd { get; set; }
        public string LienHe { get; set; }
        public string SoDienThoai { get; set; }
        public string HoTenCha { get; set; }
        public string HoTenMe { get; set; }
        public string NguoiGiamHo { get; set; }
        public string GiayCnkhuyetTat { get; set; }
        public string DangKhuyetTat { get; set; }
        public string MucDoKhuyetTat { get; set; }
        public string NgheNghiepNguoiGiamHo { get; set; }
        public string QuanHeNguoiGiamHo { get; set; }
        public string Cmnd { get; set; }
        public string NoiCapCmnd { get; set; }
        public DateTime? NgayCapCmnd { get; set; }
        public string NhomMau { get; set; }
        public string Rh { get; set; }
        public bool? Huy { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAn> BenhAns { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnKhoaDieuTri> BenhAnKhoaDieuTris { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnKhamVaoVien> BenhAnKhamVaoViens { get; set; }
        [JsonIgnore]
        public virtual ICollection<BenhAnToDieuTri> BenhAnToDieuTris { get; set; }
        [JsonIgnore]
        public virtual DmngheNghiep DmngheNghiep { get; set; }
        [JsonIgnore]
        public virtual DmdanToc DmdanToc { get; set; }
        [JsonIgnore]
        public virtual DmquocGia DmquocGia { get; set; }
        [JsonIgnore]
        public virtual Dmtinh Dmtinh { get; set; }
        [JsonIgnore]
        public virtual DmquanHuyen DmquanHuyen { get; set; }
        [JsonIgnore]
        public virtual DmphuongXa DmphuongXa { get; set; }
        [JsonIgnore]
        public virtual DmdoiTuong DmdoiTuong { get; set; }
    }
}
