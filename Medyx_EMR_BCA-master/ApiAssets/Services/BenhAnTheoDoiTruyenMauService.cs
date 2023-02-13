using System.Security.Cryptography.X509Certificates;
using System;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using System.Collections;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnTheoDoiTruyenMauService
	{
		private IRepository<BenhAnTheoDoiTruyenMau> _benhanTheodoiTruyenMauRepository = null;
		private PrintSetting PrintSetting { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;
		public BenhAnTheoDoiTruyenMauService(IHostingEnvironment hostingEnvironment = null, IHttpContextAccessor accessor = null, IOptions<PrintSetting> options = null)
		{
			_benhanTheodoiTruyenMauRepository = new GenericRepository<BenhAnTheoDoiTruyenMau>(accessor);
			PrintSetting = options != null ? options.Value : new PrintSetting();
			_hostingEnvironment = hostingEnvironment;
		}

		public BenhanTheodoiTruyenMauDto Detail(decimal idba, int stt)
		{
			return _benhanTheodoiTruyenMauRepository.Table.Where(x => x.Idba == idba && x.Sttcpm == stt).Select(x => new BenhanTheodoiTruyenMauDto()
			{
				Idba = x.Idba,
				Idhis = x.Idhis,
				Stt = x.Stt,
				KhoaDieuTri = new BenhAnKhoaDieuTriDto()
				{
					Stt = x.BenhanCpm.BenhAnKhoaDieuTri.Stt,
					NgayVaoKhoa = x.BenhanCpm.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Khoa = new DmkhoaDto()
					{
						TenKhoa = x.BenhanCpm.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
						MaKhoa = x.BenhanCpm.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
					},
                    BenhChinh = new DmbenhTatDto(){
                        TenBenh = x.BenhanCpm.BenhAnKhoaDieuTri.BenhChinh.TenBenh,
                        MaBenh = x.BenhanCpm.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
                    }
				},
				NgayChiDinh = x.BenhanCpm.NgayYlenh,
				BsChiDinh = new DmnhanVienDto()
				{
					MaNv = x.BenhanCpm.DmnhanVien.MaNv,
					HoTen = x.BenhanCpm.DmnhanVien.HoTen
				},
				ChePhamMau = new DmchephamMauDto()
				{
					MaDV = x.BenhanCpm.DmchephamMau.MaCpmau,
					TenDV = x.BenhanCpm.DmchephamMau.TenCpmau,
					DonViTinh = x.BenhanCpm.DmchephamMau.TenDvt
				},
				TheTich = x.TheTich,
				MaSoCmp = x.MaSoCmp,
				NgayDieuChe = x.NgayDieuChe,
				HanSd = x.HanSd,
				Rh = x.Rh,
				KqpuhoaHopMuoiOng1 = x.KqpuhoaHopMuoiOng1,
				KqpuhoaHopMuoiOng2 = x.KqpuhoaHopMuoiOng2,
				KqpuhoaHop37doOng1 = x.KqpuhoaHop37doOng1,
				KqpuhoaHop37doOng2 = x.KqpuhoaHop37doOng2,
				KqpuhoaHop = x.KqpuhoaHop,
				TenKqxnkhac = x.TenKqxnkhac,
				NgayXnhoaHop = x.NgayXnhoaHop,
				HoTenTruongKhoaXn = x.HoTenTruongKhoaXn,
				HoTenNguoiXn1 = x.HoTenNguoiXn1,
				HoTenNguoiXn2 = x.HoTenNguoiXn2,
				LanTruyenMau = x.LanTruyenMau,
				NhomMau = x.NhomMau,
				NhomMauCpm = x.NhomMauCpm,
				Kqxncheo = x.Kqxncheo,
				ThoiGianBd = x.ThoiGianBd,
				ThoiGianKt = x.ThoiGianKt,
				Sltruyen = x.Sltruyen,
				NhanXet = x.NhanXet,
				DieuDuong = new DmnhanVienDto()
				{
					MaNv = x.DmDieuDuong.MaNv,
					HoTen = x.DmDieuDuong.HoTen
				},
				BstheoDoi = new DmnhanVienDto()
				{
					MaNv = x.DmBsTheoDoi.MaNv,
					HoTen = x.DmBsTheoDoi.HoTen
				},
			}).FirstOrDefault();
		}

		public void Store(BenhAnTheoDoiTruyenMauVM parameters)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
			var benhAnTheoDoiTruyenMau = _benhanTheodoiTruyenMauRepository.Table.Where(x => x.Idba == parameters.Idba && x.Sttcpm == parameters.Sttcpm).FirstOrDefault();
			if (benhAnTheoDoiTruyenMau == null)
			{
                var stt = (_benhanTheodoiTruyenMauRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
                parameters.MaBa = benhAn.MaBa;
				parameters.MaBn = benhAn.MaBn;
				parameters.Stt = stt;
				// parameters.Idhis = stt.ToString();

				_benhanTheodoiTruyenMauRepository.Insert(parameters);
			}
			else
			{
				parameters.Stt = benhAnTheoDoiTruyenMau.Stt;
				parameters.MaBa = benhAnTheoDoiTruyenMau.MaBa;
				parameters.MaBn = benhAnTheoDoiTruyenMau.MaBn;
				// parameters.Idhis = benhAnTheoDoiTruyenMau.Idhis;
				_benhanTheodoiTruyenMauRepository.Update(parameters, parameters.Stt, parameters.Idba);
			}
		}
		public string Print(decimal idba, int stt)
		{
			var dataBenhAn = _benhanTheodoiTruyenMauRepository._context.BenhAn
                    .Select(ba => new BenhAnDto()
                    {
                        Idba = ba.Idba,
                        SoVaoVien = ba.SoVaoVien,
                        TruongKhoa = new DmnhanVienDto(){
                            HoTen = ba.DmTruongKhoa.HoTen,
                            MaNv = ba.DmTruongKhoa.MaNv
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
			var detail = Detail(idba, stt);
			var benhanTheodoiTruyenMauC = _benhanTheodoiTruyenMauRepository._context.BenhAnTheodoiTruyenMauC
            .Where(x => x.Idba == idba && x.StttruyenMau == stt)
            .OrderBy(x => x.Stt)
            .ToList()
            .Select(x => new BenhAnTruyenMauCPrint(){
                ThoiGian = PrintHelper.DateTimeTextShort(x.ThoiGian),
                TocDoTruyen = x.TocDo,
                MauDa_NiemMac = x.MauSacDa,
                NhipTho = x.NhipTho?.ToString(),
                Mach = x.Mach?.ToString(),
                HuyetAp = x.HuyetAp,
                ThanNhiet = x.NhietDo?.ToString(),
                DienBienKhac = x.DienBienKhac
            }).ToList();
			List<string> fields = new List<string>(){
				"HoVaTen",
				"Tuoi",
				"GioiTinh",
				"ChanDoan",
				"KhoaPhong",
				"TheTich",
				"LoaiChePhamMauTruyen",
				"MaSoDonViChePhamMauTruyen",
				"NgayLayMauHoacChePham",
				"HanSuDung",
				"Rh",
				"CacXetNghiemKhac",
				"Ong1MoiTruongMuoi",
				"Ong1KhangGlobulin",
				"Ong2MoiTruongMuoi",
				"Ong2KhangGlobulin",
				"NgayThang",
				"TruongKhoa",
				"NguoiKhongXacDinh",
				"NguoiLamXetNghiem",
				"LanTruyenMauThu",
				"DinhNhomMau",
				"NhomMauNguoiNhan",
				"KetQuaPhanUngCheoTaiGiuong",
				"ThoiGianBatDauTruyenMau",
				"ThoiGianNgungTruyen",
				"SoLuongMauThucTeDaTruyen",
				"NhanXetQuaTrinhTruyenMau",
				"BsDieuTri",
				"DieuDuong"
			};
			List<string> values = new List<string>(){
                dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
                dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
                dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
                !String.IsNullOrEmpty(detail?.KhoaDieuTri?.BenhChinh?.MaBenh) ? $"{detail?.KhoaDieuTri?.BenhChinh?.MaBenh} - {detail?.KhoaDieuTri?.BenhChinh?.TenBenh}" : "" ,
                detail?.KhoaDieuTri?.Khoa?.TenKhoa,
                detail?.TheTich?.ToString(),
                detail?.ChePhamMau?.TenDV,
                detail?.ChePhamMau?.MaDV,
                PrintHelper.DateTextShortest(detail?.NgayDieuChe),
                PrintHelper.DateTextShortest(detail?.HanSd),
                "", // CacXetNghiemKhac
				detail?.Rh,
                detail?.KqpuhoaHopMuoiOng1.ToString(),
                detail?.KqpuhoaHop37doOng1,
                detail?.KqpuhoaHopMuoiOng2.ToString(),
                detail?.KqpuhoaHop37doOng2,
                PrintHelper.DateText(detail?.NgayChiDinh),
                detail?.HoTenTruongKhoaXn,
                detail?.HoTenNguoiXn1,
                detail?.HoTenNguoiXn2,
                detail?.LanTruyenMau?.ToString(),
                detail?.NhomMauCpm,
                detail?.NhomMau,
                detail?.Kqxncheo,
                PrintHelper.DateTimeText(detail?.ThoiGianBd),
                PrintHelper.DateTimeText(detail?.ThoiGianKt),
                detail?.Sltruyen?.ToString(),
                detail?.NhanXet,
                detail?.BsChiDinh?.HoTen,
                detail?.DieuDuong?.HoTen
            };
            var dataset = DatasetHelper.ConvertToDataSet<BenhAnTruyenMauCPrint>(benhanTheodoiTruyenMauC);
            var list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry("BenhAnTruyenMauCPrint", string.Empty));
            string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "Xet_nghiem_hoa_hop_mien_dich_truyen_mau.docx", dataset, list, fields, values);
            return path;
        }
        private class BenhAnTruyenMauCPrint{
            public string ThoiGian { get; set; }
            public string TocDoTruyen { get; set; }
            public string MauDa_NiemMac { get; set; }
            public string NhipTho { get; set; }
            public string Mach { get; set; }
            public string HuyetAp { get; set; }
            public string ThanNhiet { get; set; }
            public string DienBienKhac { get; set; }
        }
	}
}
