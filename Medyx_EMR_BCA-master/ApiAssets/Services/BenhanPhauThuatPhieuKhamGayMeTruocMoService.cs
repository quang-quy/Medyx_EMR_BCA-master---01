using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhanPhauThuatPhieuKhamGayMeTruocMoService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IRepository<BenhanPhauThuatPhieuKhamGayMeTruocMo> _benhanPhauThuatPhieuKhamGayMeTruocMoRepository = null;

        public BenhanPhauThuatPhieuKhamGayMeTruocMoService(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment = null)
        {
            _hostingEnvironment = hostingEnvironment;
            _benhanPhauThuatPhieuKhamGayMeTruocMoRepository = new GenericRepository<BenhanPhauThuatPhieuKhamGayMeTruocMo>(accessor);
        }

        public BenhanPhauThuatPhieuKhamGayMeTruocMoDto DetailBenhanPhauThuatPhieuKhamGayMeTruocMo(decimal idba, int sttpt)
        {
            var DetailBenhanPhauThuatPhieuKhamGayMeTruocMoQuery = _benhanPhauThuatPhieuKhamGayMeTruocMoRepository.Table.Where(x => x.Idba == idba && x.Sttpt == sttpt);
            var benhAnPhauThuatQuery = _benhanPhauThuatPhieuKhamGayMeTruocMoRepository._context.BenhanPhauThuat.Where(x => x.Idba == idba && x.Stt == sttpt);

            return DetailBenhanPhauThuatPhieuKhamGayMeTruocMoQuery.Select(x => new BenhanPhauThuatPhieuKhamGayMeTruocMoDto()
            {
                Sttpt = x.Sttpt,
                Idba = x.Idba,
                Khoa = new DmkhoaDto()
                {
                    MaKhoa = x.BenhanPhauThuat.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                    TenKhoa = x.BenhanPhauThuat.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                },
                PhauThuat = new DmphauThuatDto()
                {
                    MaPt = x.BenhanPhauThuat.DmphauThuat.MaPt,
                    TenPt = x.BenhanPhauThuat.DmphauThuat.TenPt
                },
                BsChiDinh = new DmnhanVienDto()
                {
                    MaNv = x.BenhanPhauThuat.DmBschiDinh.MaNv,
                    HoTen = x.BenhanPhauThuat.DmBschiDinh.HoTen,
                },
                NgayChiDinh = x.BenhanPhauThuat.NgayYlenh,
                NhomMau = x.NhomMau,
                Rh = x.Rh,
                CanNang = x.CanNang,
                ChieuCao = x.ChieuCao,
                Asa = x.Asa,
                Mallampati = x.Mallampati,
                KhoangCachCamGiap = x.KhoangCachCamGiap,
                HuyetAp = x.HuyetAp,
                HaMieng = x.HaMieng,
                RangGia = x.RangGia,
                BuaAnCuoiTruocMo = x.BuaAnCuoiTruocMo,
                CapCuu = x.CapCuu,
                ChanDoan = x.ChanDoan,
                HuongXuTri = x.HuongXuTri,
                TienSuNoiKhoa = x.TienSuNoiKhoa,
                TienSuNgoaiKhoa = x.TienSuNgoaiKhoa,
                TienSuGayMe = x.TienSuGayMe,
                ThuocDt = x.ThuocDt,
                KhamLamSang = x.KhamLamSang,
                TuanHoan = x.TuanHoan,
                DiUng = x.DiUng,
                NghienThuocLa = x.NghienThuocLa,
                NghienRuou = x.NghienRuou,
                NghienMaTuy = x.NghienMaTuy,
                Mach = x.Mach,
                HoHap = x.HoHap,
                ThanKinh = x.ThanKinh,
                CotSong = x.CotSong,
                XnbatThuong = x.XnbatThuong,
                YeuCauBoSung = x.YeuCauBoSung,
                DuKienCachVoCam = x.DuKienCachVoCam,
                DuKienGiamDauSauMo = x.DuKienGiamDauSauMo,
                YlenhTruocMo = x.YlenhTruocMo,
                DieuDuong = x.DieuDuong,
                NgayKham = x.NgayKham,
                NgayThamLaiTruocMo = x.NgayThamLaiTruocMo,
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
                DaDayDay = x.DaDayDay,
                DmDieuDuong = new DmnhanVienDto()
                {
                    MaNv = x.DmDieuDuong.MaNv,
                    HoTen = x.DmDieuDuong.HoTen
                },
                DmBsgayMeKham = new DmnhanVienDto()
                {
                    MaNv = x.DmBsgayMeKham.MaNv,
                    HoTen = x.DmBsgayMeKham.HoTen
                },
                DmBsgayMeThamLaiTruocMo = new DmnhanVienDto()
                {
                    MaNv = x.DmBsgayMeThamLaiTruocMo.MaNv,
                    HoTen = x.DmBsgayMeThamLaiTruocMo.HoTen
                },

                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiLap.MaNv,
                    HoTen = x.DmNguoiLap.HoTen
                },
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiHuy.MaNv,
                    HoTen = x.DmNguoiHuy.HoTen
                },
                NguoiSD = new DmnhanVienDto()
                {
                    MaNv = x.DmNguoiSD.MaNv,
                    HoTen = x.DmNguoiSD.HoTen
                },

            }).FirstOrDefault() ?? benhAnPhauThuatQuery.Select(x => new BenhanPhauThuatPhieuKhamGayMeTruocMoDto()
            {
                Khoa = new DmkhoaDto()
                {
                    MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                    TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                },
                PhauThuat = new DmphauThuatDto()
                {
                    MaPt = x.DmphauThuat.MaPt,
                    TenPt = x.DmphauThuat.TenPt
                },
                BsChiDinh = new DmnhanVienDto()
                {
                    MaNv = x.DmBschiDinh.MaNv,
                    HoTen = x.DmBschiDinh.HoTen,
                },
                NgayChiDinh = x.NgayYlenh
            }).FirstOrDefault();
        }

        public void Store(BenhAnPhauThuatPhieuKhamGayMeTruocMoCreateVM parameters)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
            parameters.MaBa = benhAn.MaBa;

            _benhanPhauThuatPhieuKhamGayMeTruocMoRepository.Insert(parameters);
        }

        public void Update(decimal idba, int sttpt, BenhAnPhauThuatPhieuKhamGayMeTruocMoVM parameters)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhanPhauThuatPhieuKhamGayMeTruocMoRepository.Update(parameters, sttpt, idba);
        }

        public void Destroy(decimal idba, int sttpt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhanPhauThuatPhieuKhamGayMeTruocMoRepository.Delete(sttpt, idba);
        }
        public string Print(decimal idba, int sttpt)
        {
            var dataBenhAn = new BenhAnService().Detail(idba);
            var phieukhamgaymeModel = DetailBenhanPhauThuatPhieuKhamGayMeTruocMo(idba, sttpt);
            List<string> fields = new List<string>()
            {
                //box 1
                "HoTen",
                "Tuoi",
                "GioiTinh",
                "NhomMau",
                //box 2
                "CanNang",
                "ChieuCao",
                "Asa",
                "KhoangCachCamGiap",
                "HaMieng",
                "Mallampat",
                //box 3
                "BuaAnCuoiTruocMo",
                "CapCuu",
                "DaDayDay",
                //box4
                "ChanDoan",
                "HuongXuTri",
                //box5
                "TienSuNoiKhoa",
                "TienSuNgoaiKhoa",
                "TienSuGayMe",
                "DiUng",
                "NghienThuocLa",
                "NghienRuou",
                "NghienMaTuy",
                "ThuocDt",
                //box6
                "KhamLamSang",
                "TuanHoan",
                "Mach",
                "HuyetAp",
                "HoHap",
                "ThanKinh",
                "CotSong",
                "XnbatThuong",
                "YeuCauBoSung",
                "DuKienCachVoCam",
                "DuKienGiamDauSauMo",
                //box7
                "YlenhTruocMo",
                "YTaThucHien",
                //box8
                "NgayKham",
                "DmBsgayMeKham",

                //box9
                "NgayThamLaiTruocMo",
                "DmBsgayMeThamLaiTruocMo"
            };
            List<string> values = new List<string>()
            {
                //box 1
                dataBenhAn?.BenhNhan?.HoTen,
                dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
                dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
                phieukhamgaymeModel?.NhomMau,
                //box 2
                ((int?)phieukhamgaymeModel?.CanNang)?.ToString(),
                ((int?)phieukhamgaymeModel?.ChieuCao)?.ToString(),
                phieukhamgaymeModel?.Asa?.ToString(),
                ((int?)phieukhamgaymeModel?.KhoangCachCamGiap)?.ToString(),
                ((int?)phieukhamgaymeModel?.HaMieng)?.ToString(),
                phieukhamgaymeModel?.Mallampati,
                //box 3
                ((int?)phieukhamgaymeModel?.BuaAnCuoiTruocMo)?.ToString(),
                phieukhamgaymeModel?.CapCuu == 1 ? "x" : "",//"CapCuu",
                phieukhamgaymeModel?.DaDayDay == 1 ? "x" : "",//"DaDayDay",
                //box4
                phieukhamgaymeModel?.ChanDoan,
                phieukhamgaymeModel?.HuongXuTri,
                //box5
                phieukhamgaymeModel?.TienSuNoiKhoa,
                phieukhamgaymeModel?.TienSuNgoaiKhoa,
                phieukhamgaymeModel?.TienSuGayMe,
                phieukhamgaymeModel?.DiUng,
                phieukhamgaymeModel?.NghienThuocLa == 1 ? "x" : "",
                phieukhamgaymeModel?.NghienRuou == 1 ? "x" : "",
                phieukhamgaymeModel?.NghienMaTuy == 1 ? "x" : "",
                phieukhamgaymeModel?.ThuocDt,
                //box6
                phieukhamgaymeModel?.KhamLamSang,
                phieukhamgaymeModel?.TuanHoan,
                phieukhamgaymeModel?.Mach?.ToString(),
                phieukhamgaymeModel?.HuyetAp,
                phieukhamgaymeModel?.HoHap,
                phieukhamgaymeModel?.ThanKinh,
                phieukhamgaymeModel?.CotSong,
                phieukhamgaymeModel?.XnbatThuong,
                phieukhamgaymeModel?.YeuCauBoSung,
                phieukhamgaymeModel?.DuKienCachVoCam,
                phieukhamgaymeModel?.DuKienGiamDauSauMo,
                //box7
                phieukhamgaymeModel?.YlenhTruocMo,
                phieukhamgaymeModel?.DmDieuDuong?.HoTen,
                //box8
                PrintHelper.DateText(phieukhamgaymeModel?.NgayKham),
                phieukhamgaymeModel?.DmBsgayMeKham?.HoTen,                //box9
                PrintHelper.DateText(phieukhamgaymeModel?.NgayThamLaiTruocMo),
                phieukhamgaymeModel?.DmBsgayMeThamLaiTruocMo?.HoTen,
            };
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "ThaoRangGia", PrintHelper.HanlderBooleanType(phieukhamgaymeModel.RangGia), PrintHelper.CreateArrayIncreate(3, 0));

            string path = PrintHelper.PrintFile<BenhanPhauThuatPhieuKhamGayMeTruocMoDto>(_hostingEnvironment, "phieu-kham-gay-me-truoc-mo.doc", fields, values);
            return path;
        }

    }
}
