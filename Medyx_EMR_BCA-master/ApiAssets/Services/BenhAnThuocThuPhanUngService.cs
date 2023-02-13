using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Linq;
using System;
using Medyx.ApiAssets.Dto.Print;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx.ApiAssets.Models.Configure;
using Microsoft.Extensions.Options;
using Medyx_EMR_BCA.ApiAssets.ViewModels;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnThuocThuPhanUngService
	{
		private IRepository<BenhAnThuocThuPhanUng> repository = null;
		private readonly IHostingEnvironment _hostingEnvironment;
		private PrintSetting PrintSetting { get; set; }
		public BenhAnThuocThuPhanUngService(IHostingEnvironment hostingEnvironment, IHttpContextAccessor context = null, IOptions<PrintSetting> options = null)
		{
			repository = new GenericRepository<BenhAnThuocThuPhanUng>(context);
			_hostingEnvironment = hostingEnvironment;
			PrintSetting = options != null ? options.Value : new PrintSetting();
		}

		public Response<BenhAnThuocThuPhanUngDto> Get(BenhAnThuocThuPhanUngParameters parameters, UserSession user = null)
		{
			var query = repository.Table
				.Include(x => x.DmBsdocKq)
				.Include(x => x.DmBschiDinh)
				.Include(x => x.DmNguoiHuy)
				.Include(x => x.DmNguoiLap)
				.Include(x => x.DmNguoiSD)
				.Include(x => x.DmNguoiThu)
				.Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa)
				.AsQueryable();
			if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
			{
				query = query.Where(x => !Convert.ToBoolean(x.Huy));
			}
			if (!string.IsNullOrEmpty(parameters.Search))
			{
			}
			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);
			var querySelect = BenhAnThuocThuPhanUngDtoQuery();
			var query_result = query.Select(querySelect);
			return Res<BenhAnThuocThuPhanUngDto>.Get(query_result, parameters.PageNumber, parameters.PageSize);
		}

		private Expression<Func<BenhAnThuocThuPhanUng, BenhAnThuocThuPhanUngDto>> BenhAnThuocThuPhanUngDtoQuery()
		{
			return ba => new BenhAnThuocThuPhanUngDto()
			{
				Idba = ba.Idba,
				Stt = ba.Stt,
				Idhis = ba.Idhis,
				MaBa = ba.Idhis,
				MaBn = ba.MaBn,
				Sttkhoa = ba.Sttkhoa,
				NgayBatDau = ba.NgayBatDau,
				MaThuoc = ba.MaThuoc,
				TenThuoc = ba.TenThuoc,
				PhuongPhapThu = ba.PhuongPhapThu,
				KetQua = ba.KetQua,
				Huy = ba.Huy,
				MaMay = ba.MaMay,
				NgayLap = ba.NgayLap,
				NgaySd = ba.NgaySd,
				NgayHuy = ba.NgayHuy,
				NguoiThu = new DmnhanVienDto()
				{
					MaNv = ba.DmNguoiThu.MaNv,
					HoTen = ba.DmNguoiThu.HoTen
				},
				BschiDinh = new DmnhanVienDto()
				{
					MaNv = ba.DmBschiDinh.MaNv,
					HoTen = ba.DmBschiDinh.HoTen
				},
				BsdocKq = new DmnhanVienDto()
				{
					MaNv = ba.DmBsdocKq.MaNv,
					HoTen = ba.DmBsdocKq.HoTen
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
				NguoiSD = new DmnhanVienDto()
				{
					MaNv = ba.DmNguoiSD.MaNv,
					HoTen = ba.DmNguoiSD.HoTen
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
		public BenhAnThuocThuPhanUng Show(decimal id, int stt)
		{
			var model = repository.GetById(stt, id);
			return model;
		}

		public void Store(BenhAnThuocThuPhanUngCreateVM info)
		{
			var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(info.Idba);
			var stt = (repository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            info.MaBa = benhan.MaBa;
			info.MaBn = benhan.MaBn;
			info.Stt = stt;
			// info.Idhis = stt.ToString();
			repository.Insert(info);
		}

		public void Update(decimal idba, int stt, BenhAnThuocThuPhanUngVM info)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			repository.Update(info, stt, idba);
		}

		public void Destroy(decimal idba, int stt)
		{
			PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
			repository.Delete(stt, idba);
		}
		public string Print(decimal idba)
		{
			var dataBenhAn = repository._context.BenhAn
						.Include(x => x.ThongTinBn).ThenInclude(x => x.Dmtinh)
						.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquanHuyen)
						.Include(x => x.ThongTinBn).ThenInclude(x => x.DmphuongXa)
						.Include(x => x.ThongTinBn).ThenInclude(x => x.DmquocGia)
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

			var query = repository.Table
				.AsQueryable();
			var querySelect = BenhAnThuocThuPhanUngDtoQuery();
			var new_query = query.Select(querySelect);
			var data = new_query.Where(x => idba == x.Idba).ToList();
			var dataset = new DataSet();

			List<BenhAnThuocThuPhanUngPrintDto> datafill = new List<BenhAnThuocThuPhanUngPrintDto>();
			foreach (var item in data)
			{
				var index = datafill.FindIndex(x => x.Khoa == item.KhoaDieuTri.Khoa.TenKhoa);
				if (index == -1)
				{
					datafill.Add(
						new BenhAnThuocThuPhanUngPrintDto()
						{
							SoYTe = PrintSetting.SoYTe,
							BenhVien = PrintSetting.BenhVien,
							SoVaoVien = dataBenhAn.SoVaoVien,
							HoTen = dataBenhAn.BenhNhan.HoTen,
							Tuoi = dataBenhAn.BenhNhan.Tuoi.ToString(),
							DiaChi = PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
							GioiTinh = dataBenhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
							Khoa = item.KhoaDieuTri.Khoa.TenKhoa,
							Buong = item.KhoaDieuTri.Buong.TenBuong,
							Giuong = item.KhoaDieuTri.Giuong.TenGiuong,
							ChanDoan = !String.IsNullOrEmpty(item.KhoaDieuTri.BenhChinh.MaBenh) ? $"{item.KhoaDieuTri.BenhChinh.MaBenh} - {item.KhoaDieuTri.BenhChinh.TenBenh}" : "",
							Detail = new List<ThuocThuPhanUngDetailPrintDto>(){
								new ThuocThuPhanUngDetailPrintDto(){
									NgayBatDau = item.NgayBatDau.HasValue ? item.NgayBatDau.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
									TenThuoc= item.TenThuoc,
									PhuongPhapThu= item.PhuongPhapThu,
									BsChiDinh= item.BschiDinh.HoTen,
									NguoiThu= item.NguoiThu.HoTen,
									BsDocKQ= item.BsdocKq.HoTen,
									NgayDocKQ= item.NgayDocKq.HasValue ? item.NgayDocKq.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
									KetQua= item.KetQua,
								}
							}
						}
					);
				}
				else
				{
					datafill[index].Detail.Add(
						new ThuocThuPhanUngDetailPrintDto()
						{
							NgayBatDau = item.NgayBatDau.HasValue ? item.NgayBatDau.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
							TenThuoc = item.TenThuoc,
							PhuongPhapThu = item.PhuongPhapThu,
							BsChiDinh = item.BschiDinh.HoTen,
							NguoiThu = item.NguoiThu.HoTen,
							BsDocKQ = item.BsdocKq.HoTen,
							NgayDocKQ = item.NgayDocKq.HasValue ? item.NgayDocKq.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
							KetQua = item.KetQua,
						}
					);
				}
			}


			dataset = DatasetHelper.ConvertToDataSet<BenhAnThuocThuPhanUngPrintDto>(datafill);
			var list = new List<DictionaryEntry>();
			list.Add(new DictionaryEntry("BenhAnThuocThuPhanUngPrintDto", string.Empty));
			list.Add(new DictionaryEntry("ThuocThuPhanUngDetailPrintDto", "ParentID= %BenhAnThuocThuPhanUngPrintDto.ID%"));
			List<string> fields = new List<string>() { };
			List<string> values = new List<string>() { };
			string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "phieu_thu_phan_ung_thuoc.doc", dataset, list, fields, values);


			//string path = PrintHelper.PrintFile<BenhAnThuocThuPhanUngPrintDto>(_hostingEnvironment, "phieu_thu_phan_ung_thuoc.doc", new List<string>(), new List<string>(), datafill, "PhanUngThuoc");
			return path;
		}
	}
}
