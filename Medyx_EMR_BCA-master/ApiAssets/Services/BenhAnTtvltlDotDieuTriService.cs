using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
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
using System.Linq;
using static Medyx_EMR_BCA.ApiAssets.Helpers.PrintHelper;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnTtvltlDotDieuTriService
	{
		private IRepository<BenhanTtvltlDotDieuTri> repository = null;
		private PrintSetting PrintSetting { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;

		public BenhAnTtvltlDotDieuTriService(IHttpContextAccessor accessor = null, IHostingEnvironment hostingEnvironment = null, IOptions<PrintSetting> options = null)
		{
			repository = new GenericRepository<BenhanTtvltlDotDieuTri>(accessor);
			PrintSetting = options != null ? options.Value : new PrintSetting();
			_hostingEnvironment = hostingEnvironment;
		}

		public IQueryable<BenhAnTtvltlDotDieuTriDto> Get(BenhanTtvltlDotDieuTriParameters parameters, UserSession user = null)
		{
			var query = repository.Table.AsQueryable();

			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}
			if (parameters.Huy.HasValue)
			{
				query = query.Where(x => x.Huy == parameters.Huy);
			}
			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);

			return query.Select(x => new BenhAnTtvltlDotDieuTriDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				Sttkhoa = x.Sttkhoa,
				KhoaDieuTri = new BenhAnKhoaDieuTriDto()
				{
					NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Stt = x.BenhAnKhoaDieuTri.Stt,
					Idba = x.BenhAnKhoaDieuTri.Idba,
					MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
					BsdieuTri = new DmnhanVienDto()
					{
						HoTen = x.BenhAnKhoaDieuTri.DmnhanVien.HoTen,
						MaNv = x.BenhAnKhoaDieuTri.DmnhanVien.MaNv
					},
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
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem1.TenBenh,
					},
					BenhKem2 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem2.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem2.TenBenh,
					},
					BenhKem3 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem3.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem3.TenBenh,
					},
				},
				NgayVaoDieuTri = x.BenhAnTtvltlThuchiens.FirstOrDefault().BenhanTtvltl.NgayYlenh.ToString(),
				Huy = x.Huy,
				NgayLap = x.NgayLap,
				NgaySd = x.NgaySd,
				NgayHuy = x.NgayHuy,
				BsdieuTri = new DmnhanVienDto()
				{
					MaNv = x.DmBsdieuTri.MaNv ?? x.BenhAnKhoaDieuTri.DmnhanVien.MaNv,
					HoTen = x.DmBsdieuTri.HoTen ?? x.BenhAnKhoaDieuTri.DmnhanVien.HoTen
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
			}).OrderBy(x => x.NgayVaoDieuTri);
		}

		public BenhAnTtvltlDotDieuTriDto Detail(decimal idba, int stt)
		{
			var query = repository.Table.AsQueryable();

			var queryBenhAnTtvltlDotDieuTriDetail = query.Select(x => new BenhAnTtvltlDotDieuTriDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				Sttkhoa = x.Sttkhoa,
				KhoaDieuTri = new BenhAnKhoaDieuTriDto()
				{
					NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
					Stt = x.BenhAnKhoaDieuTri.Stt,
					Idba = x.BenhAnKhoaDieuTri.Idba,
					MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
					BsdieuTri = new DmnhanVienDto()
					{
						HoTen = x.BenhAnKhoaDieuTri.DmnhanVien.HoTen,
						MaNv = x.BenhAnKhoaDieuTri.DmnhanVien.MaNv
					},
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
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem1.TenBenh,
					},
					BenhKem2 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem2.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem2.TenBenh,
					},
					BenhKem3 = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhKem3.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhKem3.TenBenh,
					},
				},
				NgayVaoDieuTri = x.BenhAnTtvltlThuchiens.FirstOrDefault().BenhanTtvltl.NgayYlenh.ToString(),
				BsdieuTri = new DmnhanVienDto()
				{
					MaNv = x.DmBsdieuTri.MaNv ?? x.BenhAnKhoaDieuTri.DmnhanVien.MaNv,
					HoTen = x.DmBsdieuTri.HoTen ?? x.BenhAnKhoaDieuTri.DmnhanVien.HoTen
				},
				Ppdt = x.Ppdt,
				KhamBenh = x.KhamBenh,
				XuTri = x.XuTri,
				Kq = x.Kq,
				Huy = x.Huy,
			});
			return queryBenhAnTtvltlDotDieuTriDetail.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);
		}
        public void Store(BenhAnTtvltlDotDieuTriCreateVM info)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(info.Idba);
            var stt = (repository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            info.MaBa = benhAn.MaBa;
            info.MaBn = benhAn.MaBn;
            info.Stt = stt;
            // info.Idhis = stt.ToString();
            repository.Insert(info);
        }
        public void Update(decimal id, int stt, BenhAnTtvltlDotDieuTriVM info)
        {
			PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
            repository.Update(info, id, stt);
        }

		public void Destroy(decimal id, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
			repository.Delete(id, stt);
		}

		public string Print(decimal idba, int stt)
		{
			var detail = Detail(idba, stt);
			var dataBenhAn = repository._context.BenhAn
				.Select(ba => new BenhAnDto()
				{
					Idba = ba.Idba,
					SoVaoVien = ba.SoVaoVien,
					LoaiBa = ba.LoaiBa,
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
                        NgheNghiep = new DmngheNghiepDto(){
                            MaNn = ba.ThongTinBn.DmngheNghiep.MaNn,
                            TenNn = ba.ThongTinBn.DmngheNghiep.TenNn  
                        },
						DoiTuong = new DmdoiTuongDto()
						{
							MaDt = ba.ThongTinBn.DmdoiTuong.MaDt,
							TenDt = ba.ThongTinBn.DmdoiTuong.TenDt
						},
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
			var vltl_thuchien = repository._context.BenhAnTtvltlThuchien.Where(x => x.SttdotDt == detail.Stt && x.Idba == idba).Select(x => new BenhAnTtvltlThuchienPrint()
			{
				SttchiDinh = x.SttchiDinh,
				NgayThucHien = PrintHelper.DateTimeTextShort(x.NgayThucHien),
				PhuongPhap = x.DmdichVu.TenDv,
				ThoiGian = x.ThoiGian,
				LieuLuong = x.LieuLuong,
				GhiChu = x.GhiChu
			}).ToList();
			var vltl_thuchien_sttchidinhs = vltl_thuchien.Select(x => x.SttchiDinh).ToArray();
			var vltl = repository._context.BenhanTtvltl.Where(x => vltl_thuchien_sttchidinhs.Contains(x.Stt) && x.Idba == idba).Select(x => new BenhAnTTVLTLPrint()
			{
				NgayThang = PrintHelper.DateTextShortest(x.NgayYlenh),
				PhuongPhap = x.DmdichVu.TenDv,
				SoLan = x.SoLuong.ToString()
			}).ToList();

			var fields = new List<string>() {
				"SoYTe",
				"BV",
				"Khoa",
				"So",
				"HoTen",
				"Tuoi",
				"GT",
				"NgheNghiep",
				"DiaChi",
				"NgayVaoDieuTri",
				"BenhChinh",
				"BenhPhu",
				"KetQuaDieuTri",
				"PhuongPhapDieuTri",
				"NgayThangNam",
				"BacSiDieuTri",
				"NoiTru",
				"NgoaiTru",
                "NgayGioKhamBenh",
                "NgayNhanXetKQDieuTri"
			};
			var values = new List<string>()
			{
                PrintSetting.SoYTe,
                PrintSetting.BenhVien,
                detail?.KhoaDieuTri?.Khoa?.TenKhoa,
                dataBenhAn?.SoVaoVien,
                dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
                dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
                dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
                dataBenhAn?.BenhNhan?.NgheNghiep?.TenNn,
                PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
                detail?.NgayVaoDieuTri,
                PrintHelper.Trimmer((detail?.KhoaDieuTri.BenhChinh.TenBenh)),
                PrintHelper.ConcatStringArr(PrintHelper.Trimmer((detail?.KhoaDieuTri.BenhKem1.TenBenh)), PrintHelper.Trimmer((detail?.KhoaDieuTri.BenhKem2.TenBenh)), PrintHelper.Trimmer((detail?.KhoaDieuTri.BenhKem3.TenBenh))),
                detail?.Kq,
                detail?.Ppdt,
                PrintHelper.DateText(detail?.KhoaDieuTri?.NgayVaoKhoa),
                detail?.BsdieuTri?.HoTen,
                dataBenhAn?.LoaiBa == 1 ? "x" : "",
                dataBenhAn?.LoaiBa == 2 ? "x" : "",
                PrintHelper.DateText(detail?.KhoaDieuTri?.NgayVaoKhoa),
                detail?.NgayVaoDieuTri,
			};
            var datasets = new List<DatasetTable>(){
                new DatasetTable(){
                    DataSet = DatasetHelper.ConvertToDataSet<BenhAnTtvltlThuchienPrint>(vltl_thuchien),
                    List = new List<DictionaryEntry>(){
                        new DictionaryEntry("BenhAnTtvltlThuchienPrint", string.Empty)
                    }
                },
                new DatasetTable(){
                    DataSet = DatasetHelper.ConvertToDataSet<BenhAnTTVLTLPrint>(vltl),
                    List = new List<DictionaryEntry>(){
                        new DictionaryEntry("BenhAnTTVLTLPrint", string.Empty)
                    }
                },
            };
			PrintHelper.HanlderDoiTuongSpecail(ref fields, ref values, dataBenhAn?.BenhNhan?.DoiTuong?.MaDt);
            var path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "Phieu_dieu_trị_vat_ly_tri_lieu.doc", datasets, fields, values);
            
            return path;
		}

		class BenhAnTTVLTLPrint
		{
			public string NgayThang { get; set; }
			public string PhuongPhap { get; set; }
			public string SoLan { get; set; }
		}
		class BenhAnTtvltlThuchienPrint
		{
			public int SttchiDinh { get; set; }
			public string NgayThucHien { get; set; }
			public string PhuongPhap { get; set; }
			public string ThoiGian { get; set; }
			public string LieuLuong { get; set; }
			public string GhiChu { get; set; }
		}
	}
}
