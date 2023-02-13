using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Dto.Print;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using static Medyx_EMR_BCA.ApiAssets.Helpers.PrintHelper;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnPhieuChamSocService
	{
		private IRepository<BenhAnPhieuChamSoc> _benhAnPhieuChamSocRepository = null;
		private readonly IHostingEnvironment _hostingEnvironment;
		private PrintSetting PrintSetting { get; set; }
		private UploadFileRespository _uploadFileRespository = new UploadFileRespository();
		public BenhAnPhieuChamSocService(IHostingEnvironment hostingEnvironment, IOptions<PrintSetting> options, IHttpContextAccessor accessor, UploadFileRespository uploadFileRespository = null)
		{
			_benhAnPhieuChamSocRepository = new GenericRepository<BenhAnPhieuChamSoc>(accessor);
			PrintSetting = options.Value;
			_hostingEnvironment = hostingEnvironment;
			_uploadFileRespository = uploadFileRespository;
		}
		public IQueryable<BenhAnPhieuChamSocDto> Get(BenhAnPhieuChamSocParameters parameters, UserSession user)
		{
			var query = _benhAnPhieuChamSocRepository.Table.AsQueryable();

			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}

			query = QueryFilter(query, parameters);
			query = SortHelper.ApplySort(query, parameters.SortBy);
			return query.Select(x => new BenhAnPhieuChamSocDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				Idhis = x.Idhis,
				MaBa = x.MaBa,
				Sttkhoa = x.Sttkhoa,
				KhoaDieuTri = new BenhAnKhoaDieuTriDto()
				{
					NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Khoa = new DmkhoaDto()
					{
						MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
						TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
					}
				},
				NgayChamSoc = x.NgayChamSoc,
				Huy = x.Huy,
				NgayLap = x.NgayLap,
				NgaySd = x.NgaySd,
				NgayHuy = x.NgayHuy,
				DieuDuong = new DmnhanVienDto()
				{
					MaNv = x.DmDieuDuong.MaNv,
					HoTen = x.DmDieuDuong.HoTen
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
			});
		}
		public BenhAnPhieuChamSocDetailDto Detail(decimal idba, int stt)
		{
			var query = _benhAnPhieuChamSocRepository.Table.AsQueryable();

			var queryBenhAnPhieuChamSocDetail = query.Select(x => new BenhAnPhieuChamSocDetailDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				Idhis = x.Idhis,
				MaBa = x.MaBa,
				Sttkhoa = x.Sttkhoa,
				KhoaDieuTri = new BenhAnKhoaDieuTriDto()
				{
					NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Khoa = new DmkhoaDto()
					{
						MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
						TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
					}
				},
				ChanDoan = x.ChanDoan,
				DiUng = x.DiUng,
				DiUngMota = x.DiUngMota,
				Thuoc = x.Thuoc,
				TienSuGiaDinh = x.TienSuGiaDinh,
				NgayChamSoc = x.NgayChamSoc,
				NgayChamSocLan = x.NgayChamSocLan,
				NgayChamSocBd = x.NgayChamSocBd,
				NgayChamSocKt = x.NgayChamSocKt,
				Mach = x.Mach,
				NhietDo = x.NhietDo,
				HuyetAp = x.HuyetAp,
				CanNang = x.CanNang,
				NhipTho = x.NhipTho,
				ChieuCao = x.ChieuCao,
				SpO2 = x.SpO2,
				DienBien = x.DienBien,
				Ylenh = x.Ylenh,
				Ythuc = x.Ythuc,
				TheTrang = x.TheTrang,
				Phu = x.Phu,
				PhuVitri = x.PhuVitri,
				PhuTinhChat = x.PhuTinhChat,
				DaNiemMac = x.DaNiemMac,
				TuanHoan = x.TuanHoan,
				TuanHoanTchatDauNguc = x.TuanHoanTchatDauNguc,
				HoHap = x.HoHap,
				HoHapSloxy = x.HoHapSloxy,
				HoHapTchatDom = x.HoHapTchatDom,
				HoHapDanLuu = x.HoHapDanLuu,
				TieuHoa = x.TieuHoa,
				TieuHoaVitriDauBung = x.TieuHoaVitriDauBung,
				DaiTien = x.DaiTien,
				SoLanTieuChay = x.SoLanTieuChay,
				MauSacTieuChay = x.MauSacTieuChay,
				TietNieu = x.TietNieu,
				TieuTien = x.TieuTien,
				TieuTienMauSac = x.TieuTienMauSac,
				TieuTienSoLuong = x.TieuTienSoLuong,
				TamThanKinh = x.TamThanKinh,
				TamThanKinhKhac = x.TamThanKinhKhac,
				TamLyNguoiBenh = x.TamLyNguoiBenh,
				Ngu = x.Ngu,
				NguThoiGian = x.NguThoiGian,
				VanDong = x.VanDong,
				VanDongTchatLiet = x.VanDongTchatLiet,
				CoXuongKhop = x.CoXuongKhop,
				VetThuongViTri = x.VetThuongViTri,
				VetThuong = x.VetThuong,
				VetThuongKhac = x.VetThuongKhac,
				VetThuongMotaDanLuu = x.VetThuongMotaDanLuu,
				VetThuongDanLuu = x.VetThuongDanLuu,
				VetThuongChanDanLuu = x.VetThuongChanDanLuu,
				NhanDinhKhac = x.NhanDinhKhac,
				CapCs = x.CapCs,
				ChanDoanChamSoc = x.ChanDoanChamSoc,
				HuongDanNoiQuy = x.HuongDanNoiQuy,
				TheoDoiDhst = x.TheoDoiDhst,
				VeSinhThanThe = x.VeSinhThanThe,
				ThucHienYlenh = x.ThucHienYlenh,
				ThuThuatTayY = x.ThuThuatTayY,
				GioTruyenDichBd = x.GioTruyenDichBd,
				GioTruyenDichKt = x.GioTruyenDichKt,
				KhiDungTanSo = x.KhiDungTanSo,
				TestDhmmGio = x.TestDhmmGio,
				TestDhmmSoLan = x.TestDhmmSoLan,
				ThuThuatDy = x.ThuThuatDy,
				ThuThuatDyVltl = x.ThuThuatDyVltl,
				ThuThuatDyThuoc = x.ThuThuatDyThuoc,
				ThayBang = x.ThayBang,
				ThayBangViTriThay = x.ThayBangViTriThay,
				VeSinhCaNhan = x.VeSinhCaNhan,
				Gdsk = x.Gdsk,
				ThucHienYlenhKhac = x.ThucHienYlenhKhac,
				XuTri = x.XuTri,
				Huy = x.Huy,
				NgayLap = x.NgayLap,
				NgaySd = x.NgaySd,
				NgayHuy = x.NgayHuy,
				DieuDuong = new DmnhanVienDto()
				{
					MaNv = x.DmDieuDuong.MaNv,
					HoTen = x.DmDieuDuong.HoTen
				},
				NguoiHuy = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiHuy.MaNv,
					HoTen = x.DmNguoiHuy.HoTen
				},
				NguoiLap = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiLap.MaNv,
					HoTen = x.DmNguoiLap.HoTen
				},
				NguoiSD = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiSD.MaNv,
					HoTen = x.DmNguoiSD.HoTen
				},

			});
			return queryBenhAnPhieuChamSocDetail.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);
		}
		private IQueryable<BenhAnPhieuChamSoc> QueryFilter(IQueryable<BenhAnPhieuChamSoc> query, BenhAnPhieuChamSocParameters parameters)
		{
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			return query;
		}
		public BenhAnPhieuChamSoc Store(BenhAnPhieuChamSocCreateVM benhAnPhieuChamSocVM)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnPhieuChamSocVM.Idba);
			var stt = (_benhAnPhieuChamSocRepository.Table.Where(x => x.Idba == benhAnPhieuChamSocVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
			var khoaDieuTri = _benhAnPhieuChamSocRepository._context.BenhAnKhoaDieuTri.First(x => x.Idba == benhAnPhieuChamSocVM.Idba && x.Stt == benhAnPhieuChamSocVM.Sttkhoa);

			benhAnPhieuChamSocVM.MaBa = benhAn.MaBa;
			// benhAnPhieuChamSocVM.Idhis = "";
			benhAnPhieuChamSocVM.Stt = stt;
			benhAnPhieuChamSocVM.MaKhoa = khoaDieuTri.MaKhoa;

			_benhAnPhieuChamSocRepository.Insert(benhAnPhieuChamSocVM);

			return _benhAnPhieuChamSocRepository.GetById(benhAnPhieuChamSocVM.Idba, stt);
		}

		public void Update(decimal idba, int stt, BenhAnPhieuChamSocVM benhAnPhieuChamSocVM)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			var khoaDieuTri = _benhAnPhieuChamSocRepository._context.BenhAnKhoaDieuTri.First(x => x.Idba == idba && x.Stt == benhAnPhieuChamSocVM.Sttkhoa);

			benhAnPhieuChamSocVM.MaKhoa = khoaDieuTri.MaKhoa;
			_benhAnPhieuChamSocRepository.Update(benhAnPhieuChamSocVM, idba, stt);
		}

		public void Destroy(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_benhAnPhieuChamSocRepository.Delete(idba, stt);
		}
		public string Print(decimal idba, BenhAnChamSocPrintVM info)
		{
			// ☐,☑
			List<BenhAnChamSocPrintDto> BenhAnChamSocPrint = new List<BenhAnChamSocPrintDto>();
			var select = BenhAnPhieuChamSocDtoQuery();
			var benhAnChamSoc = _benhAnPhieuChamSocRepository.Table.Where(x => x.Idba == idba && info.Stt.Any(stt => stt == x.Stt)).OrderBy(x => x.NgayChamSoc).Select(select).ToList();
			var TienSuBanThan = _benhAnPhieuChamSocRepository._context.BenhAnKhamVaoVien.Where(x => x.Idba == idba).Select(x => x.TienSuBanThan).SingleOrDefault();
			var benhAn = _benhAnPhieuChamSocRepository._context.BenhAn
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
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var maParent = new string[] { "157", "177", "173", "174", "175", "176", "140", "146", "178", "142", "144", "181", "179", "180", "181", "184", "154", "155", "185", "158", "186", "187", "188", "189", "190", "153", "160" };
			var comboDs = _benhAnPhieuChamSocRepository._context.DmbaCombods.Where(x => maParent.Contains(x.MaParent)).OrderBy(x => x.MaParent).ToList();

			BenhAnChamSocPrint.Add(new BenhAnChamSocPrintDto()
			{
				BenhVien = PrintSetting.BenhVien,
				Khoa = benhAnChamSoc.Count > 0 ? benhAnChamSoc[0].Khoa.TenKhoa : "",
				MaSoVV = benhAn.SoVaoVien,
				NgaySinh = benhAn.BenhNhan.NgaySinh.ToString("dd/MM/yyyy"),
				GioiTinh = benhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
				HoTen = benhAn.BenhNhan.HoTen,
				TenKhoa = benhAnChamSoc.Count > 0 ? benhAnChamSoc[0].KhoaDieuTri.Khoa.TenKhoa : "",
				NgayVaoKhoa = benhAnChamSoc.Count > 0 ? benhAnChamSoc[0].KhoaDieuTri.NgayVaoKhoa?.ToString("dd/MM/yyyy") : "",
				ChanDoan = benhAnChamSoc.Count > 0 ? $"{benhAnChamSoc[0]?.KhoaDieuTri?.BenhChinh?.MaBenh} {benhAnChamSoc[0]?.KhoaDieuTri?.BenhChinh?.TenBenh}" : "",
				TienSuGiaDinh = benhAnChamSoc.Count > 0 ? benhAnChamSoc[0].TienSuGiaDinh : "",
				TienSuBanThan = TienSuBanThan,
				ChiTietBenhAnChamSocs = new List<ChiTietBenhAnChamSocPrintDto>()
			});

			foreach (var item in benhAnChamSoc)
			{

				var dataP = new ChiTietBenhAnChamSocPrintDto()
				{
					NgayGio = item.NgayChamSoc.HasValue ? item.NgayChamSoc.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
					TuNgay = item.NgayChamSocBd.HasValue ? item.NgayChamSocBd.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
					DenNgay = item.NgayChamSocKt.HasValue ? item.NgayChamSocKt.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
					DieuDuong = item.DieuDuong.HoTen,
					NgayChamSocThu = item.NgayChamSocLan.HasValue ? item.NgayChamSocLan.Value.ToString() : "",
					HtmlYThuc = PrintHelper.StringOptionHanlder("- Ý thức: ", item.Ythuc, GetOptionCombos(comboDs, item.CapCs == 1 ? "173" : "174")),
					HtmlTheTrang = PrintHelper.StringOptionHanlder("- Thể trạng:", item.TheTrang, GetOptionCombos(comboDs, item.CapCs == 1 ? "175" : "176")),
					CanNang = item.CanNang.HasValue ? item.CanNang.Value.ToString() : "",
					ChieuCao = item.ChieuCao.HasValue ? item.ChieuCao.Value.ToString() : "",
					HtmlPhu = PrintHelper.StringOptionHanlder("- Phù: ", item.Phu, new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "Phù",
								Ma = "Phù"
							},
							new OptionsBAComboDs(){
								Ten = "Cổ chướng",
								Ma = "Cổ chướng"
							}
						},
						new List<OptionExtra>(){
							new OptionExtra(){
								Ten = "phù",
								Content = $", Vị trí phù: {item.PhuVitri}, tính chất phù {item.PhuTinhChat}"
							}
					    }
                    ),
					ViTriPhu = item.PhuVitri,
					TinhChatPhu = item.PhuTinhChat,
					HtmlDaNiemMac = PrintHelper.StringOptionHanlder("- Da, niêm mạc:", item.DaNiemMac, GetOptionCombos(comboDs, "140")),
					HtmlTuanHoan = PrintHelper.StringOptionHanlder("", item.TuanHoan, new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "Bình thường",
								Ma = "Bình thường"
							},
							new OptionsBAComboDs(){
								Ten = "Đau ngực",
								Ma = "Đau ngực"
							},
						}
					),
					HuyetAp = item.HuyetAp,
					NhietDo = item.NhietDo.HasValue ? item.NhietDo.Value.ToString() : "",
					HtmlHoHap = PrintHelper.StringOptionHanlder("", item.TheTrang, GetOptionCombos(comboDs, item.CapCs == 1 ? "146" : "178")),
					TinhChatDom = item.HoHapTchatDom,
					HoHapDanLuu = item.HoHapDanLuu,
					HtmlTieuHoa = PrintHelper.StringOptionHanlder("", item.TieuHoa, GetOptionCombos(comboDs, "142")),
					ViTriDau = item.TieuHoaVitriDauBung,
					HtmlDaiTien = PrintHelper.StringOptionHanlder("", item.DaiTien, GetOptionCombos(comboDs, "144")),
					SoLan = item.SoLanTieuChay.HasValue ? item.SoLanTieuChay.Value.ToString() : "",
					TieuHoaMauSac = item.MauSacTieuChay,
					HtmlThanTietNieu = PrintHelper.StringOptionHanlder("", item.TietNieu, GetOptionCombos(comboDs, item.CapCs == 1 ? "181" : "179")),
					ThanMauSac = item.TieuTienMauSac,
					SoLuong = item.TieuTienSoLuong.HasValue ? item.TieuTienSoLuong.Value.ToString() : "",
					HtmlTamThanKinh = PrintHelper.StringOptionHanlder("", item.TamThanKinh, new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "BT",
								Ma = "1"
							}
						}),
					TamThanKinhKhac = item.TamThanKinhKhac,
					HtmlTamLyNguoiBenh = PrintHelper.StringOptionHanlder("", item.TamLyNguoiBenh, new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "Lo lắng",
								Ma = "1"
							},
							new OptionsBAComboDs(){
								Ten = "Không lo lắng",
								Ma = "2"
							},
							new OptionsBAComboDs(){
								Ten = "Không biết",
								Ma = "3"
							},
						}),
					HtmlNgu = PrintHelper.StringOptionHanlder("", item.Ngu, GetOptionCombos(comboDs, "181")),
					NguNgayGio = item.NguThoiGian.HasValue ? item.NguThoiGian.Value.ToString() : "",
					HtmlVanDong = PrintHelper.StringOptionHanlder("", item.VanDong, GetOptionCombos(comboDs, "157")),
					TinhChatLiet = item.VanDongTchatLiet,
					HtmlCoXuongKhop = PrintHelper.StringOptionHanlder("", item.CoXuongKhop, GetOptionCombos(comboDs, "184")),
					VetThuongMoViTri = item.VetThuongViTri,
					HtmlVetThuongMo = PrintHelper.StringOptionHanlder("", item.VetThuong, GetOptionCombos(comboDs, "154")),
					VetThuongMoKhac = item.VetThuongKhac,
					HtmlDanLuu = PrintHelper.StringOptionHanlder("", item.VetThuongDanLuu, GetOptionCombos(comboDs, "155")),
					ChanDanLuu = item.VetThuongChanDanLuu,
					NhanDinhKhac = item.NhanDinhKhac,
					HtmlCapChamSoc = item.CapCs == 1 ? PrintHelper.StringOptionHanlder("", item.CapCs.Value.ToString(), new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "Cấp I",
								Ma = "1"
							}
						}) : PrintHelper.StringOptionHanlder("", item.CapCs.Value.ToString(), new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "Cấp II",
								Ma = "2"
							},
							new OptionsBAComboDs(){
								Ten = "Cấp III",
								Ma = "3"
							},
						}),
					ChanDoanChamSoc = item.ChanDoanChamSoc,
					HtmlHuongDanNoiQuyThuTucNhapVien = PrintHelper.StringOptionCheckBoxHander(item.HuongDanNoiQuy),
					HtmlTheoDoiDauHieuSinhTon = PrintHelper.StringOptionCheckBoxHander(0),
					HtmlThucHienYLenhThuoc = PrintHelper.StringOptionHanlder("", item.ThucHienYlenh, GetOptionCombos(comboDs, "158")),
					HtmlTayY = PrintHelper.StringOptionHanlder("", item.ThuThuatTayY, GetOptionCombos(comboDs, item.CapCs == 1 ? "186" : "187"), new List<OptionExtra>(){
							new OptionExtra(){
								Ten = "truyền dịch",
								Content = ", giờ truyền dịch: " + (item.GioTruyenDichBd.HasValue ?  item.GioTruyenDichBd.Value.ToString("dd/MM/yyyy HH:mm:ss") : "") +", giờ kết thúc truyền dịch: " + (item.GioTruyenDichKt.HasValue ?  item.GioTruyenDichKt.Value.ToString("dd/MM/yyyy HH:mm:ss") : "")
							},
							new OptionExtra(){
								Ten = "khí dung",
								Content = $", tần số {item.KhiDungTanSo} 1/p"
							}
						}),
					GioTest = item.GioTruyenDichBd.HasValue ? item.GioTruyenDichBd.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
					SoLanTruyenDich = item.TestDhmmSoLan.HasValue ? item.TestDhmmSoLan.Value.ToString() : "",
					HtmlDongY = PrintHelper.StringOptionHanlder("", item.ThuThuatDy, GetOptionCombos(comboDs, "188"), new List<OptionExtra>(){
							new OptionExtra(){
								Ten = "vltl",
								Content = $": {item.ThuThuatDyVltl}"
							},
							new OptionExtra(){
								Ten = "ngâm thuốc yhct",
								Content = $": {item.ThuThuatDyThuoc}"
							}
						}),
					ViTriThayBang = item.ThayBangViTriThay,
					HtmlThayBang = PrintHelper.StringOptionHanlder("", item.ThayBang, GetOptionCombos(comboDs, item.CapCs == 1 ? "189" : "190")),
					HtmlVeSinhCaNhan = PrintHelper.StringOptionHanlder("", item.VeSinhCaNhan, new OptionsBAComboDs[]{
							new OptionsBAComboDs(){
								Ten = "Tự làm",
								Ma = "Tự làm"
							},
							new OptionsBAComboDs(){
								Ten = "Hỗ trợ",
								Ma = "Hỗ trợ"
							},
						}),
					// DinhDuong = PrintHelper.StringOptionHanlder(item., GetOptionCombos(comboDs, "153")),
					HtmlGDSK = PrintHelper.StringOptionHanlder("", item.Gdsk, GetOptionCombos(comboDs, "160")),
					ThucHienYLenhKhac = item.ThucHienYlenhKhac,
					XuTri = item.XuTri,
				};

				if (!string.IsNullOrEmpty(dataP.HtmlTheTrang))
				{
					dataP.HtmlTheTrang = $"{dataP.HtmlTheTrang}, cân nặng {dataP.CanNang}, chiều cao {dataP.ChieuCao}";
				}
				if (!string.IsNullOrEmpty(dataP.HtmlPhu))
				{
					dataP.HtmlPhu = $"{dataP.HtmlPhu}, Vị trí phù: {dataP.ViTriPhu}, tính chất phù {dataP.TinhChatPhu}, {dataP.CoChuong}";
				}
				BenhAnChamSocPrint[0].ChiTietBenhAnChamSocs.Add(dataP);

			}
			//- Thể trạng: 

			var dataset = DatasetHelper.ConvertToDataSet<BenhAnChamSocPrintDto>(BenhAnChamSocPrint);
			var list = new List<DictionaryEntry>();
			list.Add(new DictionaryEntry("BenhAnChamSocPrintDto", string.Empty));
			list.Add(new DictionaryEntry("ChiTietBenhAnChamSocPrintDto", "ParentID= %BenhAnChamSocPrintDto.ID%"));
			string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "BenhAnChamSocCap2_3.docx", dataset, list, null, null);
			return path;
		}

		public string SoDoPrint(decimal idba, BenhAnChamSocPrintVM info)
		{
			List<SoDoPhieuChamSocPrint> BenhAnChamSocPrint = new List<SoDoPhieuChamSocPrint>();
			var select = BenhAnPhieuChamSocDtoQuery();
			var benhAnChamSoc = _benhAnPhieuChamSocRepository.Table.Where(x => x.Idba == idba && info.Stt.Any(stt => stt == x.Stt)).OrderBy(x => x.BenhAnKhoaDieuTri.MaKhoa).ThenBy(x => x.NgayChamSoc).Select(select).ToList();
			var TienSuBanThan = _benhAnPhieuChamSocRepository._context.BenhAnKhamVaoVien.Where(x => x.Idba == idba).Select(x => x.TienSuBanThan).SingleOrDefault();
			var benhAn = _benhAnPhieuChamSocRepository._context.BenhAn
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
				},
			}).FirstOrDefault(x => x.Idba == idba);
			var count = 0;
			int index = -1;
			for (int k = 0; k < benhAnChamSoc.Count; k++)
			{
				var item = benhAnChamSoc[k];
				SoDoPhieuChamSocPrint newItem = null;

				if (index == -1)
				{
					newItem = new SoDoPhieuChamSocPrint()
					{
						MaKhoa = item.KhoaDieuTri.Khoa.MaKhoa,
						SoYTe = PrintSetting.SoYTe,
						BenhVien = PrintSetting.BenhVien,
						MaBn = benhAn.BenhNhan.MaBn,
						HoTen = benhAn.BenhNhan.HoTen,
						Tuoi = benhAn.BenhNhan.Tuoi.ToString(),
						Giuong = item.KhoaDieuTri.Giuong.TenGiuong,
						Buong = item.KhoaDieuTri.Buong.TenBuong,
						Khoa = item.KhoaDieuTri.Khoa.TenKhoa,
						NgayVV = PrintHelper.DateTextShort(benhAn.NgayVv),
						ChanDoan = !String.IsNullOrEmpty(item.KhoaDieuTri.BenhChinh.MaBenh) ? $"{item.KhoaDieuTri.BenhChinh.MaBenh} - {item.KhoaDieuTri.BenhChinh.TenBenh}" : "" ,
					};
					if (!String.IsNullOrEmpty(item.KhoaDieuTri.BenhKem1.MaBenh))
					{
						newItem.ChanKem = !String.IsNullOrEmpty(newItem.ChanKem) ? $"{newItem.ChanKem}  {item.KhoaDieuTri.BenhKem1.MaBenh}   {item.KhoaDieuTri.BenhKem1.TenBenh};" : $"{item.KhoaDieuTri.BenhKem1.MaBenh}   {item.KhoaDieuTri.BenhKem1.TenBenh};";
					}
					if (!String.IsNullOrEmpty(item.KhoaDieuTri.BenhKem2.MaBenh))
					{
						newItem.ChanKem = !String.IsNullOrEmpty(newItem.ChanKem) ? $"{newItem.ChanKem}  {item.KhoaDieuTri.BenhKem2.MaBenh}   {item.KhoaDieuTri.BenhKem2.TenBenh};" : $"{item.KhoaDieuTri.BenhKem2.MaBenh}   {item.KhoaDieuTri.BenhKem2.TenBenh};";
					}
					if (!String.IsNullOrEmpty(item.KhoaDieuTri.BenhKem2.MaBenh))
					{
						newItem.ChanKem = !String.IsNullOrEmpty(newItem.ChanKem) ? $"{newItem.ChanKem}  {item.KhoaDieuTri.BenhKem2.MaBenh}   {item.KhoaDieuTri.BenhKem2.TenBenh};" : $"{item.KhoaDieuTri.BenhKem2.MaBenh}   {item.KhoaDieuTri.BenhKem2.TenBenh};";
					}
					BenhAnChamSocPrint.Add(newItem);
					count = 0;
					index = BenhAnChamSocPrint.Count - 1;
				}
				if (BenhAnChamSocPrint[index] is INgayThangChamSoc ngayThang)
				{
					BenhAnChamSocPrint[index].GetType().GetProperty($"NgayThang_{count}").SetValue(BenhAnChamSocPrint[index], PrintHelper.DateTimeTextShort(item.NgayChamSoc));
				}
				if (BenhAnChamSocPrint[index] is IHuyetApChamSoc huyetAp)
				{
					BenhAnChamSocPrint[index].GetType().GetProperty($"HuyetAp_{count}").SetValue(BenhAnChamSocPrint[index], item.HuyetAp);
				}
				if (BenhAnChamSocPrint[index] is INhipThoChamSoc nhipTho)
				{
					BenhAnChamSocPrint[index].GetType().GetProperty($"NhipTho_{count}").SetValue(BenhAnChamSocPrint[index], item.NhipTho.ToString());
				}
				if (BenhAnChamSocPrint[index] is IYtaChamSoc yTa)
				{
					BenhAnChamSocPrint[index].GetType().GetProperty($"Yta_{count}").SetValue(BenhAnChamSocPrint[index], item.DieuDuong.HoTen);
				}
				if (count <= BenhAnChamSocPrint[index].NhietDo.Length - 1)
				{
					BenhAnChamSocPrint[index].NhietDo[count] = item.NhietDo;
					BenhAnChamSocPrint[index].Mach[count] = item.Mach;
				}

				count++;
				if (k < benhAnChamSoc.Count - 2)
				{
					index = BenhAnChamSocPrint.FindIndex(x => x.MaKhoa == benhAnChamSoc[k + 1].KhoaDieuTri.Khoa.MaKhoa);
				}

				if ((index == -1 && BenhAnChamSocPrint.Count > 0) || k == benhAnChamSoc.Count - 1)
				{
					BenhAnChamSocPrint[BenhAnChamSocPrint.Count - 1].SoDo = ImageDrawHelper.DrawImage(_hostingEnvironment, (g) =>
					{
						List<Point> pointMach = new List<Point>();
						List<Point> pointNhietDo = new List<Point>();
						for (int i = 0; i <= count - 1; i++)
						{
							var positionMach = Machhandler(BenhAnChamSocPrint[BenhAnChamSocPrint.Count - 1].Mach[i]);
							var positionNhietDo = NhietDohandler(BenhAnChamSocPrint[BenhAnChamSocPrint.Count - 1].NhietDo[i]);
							if (positionMach.HasValue)
							{
								pointMach.Add(new Point(ImageDrawHelper._defaultX + ImageDrawHelper._defaultIncreateX * i, ImageDrawHelper._defaultY + ImageDrawHelper._defaultIncreateY * positionMach.Value));
								ImageDrawHelper.DrawPoint(g, pointMach[pointMach.Count - 1].X, pointMach[pointMach.Count - 1].Y);
							}
							if (positionNhietDo.HasValue)
							{
								pointNhietDo.Add(new Point(ImageDrawHelper._defaultX + ImageDrawHelper._defaultIncreateX * i, ImageDrawHelper._defaultY + ImageDrawHelper._defaultIncreateY * positionNhietDo.Value));
								ImageDrawHelper.DrawPlus(g, pointNhietDo[pointNhietDo.Count - 1].X, pointNhietDo[pointNhietDo.Count - 1].Y);
							}
						}
						ImageDrawHelper.DrawLine(g, pointMach.ToArray());
						ImageDrawHelper.DrawLine(g, pointNhietDo.ToArray());
					}, 0, 0);
				}
			}
			var dataset = DatasetHelper.ConvertToDataSet<SoDoPhieuChamSocPrint>(BenhAnChamSocPrint);
			var list = new List<DictionaryEntry>();
			list.Add(new DictionaryEntry("SoDoPhieuChamSocPrint", string.Empty));
			string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "so-do-cham-soc-template.doc", dataset, list, null, null);
			foreach (var item in BenhAnChamSocPrint)
			{
				try
				{
					_uploadFileRespository.RemoveFile(item.SoDo, true);
				}
				catch (Exception ext)
				{

				}
			}
			return path;
		}
		private int? Machhandler(int? mach)
		{
			decimal machMax = 160;
			decimal machMin = 40;
			int heSoMin = 0;
			int heSoMax = 58;
			double number;
			if (!mach.HasValue)
            {
				return null;
			}
			if (mach >= machMax)
			{
				return heSoMin;
			}
			if (mach <= machMin)
			{
				return heSoMax;
			}
			if (Double.TryParse(mach.ToString(), out number))
			{
				return (int)Math.Round(((double)machMax - number) / 2);
			}
			return null;
		}
		private int? NhietDohandler(decimal? nhietDo)
		{
			decimal maxNhietDo = 41;
			decimal minNhietDo = 35;
            int heSoMin = 0;
            int heSoMax = 57;
			double number;
            if (!nhietDo.HasValue)
            {
				return null;
			}
			if (nhietDo >= maxNhietDo)
			{
				return heSoMin;
			}
			if (nhietDo <= minNhietDo)
			{
				return heSoMax;
			}
			if (Double.TryParse(nhietDo.ToString(), out number))
			{
				return (int)Math.Round(((double)maxNhietDo - number)) * 10;
			}
			return null;
		}
		public void MakeCopy(BenhAnPhieuChamSocSaoChepVM parameters)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
			var benhAnPhieuChamSoc = _benhAnPhieuChamSocRepository.Table
				.First(x => x.Idba == parameters.Idba && x.NgayChamSoc == parameters.NgaySaoChep);

			var stt = (_benhAnPhieuChamSocRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

			var phieuChamSocClone = (BenhAnPhieuChamSoc)_benhAnPhieuChamSocRepository._context.Entry(benhAnPhieuChamSoc).CurrentValues.ToObject();

			phieuChamSocClone.Stt = stt;
			// phieuChamSocClone.Idhis = "";
			phieuChamSocClone.NgayChamSoc = parameters.NgayChamSoc;

			_benhAnPhieuChamSocRepository.Insert(phieuChamSocClone);
		}

		private OptionsBAComboDs[] GetOptionCombos(List<DmbaCombods> comboDs, string maParent)
		{
			return comboDs.Where(x => x.MaParent == maParent).Select(x => new OptionsBAComboDs()
			{
				Ten = x.Ten,
				Ma = x.Ma
			}).ToArray();
		}
		private Expression<Func<BenhAnPhieuChamSoc, BenhAnPhieuChamSocDetailDto>> BenhAnPhieuChamSocDtoQuery()
		{
			return x => new BenhAnPhieuChamSocDetailDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				Idhis = x.Idhis,
				MaBa = x.MaBa,
				Sttkhoa = x.Sttkhoa,
				Khoa = new DmkhoaDto()
				{
					MaKhoa = x.Dmkhoa.MaKhoa,
					TenKhoa = x.Dmkhoa.TenKhoa,
				},
				ChanDoan = x.ChanDoan,
				DiUng = x.DiUng,
				DiUngMota = x.DiUngMota,
				Thuoc = x.Thuoc,
				TienSuGiaDinh = x.TienSuGiaDinh,
				NgayChamSoc = x.NgayChamSoc,
				NgayChamSocLan = x.NgayChamSocLan,
				NgayChamSocBd = x.NgayChamSocBd,
				NgayChamSocKt = x.NgayChamSocKt,
				Mach = x.Mach,
				NhietDo = x.NhietDo,
				HuyetAp = x.HuyetAp,
				CanNang = x.CanNang,
				NhipTho = x.NhipTho,
				ChieuCao = x.ChieuCao,
				SpO2 = x.SpO2,
				DienBien = x.DienBien,
				Ylenh = x.Ylenh,
				Ythuc = x.Ythuc,
				TheTrang = x.TheTrang,
				Phu = x.Phu,
				PhuVitri = x.PhuVitri,
				PhuTinhChat = x.PhuTinhChat,
				DaNiemMac = x.DaNiemMac,
				TuanHoan = x.TuanHoan,
				TuanHoanTchatDauNguc = x.TuanHoanTchatDauNguc,
				HoHap = x.HoHap,
				HoHapSloxy = x.HoHapSloxy,
				HoHapTchatDom = x.HoHapTchatDom,
				HoHapDanLuu = x.HoHapDanLuu,
				TieuHoa = x.TieuHoa,
				TieuHoaVitriDauBung = x.TieuHoaVitriDauBung,
				DaiTien = x.DaiTien,
				SoLanTieuChay = x.SoLanTieuChay,
				MauSacTieuChay = x.MauSacTieuChay,
				TietNieu = x.TietNieu,
				TieuTien = x.TieuTien,
				TieuTienMauSac = x.TieuTienMauSac,
				TieuTienSoLuong = x.TieuTienSoLuong,
				TamThanKinh = x.TamThanKinh,
				TamThanKinhKhac = x.TamThanKinhKhac,
				TamLyNguoiBenh = x.TamLyNguoiBenh,
				Ngu = x.Ngu,
				NguThoiGian = x.NguThoiGian,
				VanDong = x.VanDong,
				VanDongTchatLiet = x.VanDongTchatLiet,
				CoXuongKhop = x.CoXuongKhop,
				VetThuongViTri = x.VetThuongViTri,
				VetThuong = x.VetThuong,
				VetThuongKhac = x.VetThuongKhac,
				VetThuongMotaDanLuu = x.VetThuongMotaDanLuu,
				VetThuongDanLuu = x.VetThuongDanLuu,
				VetThuongChanDanLuu = x.VetThuongChanDanLuu,
				NhanDinhKhac = x.NhanDinhKhac,
				CapCs = x.CapCs,
				ChanDoanChamSoc = x.ChanDoanChamSoc,
				HuongDanNoiQuy = x.HuongDanNoiQuy,
				TheoDoiDhst = x.TheoDoiDhst,
				VeSinhThanThe = x.VeSinhThanThe,
				ThucHienYlenh = x.ThucHienYlenh,
				ThuThuatTayY = x.ThuThuatTayY,
				GioTruyenDichBd = x.GioTruyenDichBd,
				GioTruyenDichKt = x.GioTruyenDichKt,
				KhiDungTanSo = x.KhiDungTanSo,
				TestDhmmGio = x.TestDhmmGio,
				TestDhmmSoLan = x.TestDhmmSoLan,
				ThuThuatDy = x.ThuThuatDy,
				ThuThuatDyVltl = x.ThuThuatDyVltl,
				ThuThuatDyThuoc = x.ThuThuatDyThuoc,
				ThayBang = x.ThayBang,
				ThayBangViTriThay = x.ThayBangViTriThay,
				VeSinhCaNhan = x.VeSinhCaNhan,
				Gdsk = x.Gdsk,
				ThucHienYlenhKhac = x.ThucHienYlenhKhac,
				XuTri = x.XuTri,
				Huy = x.Huy,
				NgayLap = x.NgayLap,
				NgaySd = x.NgaySd,
				NgayHuy = x.NgayHuy,
				DieuDuong = new DmnhanVienDto()
				{
					MaNv = x.DmDieuDuong.MaNv,
					HoTen = x.DmDieuDuong.HoTen
				},
				NguoiHuy = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiHuy.MaNv,
					HoTen = x.DmNguoiHuy.HoTen
				},
				NguoiLap = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiLap.MaNv,
					HoTen = x.DmNguoiLap.HoTen
				},
				NguoiSD = new DmnhanVienDto()
				{
					MaNv = x.DmNguoiSD.MaNv,
					HoTen = x.DmNguoiSD.HoTen
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
					},
					Buong = new DmkhoaBuongDto()
					{
						MaBuong = x.BenhAnKhoaDieuTri.DmkhoaBuong.MaBuong,
						TenBuong = x.BenhAnKhoaDieuTri.DmkhoaBuong.TenBuong
					},
					Giuong = new DmkhoaGiuongDto()
					{
						MaGiuong = x.BenhAnKhoaDieuTri.DmkhoaGiuong.MaGiuong,
						TenGiuong = x.BenhAnKhoaDieuTri.DmkhoaGiuong.TenGiuong
					},
					BenhChinh = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhChinh.TenBenh
					},
					BenhKem1 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem1.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem1.TenBenh
					},
					BenhKem2 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem2.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem2.TenBenh
					},
					BenhKem3 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem3.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem3.TenBenh
					},
				} : new BenhAnKhoaDieuTriDto()
			};
		}
	}
}
