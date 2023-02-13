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
    public class BenhAnPhauThuatDuyetMoService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IRepository<BenhAnPhauThuatDuyetMo> _benhAnPhauThuatDuyetMoRepository = null;
        public BenhAnPhauThuatDuyetMoService(PrintSetting printSetting) 
        {
            this.PrintSetting = printSetting;
               
        }
                private PrintSetting PrintSetting { get; set; }
        public BenhAnPhauThuatDuyetMoService(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment = null, IOptions<PrintSetting> options = null)
        {
            _hostingEnvironment = hostingEnvironment;
            _benhAnPhauThuatDuyetMoRepository = new GenericRepository<BenhAnPhauThuatDuyetMo>(accessor);
            PrintSetting = options != null ? options.Value : new PrintSetting();
        }

        public BenhAnPhauThuatDuyetMoDto DetailPhauThuatDuyetMo(decimal idba, int sttpt)
        {
            var detailPhauThuatDuyetMoQuery = _benhAnPhauThuatDuyetMoRepository.Table.Where(x => x.Idba == idba && x.Sttpt == sttpt);
            var benhAnPhauThuatQuery = _benhAnPhauThuatDuyetMoRepository._context.BenhanPhauThuat.Where(x => x.Idba == idba && x.Stt == sttpt);

            return detailPhauThuatDuyetMoQuery.Select(x => new BenhAnPhauThuatDuyetMoDto()
            {
                Sttpt = x.Sttpt,
                Idba = x.Idba,
                NgayChiDinh = x.BenhanPhauThuat.NgayYlenh,
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
                BenhChinh = new DmbenhTatDto(){
                    MaBenh = x.BenhanPhauThuat.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
                    TenBenh = x.BenhanPhauThuat.BenhAnKhoaDieuTri.BenhChinh.TenBenh,
                },
                LyDoVv = x.LyDoVv,
                TienSuNgoaiKhoa = x.TienSuNgoaiKhoa,
                TienSuNoiKhoa = x.TienSuNoiKhoa,
                TienSuDiUng = x.TienSuDiUng,
                TienSuKhac = x.TienSuKhac,
                BenhSu = x.BenhSu,
                Mach = x.Mach,
                HuyetAp = x.HuyetAp,
                NhietDo = x.NhietDo,
                MoTaHienTaiKhac = x.MoTaHienTaiKhac,
                NhomMau = x.NhomMau,
                Hc = x.Hc,
                Hct = x.Hct,
                Bc = x.Bc,
                Tc = x.Tc,
                Pt = x.Pt,
                Apt = x.Apt,
                Kqhhkhac = x.Kqhhkhac,
                Kqsh = x.Kqsh,
                Kqcdha = x.Kqcdha,
                Kqxnkhac = x.Kqxnkhac,
                MaBenh = x.MaBenh,
                PhuongPhapPhauThuat = x.PhuongPhapPhauThuat,
                PhuongPhapVoCam = x.PhuongPhapVoCam,
                KipPhauThuat = x.KipPhauThuat,
                NgayPt = x.NgayPt,
                DuTruMau = x.DuTruMau,
                KhoKhan = x.KhoKhan,
                VanDeKhac = x.VanDeKhac,
                NgayKyBspt = x.NgayKyBspt,
                NgayKyBsgm = x.NgayKyBsgm,
                NgayKyBsldkhoa = x.NgayKyBsldkhoa,
                NgayKyLdbv = x.NgayKyLdbv,
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
                Bspt = new DmnhanVienDto()
                {
                    MaNv = x.DmBspt.MaNv,
                    HoTen = x.DmBspt.HoTen
                },
                BsgayMe = new DmnhanVienDto()
                {
                    MaNv = x.DmBsgayMe.MaNv,
                    HoTen = x.DmBsgayMe.HoTen
                },
                TruongKhoa = new DmnhanVienDto()
                {
                    MaNv = x.DmTruongKhoa.MaNv,
                    HoTen = x.DmTruongKhoa.HoTen
                },
                LanhDaoBv = new DmnhanVienDto()
                {
                    MaNv = x.DmLanhDaoBv.MaNv,
                    HoTen = x.DmLanhDaoBv.HoTen
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
            }).FirstOrDefault() ?? benhAnPhauThuatQuery.Select(x => new BenhAnPhauThuatDuyetMoDto()
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

        public void Store(BenhAnPhauThuatDuyetMoCreateVM parameters)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
            parameters.MaBa = benhAn.MaBa;
            parameters.MaBn = benhAn.MaBn;

            _benhAnPhauThuatDuyetMoRepository.Insert(parameters);
        }

        public void Update(decimal idba, int sttpt, BenhAnPhauThuatDuyetMoVM parameters)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnPhauThuatDuyetMoRepository.Update(parameters, sttpt, idba);
        }

        public void Destroy(decimal idba, int sttpt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnPhauThuatDuyetMoRepository.Delete(sttpt, idba);
        }

        public string Print(decimal idba, int sttpt)
        {
            var dataBenhAn = new BenhAnService().Detail(idba);
            var phauThuyetModel = DetailPhauThuatDuyetMo(idba, sttpt);
            if (phauThuyetModel == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy");
            }
            List<string> fields = new List<string>()
            {
                "BenhVien",
                "Khoa",
                "SoVV",
                "Buong",
                "Giuong",
                //Thong tin benh nhan
                "HoTen",
                "NgaySinh",
                "Tuoi",
                "GioiTinh",
                "DoiTuong",
                "NgayVaoVien",
                // Lam sang,
                "LyDoVaoVien",
                "TienSuNoiKhoa",
                "TienSuNgoaiKhoa",
                "TienSuDiUng",
                "TienSuKhac",
                "BenhSu",
                "Mach",
                "HuyetAp",
                "NhietDo",
                "MoTaHienTaiKhac",
                //Can lam sang
                "NhomMau",
                "Hc",
                "Hct",
                "Bc",
                "Tc",
                "Pt",
                "Apt",
                "SinhHoa",
                "Cdha",
                "XetNghiemKhac",
                //Chan doan
                "ChanDoan",
                //Du kien pha thuat
                "TenPhauThuat",
                "PhuongPhapPhauThuat",
                "PhuongPhapVoCam",
                "KipPhauThuat",
                "NgayPhauThuat",
                "DuTruMau",
                "KhoKhan",
                "VanDeKhac",
                // //chu ky
                "NgayKyBspt",
                "Bspt",
                "NgayKyBsgm",
                "BsgayMe",
                "NgayKyBsldkhoa",
                "TruongKhoa",
                "NgayKyLdbv",
                "LanhDaoBv"
            };
            List<string> values = new List<string>()
            {
                PrintSetting.BenhVien,
                phauThuyetModel?.Khoa?.TenKhoa,
                dataBenhAn?.SoVaoVien,
                phauThuyetModel?.Buong?.TenBuong,
                phauThuyetModel?.Giuong?.TenGiuong,
                //Thong tin benh nhan
                dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
                PrintHelper.DateTextShortest(dataBenhAn?.BenhNhan?.NgaySinh),
                dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
                dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
                dataBenhAn?.BenhNhan?.DoiTuong?.TenDt,
                PrintHelper.DateText(dataBenhAn?.NgayVv),
                // Lam sang,
                phauThuyetModel?.LyDoVv,
                phauThuyetModel?.TienSuNoiKhoa,
                phauThuyetModel?.TienSuNgoaiKhoa,
                phauThuyetModel?.TienSuDiUng,
                phauThuyetModel?.TienSuKhac,
                phauThuyetModel?.BenhSu,
                phauThuyetModel?.Mach?.ToString(),
                phauThuyetModel?.HuyetAp,
                phauThuyetModel?.NhietDo?.ToString(),
                phauThuyetModel?.MoTaHienTaiKhac,
                //Can lam sang
                phauThuyetModel?.NhomMau,
                phauThuyetModel?.Hc,
                phauThuyetModel?.Hct,
                phauThuyetModel?.Bc,
                phauThuyetModel?.Tc,
                phauThuyetModel?.Pt,
                phauThuyetModel?.Apt,
                phauThuyetModel?.Kqsh,
                phauThuyetModel?.Kqcdha,
                phauThuyetModel?.Kqxnkhac,
                //Chan doan
                phauThuyetModel?.MaBenh,
                ///// !String.IsNullOrEmpty(phauThuyetModel?.BenhChinh?.MaBenh) ? $"{phauThuyetModel?.BenhChinh?.MaBenh} - {phauThuyetModel?.BenhChinh?.TenBenh}" : "",
                //Du kien pha thuat
                phauThuyetModel?.PhauThuat?.TenPt, //TenPhauThuat
                phauThuyetModel?.PhuongPhapPhauThuat,
                phauThuyetModel?.PhuongPhapVoCam,
                phauThuyetModel?.KipPhauThuat,
                PrintHelper.DateText(phauThuyetModel?.NgayPt),
                phauThuyetModel?.DuTruMau,
                phauThuyetModel?.KhoKhan,
                phauThuyetModel?.VanDeKhac,
                //chu ky
				PrintHelper.DateText(phauThuyetModel?.NgayKyBspt),
                phauThuyetModel?.Bspt?.HoTen,
                PrintHelper.DateText(phauThuyetModel?.NgayKyBspt),
                phauThuyetModel?.BsgayMe?.HoTen,
                PrintHelper.DateText(phauThuyetModel?.NgayKyBsldkhoa),
                phauThuyetModel?.TruongKhoa?.HoTen,
                PrintHelper.DateText(phauThuyetModel?.NgayKyLdbv),
                phauThuyetModel?.LanhDaoBv?.HoTen,
            };
            string path = PrintHelper.PrintFile<BenhAnPhauThuatDuyetMoDto>(_hostingEnvironment, "phieu-duyet-mo.doc", fields, values);
            return path;
        }
    }
}
