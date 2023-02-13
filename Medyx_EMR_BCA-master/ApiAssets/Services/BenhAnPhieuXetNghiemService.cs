using Medyx.ApiAssets.Dto.Print;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
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
using System.Linq;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnPhieuXetNghiemService
	{
		private IRepository<BenhanClsKqcs> _repository = null;
		private PrintSetting PrintSetting { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IHttpContextAccessor _accessor;
		public BenhAnPhieuXetNghiemService(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment, IOptions<PrintSetting> options = null)
		{
			_repository = new GenericRepository<BenhanClsKqcs>(accessor);
			PrintSetting = options != null ? options.Value : new PrintSetting();
			_hostingEnvironment = hostingEnvironment;
			_accessor = accessor;

		}

		public IQueryable<BenhAnPhieuXetNghiemDto> Get(BenhAnPhieuXetNghiemParameters parameters, UserSession user = null)
		{
			var query = xetNghiemPrintQuery(parameters.Idba, new PrintParameters()
			{
				Stt = new List<int>() { parameters.Sttdv }
			}, false);

			query = SortHelper.ApplySort(query, parameters.SortBy);
			return query.OrderByDescending(x => x.Stt);
		}

		/*public BenhAnPhieuXetNghiemDto Detail(decimal idba, int stt)
        {
            
        }*/

		public void CreateOrUpdate(BenhAnPhieuXetNghiemVM parameters)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);

			var benhAnPhieuXetNghiem = _repository.Table.Where(x => x.Idba == parameters.Idba && x.Stt == parameters.Stt).FirstOrDefault();

			if (benhAnPhieuXetNghiem == null)
			{
				var benhAn = _repository._context.BenhAn.First(x => x.Idba == parameters.Idba);
				var stt = (_repository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
				parameters.MaBa = benhAn.MaBa;
				parameters.MaBn = benhAn.MaBn;
				parameters.Stt = stt;
				_repository.Insert(parameters, (model) =>
				{
					PermissionThrowHelper.IDHISCheck(model.Idhis);
				});
			}
			else
			{
				parameters.MaBa = benhAnPhieuXetNghiem.MaBa;
				parameters.MaBn = benhAnPhieuXetNghiem.MaBn;
				_repository.Update(parameters, (model) =>
				{
					PermissionThrowHelper.IDHISCheck(model.Idhis);
				}, parameters.Idba, parameters.Stt);
			}
		}

		public void Destroy(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			_repository.Delete(idba, stt);
		}
		private IQueryable<BenhAnPhieuXetNghiemDto> xetNghiemPrintQuery(decimal idba, PrintParameters parameters, bool isPrint = true)
		{
			var user = SessionHelper.GetObjectFromJson<UserSession>(_accessor.HttpContext.Session, "UserProfileSessionData");


			var query = from cls_detail in _repository._context.BenhanCls
						join benhAn_khoaDieuTri in (
							from khoadieutri in _repository._context.BenhAnKhoaDieuTri
							join dmkhoa in _repository._context.Dmkhoa on khoadieutri.MaKhoa equals dmkhoa.MaKhoa into kdt_khoa_jp
							from khoa in kdt_khoa_jp.DefaultIfEmpty()
							join dmbuong in _repository._context.DmkhoaBuong on new { b1 = khoadieutri.Buong, b2 = khoadieutri.MaKhoa } equals new { b1 = dmbuong.MaBuong, b2 = dmbuong.MaKhoa } into kdt_buong_jp
							from buong in kdt_buong_jp.DefaultIfEmpty()
							join dmgiuong in _repository._context.DmkhoaGiuong on new { g1 = khoadieutri.Giuong, g2 = khoadieutri.Buong, g3 = khoadieutri.MaKhoa } equals new { g1 = dmgiuong.MaGiuong, g2 = dmgiuong.MaGiuong, g3 = dmgiuong.MaKhoa } into kdt_giuong_jp
							from giuong in kdt_giuong_jp.DefaultIfEmpty()
							join dmbenhChinh in _repository._context.DmbenhTat on khoadieutri.MaBenhChinhVk equals dmbenhChinh.MaBenh into kdt_benhchinh_jp
							from benhChinh in kdt_benhchinh_jp.DefaultIfEmpty()
							join dmnhanvien in _repository._context.DmnhanVien on khoadieutri.BsdieuTri equals dmnhanvien.MaNv into kdt_nhanvien_jp
							from nhanvien in kdt_nhanvien_jp.DefaultIfEmpty()
							select new BenhAnKhoaDieuTriDto()
							{
								Idba = khoadieutri.Idba,
								Stt = khoadieutri.Stt,
								MaKhoa = khoadieutri.MaKhoa,
								NgayVaoKhoa = khoadieutri.NgayVaoKhoa,
								BsdieuTri = new DmnhanVienDto()
								{
									HoTen = nhanvien == null ? "" : nhanvien.HoTen,
									MaNv = nhanvien == null ? "" : nhanvien.MaNv
								},
								Khoa = new DmkhoaDto()
								{
									TenKhoa = khoa == null ? "" : khoa.TenKhoa,
									MaKhoa = khoa == null ? "" : khoa.MaKhoa,
								},
								Buong = new DmkhoaBuongDto()
								{
									MaBuong = buong == null ? "" : buong.MaBuong,
									TenBuong = buong == null ? "" : buong.TenBuong
								},
								Giuong = new DmkhoaGiuongDto()
								{
									MaGiuong = giuong == null ? "" : giuong.MaGiuong,
									TenGiuong = giuong == null ? "" : giuong.TenGiuong
								},
								BenhChinh = new DmbenhTatDto()
								{
									MaBenh = benhChinh == null ? "" : benhChinh.MaBenh,
									TenBenh = benhChinh == null ? "" : benhChinh.TenBenh
								},
							}
						) on new { k1 = cls_detail.Idba, k2 = cls_detail.Sttkhoa } equals new { k1 = benhAn_khoaDieuTri.Idba ?? 0, k2 = benhAn_khoaDieuTri.Stt } into kdt_jp
						from kdt in kdt_jp.DefaultIfEmpty()
						join dmbschidinh in _repository._context.DmnhanVien on cls_detail.Bschidinh equals dmbschidinh.MaNv into bschidinh_jp
						from bschidinh in bschidinh_jp.DefaultIfEmpty()
						join dvcs in _repository._context.DmdichVuCs on cls_detail.MaDv equals dvcs.MaDv
						//into dvcs_jp
						//from dvcs in dvcs_jp.DefaultIfEmpty()
						join dv in _repository._context.DmdichVu on cls_detail.MaDv equals dv.MaDv
						//into dv_jp
						//from dv in dv_jp.DefaultIfEmpty()
						join nhomInChiDinh in _repository._context.DmdichvuNhomInChiDinh on cls_detail.MaDv equals nhomInChiDinh.MaDv
						//into nhomchidinh_jp
						//from nhomInChiDinh in nhomchidinh_jp.DefaultIfEmpty()
						join cls_kqcs in
						 (
						   from cls_kqcs_detail in _repository._context.BenhanClsKqcs
						   join dmktv in _repository._context.DmnhanVien on cls_kqcs_detail.Ktv equals dmktv.MaNv into ktv_jp
						   from ktv in ktv_jp.DefaultIfEmpty()
						   join dmnguoiDuyetKq in _repository._context.DmnhanVien on cls_kqcs_detail.NguoiDuyetKq equals dmnguoiDuyetKq.MaNv into nguoiDuyetKq_jp
						   from nguoiDuyetKq in nguoiDuyetKq_jp.DefaultIfEmpty()
						   join dmkhoaThucHien in _repository._context.Dmkhoa on cls_kqcs_detail.MaKhoaThucHien equals dmkhoaThucHien.MaKhoa into khoaThucHien_jp
						   from khoaThucHien in khoaThucHien_jp.DefaultIfEmpty()
						   join dmnguoilap in _repository._context.DmnhanVien on cls_kqcs_detail.NguoiLap equals dmnguoilap.MaNv into dmnguoilap_jp
						   from nguoilap in dmnguoilap_jp.DefaultIfEmpty()
						   join dmnguoihuy in _repository._context.DmnhanVien on cls_kqcs_detail.NguoiHuy equals dmnguoihuy.MaNv into dmnguoihuy_jp
						   from nguoihuy in dmnguoihuy_jp.DefaultIfEmpty()
						   join dmnguoisd in _repository._context.DmnhanVien on cls_kqcs_detail.NguoiSd equals dmnguoisd.MaNv into dmnguoisd_jp
						   from nguoisd in dmnguoisd_jp.DefaultIfEmpty()
						   select new BenhAnClsKqcsV2Dto()
						   {
							   Idba = cls_kqcs_detail.Idba,
							   Sttdv = cls_kqcs_detail.Sttdv,
							   MaCs = cls_kqcs_detail.MaCs,
							   Stt = cls_kqcs_detail.Stt,
							   Idhis = cls_kqcs_detail.Idhis,
							   SoPhieu = cls_kqcs_detail.SoPhieu,
							   Kq = cls_kqcs_detail.Kq,
							   BatThuong = cls_kqcs_detail.BatThuong,
							   MaMayThucHien = cls_kqcs_detail.MaMayThucHien,
							   NgayTiepNhan = cls_kqcs_detail.NgayTiepNhan,
							   NgayTraKq = cls_kqcs_detail.NgayTraKq,
							   KetLuan = cls_kqcs_detail.KetLuan,
							   Idlis = cls_kqcs_detail.Idlis,
							   LinkPacsLis = cls_kqcs_detail.LinkPacsLis,
							   Huy = cls_kqcs_detail.Huy,
							   NgayLap = cls_kqcs_detail.NgayLap,
							   NgaySd = cls_kqcs_detail.NgaySd,
							   NgayHuy = cls_kqcs_detail.NgayHuy,
							   Ktv = new DmnhanVienDto
							   {
								   HoTen = ktv == null ? "" : ktv.HoTen,
								   MaNv = ktv == null ? "" : ktv.MaNv
							   },
							   NguoiDuyetKq = new DmnhanVienDto
							   {
								   HoTen = nguoiDuyetKq == null ? "" : nguoiDuyetKq.HoTen,
								   MaNv = nguoiDuyetKq == null ? "" : nguoiDuyetKq.MaNv
							   },
							   KhoaThucHien = new DmkhoaDto
							   {
								   MaKhoa = khoaThucHien == null ? "" : khoaThucHien.MaKhoa,
								   TenKhoa = khoaThucHien == null ? "" : khoaThucHien.TenKhoa
							   },
							   NguoiLap = new DmnhanVienDto
							   {
								   HoTen = nguoilap == null ? "" : nguoilap.HoTen,
								   MaNv = nguoilap == null ? "" : nguoilap.MaNv
							   },
							   NguoiHuy = new DmnhanVienDto
							   {
								   HoTen = nguoihuy == null ? "" : nguoihuy.HoTen,
								   MaNv = nguoihuy == null ? "" : nguoihuy.MaNv
							   },
							   NguoiSD = new DmnhanVienDto
							   {
								   HoTen = nguoisd == null ? "" : nguoisd.HoTen,
								   MaNv = nguoisd == null ? "" : nguoisd.MaNv
							   },
						   }
						)
						on new { c1 = cls_detail.Idba, c2 = cls_detail.Stt, c3 = dvcs.MaCs } equals new { c1 = cls_kqcs.Idba ?? 0, c2 = cls_kqcs.Sttdv ?? 0, c3 = cls_kqcs.MaCs } into jp
						from p in jp.DefaultIfEmpty()
						select new BenhAnPhieuXetNghiemDto()
						{
							Idba = cls_detail.Idba,
							Stt = p == null ? null : p.Stt,
							Sttdv = cls_detail.Stt,
							Idhis = p == null ? "" : p.Idhis,
							Capcuu = cls_detail.Capcuu,
							SoPhieu = p == null ? "" : p.SoPhieu,
							MaPhieu = nhomInChiDinh.MaPhieu,
							TenPhieu = nhomInChiDinh.TenPhieu,
							Sttin = nhomInChiDinh.Sttin,
							MaCs = dvcs.MaCs,
							uuid = System.Guid.NewGuid().ToString("N"),
                            NgayYlenh = cls_detail.NgayYlenh,
                            DichVu = new DmdichVuDto()
							{
								MaDv = dv.MaDv,
								TenDv = dv.TenDv,
							},
							DichVuCs = new DmdichVuCsDto()
							{
								MaCs = dvcs.MaCs,
								TenCs = dvcs.TenCs,
								ChisocaoNam = dvcs.ChisocaoNam,
								ChisothapNam = dvcs.ChisothapNam,
								ChisocaoNu = dvcs.ChisocaoNu,
								ChisothapNu = dvcs.ChisothapNu,
								DonViDo = dvcs.DonViDo
							},
							KhoaDieuTri = kdt != null ? new BenhAnKhoaDieuTriDto()
							{
								Idba = kdt.Idba,
								Stt = kdt.Stt,
								MaKhoa = kdt.MaKhoa,
								NgayVaoKhoa = kdt.NgayVaoKhoa,
								BsdieuTri = new DmnhanVienDto()
								{
									HoTen = kdt.BsdieuTri == null ? "" : kdt.BsdieuTri.HoTen,
									MaNv = kdt.BsdieuTri == null ? "" : kdt.BsdieuTri.MaNv
								},
								Khoa = new DmkhoaDto()
								{
									TenKhoa = kdt.Khoa == null ? "" : kdt.Khoa.TenKhoa,
									MaKhoa = kdt.Khoa == null ? "" : kdt.Khoa.MaKhoa,
								},
								Buong = new DmkhoaBuongDto()
								{
									MaBuong = kdt.Buong == null ? "" : kdt.Buong.MaBuong,
									TenBuong = kdt.Buong == null ? "" : kdt.Buong.TenBuong
								},
								Giuong = new DmkhoaGiuongDto()
								{
									MaGiuong = kdt.Giuong == null ? "" : kdt.Giuong.MaGiuong,
									TenGiuong = kdt.Giuong == null ? "" : kdt.Giuong.TenGiuong
								},
								BenhChinh = new DmbenhTatDto()
								{
									MaBenh = kdt.BenhChinh == null ? "" : kdt.BenhChinh.MaBenh,
									TenBenh = kdt.BenhChinh == null ? "" : kdt.BenhChinh.TenBenh
								},
							} : new BenhAnKhoaDieuTriDto(),
							Ktv = new DmnhanVienDto()
							{
								MaNv = p == null ? "" : p.Ktv.MaNv,
								HoTen = p == null ? "" : p.Ktv.HoTen
							},
							NguoiDuyetKq = new DmnhanVienDto()
							{
								MaNv = p == null ? "" : p.NguoiDuyetKq.MaNv,
								HoTen = p == null ? "" : p.NguoiDuyetKq.HoTen
							},
							KhoaThucHien = new DmkhoaDto()
							{
								MaKhoa = p == null ? "" : p.KhoaThucHien.MaKhoa,
								TenKhoa = p == null ? "" : p.KhoaThucHien.TenKhoa
							},
							BschiDinh = new DmnhanVienDto()
							{
								MaNv = bschidinh == null ? "" : bschidinh.MaNv,
								HoTen = bschidinh == null ? "" : bschidinh.HoTen,
							},
							NgayLap = p == null ? null : p.NgayLap,
							NgaySd = p == null ? null : p.NgaySd,
							NgayHuy = p == null ? null : p.NgayHuy,
							Kq = p == null ? null : p.Kq,
							BatThuong = p == null ? "" : p.BatThuong,
							MaMayThucHien = p == null ? "" : p.MaMayThucHien,
							NgayTraKq = p == null ? null : p.NgayTraKq,
							KetLuan = p == null ? "" : p.KetLuan,
							Idlis = p == null ? "" : p.Idlis,
							LinkPacsLis = p == null ? "" : p.LinkPacsLis,
							Huy = p == null ? null : p.Huy,
							NgayTiepNhan = p == null ? null : p.NgayTiepNhan,
							NguoiLap = new DmnhanVienDto()
							{
								MaNv = p == null ? "" : p.NguoiLap.MaNv,
								HoTen = p == null ? "" : p.NguoiLap.HoTen
							},
							NguoiHuy = new DmnhanVienDto()
							{
								MaNv = p == null ? "" : p.NguoiHuy.MaNv,
								HoTen = p == null ? "" : p.NguoiHuy.HoTen
							},
							NguoiSD = new DmnhanVienDto()
							{
								MaNv = p == null ? "" : p.NguoiSD.MaNv,
								HoTen = p == null ? "" : p.NguoiSD.HoTen
							},
						};




			query = query.Where(x => x.Idba == idba);
			List<String> maPhieus = new List<string>();
			if (isPrint)
			{
				query = query.Where(x => !String.IsNullOrEmpty(x.Kq));
			}
			var benhanclss = _repository._context.BenhanCls.Where(x => parameters.Stt.Any(s => s == x.Stt) && x.Idba == idba).Select(x => new { x.MaDv, x.NgayYlenh, x.Sttkhoa }).ToList();
            var maDvs = benhanclss.Select(x => x.MaDv).ToList();
			maPhieus = _repository._context.DmdichvuNhomInChiDinh.Where(x => maDvs.Any(d => d == x.MaDv)).Select(x => x.MaPhieu).ToList();
			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}
			//if (parameters.Stt.Any())
			//{
			//	query = query.Where(x => parameters.Stt.Any(s => s == x.Sttdv));
			//}
			if (maPhieus.Any())
			{
				query = query.Where(x => maPhieus.Any(s => s == x.MaPhieu));
			}
			else if (parameters.Stt.Any())
			{
				query = query.Where(x => parameters.Stt.Any(s => s == x.Sttdv));
			}
			if (benhanclss.Any())
			{
				query = query.Where(x => benhanclss.Any(cls => x.NgayYlenh == cls.NgayYlenh && x.KhoaDieuTri.Stt == cls.Sttkhoa && x.KhoaDieuTri.Idba == idba));
            }
			if (isPrint)
			{
				query = query.OrderBy(x => x.Sttin);
			}
			return query;
		}
		private List<BenhAnPhieuXetNghiemDto> DataPrint(decimal idba, PrintParameters parameters)
		{
			return xetNghiemPrintQuery(idba, parameters).ToList();
		}
		public string Print(decimal idba, PrintParameters parameters)
		{
			var listCls = DataPrint(idba, parameters);

			var dataBenhAn = _repository._context.BenhAn
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
					Tuoi = ba.ThongTinBn.Tuoi,
					GioiTinh = ba.ThongTinBn.GioiTinh,
					SoNha = ba.ThongTinBn.SoNha,
					Thon = ba.ThongTinBn.Thon,
					SoTheBhyt = ba.ThongTinBn.SoTheBhyt,
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
			List<BenhAnClsPrintDto> dataFill = new List<BenhAnClsPrintDto>();

			foreach (var item in listCls)
			{
                var index = dataFill.FindIndex(x => x.SoPhieu == PrintHelper.RegexStringReplace(item.SoPhieu)?.Trim());
				if (index == -1)
				{
					dataFill.Add(new BenhAnClsPrintDto()
					{
						SoYTe = PrintSetting.SoYTe,
						BenhVien = PrintSetting.BenhVien,
						DiaChiBenhVien = PrintSetting.DiaChiBV,
						DienThoaiBV = PrintSetting.DienThoaiBV,
						HotlineBV = PrintSetting.HotLienBV,
						Khoa = item?.KhoaDieuTri?.Khoa?.TenKhoa,
						Buong = item?.KhoaDieuTri?.Buong?.TenBuong,
						Giuong = item?.KhoaDieuTri?.Giuong?.TenGiuong,
						HoTen = dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
						SoVaoVien = dataBenhAn?.SoVaoVien,
						Tuoi = dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
						DiaChi = PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
						GioiTinh = dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
						ChanDoan = !String.IsNullOrEmpty(item?.KhoaDieuTri?.BenhChinh?.MaBenh) ? $"{item?.KhoaDieuTri?.BenhChinh?.MaBenh} - {item?.KhoaDieuTri?.BenhChinh?.TenBenh}" : "",
						NamSinh = dataBenhAn?.BenhNhan?.NgaySinh.ToString("yyyy"),
						Capcuu = Convert.ToBoolean(item?.Capcuu) ? "x" : "",
						Thuong = !Convert.ToBoolean(item?.Capcuu) ? "x" : "",
						SoPhieu = PrintHelper.RegexStringReplace(item.SoPhieu)?.Trim(),
						IDXetNghiem = item.Idlis,
						MaICD = item?.KhoaDieuTri?.BenhChinh?.MaBenh,
						NoiChiDinh = item?.KhoaDieuTri?.Khoa?.TenKhoa,
						BSChiDinh = item?.BschiDinh?.HoTen,
						NguoiThucHien = item.Ktv?.HoTen,
						NguoiDuyetKQ = item.NguoiDuyetKq?.HoTen,
						TheBHYT = dataBenhAn?.BenhNhan?.SoTheBhyt,
						XetNghiemDto = new List<XetNghiemDto>(),
						HtmlKetLuan = item.KetLuan,
					});
					index = dataFill.Count - 1;
				}
				var indexXetNghiemDto = dataFill[index].XetNghiemDto.FindIndex(x => (x.LoaiXetNghiem == item.DichVu.TenDv) || (x.LoaiXetNghiem == item.TenPhieu && (item.DichVu.TenDv == item.DichVuCs.TenCs)));
				if (indexXetNghiemDto != -1)
				{
					dataFill[index].XetNghiemDto[indexXetNghiemDto].XetNghiemItemDto.Add(new XetNghiemItemDto()
					{
						Stt = dataFill[index].XetNghiemDto[indexXetNghiemDto].XetNghiemItemDto.Count + 1,
						TenXetNgiem = item.DichVuCs.TenCs,
						KetQua = item.Kq,
						GiaTriThemChieuNam = PrintHelper.ConcatStringArr((object)" - ", PrintHelper.RegexStringReplace(item.DichVuCs.ChisothapNam)?.Trim(), PrintHelper.RegexStringReplace(item.DichVuCs.ChisocaoNam)?.Trim()),
						GiaTriThemChieuNu = PrintHelper.ConcatStringArr((object)" - ", PrintHelper.RegexStringReplace(item.DichVuCs.ChisothapNu)?.Trim(), PrintHelper.RegexStringReplace(item.DichVuCs.ChisocaoNu)?.Trim()),
						DonVi = item.DichVuCs.DonViDo,
						MayXN = item.MaMayThucHien
					});
				}
				else
				{
					dataFill[index].XetNghiemDto.Add(new XetNghiemDto()
					{
						LoaiXetNghiem = (item.DichVu.TenDv == item.DichVuCs.TenCs) ? item.TenPhieu : item.DichVu.TenDv,
						XetNghiemItemDto = new List<XetNghiemItemDto>(){
								new XetNghiemItemDto(){
									Stt = 1,
									TenXetNgiem = item.DichVuCs.TenCs,
									KetQua = item.Kq,
									GiaTriThemChieuNam = PrintHelper.ConcatStringArr((object)" - ", PrintHelper.RegexStringReplace(item.DichVuCs.ChisothapNam)?.Trim(), PrintHelper.RegexStringReplace(item.DichVuCs.ChisocaoNam)?.Trim()),
									GiaTriThemChieuNu = PrintHelper.ConcatStringArr((object)" - ", PrintHelper.RegexStringReplace(item.DichVuCs.ChisothapNu)?.Trim(), PrintHelper.RegexStringReplace(item.DichVuCs.ChisocaoNu)?.Trim()),
									DonVi = item.DichVuCs.DonViDo,
									MayXN = item.MaMayThucHien
								}
							}
					});
				}
			}
			var dataset = DatasetHelper.ConvertToDataSet<BenhAnClsPrintDto>(dataFill);
			var list = new List<DictionaryEntry>();
			list.Add(new DictionaryEntry("BenhAnClsPrintDto", string.Empty));
			list.Add(new DictionaryEntry("XetNghiemDto", "ParentID= %BenhAnClsPrintDto.ID%"));
			list.Add(new DictionaryEntry("XetNghiemItemDto", "ParentID= %XetNghiemDto.ID%"));
			string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "Ket-qua-xet-nghiem-gioi-tinh.doc", dataset, list, null, null, true);
			return path;
		}
	}
}
