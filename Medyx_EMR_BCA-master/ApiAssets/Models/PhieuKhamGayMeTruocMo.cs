﻿using System;
using System.Collections.Generic;
using Medyx.ApiAssets.Models.Interface;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class PhieuKhamGayMeTruocMo : ITrackableIDBA
    {
        public decimal Idba { get; set; }
        public string MaBa { get; set; }
        public string SoPhieu { get; set; }
        public string NhomMau { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
        public byte? Asa { get; set; }
        public string Mallampati { get; set; }
        public decimal? KhoangCachCamGiap { get; set; }
        public decimal? HaMieng { get; set; }
        public byte? RangGia { get; set; }
        public decimal? BuaAnCuoiTruocMo { get; set; }
        public byte? CapCuu { get; set; }
        public byte? DaDayDay { get; set; }
        public string ChanDoan { get; set; }
        public string HuongXuTri { get; set; }
        public string TienSuNoiKhoa { get; set; }
        public string TienSuNgoaiKhoa { get; set; }
        public string TienSuGayMe { get; set; }
        public string DiUng { get; set; }
        public string ThuocDt { get; set; }
        public string KhamLamSang { get; set; }
        public string TuanHoan { get; set; }
        public int? Mach { get; set; }
        public string HuyetAp { get; set; }
        public string HoHap { get; set; }
        public string ThanKinh { get; set; }
        public string CotSong { get; set; }
        public string XnbatThuong { get; set; }
        public string YeuCauBoSung { get; set; }
        public string DuKienCachVoCam { get; set; }
        public string DuKienGiamDauSauMo { get; set; }
        public string YlenhTruocMo { get; set; }
        public string YtaThucHien { get; set; }
        public DateTime? NgayKham { get; set; }
        public string BsgayMeKham { get; set; }
        public DateTime? NgayThamLaiTruocMo { get; set; }
        public string BsgayMeThamLaiTruocMo { get; set; }
        public bool? Huy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
    }
}
