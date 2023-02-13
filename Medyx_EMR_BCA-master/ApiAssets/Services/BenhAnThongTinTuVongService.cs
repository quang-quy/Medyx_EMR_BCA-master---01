using AutoMapper;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Dto.Print;
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
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnThongTinTuVongService
	{
		private IRepository<BenhAn> _benhAnRepository = null;
		private IRepository<BenhAnTvBbkiemDiem> _benhAnTvBbkiemDiemRepository = null;
		private IRepository<BenhAnTvBbkiemDiemTv> _benhAnTvBbkiemDiemTvRepository = null;
		private IRepository<BenhAnTvPhieuCdnguyenNhan> _benhAnTvPhieuCdnguyenNhanRepository = null;
		private PrintSetting PrintSetting { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;
		public BenhAnThongTinTuVongService(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment = null, IOptions<PrintSetting> options = null)
		{
			_benhAnRepository = new GenericRepository<BenhAn>(accessor);
			_benhAnTvBbkiemDiemRepository = new GenericRepository<BenhAnTvBbkiemDiem>(accessor);
			_benhAnTvBbkiemDiemTvRepository = new GenericRepository<BenhAnTvBbkiemDiemTv>(accessor);
			_benhAnTvPhieuCdnguyenNhanRepository = new GenericRepository<BenhAnTvPhieuCdnguyenNhan>(accessor);
			_hostingEnvironment = hostingEnvironment;
			PrintSetting = options != null ? options.Value : new PrintSetting();
		}
		#region Bien ban kiem diem
		public BenhAnTvBbkiemDiemDto DetailBienBanKiemDiem(decimal idba)
		{
			var bienBanKiemDiemQuery = _benhAnTvBbkiemDiemRepository.Table.Where(x => x.Idba == idba);
			var benhAn = _benhAnRepository.GetById(idba);
			return bienBanKiemDiemQuery.Select(x => new BenhAnTvBbkiemDiemDto()
			{
				Idba = x.Idba,
				Khoa = new DmkhoaDto()
				{
					MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
					TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
				},
				Sttkhoa = x.Sttkhoa,
				SoPhieu = x.SoPhieu,
				ThoiGianKiemDiem = x.ThoiGianKiemDiem,
				NoiHop = x.NoiHop,
				NgayTuVong = x.NgayTuVong ?? benhAn.NgayTuVong,
				NguyenNhanTv = x.NguyenNhanTv ?? benhAn.NguyenNhanTuVong,
				TomTatQtbenh = x.TomTatQtbenh,
				TinhTrangVv = x.TinhTrangVv,
				ChanDoan = x.ChanDoan,
				TomTatDienBien = x.TomTatDienBien,
				TiepDonBn = x.TiepDonBn,
				ThamKham = x.ThamKham,
				DieuTri = x.DieuTri,
				ChamSoc = x.ChamSoc,
				QuanHeVoiGdbn = x.QuanHeVoiGdbn,
				YkienBoSung = x.YkienBoSung,
				KetLuan = x.KetLuan,
				ChuToa = new DmnhanVienDto()
				{
					MaNv = x.DmChuToa.MaNv,
					HoTen = x.DmChuToa.HoTen
				},
				ThuKy = new DmnhanVienDto()
				{
					MaNv = x.DmThuKy.MaNv,
					HoTen = x.DmThuKy.HoTen
				},
				KhoaDieuTri = x.Sttkhoa != null ? new BenhAnKhoaDieuTriDto()
				{
					NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Stt = x.BenhAnKhoaDieuTri.Stt,
					Idba = x.BenhAnKhoaDieuTri.Idba,
					Khoa = new DmkhoaDto()
					{
						TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
						MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
					}
				} : new BenhAnKhoaDieuTriDto(),
			}).FirstOrDefault();
		}

		public string TrichBienBanPrint(decimal idba)
		{
			var dataBenhAn = _benhAnTvPhieuCdnguyenNhanRepository._context.BenhAn
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
					GioiTinh = ba.ThongTinBn.GioiTinh,
					Tuoi = ba.ThongTinBn.Tuoi,
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var bienBan = DetailBienBanKiemDiem(idba);
			var thanhVienThamGia = GetThanhVienThamGia(new BenhAnThongTinTuVongParameters()
			{
				Idba = idba
			}).ToList();

			List<string> fields = new List<string>(){
				"BenhVien",
				"Khoa",
				"HoTen",
				"Tuoi",
				"GioiTinh",
				"SoVaoVien",
				"GioVaoVien",
				"NgayVaoVien",
				"GioTuVong",
				"NgayTuVong",
				"TaiKhoa",
				"GioKiemDiemTuVong",
				"NgayKiemDiemTuVong",
				"ChuToa",
				"ThuKy",
				"ThanhVienThamGia",
				"QuaTrinhDienBien",
				"KetLuan",
				"NgayThang"
			};
			List<string> values = new List<string>(){
				PrintSetting.BenhVien,
				bienBan?.Khoa?.TenKhoa,
				dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
				dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
				Convert.ToBoolean(dataBenhAn?.BenhNhan?.GioiTinh) ? "Nam" : "Nữ",
				dataBenhAn?.SoVaoVien,
				PrintHelper.TimeText(dataBenhAn?.NgayVv),
				PrintHelper.DateText(dataBenhAn?.NgayVv),
				PrintHelper.TimeText(bienBan?.NgayTuVong),
				PrintHelper.DateText(bienBan?.NgayTuVong),
				bienBan?.KhoaDieuTri?.Khoa?.TenKhoa,
				PrintHelper.TimeText(bienBan?.ThoiGianKiemDiem),
				PrintHelper.DateText(bienBan?.ThoiGianKiemDiem),
				bienBan?.ChuToa?.HoTen,
				bienBan?.ThuKy?.HoTen,
				thanhVienThamGia.Select(x => $"{x.ThanhVien.HoTen} - {x.VaiTro}").Aggregate("", (acc, x) => acc + $", {x}"),
				bienBan?.TomTatDienBien,
				bienBan?.KetLuan,
				PrintHelper.DateText(bienBan?.ThoiGianKiemDiem),
			};
			string path = PrintHelper.PrintFile<BenhAnDto>(_hostingEnvironment, "Trich-bien-ban-tu-vong.doc", fields, values);
			return path;
		}

		public string BaoTuPrint(decimal idba)
		{
			var bienBan = DetailBienBanKiemDiem(idba);
			var dataBenhAn = _benhAnTvPhieuCdnguyenNhanRepository._context.BenhAn
					.Select(ba => new BenhAnDetailDto()
					{
						Idba = ba.Idba,
						SoVaoVien = ba.SoVaoVien,
						NgayVv = ba.NgayVv,
						BenhNhan = new BenhAnDetailThongTinBnDto()
						{
							MaBn = ba.ThongTinBn.MaBn,
							Idba = ba.ThongTinBn.Idba,
							HoTen = ba.ThongTinBn.HoTen,
							NgaySinh = ba.ThongTinBn.NgaySinh,
							GioiTinh = ba.ThongTinBn.GioiTinh,
							Tuoi = ba.ThongTinBn.Tuoi,
							NoiLamViec = ba.ThongTinBn.NoiLamViec,
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
							DanToc = new DmdanTocDto()
							{
								MaDanToc = ba.ThongTinBn.DmdanToc.MaDanToc,
								TenDanToc = ba.ThongTinBn.DmdanToc.TenDanToc
							},
							QuocGia = new DmquocGiaDto()
							{
								MaQg = ba.ThongTinBn.DmquocGia.MaQg,
								TenQg = ba.ThongTinBn.DmquocGia.TenQg
							},
							HoTenCha = ba.ThongTinBn.HoTenCha,
							HoTenMe = ba.ThongTinBn.HoTenMe,
							NguoiGiamHo = ba.ThongTinBn.NguoiGiamHo,
							Cmnd = ba.ThongTinBn.Cmnd,
							NoiCapCmnd = ba.ThongTinBn.NoiCapCmnd,
							NgayCapCmnd = ba.ThongTinBn.NgayCapCmnd,
							NgheNghiep = new DmngheNghiepDto()
							{
								MaNn = ba.ThongTinBn.DmngheNghiep.MaNn,
								TenNn = ba.ThongTinBn.DmngheNghiep.TenNn
							},
						},
					}).FirstOrDefault(x => x.Idba == idba);
			List<string> fields = new List<string>(){
				"SoYTe",
				"BenhVien",
				"So",
				"QuyenSo",
				"CoSoKhamBenh",
				"DiaChi",
				"ThongBao",
				"HoTen",
				"NgaySinh",
				"GioiTinh",
				"DanToc",
				"QuocTich",
				"NoiTamTru",
				"MaSoDinhDanhCaNhan",
				"GiayToTuyThan",
				"NgayCap",
				"NoiCap",
				"TuVongLuc",
				"NgayTuVong",
				"NguyenNhanTuVong",
				"HoTenNguoiThanThich",
				"HoTenNguoiGhiGiay",
				"ThuTruong",
				"SoLanDau",
				"QuyenSoLanDau",
			};
			// var giayBaoTu = _benhAnTvPhieuCdnguyenNhanRepository._context.BenhAnTvGiayBaoTu.FirstOrDefault(x => x.Idba == idba);
			// if (giayBaoTu == null)
			// {
			// 	throw new HttpStatusException(HttpStatusCode.NotFound, "Không có dữ liệu");
			// }
			//CoTuVongKhiCapCuu
			List<string> values = new List<string>(){
				PrintSetting.SoYTe,
				PrintSetting.BenhVien,
				"", //SoGiayBaoTu
				"", //QuyenSoLanDau,
				"", //Cơ sở khám bệnh
				PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
				"", // Thông báo
				dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
				PrintHelper.DateTextShortest(dataBenhAn.BenhNhan.NgaySinh),
				Convert.ToBoolean(dataBenhAn.BenhNhan.GioiTinh) ? "Nam" : "Nữ",
				dataBenhAn.BenhNhan.DanToc.TenDanToc,
				dataBenhAn.BenhNhan.QuocGia.TenQg,
				"", // Nơi tạm trú
				"", // Mã số định danh
				dataBenhAn.BenhNhan.Cmnd,
				PrintHelper.DateTextShortest(dataBenhAn.BenhNhan.NgayCapCmnd),
				dataBenhAn.BenhNhan.NoiCapCmnd,
				PrintHelper.TimeText(bienBan.NgayTuVong),
				PrintHelper.DateText(bienBan.NgayTuVong),
				bienBan.NguyenNhanTv,
				"", // người thân thích
				"", //ghi giay
				"", //thu truong
				"", //SoGiayBaoTuLanDau,
				"", //QuyenSoLanDau
			};
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "CoTuVongKhiCapCuu", "0", new string[] { "1", "2" });
			string path = PrintHelper.PrintFile<BenhAnDto>(_hostingEnvironment, "GiayBaoTu.doc", fields, values);
			return path;
		}

		public string KiemDiemTuVongPrint(decimal idba)
		{
			var dataBenhAn = _benhAnTvPhieuCdnguyenNhanRepository._context.BenhAn
			.Select(ba => new BenhAnDetailDto()
			{
				Idba = ba.Idba,
				SoVaoVien = ba.SoVaoVien,
				NgayVv = ba.NgayVv,
				BenhNhan = new BenhAnDetailThongTinBnDto()
				{
					MaBn = ba.ThongTinBn.MaBn,
					Idba = ba.ThongTinBn.Idba,
					HoTen = ba.ThongTinBn.HoTen,
					NgaySinh = ba.ThongTinBn.NgaySinh,
					GioiTinh = ba.ThongTinBn.GioiTinh,
					Tuoi = ba.ThongTinBn.Tuoi,
					NoiLamViec = ba.ThongTinBn.NoiLamViec,
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
					DanToc = new DmdanTocDto()
					{
						MaDanToc = ba.ThongTinBn.DmdanToc.MaDanToc,
						TenDanToc = ba.ThongTinBn.DmdanToc.TenDanToc
					},
					QuocGia = new DmquocGiaDto()
					{
						MaQg = ba.ThongTinBn.DmquocGia.MaQg,
						TenQg = ba.ThongTinBn.DmquocGia.TenQg
					},
					HoTenCha = ba.ThongTinBn.HoTenCha,
					HoTenMe = ba.ThongTinBn.HoTenMe,
					NguoiGiamHo = ba.ThongTinBn.NguoiGiamHo,
					Cmnd = ba.ThongTinBn.Cmnd,
					NoiCapCmnd = ba.ThongTinBn.NoiCapCmnd,
					NgayCapCmnd = ba.ThongTinBn.NgayCapCmnd,
					NgheNghiep = new DmngheNghiepDto()
					{
						MaNn = ba.ThongTinBn.DmngheNghiep.MaNn,
						TenNn = ba.ThongTinBn.DmngheNghiep.TenNn
					},
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var bienBan = DetailBienBanKiemDiem(idba);
			var thanhVienThamGia = GetThanhVienThamGia(new BenhAnThongTinTuVongParameters()
			{
				Idba = idba
			}).ToList();
			List<string> fields = new List<string>(){
				"HomNayNgay",
				"HomNayGio",
				"chungtoigom",
				"hoptai",
				"chutoa",
				"thuky",
				"hoten",
				"tuoi",
				"GioiTinh",
				"dantoc",
				"ngoaikieu",
				"nghenghiep",
				"noilamviec",
				"diachi",
				"sovaovien",
				"cmnd",
				"ngaynoicap",
				"GioVaoVien",
				"NgayVaoVien",
				"GioTuVong",
				"NgayTuVong",
				"taikhoa",
				"nn",
				"tomtat",
				"tinhtrangravien",
				"chuandoan",
				"TomTatDienBienBenh",
				"tiepdonnguoibenh",
				"thamvakhambenh",
				"dieutri",
				"chamsoc",
				"moiquanhe",
				"ykienbosung",
				"ketluan",

			};
			List<string> values = new List<string>(){
				PrintHelper.TimeText(bienBan?.ThoiGianKiemDiem),
				PrintHelper.DateText(bienBan?.ThoiGianKiemDiem),
				thanhVienThamGia.Select(x => $"{x.ThanhVien.HoTen} - {x.VaiTro}").Aggregate("", (acc, x) => acc + $", {x}"),
				bienBan?.NoiHop,
				bienBan?.ChuToa?.HoTen,
				bienBan?.ThuKy?.HoTen,
				dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
				dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
				Convert.ToBoolean(dataBenhAn?.BenhNhan?.GioiTinh) ? "Nam" : "Nữ",
				dataBenhAn?.BenhNhan?.DanToc?.TenDanToc,
				dataBenhAn?.BenhNhan?.QuocGia?.TenQg,
				dataBenhAn?.BenhNhan?.NgheNghiep?.TenNn,
				dataBenhAn?.BenhNhan?.NoiLamViec,
                PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
				dataBenhAn?.SoVaoVien,
				dataBenhAn?.BenhNhan?.Cmnd,
				$"{PrintHelper.DateTextShort(dataBenhAn?.BenhNhan?.NgayCapCmnd)}, {dataBenhAn?.BenhNhan?.NoiCapCmnd}",
				PrintHelper.TimeText(dataBenhAn?.NgayVv),
				PrintHelper.DateText(dataBenhAn?.NgayVv),
				PrintHelper.TimeText(bienBan?.NgayTuVong),
				PrintHelper.DateText(bienBan?.NgayTuVong),
				bienBan?.KhoaDieuTri?.Khoa?.TenKhoa,
				bienBan?.NguyenNhanTv,
				bienBan?.TomTatQtbenh,
				bienBan?.TinhTrangVv,
				bienBan?.ChanDoan,
				bienBan?.TomTatDienBien,
				bienBan?.TiepDonBn,
				bienBan?.ThamKham,
				bienBan?.DieuTri,
				bienBan?.ChamSoc,
				bienBan?.QuanHeVoiGdbn,
				bienBan?.YkienBoSung,
				bienBan?.KetLuan
			};
			var thanhViens = thanhVienThamGia.Select(x => new ThanhVien
			{
				Ten = x.ThanhVien.HoTen,
				VaiTro = x.VaiTro
			}).ToList();
			string path = PrintHelper.PrintFile<ThanhVien>(_hostingEnvironment, "Kiem-Diem-Tu-Vong.doc", fields, values, thanhViens, "ThanhVien");
			return path;
		}

		public void StoreBienBanKiemDiem(BenhAnTvBbkiemDiemCreateVM benhAnTvBbkiemDiemVM)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnTvBbkiemDiemVM.Idba);
			var khoaDieuTri = _benhAnRepository._context.BenhAnKhoaDieuTri.Where(x => x.Idba == benhAnTvBbkiemDiemVM.Idba).OrderByDescending(x => x.NgayVaoKhoa).First();
			benhAnTvBbkiemDiemVM.MaBa = benhAn.MaBa;
			benhAnTvBbkiemDiemVM.MaBn = benhAn.MaBn;
			benhAnTvBbkiemDiemVM.Sttkhoa = khoaDieuTri.Stt;
			benhAnTvBbkiemDiemVM.MaKhoa = khoaDieuTri.MaKhoa;

			_benhAnTvBbkiemDiemRepository.Insert(benhAnTvBbkiemDiemVM);
		}

		public void UpdateBienBanKiemDiem(decimal idba, BenhAnTvBbkiemDiemVM benhAnTvBbkiemDiemVM)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnTvBbkiemDiemRepository.Update(benhAnTvBbkiemDiemVM, idba);
		}

		public void DestroyBienBanKiemDiem(decimal idba)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnTvBbkiemDiemRepository.Delete(idba);
		}
		#endregion

		#region Thanh vien tham gia
		public IQueryable<BenhAnTvBbkiemDiemTvDto> GetThanhVienThamGia(BenhAnThongTinTuVongParameters parameters, UserSession user = null)
		{
			var query = _benhAnTvBbkiemDiemTvRepository.Table.AsQueryable();

			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			if (parameters.Huy.HasValue)
			{
				query = query.Where(x => x.Huy == parameters.Huy);
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);
			return query.Select(x => new BenhAnTvBbkiemDiemTvDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				ThanhVien = new DmnhanVienDto()
				{
					MaNv = x.DmThanhVien.MaNv,
					HoTen = x.DmThanhVien.HoTen
				},
				VaiTro = x.VaiTro,
				Huy = x.Huy,
				NgayHuy = x.NgayHuy,
				NguoiHuy = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiHuy.MaNv,
					HoTen = x.DmNguoiHuy.HoTen
				}
			});
		}
		public void StoreThanhVienThamGia(BenhAnTvBbkiemDiemTvCreateVM benhAnTvBbkiemDiemTvVM)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnTvBbkiemDiemTvVM.Idba);
			benhAnTvBbkiemDiemTvVM.Stt = (byte)((_benhAnTvBbkiemDiemTvRepository.Table.Where(x => x.Idba == benhAnTvBbkiemDiemTvVM.Idba).Max(x => (byte?)x.Stt) ?? 0) + 1);
			_benhAnTvBbkiemDiemTvRepository.Insert(benhAnTvBbkiemDiemTvVM);
		}

		public void UpdateThanhVienThamGia(decimal idba, int stt, BenhAnTvBbkiemDiemTvVM BenhAnTvBbkiemDiemTvVM)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnTvBbkiemDiemTvRepository.Update(BenhAnTvBbkiemDiemTvVM, idba, stt);
		}

		public void DestroyThanhVienThamGia(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnTvBbkiemDiemTvRepository.Delete(idba, stt);
		}
		#endregion

		#region Chan doan nguyen nhan
		public BenhAnTvPhieuCdnguyenNhanDto DetailChanDoanNguyenNhan(decimal idba)
		{
			var chanDoanNguyenNhanQuery = _benhAnTvPhieuCdnguyenNhanRepository.Table.Where(x => x.Idba == idba);
			var benhAn = _benhAnRepository.GetById(idba);
			return chanDoanNguyenNhanQuery.Select(x => new BenhAnTvPhieuCdnguyenNhanDto()
			{
				Idba = x.Idba,
				SoPhieu = x.SoPhieu,
				NgayTv = x.NgayTv ?? benhAn.NgayTuVong,
				NguyenNhanA = x.NguyenNhanA,
				ThoiGianA = x.ThoiGianA,
				NguyenNhanB = x.NguyenNhanB,
				ThoiGianB = x.ThoiGianB,
				NguyenNhanC = x.NguyenNhanC,
				ThoiGianC = x.ThoiGianC,
				NguyenNhanD = x.NguyenNhanD,
				ThoiGianD = x.ThoiGianD,
				NguyenNhan2 = x.NguyenNhan2,
				ThoiGian2 = x.ThoiGian2,
				PhauThuat = x.PhauThuat,
				NgayPhauThuat = x.NgayPhauThuat,
				LyDoPt = x.LyDoPt,
				Kntt = x.Kntt,
				Sdkq = x.Sdkq,
				HinhThucTv = x.HinhThucTv,
				NgayChanThuong = x.NgayChanThuong,
				NguyenNhanChanThuong = x.NguyenNhanChanThuong,
				MoTaNguyenNhanChanThuong = x.MoTaNguyenNhanChanThuong,
				NoiTuVong = x.NoiTuVong,
				NoiTv = x.NoiTv,
				DaThai = x.DaThai,
				SinhNon = x.SinhNon,
				GioSongSauSinh = x.GioSongSauSinh,
				CanNang = x.CanNang,
				SoTuanMangThai = x.SoTuanMangThai,
				TuoiMe = x.TuoiMe,
				ChuSinh = x.ChuSinh,
				MangThai = x.MangThai,
				ThoiDiemMangThai = x.ThoiDiemMangThai,
				MangThaiGayTv = x.MangThaiGayTv,
				Tvcc = x.Tvcc,
				ChanDoan = new DmbenhTatDto()
				{
					MaBenh = x.DmbenhTat.MaBenh,
					TenBenh = x.DmbenhTat.TenBenh
				},
				TenNntv = x.TenNntv,
				NguoiLapPhieu = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiLapPhieu.MaNv,
					HoTen = x.DmNguoiLapPhieu.HoTen
				},
				Thutruong = new DmnhanVienDto()
				{
					MaNv = x.DmThutruong.MaNv,
					HoTen = x.DmThutruong.HoTen
				},
				NgayKy = x.NgayKy
			}).FirstOrDefault();
		}

		public void StoreChanDoanNguyenNhan(BenhAnTvPhieuCdnguyenNhanCreateVM benhAnTvPhieuCdnguyenNhanCreateVM)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnTvPhieuCdnguyenNhanCreateVM.Idba);
			benhAnTvPhieuCdnguyenNhanCreateVM.MaBa = benhAn.MaBa;
			benhAnTvPhieuCdnguyenNhanCreateVM.MaBn = benhAn.MaBn;

			_benhAnTvPhieuCdnguyenNhanRepository.Insert(benhAnTvPhieuCdnguyenNhanCreateVM);
		}

		public void UpdateChanDoanNguyenNhan(decimal idba, BenhAnTvPhieuCdnguyenNhanVM benhAnTvPhieuCdnguyenNhanVM)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnTvPhieuCdnguyenNhanRepository.Update(benhAnTvPhieuCdnguyenNhanVM, idba);
		}

		public void DestroyChanDoanNguyenNhan(decimal idba)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnTvPhieuCdnguyenNhanRepository.Delete(idba);
		}

		public string Print(decimal idba)
		{
			var chuanDoanNguyenNhan = DetailChanDoanNguyenNhan(idba);
			var dataBenhAn = _benhAnTvPhieuCdnguyenNhanRepository._context.BenhAn
			.Select(ba => new BenhAnDto()
			{
				Idba = ba.Idba,
				SoVaoVien = ba.SoVaoVien,
				BenhNhan = new ThongTinBnDto()
				{
					MaBn = ba.ThongTinBn.MaBn,
					Idba = ba.ThongTinBn.Idba,
					HoTen = ba.ThongTinBn.HoTen,
					NgaySinh = ba.ThongTinBn.NgaySinh,
					GioiTinh = ba.ThongTinBn.GioiTinh,
				},
			}).FirstOrDefault(x => x.Idba == idba);
			List<string> fields = new List<string>(){
				"HoTen",
				"MaSoNguoiBenh",
				"NguyenNhanTuVongA",
				"KhoangThoiGianA",
				"NguyenNhanTuVongB",
				"KhoangThoiGianB",
				"NguyenNhanTuVongC",
				"KhoangThoiGianC",
				"NguyenNhanTuVongD",
				"KhoangThoiGianD",
				"NguyenNhanTuVong",
				"KhoangThoiGian",
				"LyDoPhaiPhauThuat",
				"GioiTinh_0",
				"GioiTinh_1",
				"GioiTinh_2",
				"MoTaNguyenNhanChanThuong",
				"GhiRoDiaDiemKhac",
				"SoGioSongSotSauSinh",
				"SoTuanMangThaiCuaChuKy",
				"CanNangKhiSinh",
				"TuoiMe",
				"NeuLaChetChuSinh",
				"KetLuan",
				"MaICD",
				"NgayThang",
				"NguoiLapPhieu",
				"CoQuanToChuc"
			};
			List<string> values = new List<string>(){
				dataBenhAn?.BenhNhan?.HoTen,
				dataBenhAn?.BenhNhan?.MaBn,
				chuanDoanNguyenNhan?.NguyenNhanA,
				chuanDoanNguyenNhan?.ThoiGianA,
				chuanDoanNguyenNhan?.NguyenNhanB,
				chuanDoanNguyenNhan?.ThoiGianB,
				chuanDoanNguyenNhan?.NguyenNhanC,
				chuanDoanNguyenNhan?.ThoiGianC,
				chuanDoanNguyenNhan?.NguyenNhanD,
				chuanDoanNguyenNhan?.ThoiGianD,
				chuanDoanNguyenNhan?.NguyenNhan2,
				chuanDoanNguyenNhan?.ThoiGian2,
				chuanDoanNguyenNhan?.LyDoPt,
				dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "x" : "",
				dataBenhAn?.BenhNhan?.GioiTinh == 2 ? "x" : "",
				"",
				chuanDoanNguyenNhan?.NguyenNhanChanThuong,
				"", //Noi tu vong khac
				chuanDoanNguyenNhan?.GioSongSauSinh,
				chuanDoanNguyenNhan?.SoTuanMangThai,
				chuanDoanNguyenNhan?.CanNang,
				chuanDoanNguyenNhan?.TuoiMe,
				chuanDoanNguyenNhan?.ChuSinh,
				"",
				"",
				PrintHelper.DateText(chuanDoanNguyenNhan?.NgayTv),
				chuanDoanNguyenNhan?.NguoiLapPhieu?.HoTen,
				chuanDoanNguyenNhan?.Thutruong?.HoTen
			};
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "GioiTinh", dataBenhAn?.BenhNhan?.GioiTinh.ToString(), PrintHelper.CreateArrayIncreate(3));
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, PrintHelper.BirthText(dataBenhAn?.BenhNhan?.NgaySinh), "NS", 8, ' ');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, PrintHelper.BirthText(chuanDoanNguyenNhan?.NgayTv), "NT", 8, ' ');
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "PhauThuatCoDuocThucHien", chuanDoanNguyenNhan?.PhauThuat?.ToString(), PrintHelper.CreateArrayIncreate(3));
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, PrintHelper.BirthText(chuanDoanNguyenNhan?.NgayPhauThuat), "P", 8, ' ');
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "DaKhamNghiemTuThi", chuanDoanNguyenNhan?.Kntt?.ToString(), PrintHelper.CreateArrayIncreate(3));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "NNTV", chuanDoanNguyenNhan?.Sdkq?.ToString(), PrintHelper.CreateArrayIncreate(3));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "HinhThucTuVong", chuanDoanNguyenNhan?.HinhThucTv?.ToString(), PrintHelper.CreateArrayIncreate(9));
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, PrintHelper.BirthText(chuanDoanNguyenNhan?.NgayChanThuong), "T", 8, ' ');
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "NoiTuVong", chuanDoanNguyenNhan?.NoiTv, PrintHelper.CreateArrayIncreate(10));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "DaThai", chuanDoanNguyenNhan?.DaThai, PrintHelper.CreateArrayIncreate(3));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "SinhNon", chuanDoanNguyenNhan?.SinhNon, PrintHelper.CreateArrayIncreate(3));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "NguoiChetCoMangThaiKhong", chuanDoanNguyenNhan?.MangThai, PrintHelper.CreateArrayIncreate(3));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "ThoiDiemTuVong", chuanDoanNguyenNhan?.ThoiDiemMangThai, PrintHelper.CreateArrayIncreate(4));
			PrintHelper.OptionFieldHanlder(ref fields, ref values, "MangThaiCoGayTuVongKhong", chuanDoanNguyenNhan?.MangThaiGayTv, PrintHelper.CreateArrayIncreate(3));

			string path = PrintHelper.PrintFile<BenhAnDto>(_hostingEnvironment, "phieu-chuan-doan-tu-vong.docx", fields, values);
			return path;
		}
		#endregion
		private class ThanhVien
		{
			public string Ten { get; set; }
			public string VaiTro { get; set; }
		}
	}
}
