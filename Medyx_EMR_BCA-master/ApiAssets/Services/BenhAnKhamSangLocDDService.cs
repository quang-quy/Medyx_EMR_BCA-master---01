using System.Data.Common;
using AutoMapper;
using Medyx.ApiAssets.Dto.Print;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Medyx_EMR_BCA.ApiAssets.ViewModels;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnKhamSangLocDDService
    {
        private IRepository<BenhAnKhamSangLocDd> _benhAnKhamSangLocDdRepository = null;
        private readonly IHostingEnvironment _hostingEnvironment;
        private PrintSetting PrintSetting { get; set; }
        public BenhAnKhamSangLocDDService(Microsoft.AspNetCore.Http.IHttpContextAccessor accessor, IOptions<PrintSetting> options, HostingEnvironment hostingEnvironment)
        {
            _benhAnKhamSangLocDdRepository = new GenericRepository<BenhAnKhamSangLocDd>(accessor);
            PrintSetting = options.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public IQueryable<BenhAnKhamSangLocDdDto> Get(BenhAnBenhAnKhamSangLocDDParameters parameters, UserSession user = null)
        {
            var query = _benhAnKhamSangLocDdRepository.Table
            .AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);
            var querySelect = BenhAnKhamSangLocDtoQuery();

            IQueryable<BenhAnKhamSangLocDdDto> benhAnPhauThuatQuery = query.Select(querySelect);
            return benhAnPhauThuatQuery;
        }

		private IQueryable<BenhAnKhamSangLocDd> QueryFilter(IQueryable<BenhAnKhamSangLocDd> query, BenhAnBenhAnKhamSangLocDDParameters parameters)
		{
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			return query;
		}
		 public void Store(BenhAnKhamSangLocDdCreateVM benhAnKhamSangLocDd)
        {
            var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnKhamSangLocDd.Idba);
            var stt = (_benhAnKhamSangLocDdRepository.Table.Where(x => x.Idba == benhAnKhamSangLocDd.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            benhAnKhamSangLocDd.MaBa = benhan.MaBa;
            // benhAnKhamSangLocDd.Idhis = "";
            benhAnKhamSangLocDd.Stt = stt;
            benhAnKhamSangLocDd.MaBn = benhan.MaBn;
            _benhAnKhamSangLocDdRepository.Insert(benhAnKhamSangLocDd);
        }

        public void Update(decimal idba, int stt, int sttKhoa, BenhAnKhamSangLocDdVM benhanTheodoiTruyenDich)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnKhamSangLocDdRepository.Update(benhanTheodoiTruyenDich, idba, stt, sttKhoa);
        }


        public void Destroy(decimal idba, int stt, int sttKhoa)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnKhamSangLocDdRepository.Delete(idba, stt, sttKhoa);
        }
        public string Print(decimal idba, int stt, int sttKhoa)
        {
            var benhAn = _benhAnKhamSangLocDdRepository._context.BenhAn
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

                    },
                },
            }).FirstOrDefault(x => x.Idba == idba);
            var querySelect = BenhAnKhamSangLocDtoQuery();
            var data = _benhAnKhamSangLocDdRepository.Table
            .Select(querySelect)
            .FirstOrDefault(x => x.Idba == idba && x.Stt == stt && x.Sttkhoa == sttKhoa);
            var chiSoNgonMieng = data?.DiemNgonMieng != null ? data.DiemNgonMieng : 0;
            var diemSutCan = data?.DiemSutCan != null ? data.DiemSutCan : 0;
            int? mst = (data?.DiemNgonMieng == null && data?.DiemSutCan == null) ? null : chiSoNgonMieng + diemSutCan;
            List<BenhAnKhamSangLocDDPrintDto> dataFill = new List<BenhAnKhamSangLocDDPrintDto>(){
                    new BenhAnKhamSangLocDDPrintDto(){
                        SoYTe = PrintSetting.SoYTe,
                        BenhVien = PrintSetting.BenhVien,
                        SoVaoVien = benhAn.SoVaoVien,
                        HoTen = benhAn?.BenhNhan?.HoTen?.ToUpper(),
                        Tuoi = benhAn?.BenhNhan?.Tuoi?.ToString(),
                        DiaChi = PrintHelper.HanlderDiaChiText(benhAn?.BenhNhan?.SoNha, benhAn?.BenhNhan?.Thon, benhAn?.BenhNhan?.PhuongXa?.TenPxa, benhAn?.BenhNhan?.QuanHuyen?.TenQh, benhAn?.BenhNhan?.Tinh?.TenTinh),
                        GioiTinh = benhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
                        CanNang = data.CanNang,
                        ChieuCao = data.ChieuCao,
                        BMI = data.Bmi,
                        NamSinh = benhAn.BenhNhan.NgaySinh.ToString("yyyy"),
                        NgayThang = PrintHelper.DateText(data.NgayDg),
                        CanThiepDD = data.CanThiepDd,
                        CoSutCan_0 = data.CoSutCan == 0 ? "0" : "",
                        CoSutCan_1 = data.CoSutCan == 2 ? "2" : "",
                        DiemSutCan_0  = data.CoSutCan == 1 && data.DiemSutCan == 1 ? "1": "" ,
                        DiemSutCan_1 = data.CoSutCan == 1 && data.DiemSutCan == 2 ? "2" : "",
                        DiemSutCan_2 = data.CoSutCan == 1 && data.DiemSutCan == 3 ? "3" : "",
                        DiemSutCan_3 = data.CoSutCan == 1 && data.DiemSutCan == 4 ? "4" : "",
                        DiemSutCan_4 = data.CoSutCan == 2 ? "2" : "",
                        ChiSoSutCan = data?.DiemSutCan?.ToString(),
                        DiemNgonMieng_0 = data.DiemNgonMieng == 0 ? "0" : "",
                        DiemNgonMieng_1 = data.DiemNgonMieng == 1 ? "1" : "",
                        ChiSoNgonMieng = data?.DiemNgonMieng?.ToString(),
                        ChiSoMST = mst?.ToString(),
                        PhieuSo = data.SoPhieu,
                        Khoa = data.KhoaDieuTri.Khoa.TenKhoa,
                        Buong = data.KhoaDieuTri.Buong.TenBuong,
                        Giuong = data.KhoaDieuTri.Giuong.TenGiuong,
                        ChanDoan = data.KhoaDieuTri.BenhChinh.TenBenh,
                        NguoiDG = data.NguoiDg.HoTen
                    }
            };
            return PrintHelper.PrintFile<BenhAnKhamSangLocDDPrintDto>(_hostingEnvironment, "PhieuKhamDinhDuong.doc", null, null, dataFill, "PhieuKhamDinhDuong");
        }
        private Expression<Func<BenhAnKhamSangLocDd, BenhAnKhamSangLocDdDto>> BenhAnKhamSangLocDtoQuery()
        {
            return ba => new BenhAnKhamSangLocDdDto()
            {
                Idba = ba.Idba,
                Stt = ba.Stt,
                Idhis = ba.Idhis,
                MaBa = ba.MaBa,
                MaBn = ba.MaBn,
                Sttkhoa = ba.Sttkhoa,
                SoPhieu = ba.SoPhieu,
                NgayDg = ba.NgayDg,
                CanNang = ba.CanNang,
                ChieuCao = ba.ChieuCao,
                Bmi = ba.Bmi,
                CoSutCan = ba.CoSutCan,
                DiemSutCan = ba.DiemSutCan,
                DiemNgonMieng = ba.DiemNgonMieng,
                ChiSoMst = ba.ChiSoMst,
                DanhGiaTheoMst = ba.DanhGiaTheoMst,
                CanThiepDd = ba.CanThiepDd,
                Huy = ba.Huy,
                NgayLap = ba.NgayLap,
                NgaySd = ba.NgaySd,
                MaMay = ba.MaMay,
                NgayHuy = ba.NgayHuy,
                NguoiDg = new DmnhanVienDto()
                {
                    MaNv = ba.DmNguoiDg.MaNv,
                    HoTen = ba.DmNguoiDg.HoTen
                },
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = ba.DmNguoiLap.MaNv,
                    HoTen = ba.DmNguoiLap.HoTen
                },
                Bsdieutri = new DmnhanVienDto()
                {
                    MaNv = ba.DmBsdieuTri.MaNv,
                    HoTen = ba.DmBsdieuTri.HoTen
                },
                NguoiSd = new DmnhanVienDto()
                {
                    MaNv = ba.DmNguoiSD.MaNv,
                    HoTen = ba.DmNguoiSD.HoTen
                },
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = ba.DmNguoiHuy.MaNv,
                    HoTen = ba.DmNguoiHuy.HoTen
                },
                KhoaDieuTri = new BenhAnKhoaDieuTriDto()
                {
                    NgayVaoKhoa = ba.BenhAnKhoaDieuTri.NgayVaoKhoa,
                    Stt = ba.BenhAnKhoaDieuTri.Stt,
                    Idba = ba.BenhAnKhoaDieuTri.Idba,
                    Khoa = new DmkhoaDto()
                    {
                        TenKhoa = ba.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                        MaKhoa = ba.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                    },
                    Buong = new DmkhoaBuongDto()
                    {
                        MaBuong = ba.BenhAnKhoaDieuTri.DmkhoaBuong.MaBuong,
                        TenBuong = ba.BenhAnKhoaDieuTri.DmkhoaBuong.TenBuong
                    },
                    Giuong = new DmkhoaGiuongDto()
                    {
                        MaGiuong = ba.BenhAnKhoaDieuTri.DmkhoaGiuong.MaGiuong,
                        TenGiuong = ba.BenhAnKhoaDieuTri.DmkhoaGiuong.TenGiuong
                    },
                    BenhChinh = new DmbenhTatDto()
                    {
                        MaBenh = ba.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
                        TenBenh = ba.BenhAnKhoaDieuTri.BenhChinh.TenBenh
                    },
                }
            };
        }
    }
}
