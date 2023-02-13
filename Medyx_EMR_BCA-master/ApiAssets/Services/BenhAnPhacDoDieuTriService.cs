using Medyx.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Medyx_EMR_BCA.ApiAssets.Services
{
	public class BenhAnPhacDoDtService
	{
		private IRepository<BenhAnPhacDoDt> repository = null;
		private readonly IHostingEnvironment _hostingEnvironment;
		public BenhAnPhacDoDtService(IHttpContextAccessor accessor = null, IHostingEnvironment hostingEnvironment = null)
		{
			repository = new GenericRepository<BenhAnPhacDoDt>(accessor);
			_hostingEnvironment = hostingEnvironment;
		}

		public IQueryable<BenhAnPhacDoDtDto> Get(BenhAnPhacDoDtParameters parameters, UserSession user = null)
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

			return query.Select(x => new BenhAnPhacDoDtDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
				Sttkhoa = x.Sttkhoa,
				KhoaDieuTri = new BenhAnKhoaDieuTriDto()
				{
					Khoa = new DmkhoaDto()
					{
						MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
						TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
					},
					Buong = new DmkhoaBuongDto()
					{
						TenBuong = x.BenhAnKhoaDieuTri.DmkhoaBuong.TenBuong,
						MaBuong = x.BenhAnKhoaDieuTri.DmkhoaBuong.MaBuong
					},
					Giuong = new DmkhoaGiuongDto()
					{
						TenGiuong = x.BenhAnKhoaDieuTri.DmkhoaGiuong.TenGiuong,
						MaGiuong = x.BenhAnKhoaDieuTri.DmkhoaGiuong.MaGiuong
					},
					BenhChinh = new DmbenhTatDto()
					{
						MaBenh = x.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
						TenBenh = x.BenhAnKhoaDieuTri.BenhChinh.TenBenh
					}
				},
				MaBenh = x.MaBenh ?? x.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
				TenBenh = x.TenBenh ?? x.BenhAnKhoaDieuTri.BenhChinh.TenBenh,
				NgayAdphacDo = x.NgayAdphacDo,
				Huy = x.Huy,
				NgayLap = x.NgayLap,
				NgaySd = x.NgaySd,
				NgayHuy = x.NgayHuy,
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
		}

		public BenhAnPhacDoDtDto Detail(decimal idba, int stt)
		{
			var query = repository.Table.AsQueryable();

			var queryBenhAnTaiBienPtttDetail = query.Select(x => new BenhAnPhacDoDtDto()
			{
				Idba = x.Idba,
				Stt = x.Stt,
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
				MaBenh = x.MaBenh ?? x.BenhAnKhoaDieuTri.BenhChinh.MaBenh,
				TenBenh = x.TenBenh ?? x.BenhAnKhoaDieuTri.BenhChinh.TenBenh,
				GiaiDoan = x.GiaiDoan,
				NgayAdphacDo = x.NgayAdphacDo,
				GioiTinh = x.GioiTinh,
				DoTuoiTu = x.DoTuoiTu,
				DoTuoiDen = x.DoTuoiDen,
				VungApDung = x.VungApDung,
				MoTa = x.MoTa,
				XuTri = x.XuTri,
				TruocPhacDo = x.TruocPhacDo,
				SauPhacDo = x.SauPhacDo,
				Huy = x.Huy,
			});
			return queryBenhAnTaiBienPtttDetail.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);
		}
		public void Store(BenhAnPhacDoDtCreateVM info)
		{
			var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(info.Idba);
			var stt = (repository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
			info.MaBa = benhAn.MaBa;
			info.MaBn = benhAn.MaBn;
			info.Stt = stt;
			// info.Idhis = "";
			repository.Insert(info);
		}
		public void Update(decimal id, int stt, BenhAnPhacDoDtVM info)
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
			var dataBenhAn = repository._context.BenhAn
					.Select(ba => new BenhAnDto()
					{
						Idba = ba.Idba,
						SoVaoVien = ba.SoVaoVien,
						TruongKhoa = new DmnhanVienDto()
						{
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
			var model = Detail(idba, stt);
			List<string> fields = new List<string>(){
				"HoTen",
				"Tuoi",
				"GioiTinh",
				"DiaChi",
				"Khoa",
				"Buong",
				"Giuong",
				"ChanDoan",
				"GiaiDoanBenh",
				"NgayApDung",
				"GioiTinhApDung",
				"DoTuoiApDung",
				"VungApDung",
				"MoTaBenh",
				"XuTri",
				"TinhTrangNguoiBenhTruocPhacDo",
				"TinhTrangNguoiBenhSauPhacDo"
			};
			List<string> values = new List<string>(){
			   dataBenhAn?.BenhNhan?.HoTen?.ToUpper(),
			   dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
			   dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
			   PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
			   model?.KhoaDieuTri?.Khoa?.TenKhoa,
			   model?.KhoaDieuTri?.Buong?.TenBuong,
			   model?.KhoaDieuTri?.Buong?.TenBuong,
			   $"{model?.KhoaDieuTri?.BenhChinh?.MaBenh} {model?.KhoaDieuTri?.BenhChinh?.TenBenh}",
			   model?.GiaiDoan,
			   PrintHelper.DateTextShortest(model?.NgayAdphacDo),
			   model?.GioiTinh == 1 ? "Nam" : "Nữ",
			   model?.DoTuoiTu?.ToString(),
			   model?.VungApDung,
			   model?.MoTa,
			   model?.XuTri,
			   model?.TruocPhacDo,
			   model?.SauPhacDo
			};
			return PrintHelper.PrintFile<BenhAn>(_hostingEnvironment, "Phieu-phac-do-dieu-tri.docx", fields, values, null, null);
		}
	}
}
