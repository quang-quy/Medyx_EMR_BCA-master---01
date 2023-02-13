using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhanPhauThuatPhieuPtttService
    {
        private IRepository<BenhanPhauThuatPhieuPttt> _benhanPhauThuatPhieuPtttRepository = null;

        private PrintSetting PrintSetting { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        public BenhanPhauThuatPhieuPtttService(IHttpContextAccessor accessor, IOptions<PrintSetting> options = null, IHostingEnvironment hostingEnvironment = null)
        {
            _benhanPhauThuatPhieuPtttRepository = new GenericRepository<BenhanPhauThuatPhieuPttt>(accessor);
            PrintSetting = options != null ? options.Value : new PrintSetting();
            _hostingEnvironment = hostingEnvironment;
        }

        public BenhanPhauThuatPhieuPtttDto DetailBenhanPhauThuatPhieuPttt(decimal idba, int sttpt)
        {
            var DetailBenhanPhauThuatPhieuPtttQuery = _benhanPhauThuatPhieuPtttRepository.Table.Where(x => x.Idba == idba && x.Sttpt == sttpt);
            var benhAnPhauThuatQuery = _benhanPhauThuatPhieuPtttRepository._context.BenhanPhauThuat.Where(x => x.Idba == idba && x.Stt == sttpt);

            return DetailBenhanPhauThuatPhieuPtttQuery.Select(x => new BenhanPhauThuatPhieuPtttDto()
            {
                Sttpt = x.Sttpt,
                Idba = x.Idba,
                Khoa = new DmkhoaDto()
                {
                    MaKhoa = x.BenhanPhauThuat.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                    TenKhoa = x.BenhanPhauThuat.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                },
                Buong = new DmkhoaBuongDto()
                {
                    TenBuong = x.BenhanPhauThuat.BenhAnKhoaDieuTri.DmkhoaBuong.TenBuong,
                    MaBuong = x.BenhanPhauThuat.BenhAnKhoaDieuTri.DmkhoaBuong.MaBuong,
                },
                Giuong = new DmkhoaGiuongDto()
                {
                    TenGiuong = x.BenhanPhauThuat.BenhAnKhoaDieuTri.DmkhoaGiuong.TenGiuong,
                    MaGiuong = x.BenhanPhauThuat.BenhAnKhoaDieuTri.DmkhoaGiuong.MaGiuong,
                },
                ChanDoan = new DmbenhTatDto()
                {
                    TenBenh = x.BenhanPhauThuat.BenhAnKhoaDieuTri.BenhChinh.TenBenh,
                    MaBenh = x.BenhanPhauThuat.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
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
                NgayPt = x.NgayPt,
                ChanDoanTruocPt = new DmbenhTatDto
                {
                    MaBenh = x.DmbenhTatChanDoanTruocPt.MaBenh,
                    TenBenh = x.DmbenhTatChanDoanTruocPt.TenBenh
                },
                ChanDoanSauPt = new DmbenhTatDto
                {
                    MaBenh = x.DmbenhTatChanDoanSauPt.MaBenh,
                    TenBenh = x.DmbenhTatChanDoanSauPt.TenBenh
                },
                PhuongPhap = x.PhuongPhap,
                LoaiPhauThuat = new DmdichvuPhanLoaiPtttDto()
                {
                    MaPlpttt = x.DmdichvuPhanLoaiPttt.MaPlpttt,
                    TenPlpttt = x.DmdichvuPhanLoaiPttt.TenPlpttt
                },
                PhuongPhapVoCam = x.PhuongPhapVoCam,
                DanLuu = x.DanLuu,
                Bac = x.Bac,
                NgayRutChi = x.NgayRutChi,
                NgayCatChi = x.NgayCatChi,
                Khac = x.Khac,
                TrinhTuPt = x.TrinhTuPt,
                PhuongThucPt = x.PhuongThucPt,
                ViTriPt = x.ViTriPt,
                CachThucPt = x.CachThucPt,
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
                NgayKy = x.NgayKy,
                LuocDoPt = x.LuocDoPt,
                NgayChiDinh = x.BenhanPhauThuat.NgayYlenh,
                Bspt = new DmnhanVienDto()
                {
                    MaNv = x.DmBspt.MaNv,
                    HoTen = x.DmBspt.HoTen
                },
                BsphuMo = new DmnhanVienDto()
                {
                    MaNv = x.DmBsphuMo.MaNv,
                    HoTen = x.DmBsphuMo.HoTen
                },
                BsgayMe = new DmnhanVienDto()
                {
                    MaNv = x.DmBsgayMe.MaNv,
                    HoTen = x.DmBsgayMe.HoTen
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
            }).FirstOrDefault() ?? benhAnPhauThuatQuery.Select(x => new BenhanPhauThuatPhieuPtttDto()
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
            }).FirstOrDefault(); ;
        }

        public void Store(BenhAnPhauThuatPhieuPtttCreateVM parameters)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
            parameters.MaBa = benhAn.MaBa;
            parameters.MaBn = benhAn.MaBn;

            _benhanPhauThuatPhieuPtttRepository.Insert(parameters);
        }

        public void Update(decimal idba, int sttpt, BenhAnPhauThuatPhieuPtttVM parameters)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhanPhauThuatPhieuPtttRepository.Update(parameters, sttpt, idba);
        }

        public void Destroy(decimal idba, int sttpt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhanPhauThuatPhieuPtttRepository.Delete(sttpt, idba);
        }
        public string Print(decimal idba, int sttpt)
        {
            var data = DetailBenhanPhauThuatPhieuPttt(idba, sttpt);
            if (data == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy");
            }
            var dataBenhAn = _benhanPhauThuatPhieuPtttRepository._context.BenhAn
            .Select(ba => new BenhAnDto()
            {
                Idba = ba.Idba,
                SoVaoVien = ba.SoVaoVien,
                NgayVv = ba.NgayVv,
                BenhNhan = new ThongTinBnDto()
                {
                    MaBn = ba.ThongTinBn.MaBn,
                    Idba = ba.ThongTinBn.Idba,
                    HoTen = ba.ThongTinBn.HoTen,
                    NgaySinh = ba.ThongTinBn.NgaySinh,
                    Tuoi = ba.ThongTinBn.Tuoi,
                    GioiTinh = ba.ThongTinBn.GioiTinh,
                    Buong = new DmkhoaBuongDto()
                    {
                        TenBuong = ba.DmkhoaBuong.TenBuong,
                        MaBuong = ba.DmkhoaBuong.TenBuong,
                    },
                    Giuong = new DmkhoaGiuongDto()
                    {
                        TenGiuong = ba.DmkhoaGiuong.TenGiuong,
                        MaGiuong = ba.DmkhoaGiuong.MaGiuong
                    }
                },
            }).FirstOrDefault(x => x.Idba == idba);

            List<string> fields = new List<string>(){
                "SoYTe",
                "BenhVien",
                "SoVV",
                "HoTen",
                "Tuoi",
                "GioiTinh",
                "Khoa",
                "Buong",
                "Giuong",
                "GioVaoVien",
                "NgayVaoVien",
                "GioPhauThuat",
                "NgayPhauThuat",
                "ChanDoan",
                "TruocPhauThuat",
                "SauPhauThuat",
                "PhuongPhapPhauThuat",
                "LoaiPhauThuat",
                "PhuongPhapVoCam",
                "BsPhauThuat",
                "BsGayMe",
                "DanLuu",
                "Bac",
                "NgayRut",
                "CatChi",
                "Khac",
                "TrinhTuPhauThuat",
                "NgayThang",
                "HoTenTT"
            };
            List<string> values = new List<string>()
            {
                PrintSetting.SoYTe,
                PrintSetting.BenhVien,
                dataBenhAn.SoVaoVien,
                dataBenhAn.BenhNhan.HoTen,
                PrintHelper.HanlderUnknowsType<byte>(dataBenhAn.BenhNhan.Tuoi),
                dataBenhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
                data?.Khoa?.TenKhoa,
                data?.Buong?.TenBuong,
                data?.Giuong?.TenGiuong,
                PrintHelper.TimeText(dataBenhAn.NgayVv),
                PrintHelper.DateText(dataBenhAn.NgayVv),
                PrintHelper.TimeText(data.NgayPt),
                PrintHelper.DateText(data.NgayPt),
                !String.IsNullOrEmpty(data?.ChanDoan?.MaBenh) ? $"{data?.ChanDoan?.MaBenh} - {data?.ChanDoan?.TenBenh}" : "",
                data?.ChanDoanTruocPt?.TenBenh,
                data?.ChanDoanSauPt?.TenBenh,
                data?.PhuongPhap,
                data?.LoaiPhauThuat?.TenPlpttt,
                data?.PhuongPhapVoCam,
                data?.Bspt?.HoTen,
                data?.BsgayMe?.HoTen,
                data?.DanLuu,
                data?.Bac,
                PrintHelper.DateText(data?.NgayRutChi),
                PrintHelper.DateText(data?.NgayCatChi),
                data?.Khac,
                data?.TrinhTuPt,
                PrintHelper.DateText(data?.NgayPt),
                data?.Bspt?.HoTen
            };
            string path = PrintHelper.PrintFile<BenhAnDto>(_hostingEnvironment, "Phieu-phau-thuat-thu-thuat.docx", fields, values);
            return path;
        }

        public string GiayChungNhanBaoTu(decimal idba, int stt)
        {
            var data = DetailBenhanPhauThuatPhieuPttt(idba, stt);
            var benhAnGayMe = _benhanPhauThuatPhieuPtttRepository._context.BenhanPhauThuatPhieuKhamGayMeTruocMo.FirstOrDefault(x => x.Idba == idba && x.Sttpt == stt);
            var dataBenhAn = _benhanPhauThuatPhieuPtttRepository._context.BenhAn
            .Select(ba => new BenhAnDto()
            {
                Idba = ba.Idba,
                SoLuuTru = ba.SoLuuTru,
                SoVaoVien = ba.SoVaoVien,
                NgayVv = ba.NgayVv,
                NgayRv = ba.NgayRv,
                Giamdoc = new DmnhanVienDto()
                {
                    MaNv = ba.DmGiamdoc.MaNv,
                    HoTen = ba.DmGiamdoc.HoTen
                },
                TruongKhoa = new DmnhanVienDto()
                {
                    MaNv = ba.DmTruongKhoa.MaNv,
                    HoTen = ba.DmTruongKhoa.HoTen
                },
                BenhNhan = new ThongTinBnDto()
                {
                    MaBn = ba.ThongTinBn.MaBn,
                    Idba = ba.ThongTinBn.Idba,
                    HoTen = ba.ThongTinBn.HoTen,
                    NgaySinh = ba.ThongTinBn.NgaySinh,
                    Tuoi = ba.ThongTinBn.Tuoi,
                    GioiTinh = ba.ThongTinBn.GioiTinh,
                    SoNha = ba.ThongTinBn.SoNha,
                    Thon = ba.ThongTinBn.Thon,
                    QuocGia = new DmquocGiaDto()
                    {
                        MaQg = ba.ThongTinBn.DmquocGia.MaQg,
                        TenQg = ba.ThongTinBn.DmquocGia.TenQg
                    },
                    Tinh = new DmtinhDto()
                    {
                        MaTinh = ba.ThongTinBn.Dmtinh.MaTinh,
                        TenTinh = ba.ThongTinBn.Dmtinh.TenTinh
                    },
                    QuanHuyen = new DmquanHuyenDto()
                    {
                        MaQh = ba.ThongTinBn.DmquanHuyen.MaQh,
                        TenQh = ba.ThongTinBn.DmquanHuyen.TenQh
                    },
                    PhuongXa = new DmphuongXaDto()
                    {
                        MaPxa = ba.ThongTinBn.DmphuongXa.MaPxa,
                        TenPxa = ba.ThongTinBn.DmphuongXa.TenPxa
                    },
                },
            }).FirstOrDefault(x => x.Idba == idba);
            List<string> fields = new List<string>(){
                "SoLuuTru",
                "BenhVien",
                "HoTen",
                "DiaChi",
                "NgayVV",
                "NgayRV",
                "DaPhauThuat",
                "CachThucPhauThuat",
                "NhomMau",
                "YeuTo",
                "NgayThang",
                "BsTruongKhoa",
                "GiamDoc"
            };
            List<string> values = new List<string>(){
                dataBenhAn.SoLuuTru,
                PrintSetting.BenhVien,
                dataBenhAn.BenhNhan.HoTen,
                PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
                PrintHelper.DateTextShort(dataBenhAn.NgayVv),
                PrintHelper.DateTextShort(dataBenhAn.NgayRv),
                $"Vị trí: {data.ViTriPt}, Phương thức: {data.PhuongThucPt}",
                data.CachThucPt,
                benhAnGayMe.NhomMau,
                benhAnGayMe.Rh,
                PrintHelper.DateText(data.NgayPt),
                dataBenhAn.TruongKhoa.HoTen,
                dataBenhAn.Giamdoc.HoTen
            };
            string path = PrintHelper.PrintFile<BenhAnDto>(_hostingEnvironment, "PhauThuat_giay-chung-nhan-phau-thuatdoc.doc", fields, values);
            return path;
        }
    }
}
