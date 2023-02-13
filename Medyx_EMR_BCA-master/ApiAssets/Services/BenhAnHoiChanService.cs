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
    public class BenhAnHoiChanService
    {
        private IRepository<BenhAnHoiChan> _benhAnHoiChanRepository = null;
        private readonly IHostingEnvironment _hostingEnvironment;
        private PrintSetting PrintSetting { get; set; }
        public BenhAnHoiChanService(Microsoft.AspNetCore.Http.IHttpContextAccessor accessor, IOptions<PrintSetting> options, HostingEnvironment hostingEnvironment)
        {
            _benhAnHoiChanRepository = new GenericRepository<BenhAnHoiChan>(accessor);
            PrintSetting = options.Value;
            _hostingEnvironment = hostingEnvironment;
        }
        public string Print(decimal idba, int stt, int sttKhoa)
        {
            var benhAn = _benhAnHoiChanRepository._context.BenhAn
			.Include(x => x.ThongTinBn).ThenInclude(x => x.Dmtinh)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquanHuyen)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmphuongXa)
			.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquocGia)
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
					GioiTinh = ba.ThongTinBn.GioiTinh
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var query = _benhAnHoiChanRepository.Table.Include(x => x.DmChuToa)
						.Include(x => x.DmThuKy)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmkhoaBuong)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.DmkhoaGiuong)
						.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.BenhChinh)
						.AsQueryable();
			var querySelect = BenhAnHoiChanDtoQuery();
			var new_query = query.Select(querySelect);
			var benhAnHoiChan = new_query.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);

			List<BenhAnHoiChanPrintDto> benhAnHoiChans = new List<BenhAnHoiChanPrintDto>();
			benhAnHoiChans.Add(new BenhAnHoiChanPrintDto()
			{
				SoVaoVien = benhAn.SoVaoVien,
				HoTen = benhAn.BenhNhan.HoTen,
				Tuoi = benhAn.BenhNhan.Tuoi.ToString(),
				GioiTinh = benhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
				DieuTriTuNgay = PrintHelper.DateText(benhAn.NgayVv),
				DieuTriDenNgay = PrintHelper.DateText(benhAnHoiChan?.NgayHoiChan),
				BienBanHoiChan = benhAnHoiChan?.TenBienBanHoiChan,
				Giuong = benhAnHoiChan?.KhoaDieuTri?.Giuong?.TenGiuong,
				Buong = benhAnHoiChan?.KhoaDieuTri?.Buong?.TenBuong,
				ChuanDoan = !String.IsNullOrEmpty(benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.MaBenh) ? $"{benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.MaBenh} - {benhAnHoiChan?.KhoaDieuTri?.BenhChinh?.TenBenh}" : "",
				HoiChanG = PrintHelper.DateText(benhAnHoiChan?.NgayHoiChan),
				HoiChuanNgay = PrintHelper.DateTextShort(benhAnHoiChan?.NgayHoiChan),
				ChuToa = benhAnHoiChan?.ChuToa.HoTen,
				ThuKi = benhAnHoiChan?.ThuKy.HoTen,
				ThanhVienThamGia = benhAnHoiChan?.ThanhVien,
				TomTatDienBien = benhAnHoiChan?.TomTatDienBienBenh,
				KetLuan = benhAnHoiChan?.KetLuan,
				HuongDieuTri = benhAnHoiChan?.HuongDt
			});
			string path = PrintHelper.PrintFile<BenhAnHoiChanPrintDto>(_hostingEnvironment, "Trich-bien-ban-hoi-chuan.doc", null, null, benhAnHoiChans, "BenhAnHoiChan");
            return path;
        }
		private Expression<Func<BenhAnHoiChan, BenhAnHoiChanDto>> BenhAnHoiChanDtoQuery()
		{
			return ba => new BenhAnHoiChanDto()
			{
				Idba = ba.Idba,
				Stt = ba.Stt,
				Idhis = ba.Idhis,
				MaBa = ba.MaBa,
				MaBn = ba.MaBn,
				Sttkhoa = ba.Sttkhoa,
				TenBienBanHoiChan = ba.TenBienBanHoiChan,
				NgayHoiChan = ba.NgayHoiChan,
				ThanhVien = ba.ThanhVien,
				ChuToa = new DmnhanVienDto()
				{
					HoTen = ba.DmChuToa.HoTen,
					MaNv = ba.DmChuToa.MaNv,
				},
				ThuKy = new DmnhanVienDto()
				{
					HoTen = ba.DmThuKy.HoTen,
					MaNv = ba.DmThuKy.MaNv,
				},
				TomTatDienBienBenh = ba.TomTatDienBienBenh,
				KetLuan = ba.KetLuan,
				HuongDt = ba.HuongDt,
				Huy = ba.Huy,
				MaMay = ba.MaMay,
				NgayLap = ba.NgayLap,
				NguoiLap = new DmnhanVienDto()
				{
					HoTen = ba.DmNguoiLap.HoTen,
					MaNv = ba.DmNguoiLap.MaNv,
				},
				NgaySd = ba.NgaySd,
				NguoiSd = new DmnhanVienDto()
				{
					HoTen = ba.DmNguoiSD.HoTen,
					MaNv = ba.DmNguoiSD.MaNv,
				},
				NgayHuy = ba.NgayHuy,
				NguoiHuy = new DmnhanVienDto()
				{
					HoTen = ba.DmNguoiHuy.HoTen,
					MaNv = ba.DmNguoiHuy.MaNv,
				},
				KhoaDieuTri = ba.Sttkhoa != null ? new BenhAnKhoaDieuTriDto()
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
				} : new BenhAnKhoaDieuTriDto()
			};
		}
	}
}
