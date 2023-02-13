using AutoMapper;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnService
    {
        private IRepository<BenhAn> _benhAnRepository = null;
        private PrintSetting PrintSetting { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private IHttpContextAccessor _context { get; set; }
        public BenhAnService(IHostingEnvironment hostingEnvironment = null, IHttpContextAccessor context = null, IOptions<PrintSetting> options = null)
        {
            _benhAnRepository = new GenericRepository<BenhAn>(context);
            PrintSetting = options != null ? options.Value : new PrintSetting();
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public IQueryable<BenhAnDto> Get(BenhAnParameters parameters, UserSession user = null)
        {
            List<DmkhoaDto> dskhoa = user.DMKhoaAcc.Select(ba => new DmkhoaDto()
            {
                MaKhoa = ba.MaKhoa,
                TenKhoa = ba.TenKhoa
            }).ToList();
            var query = _benhAnRepository.Table
                .Include(x => x.ThongTinBn)
                .Include(x => x.DmbaLoaiBa)
                //.Include(x => x.Dmkhoa)
                .Include(x => x.DmkhoaBuong)
                .Include(x => x.DmkhoaGiuong)
                .Include(x => x.ThongTinBn).ThenInclude(x => x.Dmtinh)
                .Include(x => x.ThongTinBn).ThenInclude(x => x.DmquanHuyen)
                .Include(x => x.ThongTinBn).ThenInclude(x => x.DmphuongXa)
                .Include(x => x.NguoiLap)
                .Include(x => x.NguoiLap)
                .Where(x => user.DMKhoaAcc.Contains(x.Dmkhoa))
                .AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);

            IQueryable<BenhAnDto> benhAnQuery = query.Select(ba => new BenhAnDto()
            {
                Idba = ba.Idba,
                SoVaoVien = ba.SoVaoVien,
                SoLuuTru = ba.SoLuuTru,
                MaBa = ba.MaBa,
                MaYt = ba.MaYt,
                TenDvcq = ba.TenDvcq,
                MaBv = ba.MaBv,
                TenBv = ba.TenBv,
                XacNhanLuuTru = ba.XacNhanLuuTru,
                NgayLuuTru = ba.NgayLuuTru,
                XacNhanKetThucHs = ba.XacNhanKetThucHs,
                NgayXacNhanKetThucHs = ba.NgayXacNhanKetThucHs,
                NgayVv = ba.NgayVv,
                NgayRv = ba.NgayRv,
                NgayLap = ba.NgayLap,
                NgayHuy = ba.NgayHuy,
                Huy = ba.Huy,
                MaBvChuyenDen = ba.MaBvChuyenDen,
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

                    },
                    QuocGia = new DmquocGiaDto()
                    {
                        MaQg = ba.ThongTinBn.DmquocGia.MaQg,
                        TenQg = ba.ThongTinBn.DmquocGia.TenQg
                    },
                },
                LoaiBenhAn = new DmbaLoaiBaDto()
                {
                    MaLoaiBa = ba.DmbaLoaiBa.MaLoaiBa,
                    TenLoaiBa = ba.DmbaLoaiBa.TenLoaiBa
                },
                Khoa = new DmkhoaDto()
                {
                    MaKhoa = ba.Dmkhoa.MaKhoa,
                    TenKhoa = ba.Dmkhoa.TenKhoa
                },
                Buong = new DmkhoaBuongDto()
                {
                    MaBuong = ba.DmkhoaBuong.MaBuong,
                    TenBuong = ba.DmkhoaBuong.TenBuong
                },
                Giuong = new DmkhoaGiuongDto()
                {
                    MaGiuong = ba.DmkhoaGiuong.MaGiuong,
                    TenGiuong = ba.DmkhoaGiuong.TenGiuong
                },
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = ba.DmNguoiHuy.MaNv,
                    HoTen = ba.DmNguoiHuy.HoTen
                },
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = ba.DmNguoiLap.MaNv,
                    HoTen = ba.DmNguoiLap.HoTen
                },
            });
                //.Where(x => dskhoa.Contains(x.Khoa));
            return benhAnQuery;
        }

        private IQueryable<BenhAn> QueryFilter(IQueryable<BenhAn> query, BenhAnParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                query = query.Where(x => x.ThongTinBn.HoTen.Contains(parameters.Search) || x.MaBa.Contains(parameters.Search));
            }
            if (!string.IsNullOrEmpty(parameters.MaBa))
            {
                query = query.Where(x => x.MaBa.Contains(parameters.MaBa));
            }
            if (!string.IsNullOrEmpty(parameters.TenBenhNhan))
            {
                query = query.Where(x => x.ThongTinBn.HoTen.Contains(parameters.TenBenhNhan));
            }
            if (parameters.Tuoi.HasValue)
            {
                query = query.Where(x => x.ThongTinBn.Tuoi == parameters.Tuoi);
            }
            if (parameters.GioiTinh.HasValue)
            {
                query = query.Where(x => x.ThongTinBn.GioiTinh == parameters.GioiTinh);
            }
            if (!string.IsNullOrEmpty(parameters.MaBv))
            {
                query = query.Where(x => x.MaBv.Contains(parameters.MaBv));
            }
            if (!string.IsNullOrEmpty(parameters.TenBv))
            {
                query = query.Where(x => x.TenBv.Contains(parameters.TenBv));
            }
            // if (parameters.ngayVaoVien.Any())
            // {
            // 	query = query.Where(x => DateTime.Compare((DateTime)parameters.ngayVaoVien[0], x.NgayVv) <= 0)
            // 		.Where(x => DateTime.Compare((DateTime)parameters.ngayVaoVien[1], x.NgayVv) >= 0);
            // }
            // if (parameters.ngayRaVien.Any())
            // {
            // 	query = query.Where(x => DateTime.Compare((DateTime)parameters.ngayRaVien[0], x.NgayVv) <= 0)
            // 		.Where(x => DateTime.Compare((DateTime)parameters.ngayRaVien[1], x.NgayVv) >= 0);
            // }
            if (parameters.TuNgayVaoVien.HasValue)
            {
                query = query.Where(x => DateTime.Compare((DateTime)parameters.TuNgayVaoVien, x.NgayVv) <= 0);
            }
            if (parameters.DenNgayVaoVien.HasValue)
            {
                query = query.Where(x => DateTime.Compare((DateTime)parameters.DenNgayVaoVien, x.NgayVv) >= 0);
            }
            if (parameters.TuNgayRaVien.HasValue)
            {
                query = query.Where(x => DateTime.Compare((DateTime)parameters.TuNgayRaVien, x.NgayVv) <= 0);
            }
            if (parameters.DenNgayRaVien.HasValue)
            {
                query = query.Where(x => DateTime.Compare((DateTime)parameters.DenNgayRaVien, x.NgayVv) >= 0);
            }

            if (parameters.MaKhoa.Any())
            {
                query = query.Where(x => parameters.MaKhoa.Any(mk => mk.Trim() == x.Dmkhoa.MaKhoa));
            }
            if (parameters.LoaiBenhAn.Any())
            {
                query = query.Where(x => parameters.LoaiBenhAn.Any(lba => lba.Trim() == x.DmbaLoaiBa.MaLoaiBa.ToString()));
            }
            if (parameters.XacNhanLuuTru.HasValue)
            {
                query = query.Where(x => x.XacNhanLuuTru == parameters.XacNhanLuuTru);
            }
            if (parameters.XacNhanKetThucHs.HasValue)
            {
                query = query.Where(x => x.XacNhanKetThucHs == parameters.XacNhanKetThucHs);
            }
            return query;
        }
        public BenhAnDetailDto Detail(decimal id)
        {
            var query = _benhAnRepository.Table
                .Where(x => x.Idba == id)
                .AsQueryable();
            var queryBenhAnDetail = query.Select(benhAn => new BenhAnDetailDto()
            {
                Idba = benhAn.Idba,
                MaBa = benhAn.MaBa,
                TenDvcq = benhAn.TenDvcq,
                MaBv = benhAn.MaBv,
                TenBv = benhAn.TenBv,
                SoVaoVien = benhAn.SoVaoVien,
                SoLuuTru = benhAn.SoLuuTru,
                MaYt = benhAn.MaYt,
                Huy = benhAn.Huy,
                NgayVv = benhAn.NgayVv,
                NgayRv = benhAn.NgayRv,
                TrucTiepVao = benhAn.TrucTiepVao,
                NoiGt = benhAn.NoiGt,
                ChuyenVien = benhAn.ChuyenVien,
                MaBvChuyenDen = benhAn.MaBvChuyenDen,
                HtraVien = benhAn.HtraVien,
                TongSoNgayDt = benhAn.TongSoNgayDt,
                MaBenhChinhVv = benhAn.MaBenhChinhVv,
                TenBenhChinhVv = benhAn.TenBenhChinhVv,
                ThuThuatYhhd = benhAn.ThuThuatYhhd,
                PhauThuatYhhd = benhAn.PhauThuatYhhd,
                MaBenhChinhRv = benhAn.MaBenhChinhRv,
                TenBenhChinhRv = benhAn.TenBenhChinhRv,
                TaiBienYhhd = benhAn.TaiBienYhhd,
                BienChungYhhd = benhAn.BienChungYhhd,
                MaBenhChinhVvyhct = benhAn.MaBenhChinhVvyhct,
                TenBenhChinhVvyhct = benhAn.TenBenhChinhVvyhct,
                MaBenhChinhRvyhct = benhAn.MaBenhChinhRvyhct,
                TenBenhChinhRvyhct = benhAn.TenBenhChinhRvyhct,
                ThuThuatYhct = benhAn.ThuThuatYhct,
                PhauThuatYhct = benhAn.PhauThuatYhct,
                TaiBienYhct = benhAn.TaiBienYhct,
                BienChungYhct = benhAn.BienChungYhct,
                Kqdt = benhAn.Kqdt,
                GiaiPhauBenh = benhAn.GiaiPhauBenh,
                NgayTuVong = benhAn.NgayTuVong,
                NguyenNhanTuVong = benhAn.NguyenNhanTuVong,
                KhamNghiemTuThi = benhAn.KhamNghiemTuThi,
                NgayKy = benhAn.NgayKy,
                NgayTruongKhoaKy = benhAn.NgayTruongKhoaKy,
                TinhTrangTuVong = benhAn.TinhTrangTuVong,
                Vvlan = benhAn.Vvlan,
                benhVienChuyenDen = new DmbenhVienDto()
                {
                    MaBv = benhAn.DmbenhVien.MaBv,
                    TenBv = benhAn.DmbenhVien.TenBv
                },
                BenhNhan = new BenhAnDetailThongTinBnDto()
                {
                    MaBn = benhAn.ThongTinBn.MaBn,
                    Idba = benhAn.ThongTinBn.Idba,
                    HoTen = benhAn.ThongTinBn.HoTen,
                    NgaySinh = benhAn.ThongTinBn.NgaySinh,
                    Tuoi = benhAn.ThongTinBn.Tuoi,
                    GioiTinh = benhAn.ThongTinBn.GioiTinh,
                    SoNha = benhAn.ThongTinBn.SoNha,
                    Thon = benhAn.ThongTinBn.Thon,
                    NoiLamViec = benhAn.ThongTinBn.NoiLamViec,
                    Gtbhytdn = benhAn.ThongTinBn.Gtbhytdn,
                    SoTheBhyt = benhAn.ThongTinBn.SoTheBhyt,
                    LienHe = benhAn.ThongTinBn.LienHe,
                    SoDienThoai = benhAn.ThongTinBn.SoDienThoai,
                    HoTenCha = benhAn.ThongTinBn.HoTenCha,
                    HoTenMe = benhAn.ThongTinBn.HoTenMe,
                    NguoiGiamHo = benhAn.ThongTinBn.NguoiGiamHo,
                    GiayCnkhuyetTat = benhAn.ThongTinBn.GiayCnkhuyetTat,
                    DangKhuyetTat = benhAn.ThongTinBn.DangKhuyetTat,
                    MucDoKhuyetTat = benhAn.ThongTinBn.MucDoKhuyetTat,
                    NgheNghiepNguoiGiamHo = benhAn.ThongTinBn.NgheNghiepNguoiGiamHo,
                    QuanHeNguoiGiamHo = benhAn.ThongTinBn.QuanHeNguoiGiamHo,
                    Cmnd = benhAn.ThongTinBn.Cmnd,
                    NoiCapCmnd = benhAn.ThongTinBn.NoiCapCmnd,
                    NgayCapCmnd = benhAn.ThongTinBn.NgayCapCmnd,
                    NgheNghiep = new DmngheNghiepDto()
                    {
                        MaNn = benhAn.ThongTinBn.DmngheNghiep.MaNn,
                        TenNn = benhAn.ThongTinBn.DmngheNghiep.TenNn
                    },
                    DanToc = new DmdanTocDto()
                    {
                        MaDanToc = benhAn.ThongTinBn.DmdanToc.MaDanToc,
                        TenDanToc = benhAn.ThongTinBn.DmdanToc.TenDanToc,
                        MaQl = benhAn.ThongTinBn.DmdanToc.MaQl
                    },
                    QuocGia = new DmquocGiaDto()
                    {
                        MaQg = benhAn.ThongTinBn.DmquocGia.MaQg,
                        TenQg = benhAn.ThongTinBn.DmquocGia.TenQg
                    },
                    Tinh = new DmtinhDto()
                    {
                        MaTinh = benhAn.ThongTinBn.Dmtinh.MaTinh,
                        TenTinh = benhAn.ThongTinBn.Dmtinh.TenTinh
                    },
                    QuanHuyen = new DmquanHuyenDto()
                    {
                        MaQh = benhAn.ThongTinBn.DmquanHuyen.MaQh,
                        TenQh = benhAn.ThongTinBn.DmquanHuyen.TenQh,
                        MaBhxh = benhAn.ThongTinBn.DmquanHuyen.MaBhxh
                    },
                    PhuongXa = new DmphuongXaDto()
                    {
                        MaPxa = benhAn.ThongTinBn.DmphuongXa.MaPxa,
                        TenPxa = benhAn.ThongTinBn.DmphuongXa.TenPxa,
                        MaBhxh = benhAn.ThongTinBn.DmphuongXa.MaBhxh
                    },
                    DoiTuong = new DmdoiTuongDto()
                    {
                        MaDt = benhAn.ThongTinBn.DmdoiTuong.MaDt,
                        TenDt = benhAn.ThongTinBn.DmdoiTuong.TenDt
                    }
                },
                Buong = new DmkhoaBuongDto()
                {
                    MaBuong = benhAn.DmkhoaBuong.MaBuong,
                    TenBuong = benhAn.DmkhoaBuong.TenBuong
                },
                Giuong = new DmkhoaGiuongDto()
                {
                    MaGiuong = benhAn.DmkhoaGiuong.MaGiuong,
                    TenGiuong = benhAn.DmkhoaGiuong.TenGiuong
                },
                LoaiBenhAn = new DmbaLoaiBaDto()
                {
                    MaLoaiBa = benhAn.DmbaLoaiBa.MaLoaiBa,
                    TenLoaiBa = benhAn.DmbaLoaiBa.TenLoaiBa
                },
                Khoa = new DmkhoaDto()
                {
                    MaKhoa = benhAn.Dmkhoa.MaKhoa,
                    TenKhoa = benhAn.Dmkhoa.TenKhoa
                },
                BenhTatNoiChuyenDen = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhTatNoiChuyenDen.MaBenh,
                    TenBenh = benhAn.DmBenhTatNoiChuyenDen.TenBenh
                },
                BenhKKBYHHD = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhKKBYHHD.MaBenh,
                    TenBenh = benhAn.DmBenhKKBYHHD.TenBenh
                },
                BenhChinhVv = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhChinhVV.MaBenh,
                    TenBenh = benhAn.DmBenhChinhVV.TenBenh
                },
                BenhKemVV1 = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhKemVV1.MaBenh,
                    TenBenh = benhAn.DmBenhKemVV1.TenBenh
                },
                BenhKemVV2 = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhKemVV2.MaBenh,
                    TenBenh = benhAn.DmBenhKemVV2.TenBenh
                },
                BenhKemVV3 = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhKemVV3.MaBenh,
                    TenBenh = benhAn.DmBenhKemVV3.TenBenh
                },
                BenhChinhRv = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhChinhRV.MaBenh,
                    TenBenh = benhAn.DmBenhChinhRV.TenBenh
                },
                BenhKemRV1 = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhKemRV1.MaBenh,
                    TenBenh = benhAn.DmBenhKemRV1.TenBenh
                },
                //BenhNoiChuyenDenYHCT = new DmbenhTatYhctDto()
                //{
                //    MaBenhIcd = benhAn.DmBenhNoiChuyenDenYHCT.MaBenhIcd,
                //    TenBenh = benhAn.DmBenhNoiChuyenDenYHCT.TenBenhIcd
                //},
                //BenhKemVV1YHCT = new DmbenhTatYhctDto()
                //{
                //    MaBenh = benhAn.DmBenhKemVV1YHCT.MaBenhIcd,
                //    TenBenh = benhAn.DmBenhKemVV1YHCT.TenBenhIcd
                //},
                //BenhKemVV2YHCT = new DmbenhTatYhctDto()
                //{
                //    MaBenh = benhAn.DmBenhKemVV2YHCT.MaBenhIcd,
                //    TenBenh = benhAn.DmBenhKemVV2YHCT.TenBenhIcd
                //},
                //BenhKemVV3YHCT = new DmbenhTatYhctDto()
                //{
                //    MaBenh = benhAn.DmBenhKemVV3YHCT.MaBenhIcd,
                //    TenBenh = benhAn.DmBenhKemVV3YHCT.TenBenhIcd
                //},
                //BenhKemRv1yhct = new DmbenhTatYhctDto()
                //{
                //    MaBenh = benhAn.DmBenhKemRV1YHCT.MaBenhIcd,
                //    TenBenh = benhAn.DmBenhKemRV1YHCT.TenBenhIcd
                //},
                Giamdoc = new DmnhanVienDto()
                {
                    HoTen = benhAn.DmGiamdoc.HoTen,
                    MaNv = benhAn.DmGiamdoc.MaNv
                },
                TruongKhoa = new DmnhanVienDto()
                {
                    HoTen = benhAn.DmTruongKhoa.HoTen,
                    MaNv = benhAn.DmTruongKhoa.MaNv
                },
                BsDieutri = new DmnhanVienDto()
                {
                    HoTen = benhAn.DmBsDieutri.HoTen,
                    MaNv = benhAn.DmBsDieutri.MaNv
                },
                BenhGPTuThis = new DmbenhTatDto()
                {
                    MaBenh = benhAn.DmBenhGPTuThi.MaBenh,
                    TenBenh = benhAn.DmBenhGPTuThi.TenBenh
                },
                XacNhanKetThucHs = benhAn.XacNhanKetThucHs,
                NgayXacNhanKetThucHs = benhAn.NgayXacNhanKetThucHs,
                NguoiXacNhanKetThucHs = benhAn.NguoiXacnhanKetThucHs,
            });
            var result = queryBenhAnDetail.FirstOrDefault();
            var benhanYhctShort = query.Select(benhAn => new
            {
                BenhNoiChuyenDenYHCT = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhNoiChuyenDenYHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhNoiChuyenDenYHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhNoiChuyenDenYHCT.TenBenh,
                    MaBenh = benhAn.DmBenhNoiChuyenDenYHCT.MaBenh
                },
                BenhKemVV1YHCT = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKemVV1YHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKemVV1YHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKemVV1YHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKemVV1YHCT.MaBenh
                },
                BenhKemVV2YHCT = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKemVV2YHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKemVV2YHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKemVV2YHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKemVV2YHCT.MaBenh
                },
                BenhKemVV3YHCT = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKemVV3YHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKemVV3YHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKemVV3YHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKemVV3YHCT.MaBenh
                },
                BenhKemRv1yhct = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKemRV1YHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKemRV1YHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKemRV1YHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKemRV1YHCT.MaBenh
                },
                BenhKemRv2yhct = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKemRV2YHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKemRV2YHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKemRV2YHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKemRV2YHCT.MaBenh
                },
                BenhKemRv3yhct = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKemRV3YHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKemRV3YHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKemRV3YHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKemRV3YHCT.MaBenh
                },
                BenhKKBYHCT = new DmbenhTatYhctDto()
                {
                    MaBenhIcd = benhAn.DmBenhKKBYHCT.MaBenhIcd,
                    TenBenhIcd = benhAn.DmBenhKKBYHCT.TenBenhIcd,
                    TenBenh = benhAn.DmBenhKKBYHCT.TenBenh,
                    MaBenh = benhAn.DmBenhKKBYHCT.MaBenh
                },
                BenhKemRV2 = new DmbenhTatDto()
                {
                    TenBenh = benhAn.DmBenhKemRV2.TenBenh,
                    MaBenh = benhAn.DmBenhKemRV2.MaBenh,
                },
                BenhKemRV3 = new DmbenhTatDto()
                {
                    TenBenh = benhAn.DmBenhKemRV3.TenBenh,
                    MaBenh = benhAn.DmBenhKemRV3.MaBenh,
                },
            }).FirstOrDefault();
            result.BenhNoiChuyenDenYHCT = benhanYhctShort != null ? benhanYhctShort.BenhNoiChuyenDenYHCT : new DmbenhTatYhctDto();
            result.BenhKemVV1YHCT = benhanYhctShort != null ? benhanYhctShort.BenhKemVV1YHCT : new DmbenhTatYhctDto();
            result.BenhKemVV2YHCT = benhanYhctShort != null ? benhanYhctShort.BenhKemVV2YHCT : new DmbenhTatYhctDto();
            result.BenhKemVV3YHCT = benhanYhctShort != null ? benhanYhctShort.BenhKemVV3YHCT : new DmbenhTatYhctDto();
            result.BenhKemRv1yhct = benhanYhctShort != null ? benhanYhctShort.BenhKemRv1yhct : new DmbenhTatYhctDto();
            result.BenhKemRv2yhct = benhanYhctShort != null ? benhanYhctShort.BenhKemRv2yhct : new DmbenhTatYhctDto();
            result.BenhKemRv3yhct = benhanYhctShort != null ? benhanYhctShort.BenhKemRv3yhct : new DmbenhTatYhctDto();
            result.BenhKKBYHCT = benhanYhctShort != null ? benhanYhctShort.BenhKKBYHCT : new DmbenhTatYhctDto();
            result.BenhKemRV2 = benhanYhctShort != null ? benhanYhctShort.BenhKemRV2 : new DmbenhTatDto();
            result.BenhKemRV3 = benhanYhctShort != null ? benhanYhctShort.BenhKemRV3 : new DmbenhTatDto();

            return result;
        }

        public object GetLoaiBA(decimal id)
        {
            var data = _benhAnRepository.Table.Include(x => x.DmbaLoaiBa).Where(x => x.Idba == id).FirstOrDefault();
            if (data == null)
            {
                return data;
            }
            return new
            {
                ma = data.LoaiBa,
                tenLoaiBA = data.DmbaLoaiBa.TenLoaiBa
            };
        }
        public BenhAn Show(decimal id)
        {
            var data = _benhAnRepository.Table.First(x => x.Idba == id);
            return data;
        }
        public void Store(BenhAn benhAn)
        {
            benhAn.Idba = (_benhAnRepository.Table.Max(x => (decimal?)x.Idba) ?? 0) + 1;
            _benhAnRepository.Insert(benhAn);
        }
        public void Update(decimal id, BenhAn benhAn)
        {
            _benhAnRepository.Update(benhAn, id);
        }

        public void ThongTinBnCreate(BenhAnDetailDto benhAn)
        {
            benhAn.Idba = (_benhAnRepository.Table.Max(x => (decimal?)x.Idba) ?? 0) + 1;
            benhAn.MaBv = "01062";
            // benhAn.MaBvChuyenDen = "01062";
            benhAn.TenBv = "Bệnh viện YHCT Bộ Công An";
            benhAn.TenDvcq = "Bộ Công An";
            if (benhAn.Khoa != null)
            {
                benhAn.MaKhoaVv = benhAn.Khoa.MaKhoa;
            }
            _benhAnRepository.Insert<BenhAnDetailDto>(benhAn, (model) =>
            {
                model.BsdieuTri = benhAn?.BsDieutri?.MaNv;
                if (benhAn.BenhNhan != null)
                {
                    var infoBn = new ThongTinBn();
                    model.MaBn = benhAn.BenhNhan.MaBn;
                    MapEntityHelper.MapEntity<ThongTinBn, BenhAnDetailThongTinBnDto>(infoBn, benhAn.BenhNhan);
                    infoBn.Idba = model.Idba;
                    infoBn.MaNgheNghiep = benhAn.BenhNhan.NgheNghiep.MaNn;
                    infoBn.MaDanToc = benhAn.BenhNhan.DanToc.MaDanToc;
                    infoBn.MaQuocTich = benhAn.BenhNhan.QuocGia.MaQg;
                    infoBn.MaTinh = benhAn.BenhNhan.Tinh.MaTinh;
                    infoBn.MaHuyen = benhAn.BenhNhan.QuanHuyen.MaQh;
                    infoBn.MaPxa = benhAn.BenhNhan.PhuongXa.MaPxa;
                    infoBn.DoiTuong = benhAn.BenhNhan.DoiTuong.MaDt;
                    _benhAnRepository._context.ThongTinBn.Add(infoBn);
                    _benhAnRepository.Log<ThongTinBn>(ActionLogType.Create, infoBn);
                }
                if (benhAn.LoaiBenhAn != null)
                {
                    model.LoaiBa = benhAn.LoaiBenhAn.MaLoaiBa;
                }
                if (benhAn.Buong != null)
                {
                    model.Buong = benhAn.Buong.MaBuong;
                }
                if (benhAn.Giuong != null)
                {
                    model.Giuong = benhAn.Giuong.MaGiuong;
                }
                var benhAnKhoaDieuTri = new BenhAnKhoaDieuTri();
                benhAnKhoaDieuTri.Stt = 1;
                benhAnKhoaDieuTri.Idba = model.Idba;
                benhAnKhoaDieuTri.MaKhoa = model.MaKhoaVv;
                benhAnKhoaDieuTri.MaBa = model.MaBa;
                benhAnKhoaDieuTri.MaBn = benhAn?.BenhNhan?.MaBn ?? "";
                benhAnKhoaDieuTri.NgayVaoKhoa = model.NgayVv;
                benhAnKhoaDieuTri.Buong = model.Buong;
                benhAnKhoaDieuTri.Giuong = model.Giuong;
                benhAnKhoaDieuTri.BsdieuTri = benhAn?.BsDieutri?.MaNv != null ? benhAn?.BsDieutri?.MaNv : "";
                _benhAnRepository._context.BenhAnKhoaDieuTri.Add(benhAnKhoaDieuTri);
                _benhAnRepository.Log<BenhAnKhoaDieuTri>(ActionLogType.Create, benhAnKhoaDieuTri);
            });
        }

        public void ThongTinBnUpdate(BenhAnDetailDto benhAn, decimal idba, bool withoutPermission = false)
        {
            //Update KhoaDieuTri


            _benhAnRepository.Update<BenhAnDetailDto>(benhAn, (model) =>
            {
                if (!withoutPermission)
                {
                    PermissionThrowHelper.DongBenhAnCheck(model.XacNhanKetThucHs);
                }
                model.GiamDoc = benhAn?.Giamdoc?.MaNv;
                model.TruongKhoa = benhAn?.TruongKhoa?.MaNv;
                model.BsdieuTri = benhAn?.BsDieutri?.MaNv;
                var khoaDieuTri = _benhAnRepository._context.BenhAnKhoaDieuTri.FirstOrDefault(x => x.Idba == model.Idba && x.Stt == 1);
                //_benhAnRepository._context.Entry(khoaDieuTri).State = EntityState.Detached;

                if (benhAn.Khoa != null)
                {
                    model.MaKhoaVv = benhAn.Khoa.MaKhoa;
                }
                if (benhAn.LoaiBenhAn != null)
                {
                    model.LoaiBa = benhAn.LoaiBenhAn.MaLoaiBa;
                }
                if (benhAn.Buong != null)
                {
                    model.Buong = benhAn.Buong.MaBuong;
                }
                if (benhAn.Giuong != null)
                {
                    model.Giuong = benhAn.Giuong.MaGiuong;
                }
                if (benhAn.BenhNhan != null)
                {
                    model.MaBn = benhAn.BenhNhan.MaBn;
                    var infoBn = _benhAnRepository._context.ThongTinBn.FirstOrDefault(x => x.Idba == model.Idba);
                    infoBn = MapEntityHelper.MapEntity<ThongTinBn, BenhAnDetailThongTinBnDto>(infoBn, benhAn.BenhNhan);
                    infoBn.MaNgheNghiep = benhAn.BenhNhan.NgheNghiep.MaNn;
                    infoBn.MaDanToc = benhAn.BenhNhan.DanToc.MaDanToc;
                    infoBn.MaQuocTich = benhAn.BenhNhan.QuocGia.MaQg;
                    infoBn.MaTinh = benhAn.BenhNhan.Tinh.MaTinh;
                    infoBn.MaHuyen = benhAn.BenhNhan.QuanHuyen.MaQh;
                    infoBn.MaPxa = benhAn.BenhNhan.PhuongXa.MaPxa;
                    infoBn.DoiTuong = benhAn.BenhNhan.DoiTuong.MaDt;
                    infoBn.GioiTinh = benhAn.BenhNhan.GioiTinh;

                    _benhAnRepository.Log<ThongTinBn>(ActionLogType.Modify, infoBn);
                }
                if (khoaDieuTri != null)
                {
                    //khoaDieuTri.MaKhoa = model.MaKhoaVv;
                    //khoaDieuTri.MaBa = model.MaBa;
                    //khoaDieuTri.MaBn = model.MaBn;
                    //khoaDieuTri.NgayVaoKhoa = model.NgayVv;
                    //khoaDieuTri.Buong = model.Buong;
                    //khoaDieuTri.Giuong = model.Giuong;
                    //khoaDieuTri.BsdieuTri = model.BsdieuTri != null ? model.BsdieuTri : "";
                    //_benhAnRepository.Log<BenhAnKhoaDieuTri>(ActionLogType.Modify, khoaDieuTri);
                    //HanlderCreateUpdate<BenhAnKhoaDieuTri, BenhAnKhoaDieuTri>(khoaDieuTri, null, true, khoaDieuTri.Idba, khoaDieuTri.Stt);
                    //_benhAnRepository._context.Entry(khoaDieuTri).State = EntityState.Modified;
                }
            }, idba);
        }

        public void ThongTinToBenhAnCreateUpdate(ToBenhAnVM info, decimal idba)
        {
            _benhAnRepository.setLogActionName("Tờ bệnh án");
            _benhAnRepository.Update(info.benhAn, (model) =>
            {
                PermissionThrowHelper.DongBenhAnCheck(model.XacNhanKetThucHs);
                // BenhAnKhamYhct
                info.BenhAnKhamYhct.Idba = model.Idba;
                info.BenhAnKhamYhct.MaBa = model.MaBa;
                info.BenhAnKhamYhct.MaBn = model.MaBn;
                // BenhAnKhamYhhd
                info.BenhAnKhamYhhd.Idba = model.Idba;
                info.BenhAnKhamYhhd.MaBa = model.MaBa;
                info.BenhAnKhamYhhd.MaBn = model.MaBn;
                // BenhAnTongKetBenhAn
                info.BenhAnTongKetBenhAn.Idba = model.Idba;
                info.BenhAnTongKetBenhAn.MaBa = model.MaBa;
                info.BenhAnTongKetBenhAn.MaBn = model.MaBn;
                // BenhAnKhoaDieuTri
                info.BenhAnKhoaDieuTri.Idba = model.Idba;
                info.BenhAnKhoaDieuTri.MaBn = model.MaBn;
                info.BenhAnKhoaDieuTri.MaBa = model.MaBa;
                //info.BenhAnKhoaDieuTri.MaKhoa = model.MaKhoaVv;
                //info.BenhAnKhoaDieuTri.NgayVaoKhoa = model.NgayVv;
                //BenhAnTienSuBenh
                info.BenhAnTienSuBenh.Idba = model.Idba;
                info.BenhAnTienSuBenh.MaBn = model.MaBn;
                info.BenhAnTienSuBenh.MaBa = model.MaBa;
                if (info.BenhAnKhoaDieuTri.Stt == null)
                {
                    info.BenhAnKhoaDieuTri.Stt = 1;
                }
                var kdt = _benhAnRepository._context.BenhAnKhoaDieuTri.FirstOrDefault(x => x.Idba == idba && x.Stt == info.BenhAnKhoaDieuTri.Stt);
                if (kdt != null)
                {
                    info.BenhAnKhoaDieuTri.MaKhoa = kdt.MaKhoa;
                    info.BenhAnKhoaDieuTri.NgayVaoKhoa = kdt.NgayVaoKhoa;
                }

                HanlderCreateUpdate<BenhAnKhamYhct, BenhAnKhamYhctVM>(info.BenhAnKhamYhct, null, false, info.BenhAnKhamYhct.Idba);
                HanlderCreateUpdate<BenhAnKhamYhhd, BenhAnKhamYhhdVM>(info.BenhAnKhamYhhd, null, false, info.BenhAnKhamYhhd.Idba);
                HanlderCreateUpdate<BenhAnTienSuBenh, BenhAnTienSuBenhVM>(info.BenhAnTienSuBenh, null, false, info.BenhAnTienSuBenh.Idba);
                HanlderCreateUpdate<BenhAnTongKetBenhAn, BenhAnTongKetBenhAnVM>(info.BenhAnTongKetBenhAn, null, false, info.BenhAnTongKetBenhAn.Idba);
                HanlderCreateUpdate<BenhAnKhoaDieuTri, ToBenhAnBenhAnKhoaDieuTriVM>(info.BenhAnKhoaDieuTri, null, true, info.BenhAnKhoaDieuTri.Idba, info.BenhAnKhoaDieuTri.Stt);
                // save benhan
                model.MaBenhChinhVv = info.BenhAnKhoaDieuTri?.MaBenhChinhVk;
                model.MaBenhKemVv1 = info.BenhAnKhoaDieuTri?.MaBenhKemVk1;
                model.MaBenhKemVv2 = info.BenhAnKhoaDieuTri?.MaBenhKemVk2;
                model.MaBenhKemVv3 = info.BenhAnKhoaDieuTri?.MaBenhKemVk3;
                model.BsdieuTri = info.BenhAnTongKetBenhAn?.BsdieuTri;
            }, idba);
        }
        public void Destroy(decimal idba)
        {
            _benhAnRepository.setLogActionName("Bệnh án");
            _benhAnRepository.Delete((model) => {
                PermissionThrowHelper.DongBenhAnCheck(model.XacNhanKetThucHs);
            }, idba);
        }

        private void HanlderCreateUpdate<T, Tb>(Tb info, Action<T> callback = null, bool withoutInsert = false, params object[] id) where T : class
        {
            // need to fix
            // var response = new GenericRepository<T>(_context, _benhAnRepository._context);
            var response = new GenericRepository<T>(_context);
            try
            {
                response.UpdateWithoutTransaction<Tb>(info, callback, id);
            }
            catch (Exception ex)
            {
                if (withoutInsert == false)
                {
                    if (ex is HttpStatusException httpException)
                    {
                        response.InsertWithoutTransaction<Tb>(info, callback);
                    }
                }
            }
        }
        public string Print(decimal idba)
        {
            var benhAn = Detail(idba);

            var template = "";

            switch (benhAn.LoaiBenhAn.MaLoaiBa)
            {
                case 1:
                    template = "Benhan_YHCT_noi_tru-cp.docx";
                    break;
                case 2:
                    // code block
                    template = "Benhan_YHCT_ngoai_tru_v1.docx";
                    break;
                case 3:
                    template = "Benh_an_YHCT_man_tinh.docx";
                    break;
                case 4:
                    template = "Benhan_YHCT_noi_tru_theo_ngay.docx";
                    break;
                //break;
                default:
                    // code block
                    throw new HttpStatusException(HttpStatusCode.UnsupportedMediaType, "Chưa hỗ trợ");
            }

            var benhAnKhoaDieuTriService = new BenhAnKhoaDieuTriService();
            //benhAnKhoaDieuTri
            var benhAnKhoaDieuTris = benhAnKhoaDieuTriService.Get(new BenhAnKhoaDieuTriParameters()
            {
                Idba = idba
            }).data.OrderBy(x => x.Stt).ToList();
            var benhAnKhoaDieuTri = benhAnKhoaDieuTris.Count > 0 ? benhAnKhoaDieuTris[0] : null;
            //benhanKhamVV
            var phieukhamvv = _benhAnRepository._context.BenhAnKhamVaoVien.Where(
                x => x.Idba == idba
            ).FirstOrDefault();
            phieukhamvv = phieukhamvv ?? new BenhAnKhamVaoVien();
            //benhanTienSuBenh
            var tienSuBenh = _benhAnRepository._context.BenhAnTienSuBenh.FirstOrDefault(x => x.Idba == idba);
            tienSuBenh = tienSuBenh ?? new BenhAnTienSuBenh();
            //benhanYHCT
            var benhanYHHD = _benhAnRepository._context.BenhAnKhamYhhd.Include(x => x.DmBskham).Include(x => x.DmBenhPhanBiet).FirstOrDefault(x => x.Idba == idba);
            benhanYHHD = benhanYHHD ?? new BenhAnKhamYhhd();
            //benhanYHCT
            Mapper.CreateMap<BenhAnKhamYhctDto, BenhAnKhamYhct>().ReverseMap();
            Mapper.CreateMap<DmbenhTatYhctDto, DmbenhTatYhct>().ReverseMap();
            var benhanYHCT = _benhAnRepository._context.BenhAnKhamYhct.Include(x => x.DmBenhDanhTheoYHCT).Select(Mapper.Map<BenhAnKhamYhctDto>).FirstOrDefault(x => x.Idba == idba);
            benhanYHCT = benhanYHCT ?? new BenhAnKhamYhctDto();
            //TongKetBenhAn
            Mapper.CreateMap<BenhAnTongKetBenhAnDto, BenhAnTongKetBenhAn>().ReverseMap();
            Mapper.CreateMap<DmnhanVienDto, DmnhanVien>().ReverseMap();
            var tongKetBenhAn = _benhAnRepository._context.BenhAnTongKetBenhAn
                .Include(x => x.DmBsDieutri)
                .Include(x => x.DmNguoiGiao)
                .Include(x => x.DmNguoiNhan)
                .Select(Mapper.Map<BenhAnTongKetBenhAnDto>)
                .FirstOrDefault(x => x.Idba == idba);
            tongKetBenhAn = tongKetBenhAn ?? new BenhAnTongKetBenhAnDto();

            List<string> fields = new List<string>(){
                "BenhVien",
                "Khoa",
                "Buong",
                "SoVVien",
                "SoLuuTru",
                "MaNgBenh",
                "MaNB",
                "MaYTe",
                "HoVaTen",
                "DanToc",
                "NgheNghiep",
                "QuocTich",
                "SoNha",
                "Thon",
                "Xa",
                "Huyen",
                "Tinh",
                "NoiLamViec",
                "GiaTriBaoHiemYTe",
                "LienHe",
                "SoDienThoai",
                "Nam",
                "Nu",
                "VaoVienGioPhut",
                "VaoVienNgayThang",
                "ChuyenDen",
                "RaVienGioPhut",
                "RaVienNgayThang",
                "NoiChuyenDenYHHD",
                "BenhChinhYHHD",
                "BenhKemTheoYHHD_1",
                "BenhKemTheoYHHD_2",
                "BenhKemTheoYHHD_3",
                "ThuThuatYHHD",
                "PhauThuatYHHD",
                "RaVienBenhChinhYHHD",
                "RaVienBenhKemTheoYHHD",
                "RaVienTaiBien",
                "RaVienBienChung",
                "NoiChuyenDenYHCT",
                "BenhChinhYHCT",
                "BenhKemTheoYHCT_1",
                "BenhKemTheoYHCT_2",
                "BenhKemTheoYHCT_3",
                "ThuThuatYHCT",
                "PhauThuatYHCT",
                "RaVienTaiBien",
                "RaVienBienChung",
                "RaVienBenhChinhYHCT",
                "RaVienBenhKemTheoYHCT",
                "GiamDoc",
                "TruongKhoa",
                "BsKhamBenh",
                "LyDoVaoVien",
                "BenhSu",
                "BanThan",
                "DacDiem",
                "GiaDinh",
                "ToanThan",
                // bang mach
                "mach",
                "nhietdo",
                "huyetap",
                "nhiptho",
                "cannang",
                "chieucao",
                "bmi",
                "TuanHoan",
                "HoHap",
                "TieuHoa",
                "TietNieu",
                "ThanKinh",
                "CoXuongKhop",
                "TaiMuiHong",
                "RangHamMat",
                "Mat",
                "NoiTiet",
                "TomTatCls",
                "TomTatBenhAn",
                "BenhKemTheoYHHD",
                "PhanBiet",
                "VongChan",
                "VanChan",
                "VaanChan",
                "XuaChan",
                "MachTayTrai",
                "MachTayPhai",
                "TomTatTuChuan",
                "BienChuong",
                "BenhDanh",
                "BatCuong",
                "NguyenNhan",
                "TangPhu",
                "KinhMach",
                "DinhViBenh",
                "PhapDieuTri",
                "PhuongDuoc",
                "KhongDungThuoc",
                "HuongDieuTri",
                "DuHau",
                "TongKetLyDoVaoVien",
                "TongKetQuaTrinhBenh",
                "KetQuaXetNghiemCanLamSang",
                "TinhTrangRaVien",
                "HuongDieuTriCheDoTiep",
                "TongKetBenhAnPPDTYHHD",
                "TongKetBenhAnPPDTYHCT",
                "VongChanMTKhac",
                "VanChanMoTaKhac",
                "VaanChanMTKhac",
                "ThietChanMTKhac",
                "PhuongPhapDieuTriKhongDungThuoc",
                "PhuongPhapKhac",
                "YHocHienDai",
                "NgayTuVong",
                "NguyenNhanTuVong",
                "KhamNghiemTuThi",
                "ChanDoanGiaiPhauTuThi",
				/*tổng kết bệnh án*/
				"soTongKetXQuang",
                "soTongKetCT",
                "soTongKetMRI",
                "soToSieuAm",
                "soToXetNghiem",
                "tongKetKhac",
                "soTongKetKhac",
                "soTongKetToanHoSo",
                "HoTenNguoiGiao",
                "HoTenNhan",
                "HoTenThay",
                "NgayThangTongKet",
                "soToSieuAm",
                "soToXetNghiem",
				/*thông tin chung bệnh án*/
                "NgayKy",
                "NgayGioLamBenh",
                "ThayThuocLamBenh",
                "BenhChinh",
                "VaoVienLanThu",
                "NgayThang",
                "KhoaKhamBenhYHCT",
                "KhoaKhamBenhYHHD",
                "MoTa",
                //yhct
                "MoTaKhac",
                "MoTaKhac2",
                "MoTaKhac3",
                "XucChan",
                "TangPhu",
                "KinhMach"
            };
            List<string> values = new List<string>(){
                PrintSetting.BenhVien,
                benhAn?.Khoa?.TenKhoa,
                benhAn?.Buong?.TenBuong,
                benhAn?.SoVaoVien,
                benhAn?.SoLuuTru,
                benhAn?.BenhNhan?.MaBn,
                benhAn?.BenhNhan?.MaBn,
                benhAn?.MaYt,
                benhAn?.BenhNhan?.HoTen?.ToUpper(),
                benhAn?.BenhNhan?.DanToc?.TenDanToc,
                benhAn?.BenhNhan?.NgheNghiep?.TenNn,
                benhAn?.BenhNhan?.QuocGia?.TenQg,
                benhAn?.BenhNhan?.SoNha,
                benhAn?.BenhNhan?.Thon,
                benhAn?.BenhNhan?.PhuongXa?.TenPxa,
                benhAn?.BenhNhan?.QuanHuyen?.TenQh,
                benhAn?.BenhNhan?.Tinh?.TenTinh,
                benhAn?.BenhNhan?.NoiLamViec,
                benhAn?.BenhNhan?.Gtbhytdn?.ToString("dd/MM/yyyy"),
                benhAn?.BenhNhan?.LienHe,
                benhAn?.BenhNhan?.SoDienThoai,
                benhAn?.BenhNhan?.GioiTinh == 1 ? "x" : null,
                benhAn?.BenhNhan?.GioiTinh == 2 ? "x": null,
                PrintHelper.TimeText(benhAn?.NgayVv),
                PrintHelper.DateText(benhAn?.NgayVv),
                benhAn?.benhVienChuyenDen?.TenBv,
                PrintHelper.TimeText(benhAn?.NgayRv),
                PrintHelper.DateText(benhAn?.NgayRv),
                benhAn?.BenhTatNoiChuyenDen?.TenBenh,
                !String.IsNullOrEmpty(benhAn?.TenBenhChinhVv) ? PrintHelper.Trimmer(benhAn?.TenBenhChinhVv) : PrintHelper.Trimmer(benhAn?.BenhChinhVv?.TenBenh),
                PrintHelper.Trimmer(benhAn?.BenhKemVV1?.TenBenh),
                PrintHelper.Trimmer(benhAn?.BenhKemVV2?.TenBenh),
                PrintHelper.Trimmer(benhAn?.BenhKemVV3?.TenBenh),
                benhAn?.ThuThuatYhhd == 1 ? "x" : "",
                benhAn?.PhauThuatYhhd == 1 ? "x" : "",
                PrintHelper.Trimmer(benhAn?.TenBenhChinhRv),
                PrintHelper.ConcatStringArr((object)"\n", PrintHelper.Trimmer(benhAn?.BenhKemRV1?.TenBenh), PrintHelper.Trimmer(benhAn?.BenhKemRV2?.TenBenh), PrintHelper.Trimmer(benhAn?.BenhKemRV3?.TenBenh)),
                benhAn?.TaiBienYhhd == 1 ? "x" : "",
                benhAn?.BienChungYhhd == 1 ? "x" : "",
                PrintHelper.Trimmer(benhAn?.BenhNoiChuyenDenYHCT?.TenBenhIcd),
                !String.IsNullOrEmpty(benhAn?.TenBenhChinhVvyhct) ? PrintHelper.Trimmer(benhAn?.TenBenhChinhVvyhct) : PrintHelper.Trimmer(benhAn?.BenhChinhVvyhct?.TenBenhIcd),
                PrintHelper.Trimmer(benhAn?.BenhKemVV1YHCT?.TenBenhIcd),
                PrintHelper.Trimmer(benhAn?.BenhKemVV2YHCT?.TenBenhIcd),
                PrintHelper.Trimmer(benhAn?.BenhKemVV3YHCT?.TenBenhIcd),
                benhAn?.ThuThuatYhct == 1 ? "x" : "",
                benhAn?.PhauThuatYhct == 1 ? "x" : "",
                benhAn?.TaiBienYhct == 1 ? "x" : "",
                benhAn?.BienChungYhct == 1 ? "x" : "",
                benhAn?.TenBenhChinhRvyhct,
                PrintHelper.ConcatStringArr((object)"\n", PrintHelper.Trimmer(benhAn?.BenhKemRv1yhct?.TenBenhIcd), PrintHelper.Trimmer(benhAn?.BenhKemRv2yhct?.TenBenhIcd), PrintHelper.Trimmer(benhAn?.BenhKemRv3yhct?.TenBenhIcd)),
                benhAn?.Giamdoc?.HoTen,
                benhAn?.TruongKhoa?.HoTen,
                benhAn?.BsDieutri?.HoTen,
                benhanYHHD?.LyDoVv,
                benhanYHHD?.BenhSu, //BenhSu
				tienSuBenh?.TienSuBanThan,
                tienSuBenh?.DacDiemLienQuanBenh, //DacDiem
				tienSuBenh?.TienSuGiaDinh,
                benhanYHHD?.ToanThan,
                benhanYHHD?.Mach?.ToString(),
                benhanYHHD?.NhietDo?.ToString(),
                benhanYHHD?.HuyetAp?.ToString(),
                benhanYHHD?.NhipTho?.ToString(),
                ((int?)benhanYHHD?.CanNang)?.ToString(),
                ((int?)benhanYHHD?.ChieuCao)?.ToString(),
                benhanYHHD?.Bmi?.ToString("0.00"),
                benhanYHHD?.TuanHoan,
                benhanYHHD?.HoHap,
                benhanYHHD?.TieuHoa,
                benhanYHHD?.ThanTnieuSduc, //TietNieu
				benhanYHHD?.ThanKinh,
                benhanYHHD?.XuongKhop,
                benhanYHHD?.TaiMuiHong,
                benhanYHHD?.RangHamMat,
                benhanYHHD?.Mat,
                benhanYHHD?.NoiTietDd,
                benhanYHHD?.CanLamSang,
                benhanYHHD?.TomTatBenhAn,
                "",//BenhKemTheoYHHD
				benhanYHHD?.DmBenhPhanBiet != null ? $"{benhanYHHD?.DmBenhPhanBiet?.MaBenh} - {benhanYHHD?.DmBenhPhanBiet?.TenBenh}" : "", //PhanBiet
				benhanYHCT?.MoTaVongChan,
                benhanYHCT?.MoTaVanChan,
                benhanYHCT?.MtvaanChan,
                benhanYHCT?.MtthietChan,
                benhanYHCT?.MachTrai,
                benhanYHCT?.MachPhai,
                benhanYHCT?.TomTatTuChan,
                benhanYHCT?.BienChungLuanTri,
                $"{benhanYHCT?.DmBenhDanhTheoYHCT?.MaBenh} - {benhanYHCT?.DmBenhDanhTheoYHCT?.TenBenh}",
                benhanYHCT?.BatCuong,
                benhanYHCT?.MoTaNguyenNhan,
                benhanYHCT?.MoTaTangPhu,
                benhanYHCT?.MoTaKinhMach,
                benhanYHCT?.MoTaDinhViBenhTheo,
                benhanYHCT?.Ppdtyhct,
                benhanYHCT?.PhuongDuoc,
                benhanYHCT?.PpdtkhongDungThuoc,
                benhanYHHD?.HuongDtyhhd, //Hướng điều trị
				benhanYHHD?.TienLuong, //Dư hậu,
				tongKetBenhAn?.LyDoVv,
                tongKetBenhAn?.QuaTrinhBenhLy,
                tongKetBenhAn?.TomTatKetQuaCls,
                tongKetBenhAn?.TinhTrangBnrv,
                tongKetBenhAn?.HuongDt,
                tongKetBenhAn?.PpdttheoYhhd,
                tongKetBenhAn?.PpdttheoYhct,
                benhanYHCT?.MoTaVongChan,
                benhanYHCT?.MtvaanChan,
                benhanYHCT?.MoTaVanChan,
                benhanYHCT?.MoTaXucChan,
                benhanYHCT?.PpdtkhongDungThuoc,
                benhanYHCT?.Ppkhac,
                benhanYHHD?.Ppdtyhhd,
                PrintHelper.DateTimeText(benhAn?.NgayTuVong),
                benhAn?.NguyenNhanTuVong,
                benhAn?.KhamNghiemTuThi == 1 ? "x" : "",
                benhAn?.BenhGPTuThis?.TenBenh,
                tongKetBenhAn?.SoToXquang?.ToString(),
                tongKetBenhAn?.SoToCt?.ToString(),
                tongKetBenhAn?.SoToMri?.ToString(),
                tongKetBenhAn?.SoToSa?.ToString(),
                tongKetBenhAn?.SoToXn?.ToString(),
                String.IsNullOrEmpty(tongKetBenhAn?.Khac) ? "Khác ...." : tongKetBenhAn?.Khac,
                tongKetBenhAn?.SoToKhac?.ToString(),
                tongKetBenhAn?.SoToToanBoHs?.ToString(),
                tongKetBenhAn?.DmNguoiGiao?.HoTen,
                tongKetBenhAn?.DmNguoiNhan?.HoTen,
                tongKetBenhAn?.DmBsDieutri?.HoTen,
                PrintHelper.DateText(tongKetBenhAn?.NgayKy),
                tongKetBenhAn?.SoToSa?.ToString(),
                tongKetBenhAn?.SoToXn?.ToString(),
                PrintHelper.DateText(benhAn?.NgayKy),
                //yhhd
                PrintHelper.DateTimeText(benhanYHHD?.NgayKham), //NgayGioLamBenh
				benhanYHHD?.DmBskham?.HoTen, //ThayThuocLamBenh
                PrintHelper.Trimmer(benhAn?.TenBenhChinhVv),
                benhAn?.Vvlan?.ToString(),
                PrintHelper.DateText(benhAn?.NgayKy),
                benhAn?.BenhKKBYHCT?.TenBenhIcd,
                benhAn?.BenhKKBYHHD?.TenBenh,
                tienSuBenh?.MoTaTienSu,
                //yhct
                //MoTaKhac
                benhanYHCT?.MoTaVongChan,
                benhanYHCT?.MoTaVanChan,
                benhanYHCT?.MtthietChan,
                benhanYHCT?.MoTaXucChan,
                benhanYHCT?.MoTaTangPhu,
                benhanYHCT?.MoTaKinhMach,
            };

            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNhan?.NgheNghiep?.MaNn, "Nghenghiep", 2, '0', true);
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNhan?.DanToc?.MaDanToc, "dantoc", 2, '0', true);
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNhan?.QuanHuyen?.MaBhxh, "huyen", 3, '0', true);
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNhan?.PhuongXa?.MaBhxh, "xaphuong", 5, '0', true);
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNhan?.Tinh?.MaTinh, "thanhpho", 2, '0', true);

            var combo_ds = _benhAnRepository._context.DmbaCombods.Where(x => maDsCombo.Contains(x.MaParent)).OrderBy(x => x.MaParent).ThenBy(x => x.Ma).ToList();
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, PrintHelper.BirthText(benhAn?.BenhNhan?.NgaySinh), "NgaySinh", 8, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNhan?.Tuoi?.ToString(), "Tuoi", 2, '0');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, PrintHelper.CompareTwoDate(benhAnKhoaDieuTri?.NgayVaoKhoa, benhAn.NgayRv, 1), "TongSoNgayDT", 2, '0');
            PrintHelper.TextboxFieldDoiTuongHanlder(ref fields, ref values, benhAn?.BenhNhan?.DoiTuong?.MaDt);
            PrintHelper.TextboxFieldBHYTHanlder(ref fields, ref values, benhAn?.BenhNhan?.SoTheBhyt, "Bhyt", false);
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "tructiepvao", benhAn?.TrucTiepVao, new string[] { "1", "2", "3" });
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "NoiGioiThieu", benhAn?.NoiGt, new string[] { "1", "2", "3" });
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "ChuyenVien", benhAn?.ChuyenVien, new string[] { "1", "2", "3" });
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "RaVien", benhAn?.HtraVien, new string[] { "1", "2", "3", "4" });
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhTatNoiChuyenDen?.MaBenh, "Noichuyenden", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKKBYHHD?.MaBenh, "KhoaKhamBenh", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.MaBenhChinhVv, "BenhChinh", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemVV1?.MaBenh, "BenhKemTheo_1", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemVV2?.MaBenh, "BenhKemTheo_2", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemVV3?.MaBenh, "BenhKemTheo_3", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.MaBenhChinhRv, "MaBenhChinhRv", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemRV1?.MaBenh, "RaVienBenhKemTheoYHHD_1", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemRV2?.MaBenh, "RaVienBenhKemTheoYHHD_2", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemRV3?.MaBenh, "RaVienBenhKemTheoYHHD_3", 5, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhNoiChuyenDenYHCT?.MaBenh, "NoichuyendenYHCT", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKKBYHCT?.MaBenh, "KhoaKhamBenhYHCT", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.MaBenhChinhVvyhct, "BenhChinhYHCT", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemVV1YHCT?.MaBenh, "BenhKemTheoYHCT_1", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemVV2YHCT?.MaBenh, "BenhKemTheoYHCT_2", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemVV3YHCT?.MaBenh, "BenhKemTheoYHCT_3", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.MaBenhChinhRvyhct, "RaVienBenhChinh", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhanYHCT?.DmBenhDanhTheoYHCT?.MaBenh, "ChanDoanBenhDanh", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemRv1yhct?.MaBenh, "RaVienBenhKeoTheo_1", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemRv2yhct?.MaBenh, "RaVienBenhKeoTheo_2", 6, ' ');
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhKemRv3yhct?.MaBenh, "RaVienBenhKeoTheo_3", 6, ' ');
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "KQDT", benhAn.Kqdt, new string[] { "1", "2", "3", "4", "5" });
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "KQDT_TK", tongKetBenhAn.Kqdt, 1, getDsCombo(combo_ds, "130"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanHinhThai", benhanYHCT.HinhThaiVongChan, 3, getDsCombo(combo_ds, "045"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanThan", benhanYHCT.ThanVongChan, 2, getDsCombo(combo_ds, "046"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanSac", benhanYHCT.SacVongChan, 3, getDsCombo(combo_ds, "047"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanTrach", benhanYHCT.TrachVongChan, 2, getDsCombo(combo_ds, "048"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanLuoi", benhanYHCT.HinhThaiLuoi, 2, getDsCombo(combo_ds, "049"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanChatLuoi", benhanYHCT.ChatLuoi, 3, getDsCombo(combo_ds, "050")); //old 6
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VongChuanReuLuoi", benhanYHCT.ReuLuoi, 3, getDsCombo(combo_ds, "051")); //old 6
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanAmThanhTiengNoi", benhanYHCT.GiongNoi, 5, getDsCombo(combo_ds, "056"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanAmThanhHoiTho", benhanYHCT.HoiTho, 5, getDsCombo(combo_ds, "057"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanCoAmThanhHo", PrintHelper.HanlderBooleanType(benhanYHCT.CoHo), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanAmThanhHo", benhanYHCT.Ho, 3, getDsCombo(combo_ds, "059"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanAmThanhO", PrintHelper.HanlderBooleanType(benhanYHCT.OamThanh), 1);
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanAmThanhNac", PrintHelper.HanlderBooleanType(benhanYHCT.NacAmThanh), 1);
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanCoMui", PrintHelper.HanlderBooleanType(benhanYHCT.CoMui), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanMui", benhanYHCT.KieuMui, 3, getDsCombo(combo_ds, "063"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanCoChatThai", PrintHelper.HanlderBooleanType(benhanYHCT.CoChatThaiBenhLy), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanChatThai", benhanYHCT.KieuChatThai, 3, getDsCombo(combo_ds, "065"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanCoHanNhiet", PrintHelper.HanlderBooleanType(benhanYHCT.BhhanNhiet), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanHanNhiet", benhanYHCT.Hannhiet, 3, getDsCombo(combo_ds, "067"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanMoHoi", benhanYHCT.MoHoi, 3, getDsCombo(combo_ds, "068"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanCoDauMatCo", PrintHelper.HanlderBooleanType(benhanYHCT.BhdauMatCo), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanDauMatCoDauDau", benhanYHCT.DauDau, 3, getDsCombo(combo_ds, "070"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanDauMatCoHoaMatChongMat", PrintHelper.HanlderBooleanType(benhanYHCT.HoaMat), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanDauMatCoMat", benhanYHCT.Mat, 3, getDsCombo(combo_ds, "072"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanDauMatCoTai", benhanYHCT.Tai, 3, getDsCombo(combo_ds, "073"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanDauMatCoMui", benhanYHCT.Mui, 3, getDsCombo(combo_ds, "074"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanDauMatCoHong", benhanYHCT.Hong, 3, getDsCombo(combo_ds, "075"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanDauMatCoCoVai", benhanYHCT.CoVai, 3, getDsCombo(combo_ds, "076"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanCoLung", PrintHelper.HanlderBooleanType(benhanYHCT.Bhlung), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanLung", benhanYHCT.Lung, 1, getDsCombo(combo_ds, "078"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanCoNguc", PrintHelper.HanlderBooleanType(benhanYHCT.Bhnguc), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanNguc", benhanYHCT.Nguc, 6, getDsCombo(combo_ds, "080"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanBung", PrintHelper.HanlderBooleanType(benhanYHCT.Bhbung), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanBung", benhanYHCT.Bung, 6, getDsCombo(combo_ds, "082"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChanChanTay", PrintHelper.HanlderBooleanType(benhanYHCT.BhchanTay), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChanChanTay", benhanYHCT.ChanTay, 6, getDsCombo(combo_ds, "084"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanAn", PrintHelper.HanlderBooleanType(benhanYHCT.Bhan), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanAn", benhanYHCT.An, 3, getDsCombo(combo_ds, "086"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanUong", PrintHelper.HanlderBooleanType(benhanYHCT.Bhuong), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanUong", benhanYHCT.Uong, 3, getDsCombo(combo_ds, "088"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanDaiTieuTien", PrintHelper.HanlderBooleanType(benhanYHCT.BhdaiTieuTien), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanTieuTien", benhanYHCT.TieuTien, 3, getDsCombo(combo_ds, "090"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanDaiTien", benhanYHCT.DaiTien, 3, getDsCombo(combo_ds, "091"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanNgu", PrintHelper.HanlderBooleanType(benhanYHCT.Bhngu), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanNgu", benhanYHCT.Ngu, 3, getDsCombo(combo_ds, "093"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanSinhSan", PrintHelper.HanlderBooleanType(benhanYHCT.RlknsinhDuc), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNam", benhanYHCT.Rlnam, 3, getDsCombo(combo_ds, "095"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNu", benhanYHCT.Rlnu, 3, getDsCombo(combo_ds, "096"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNuKinhNguyet", PrintHelper.HanlderBooleanType(benhanYHCT.Bhkn), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNuKinhNguyet", benhanYHCT.Rlkinhnguyet, 2, getDsCombo(combo_ds, "098"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNuThongKinh", benhanYHCT.ThongKinh, 2, getDsCombo(combo_ds, "099"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNuDoiHa", PrintHelper.HanlderBooleanType(benhanYHCT.BhdoiHa), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "VanChuanSinhSanNuDoiHa", benhanYHCT.DoiHa, 2, getDsCombo(combo_ds, "101"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "VanChuanLienQuan", PrintHelper.HanlderBooleanType(benhanYHCT.Dkxhbenh), 1);
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "ThietChuan", PrintHelper.HanlderBooleanType(benhanYHCT.BhxucChan), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanDa", benhanYHCT.XucChanDa, 3, getDsCombo(combo_ds, "105"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "ThietChuanCoXuong", PrintHelper.HanlderBooleanType(benhanYHCT.BhcoXuongKhop), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanCoXuong", benhanYHCT.XucChanCoXuongKhop, 3, getDsCombo(combo_ds, "107"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "ThietChuanBung", PrintHelper.HanlderBooleanType(benhanYHCT.BhbungXucChan), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanBung", benhanYHCT.XucChanBung, 3, getDsCombo(combo_ds, "109"));
            PrintHelper.OptionFieldMultipleHanlder(ref fields, ref values, "ThietChuanMoHoi", PrintHelper.HanlderBooleanType(benhanYHCT.BhmoHoi), 1);
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMoHoi", benhanYHCT.XucChanMoHoi, 3, getDsCombo(combo_ds, "111"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuan", benhanYHCT.MachChan, 3, getDsCombo(combo_ds, "112"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanTongKhamPhai", benhanYHCT.TongKhanPhai, 3, getDsCombo(combo_ds, "113"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanTongKhamTrai", benhanYHCT.TongKhanTrai, 3, getDsCombo(combo_ds, "114"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanViKhanTraiThon", benhanYHCT.ViKhanTraiThon, 3, getDsCombo(combo_ds, "115"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanViKhanTraiQuan", benhanYHCT.ViKhanTraiQuan, 3, getDsCombo(combo_ds, "116"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanViKhanTraiXich", benhanYHCT.ViKhanTraiXich, 3, getDsCombo(combo_ds, "117"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanViKhanPhaiThon", benhanYHCT.ViKhanPhaiThon, 3, getDsCombo(combo_ds, "118"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanViKhanPhaiQuan", benhanYHCT.ViKhanPhaiQuan, 3, getDsCombo(combo_ds, "119"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ThietChuanMachChuanViKhanPhaiXich", benhanYHCT.ViKhanPhaiXich, 3, getDsCombo(combo_ds, "120"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ChanDoanBatCuong", benhanYHCT.BhbatCuong, 5, getDsCombo(combo_ds, "121"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ChanDoanNguyenNhan", benhanYHCT.NguyenNhan, 1, getDsCombo(combo_ds, "122"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ChanDoanTangPhu", benhanYHCT.TangPhu, 4, getDsCombo(combo_ds, "123"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ChanDoanKinhMach", benhanYHCT.KinhMach, 4, getDsCombo(combo_ds, "124"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "ChanDoanDinhViBenh", benhanYHCT.DinhViBenhTheo, 4, getDsCombo(combo_ds, "125"));

            //tinh trang ra vien
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "TTRVKQDT", benhAn?.Kqdt, PrintHelper.CreateArrayIncreate(5));
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "GiaiPhauBenh", benhAn?.GiaiPhauBenh, PrintHelper.CreateArrayIncreate(3));
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "TTRVTTTV", benhAn?.TinhTrangTuVong, PrintHelper.CreateArrayIncreate(5));
            PrintHelper.OptionFieldHanlder(ref fields, ref values, "TTRVGPB", benhAn?.GiaiPhauBenh, PrintHelper.CreateArrayIncreate(3));
            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn?.BenhGPTuThis?.MaBenh, "ChuanDoanGiaiPhau", 5, ' ');


            PrintHelper.OptionFieldSyncMultipleHanlder(ref fields, ref values, "BanThan", tienSuBenh.MaTienSu, 4, getDsCombo(combo_ds, "017"));

            fields.Add("Khoa");
            fields.Add("VaoKhoaNgayGio");
            if (benhAnKhoaDieuTri != null)
            {
                values.Add(benhAnKhoaDieuTri.Khoa.TenKhoa);
                values.Add(PrintHelper.DateShortTimeText(benhAnKhoaDieuTri.NgayVaoKhoa));
            }
            else
            {
                values.Add("");
                values.Add("");
                values.Add("");
            }
            // to dieu tri
            var toDieuTriService = new BenhAnToDieuTriService();

            var dataset = new DataSet();
            var list = new List<DictionaryEntry>();
            if (benhAn.LoaiBenhAn.MaLoaiBa == 3)
            {
                ManTinhPrint(ref fields, ref values, benhAn, benhAnKhoaDieuTris, phieukhamvv, tienSuBenh, benhanYHHD, benhanYHCT, tongKetBenhAn, combo_ds);

            }
            else
            {
                for (int i = 1; i < benhAnKhoaDieuTris.Count; i++)
                {
                    fields.Add($"KhoaChuyen{i}");
                    values.Add(benhAnKhoaDieuTris[i].Khoa.TenKhoa);
                    fields.Add($"NgayGioKhoaChuyen{i}");
                    values.Add(PrintHelper.DateShortTimeText(benhAnKhoaDieuTris[i].NgayVaoKhoa));
                    var compareDate = i != (benhAnKhoaDieuTris.Count - 1) ? PrintHelper.CompareTwoDate(benhAnKhoaDieuTris[i].NgayVaoKhoa, benhAnKhoaDieuTris[i + 1].NgayVaoKhoa, 1) : PrintHelper.CompareTwoDate(benhAnKhoaDieuTris[i].NgayVaoKhoa, benhAn.NgayRv, 1);
                    
                    PrintHelper.TexboxFieldHanlder(ref fields, ref values, compareDate, $"MaKhoaChuyen{i}", 2, '0');
                }
            }
            string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, template, null, null, fields, values);
            return path;
        }
        //hanlder mãn tính 
        private void ManTinhPrint(ref List<string> fields, ref List<string> values, BenhAnDetailDto benhAn, List<BenhAnKhoaDieuTriDto> benhAnKhoaDieuTris, BenhAnKhamVaoVien phieukhamvv, BenhAnTienSuBenh tienSuBenh, BenhAnKhamYhhd benhanYHHD, BenhAnKhamYhct benhanYHCT, BenhAnTongKetBenhAn tongKetBenhAn, List<DmbaCombods> combo_ds)
        {
            List<string> field_more = new List<string>()
            {
                "SoYTe",
                "NgaySinh",
                "Tuoi",
                "DiaChi",
                "DoiTuong",
                "SoTheBHYT",
                "HinhThucRaVien",
                "NoiGioiThieu",
                "TongSoNgayDT",
                "TuyenDuoi",
                "CapCuuKhoaKhamBenh",
                "VaoKhoaBenhChinh",
                "VaoKhoaBenhKemTheo",
                "RaVienBenhChinh",
                "RaVienKemTheo",
                "BienChungTaiBien",
                "GiaiPhauBenh_MT",
                "KhamNghiemTuThiManTinh",
                "KetQuaDieuTriRV",
                "TinhHinhTuVong",
                "TinhHinhSauVaoVien",
                "SauPhauThuat",
                "HutThuocLa",
                "SoDieu",
                "SoBao",
                "UongRuou",
                "LuongUongRuou",
                "CacYeuToKhac",
                "BenhLyKhac",
                "BenhTangHuyetApPhatHienKhiNao",
                "BenhTangHuyetApTuDieuTriHoacDieuTriODau",
                "BenhTangHuyetApCoDieuTriThuongXuyenKhong",
                "BenhTangHuyetApDonTriLieuHayDaTriLieu",
                "ChiSoHA",
                "BenhDaiThaoDuongPhatHienKhiNao",
                "BenhDaiThaoDuongTuDieuTri",
                "BenhDaiThaoDuongDieuTriThuongXuyen",
                "BenhDaiThaoDuongDonTriLieuHayDaTriLieu",
                "ChiSoDuongHuyet",
                "BenhSu",
                "HA",
                "NhipTim",
                "ChieuCao",
                "CanNang",
                "ChiSoBMI",
                "TrieuChung",
                "KetQuaXetNghiemMau",
                "KetQuaXetNghiemNuocTieu",
                "KetQuaChanDoanHinhAnh",
                "ChanDoanXacDinh",
                "MoTaVongChan",
                "MoTaVanChan",
                "MoTaXucChan",
                "MachChanTayTrai",
                "MachChanTayPhai",
                "TomTatTuChan",
                "BienChungLuanTri",
                "BenhDanh",
                "BatCuong",
                "TangPhuKinhLac",
                "NguyenNhan",
                "DieuTriDonThuanYHCT",
                "PhapDieuTri",
                "PhuongThuoc",
                "PhuongHuyet",
                "XoaBopDamHuyet",
                "DieuTriKhac",
                "CoDieuTriKetHopYHHD",
                "DieuTriKetHopYHHD",
                "KetQuaDieuTri",
                "HuongDieuTriVaCacCheDoTiep",
                "NgayHenKhamLai",
                "NgayHenXetNghiemLai",
                "DuHauTL",
                "NgayKy_MT"
            };
            List<string> value_more = new List<string>()
            {
                PrintSetting.SoYTe,
                PrintHelper.DateTextShortest(benhAn.BenhNhan.NgaySinh),
                benhAn.BenhNhan.Tuoi.ToString(),
                PrintHelper.HanlderDiaChiText(benhAn?.BenhNhan?.SoNha, benhAn?.BenhNhan?.Thon, benhAn?.BenhNhan?.PhuongXa?.TenPxa, benhAn?.BenhNhan?.QuanHuyen?.TenQh, benhAn?.BenhNhan?.Tinh?.TenTinh),
                benhAn.BenhNhan.DoiTuong.MaDt,
                benhAn.BenhNhan.SoTheBhyt,
                benhAn.HtraVien,
                benhAn.NoiGt,
                PrintHelper.HanlderUnknowsType<int>(benhAn.TongSoNgayDt),
                "", //TuyenDuoi
				benhAn.BenhKKBYHHD.TenBenh, //CapCuuKhoaKhamBenh
				benhAn.BenhChinhVv.TenBenh,
                benhAn.BenhKemVV1.TenBenh,
                benhAn.BenhChinhRv.TenBenh,
                benhAn.BenhKemRV1.TenBenh,
                (benhAn.TaiBienYhhd == 1 || benhAn.BienChungYhhd == 1) ? "1" : "2",
                benhAn.GiaiPhauBenh,
                benhAn.KhamNghiemTuThi?.ToString(),
                benhAn.Kqdt,
                benhAn.TinhTrangTuVong == "1" || benhAn.TinhTrangTuVong == "2" ? benhAn.TinhTrangTuVong:"",
                benhAn.TinhTrangTuVong == "4" ? benhAn.TinhTrangTuVong:"",
                benhAn.TinhTrangTuVong == "5" ? benhAn.TinhTrangTuVong:"",
                tienSuBenh.HutThuoc?.ToString(),
                tienSuBenh?.SoDieu?.ToString(),
                tienSuBenh?.SoBao?.ToString(),
                tienSuBenh?.UongRuou?.ToString(),
                ((int?)tienSuBenh?.LuongRuou)?.ToString(),
                tienSuBenh.YeuToNguyCoKhac,
                tienSuBenh.BenhPhoiHopBenhLyKhac,
                tienSuBenh.ThoiDiemPhatHienTangHa,
                tienSuBenh.NoiDieuTriTangHa,
                tienSuBenh.DieuTriTangHathuongXuyen,
                tienSuBenh.DonDaTriLieuHa,
                tienSuBenh.ChiSoHamax,
                tienSuBenh.ThoiDiemPhatHienDtd,
                tienSuBenh.NoiDieuTriDtd,
                tienSuBenh.DieuTriDtdthuongXuyen,
                tienSuBenh.DonDaTriLieuDtd,
                tienSuBenh.Dtdmax,
                benhanYHHD.BenhSu,
                benhanYHHD.HuyetAp,
                benhanYHHD?.NhipTim?.ToString(),
                ((int?)benhanYHHD.ChieuCao)?.ToString(),
                ((int?)benhanYHHD?.CanNang)?.ToString(),
                benhanYHHD.Bmi?.ToString("0.00"),
                benhanYHHD.TrieuChung,// Triệu chứng
				benhanYHHD.Kqxnmau,
                benhanYHHD.KqxnnuocTieu,
                benhanYHHD.Kqcdha,
                $"{benhAn.BenhChinhVv.MaBenh} - {benhAn.BenhChinhVv.TenBenh}",//ChanDoanXacDinh
                benhanYHCT.MoTaVongChan,
                benhanYHCT.MoTaVanChan,
                benhanYHCT.MoTaXucChan,
                benhanYHCT.MachTrai,
                benhanYHCT.MachPhai,
                benhanYHCT.TomTatTuChan,
                benhanYHCT.BienChungLuanTri,
                benhanYHCT.DmBenhDanhTheoYHCT != null ? benhanYHCT.DmBenhDanhTheoYHCT.TenBenhIcd : null,
                benhanYHCT.BatCuong,
                benhanYHCT.MoTaTangPhu,
                benhanYHCT.NguyenNhan,
                benhanYHCT.DtdonThuanYhct == 1 ? "x" : "",
                benhanYHCT.Ppdtyhct,
                benhanYHCT.PhuongDuoc,
                benhanYHCT.PhuongHuyet,
                benhanYHCT.XoaBopBamHuyet,
                benhanYHCT.Ppkhac,
                benhanYHHD.DtketHopYhhd == 1 ? "x" : "",
                benhanYHHD.Ppdtyhhd,
                benhanYHHD.Kqdt,
                benhanYHHD.HuongDtyhhd,
                PrintHelper.DateTextShortest(benhanYHHD.NgayHenKhamLai),
                PrintHelper.DateTextShortest(benhanYHHD.NgayHenXnlai),
                benhanYHHD.TienLuong,
                PrintHelper.DateText(tongKetBenhAn.NgayKy)
            };

            PrintHelper.TexboxFieldHanlder(ref field_more, ref value_more, benhAn.MaBenhChinhVv, "VaoKhoaBenhChinh", 4, ' ');
            PrintHelper.TexboxFieldHanlder(ref field_more, ref value_more, benhAn.MaBenhChinhRv, "RaVienBenhChinh", 4, ' ');
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopTangHa, "TangHuyetAp");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopDtd, "DaiThaoDuong");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopGout, "Gout");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopKhopManTinh, "KhopManTinh");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopRlchLipid, "RLCHLipit");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopThan, "BenhThan");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopMachVanh, "BenhMachVanh");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhPhoiHopNoiTietKhac, "BenhNoiTiet");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.NamMacTmHaDtd, "TienSuGiaDinh_Nam");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.NuMacTmHaDtd, "TienSuGiaDinh_Nu");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhTangHa, "BenhTangHuyetAp");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.BenhDtd, "BenhDaiThaoDuong");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.ThucHienCdanDtd, "TieuDuongAnKieng");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, tienSuBenh.UongThuocDtd, "ThucUong");
            //PrintHelper.HanlderBooleanTypeOption(ref field_more, ref value_more, tienSuBenh.LoaiThuocDtd, "ThucUong");
            PrintHelper.HanlderBooleanNumberTypeOption(ref field_more, ref value_more, benhanYHHD.NhipTimDeu, "NhipTimDeu");
            PrintHelper.OptionFieldSyncMultipleHanlder(ref field_more, ref value_more, "CheDoDinhDuong", benhanYHHD.CddinhDuong, 3, getDsCombo(combo_ds, "128"));
            PrintHelper.OptionFieldSyncMultipleHanlder(ref field_more, ref value_more, "KQDT_MT", tongKetBenhAn.Kqdt, 1, getDsCombo(combo_ds, "131"));
            PrintHelper.OptionFieldSyncHanlder(ref field_more, ref value_more, "LoaiThuocUong", tienSuBenh.LoaiThuocDtd, 5, getDsCombo(combo_ds, "192"));
            PrintHelper.OptionFieldMultipleHanlder(ref field_more, ref value_more, "CheDoChamSoc", benhanYHHD.CdchamSoc, 1);

            var benhPhoiHop = new string[]{
               !String.IsNullOrEmpty(benhAn.BenhKemVV1.MaBenh) ?  $"{benhAn.BenhKemVV1.MaBenh} - {benhAn.BenhKemVV1.TenBenh}" : "",
               !String.IsNullOrEmpty(benhAn.BenhKemVV2.MaBenh) ?  $"{benhAn.BenhKemVV2.MaBenh} - {benhAn.BenhKemVV2.TenBenh}" : "",
               !String.IsNullOrEmpty(benhAn.BenhKemVV3.MaBenh) ?  $"{benhAn.BenhKemVV3.MaBenh} - {benhAn.BenhKemVV3.TenBenh}" : "",
            };
            //benh phoi hop
            field_more.Add("BenhPhoiHop");
            value_more.Add(string.Join(",", Array.FindAll(benhPhoiHop, x => !string.IsNullOrEmpty(x))));
            //chuyen khoa
            field_more.Add("ChuyenKhoa");
            var chuyenKhoa = new List<string>();
            for (int i = 1; i < benhAnKhoaDieuTris.Count; i++)
            {
                chuyenKhoa.Add(benhAnKhoaDieuTris[i].Khoa.TenKhoa);
            }
            value_more.Add(string.Join(",", Array.FindAll(chuyenKhoa.ToArray(), x => !string.IsNullOrEmpty(x))));
            for (int i = 0; i < field_more.Count; i++)
            {
                fields.Add(field_more[i]);
                values.Add(value_more[i]);
            }
            //tongket chẩn đoán 
            fields.Add("BenhChinhYHHDVV");
            if (benhAnKhoaDieuTris.Count > 0)
            {
                values.Add(PrintHelper.ConcatStringArr(
                 !string.IsNullOrEmpty(benhAnKhoaDieuTris[0].BenhChinh.MaBenh) ? $"{benhAnKhoaDieuTris[0].BenhChinh.MaBenh} - {benhAnKhoaDieuTris[0].BenhChinh.TenBenh}" : "",
                 !string.IsNullOrEmpty(benhAnKhoaDieuTris[0].BenhKem1.MaBenh) ? $"{benhAnKhoaDieuTris[0].BenhKem1.MaBenh} - {benhAnKhoaDieuTris[0].BenhKem1.TenBenh}" : "",
                 !string.IsNullOrEmpty(benhAnKhoaDieuTris[0].BenhKem2.MaBenh) ? $"{benhAnKhoaDieuTris[0].BenhKem2.MaBenh} - {benhAnKhoaDieuTris[0].BenhKem2.TenBenh}" : "",
                 !string.IsNullOrEmpty(benhAnKhoaDieuTris[0].BenhKem3.MaBenh) ? $"{benhAnKhoaDieuTris[0].BenhKem3.MaBenh} - {benhAnKhoaDieuTris[0].BenhKem3.TenBenh}" : ""
                ));
            }
            else
            {
                values.Add("");
            }
            fields.Add("BenhChinhYHCTVV");
            var BenhChinhVvyhct = _benhAnRepository._context.DmbenhTatYhct.Where(x => x.MaBenh == benhAn.MaBenhChinhVvyhct).Select(x => $"{x.MaBenhIcd} - {x.TenBenhIcd}").FirstOrDefault();

            values.Add(PrintHelper.ConcatStringArr(BenhChinhVvyhct,
                 !string.IsNullOrEmpty(benhAn.BenhKemVV1YHCT.MaBenhIcd) ? $"{benhAn.BenhKemVV1YHCT.MaBenhIcd} - {benhAn.BenhKemVV1YHCT.TenBenhIcd}" : "",
                 !string.IsNullOrEmpty(benhAn.BenhKemVV2YHCT.MaBenhIcd) ? $"{benhAn.BenhKemVV2YHCT.MaBenhIcd} - {benhAn.BenhKemVV2YHCT.TenBenhIcd}" : "",
                 !string.IsNullOrEmpty(benhAn.BenhKemVV3YHCT.MaBenhIcd) ? $"{benhAn.BenhKemVV3YHCT.MaBenhIcd} - {benhAn.BenhKemVV3YHCT.TenBenhIcd}" : ""));


            PrintHelper.TexboxFieldHanlder(ref fields, ref values, benhAn.BenhKemRV1.MaBenh, "RaVienBenhKem", 4, ' ');
            var benhanshort = _benhAnRepository._context.BenhAn.Where(x => x.Idba == benhAn.Idba).Select(x => new
            {
                benhChinhRv = x.DmBenhChinhRV != null ? $"{x.DmBenhChinhRV.MaBenh} - {x.DmBenhChinhRV.TenBenh}" : null,
                DmBenhKemRV1 = x.DmBenhKemRV1 != null ? $"{x.DmBenhKemRV1.MaBenh} - {x.DmBenhKemRV1.TenBenh}" : null,
                DmBenhKemRV2 = x.DmBenhKemRV2 != null ? $"{x.DmBenhKemRV2.MaBenh} - {x.DmBenhKemRV2.TenBenh}" : null,
                DmBenhKemRV3 = x.DmBenhChinhRV != null ? $"{x.DmBenhKemRV3.MaBenh} - {x.DmBenhKemRV3.TenBenh}" : null,
                benhChinhRvyhct = x.DmBenhChinhRVYHCT != null ? $"{x.DmBenhChinhRVYHCT.MaBenhIcd} - {x.DmBenhChinhRVYHCT.TenBenhIcd}" : null,
                DmBenhKemRV1YHCT = x.DmBenhKemRV1YHCT != null ? $"{x.DmBenhKemRV1YHCT.MaBenhIcd} - {x.DmBenhKemRV1YHCT.TenBenhIcd}" : null,
                DmBenhKemRV2YHCT = x.DmBenhKemRV2YHCT != null ? $"{x.DmBenhKemRV2YHCT.MaBenhIcd} - {x.DmBenhKemRV2YHCT.TenBenhIcd}" : null,
                DmBenhKemRV3YHCT = x.DmBenhKemRV3YHCT != null ? $"{x.DmBenhKemRV3YHCT.MaBenhIcd} - {x.DmBenhKemRV3YHCT.TenBenhIcd}" : null,
            }).FirstOrDefault();
            fields.Add("ChanDoanRVYHHD");
            values.Add(benhanshort == null ? "" : PrintHelper.ConcatStringArr(benhanshort.benhChinhRv, benhanshort.DmBenhKemRV1, benhanshort.DmBenhKemRV2, benhanshort.DmBenhKemRV3));
            fields.Add("ChanDoanRVYHCT");
            values.Add(benhanshort == null ? "" : PrintHelper.ConcatStringArr(benhanshort.benhChinhRvyhct, benhanshort.DmBenhKemRV1YHCT, benhanshort.DmBenhKemRV2YHCT, benhanshort.DmBenhKemRV3YHCT));

        }

        public string GiayRaVienPrint(decimal idba)
        {

            var benhAn = Detail(idba);
            var tongKetBenhAn = _benhAnRepository._context.BenhAnTongKetBenhAn
                    .Include(x => x.DmBsDieutri)
                    .Include(x => x.DmNguoiGiao)
                    .Include(x => x.DmNguoiNhan)
                    .Select(Mapper.Map<BenhAnTongKetBenhAnDto>)
                    .FirstOrDefault(x => x.Idba == idba);
            tongKetBenhAn = tongKetBenhAn ?? new BenhAnTongKetBenhAnDto();
            List<string> fields = new List<string>(){
                "SoYTe",
                "BenhVien",
                "SoLuuTru",
                "MaYTe",
                "HoTen",
                "Tuoi",
                "GioiTinh",
                "MaBN",
                "DanToc",
                "NgheNghiep",
                "Bhyt",
                "DiaChi",
                "GioVaoVien",
                "NgayVaoVien",
                "GioRaVien",
                "NgayRaVien",
                "ChanDoan",
                "PhuongPhapDieuTri",
                "GhiChu",
                "NgayGioDongDau",
                "NgayGioDieuTri",
                "GiamDoc",
                "TruongKhoaDieuTri"
            };
            List<string> values = new List<string>(){
                PrintSetting.SoYTe,
                PrintSetting.BenhVien,
                benhAn?.SoLuuTru,
                benhAn?.MaYt,
                benhAn?.BenhNhan?.HoTen?.ToUpper(),
                benhAn?.BenhNhan?.Tuoi?.ToString(),
                benhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
                benhAn?.BenhNhan?.MaBn,
                benhAn?.BenhNhan?.DanToc?.TenDanToc,
                benhAn.BenhNhan.NgheNghiep.TenNn,
                benhAn.BenhNhan.SoTheBhyt,
                PrintHelper.HanlderDiaChiText(benhAn?.BenhNhan?.SoNha, benhAn?.BenhNhan?.Thon, benhAn?.BenhNhan?.PhuongXa?.TenPxa, benhAn?.BenhNhan?.QuanHuyen?.TenQh, benhAn?.BenhNhan?.Tinh?.TenTinh),
                PrintHelper.TimeText(benhAn.NgayVv),
                PrintHelper.DateText(benhAn.NgayVv),
                PrintHelper.TimeText(benhAn.NgayRv),
                PrintHelper.DateText(benhAn.NgayRv),
                benhAn.TenBenhChinhRv,
                tongKetBenhAn.HuongDt,
                "",
                PrintHelper.DateText(tongKetBenhAn.NgayKy),
                PrintHelper.DateText(benhAn.NgayTruongKhoaKy),
                benhAn.Giamdoc.HoTen,
                benhAn.BsDieutri.HoTen
            };
            string path = PrintHelper.PrintFile<BenhAn>(_hostingEnvironment, "giay-ra-vien.doc", fields, values);
            return path;
        }

        public string[] getDsCombo(List<DmbaCombods> combos, string maParent)
        {
            return combos.Where(x => x.MaParent == maParent).Select(x => x.Ma).ToArray();
        }
        private string[] maDsCombo = new string[] {
            "017",
            "045",
            "046",
            "047",
            "048",
            "049",
            "050",
            "051",
            "056",
            "057",
            "059",
            "063",
            "065",
            "067",
            "068",
            "070",
            "072",
            "073",
            "074",
            "075",
            "076",
            "078",
            "080",
            "082",
            "084",
            "086",
            "088",
            "091",
            "090",
            "093",
            "095",
            "096",
            "098",
            "099",
            "101",
            "105",
            "107",
            "109",
            "111",
            "112",
            "114",
            "113",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "124",
            "121",
            "122",
            "123",
            "125",
            "128",
            "192",
            "130",
            "131"
        };
    }
}
