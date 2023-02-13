using Medyx.ApiAssets.Dto.Print;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
	[Route("api/benh-an-kham-vao-vien")]
	[ApiController]
	[SessionFilter]
	public class BenhAnKhamVaoVienController : ControllerBase
	{
		private IRepository<BenhAnKhamVaoVien> repository = null;
		private readonly IHostingEnvironment _hostingEnvironment;
		private UploadFileRespository uploadFileRespository = null;
		private PrintSetting PrintSetting { get; set; }
		public BenhAnKhamVaoVienController(IHostingEnvironment hostingEnvironment, IOptions<PrintSetting> options, IHttpContextAccessor accessor = null)
		{
			repository = new GenericRepository<BenhAnKhamVaoVien>(accessor);
			_hostingEnvironment = hostingEnvironment;
			uploadFileRespository = new UploadFileRespository();
			PrintSetting = options.Value;
		}

		// GET: api/<BenhAnController>
		[HttpGet]
		[SetActionContextItem(ActionType.PagedList)]
		public Response<BenhAnKhamVaoVien> Get([FromQuery] BenhAnKhamVaoVienParameters parameters)
		{
			var query = repository.Table.AsQueryable();

			if (parameters.Idba.HasValue)
			{
				query = query.Where(x => x.Idba == parameters.Idba);
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);
			return Res<BenhAnKhamVaoVien>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		// GET api/<BenhAnController>/5
		[HttpGet("{id}")]
		public BenhAnKhamVaoVien Detail(string id)
		{
			var model = repository.GetById(Convert.ToDecimal(id));
			return model;
		}

		#region Khong su dung
		// POST api/<BenhAnController>
		[HttpPost("cap-nhap-them-moi-kham-vao-vien")]
		public ActionResult CreateOrEdit([FromBody] BenhAnKhamVaoVien info)
		{
			if (ModelState.IsValid)
			{
				var benhan = repository._context.BenhAn.First(x => x.Idba == info.Idba);
				info.MaBa = benhan.MaBa;
				info.MaBn = benhan.MaBn;
				var model = repository.GetById(info.Idba);
				if (model != null)
				{
					repository.Update(info, info.Idba);
				}
				else
				{
					repository.Insert(info);
				}
			}
			return Ok();
		}
		#endregion

		#region Khong su dung
		[HttpPost]
		public ActionResult Post([FromBody] BenhAnKhamVaoVienCreateVM info)
		{
			if (ModelState.IsValid)
			{
				var benhan = repository._context.BenhAn.First(x => x.Idba == info.Idba);
				info.MaBa = benhan.MaBa;
				info.MaBn = benhan.MaBn;
				repository.Insert(info);
			}
			return Ok();
		}
		#endregion

		// PUT api/<BenhAnController>/5
		[HttpPut("{id}")]
		[SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/phieukhambenhvaovien/modify")]
		public ActionResult Put(decimal id, [FromBody] BenhAnKhamVaoVienCreateVM info)
		{
			if (ModelState.IsValid)
			{
				var model = repository.GetById(id);
				var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(id);
				info.Idba = id;
				info.MaBa = benhan.MaBa;
				info.MaBn = benhan.MaBn;
				repository.setLogActionName("Phiếu khám vào viện");
				if (model != null)
				{
					repository.Update(info, id);
				}
				else
				{
					repository.Insert(info);
				}
			}
			return Ok();
		}

		// DELETE api/<BenhAnController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		[HttpGet("{id}/print-ba-file/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/phieukhambenhvaovien/export")]
		public ActionResult Print(decimal id)
		{
			var phieukhamvv = repository._context.BenhAnKhamVaoVien.Where(
				x => x.Idba == id
			).Include(x => x.DmBsKham)
			  .Include(x => x.DmChanDoanKkb)
			  .Include(x => x.DmBenhNoiChuyenDen)
			  .Include(x => x.Dmkhoa)
			  .Include(x => x.DmKhoaKham)
			.FirstOrDefault();
			var dataBenhAn = (new BenhAnService()).Detail(id);

			List<string> fields = new List<string>() { "gt_nu", "gt_nam" };
			List<string> values = new List<string>() {
				dataBenhAn?.BenhNhan?.GioiTinh == 2 ? "x": null,
				dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "x" : null
			};
			List<KhamVaoVienPrintDto> khamVaoViens = new List<KhamVaoVienPrintDto>()
			{
				new KhamVaoVienPrintDto()
				{
					soyte = PrintSetting.SoYTe,
					benhvien = PrintSetting.BenhVien,
					buong = phieukhamvv?.DmKhoaKham?.TenKhoa?.ToUpper(),
					sovaovien = dataBenhAn?.SoVaoVien,
					hoten = dataBenhAn?.BenhNhan?.HoTen,
					nghenghiep = dataBenhAn?.BenhNhan?.NgheNghiep?.TenNn,
					dantoc = dataBenhAn?.BenhNhan?.DanToc?.TenDanToc,
					ngoaikieu = dataBenhAn?.BenhNhan?.QuocGia?.TenQg,
					sonha = dataBenhAn?.BenhNhan?.SoNha,
					thon = dataBenhAn?.BenhNhan?.Thon,
					xaphuong = dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa,
					huyen = dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh,
					thanhpho = dataBenhAn?.BenhNhan?.Tinh?.TenTinh,
					noilamviec = dataBenhAn?.BenhNhan?.NoiLamViec,
					giatribhytdn = PrintHelper.DateText(dataBenhAn?.BenhNhan?.Gtbhytdn),
					lienhe = dataBenhAn?.BenhNhan?.LienHe,
					sodienthoai = dataBenhAn?.BenhNhan?.SoDienThoai,
					kbgiophut = PrintHelper.TimeText(dataBenhAn?.NgayVv),
					kbngaythang = PrintHelper.DateText(dataBenhAn?.NgayVv),
					cdnoigt =  $"{phieukhamvv?.DmBenhNoiChuyenDen?.MaBenh} - {phieukhamvv?.DmBenhNoiChuyenDen?.TenBenh}",
					lydovaovien = phieukhamvv?.LyDoVv,
					quatrinhbenhly = phieukhamvv?.QuaTrinhBenhLy,
					tiensubanthan = phieukhamvv?.TienSuBanThan,
					tiensugiadinh = phieukhamvv?.TienSuGiaDinh,
					toanthan = phieukhamvv?.KhamToanThan,
					mach = phieukhamvv?.Mach,
					nhietdo = phieukhamvv?.NhietDo,
					nhiptho = phieukhamvv?.NhipTho,
					huyetap = phieukhamvv?.HuyetAp,
					cannang = "",
					cacbophan = phieukhamvv?.CacBoPhan,
					tomtatlamsan = PrintHelper.RegexStringReplace(phieukhamvv?.TomTatKqcls, " "),
					chandoanvv = $"{phieukhamvv?.DmChanDoanKkb?.MaBenh} - {phieukhamvv?.DmChanDoanKkb?.TenBenh}" ,
					daxuly = phieukhamvv?.DaXuLy,
					khoa = phieukhamvv?.Dmkhoa?.TenKhoa,
					chuy = phieukhamvv?.ChuY,
					bsdieutri = phieukhamvv?.DmBsKham?.HoTen,
					NgayThang = PrintHelper.DateText(dataBenhAn?.NgayVv)
				}
			};


			string birthday = PrintHelper.BirthText(dataBenhAn?.BenhNhan?.NgaySinh);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, birthday, "ngaysinh", 8, ' ');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.Tuoi?.ToString(), "tuoi", 2, '0');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.DanToc?.MaDanToc, "dantoc", 2, '0', true);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.NgheNghiep?.MaNn, "Nghenghiep", 2, '0', true);
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaQuocTich, "maquocgia", 2, '0');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.QuanHuyen?.MaBhxh, "huyen", 3, '0', true);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.PhuongXa?.MaBhxh, "xaphuong", 5, '0', true);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.Tinh?.MaTinh, "thanhpho", 2, '0', true);
			PrintHelper.TextboxFieldDoiTuongHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.DoiTuong?.MaDt);
			PrintHelper.TextboxFieldBHYTHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.SoTheBhyt, "bhyt");

			string path = PrintHelper.PrintFile<KhamVaoVienPrintDto>(_hostingEnvironment, "Phieu-kham-benh-vao-vien-chung-template.doc", fields, values, khamVaoViens, "KhamVaoVien");

			DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);

			return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
		}
		public string Print(decimal id, bool shouldReturnPath = true)
		{
			var phieukhamvv = repository._context.BenhAnKhamVaoVien.Where(
				x => x.Idba == id
			).Include(x => x.DmBsKham)
			  .Include(x => x.DmChanDoanKkb)
			  .Include(x => x.DmBenhNoiChuyenDen)
			  .Include(x => x.Dmkhoa)
			.FirstOrDefault();
			var dataBenhAn = (new BenhAnService()).Detail(id);
			List<string> fields = new List<string>() { "gt_nu", "gt_nam" };
			List<string> values = new List<string>() {
				dataBenhAn?.BenhNhan?.GioiTinh == 2 ? "x": null,
				dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "x" : null
			};
			List<KhamVaoVienPrintDto> khamVaoViens = new List<KhamVaoVienPrintDto>()
			{
				new KhamVaoVienPrintDto()
				{
					soyte = PrintSetting.SoYTe,
					benhvien = PrintSetting.BenhVien,
					buong = dataBenhAn?.Buong?.TenBuong,
					sovaovien = dataBenhAn?.SoVaoVien,
					hoten = dataBenhAn?.BenhNhan?.HoTen,
                    nghenghiep = dataBenhAn?.BenhNhan?.NgheNghiep?.TenNn,
					dantoc = dataBenhAn?.BenhNhan?.DanToc?.TenDanToc,
					ngoaikieu = dataBenhAn?.BenhNhan?.QuocGia?.TenQg,
					sonha = dataBenhAn?.BenhNhan?.SoNha,
					thon = dataBenhAn?.BenhNhan?.Thon,
					xaphuong = dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa,
					huyen = dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh,
					thanhpho = dataBenhAn?.BenhNhan?.Tinh?.TenTinh,
					noilamviec = dataBenhAn?.BenhNhan?.NoiLamViec,
					giatribhytdn = PrintHelper.DateText(dataBenhAn?.BenhNhan?.Gtbhytdn),
					lienhe = dataBenhAn?.BenhNhan?.LienHe,
					sodienthoai = dataBenhAn?.BenhNhan?.SoDienThoai,
					kbgiophut = PrintHelper.TimeText(dataBenhAn?.NgayVv),
					kbngaythang = PrintHelper.DateText(dataBenhAn?.NgayVv),
                    cdnoigt =  $"{phieukhamvv?.DmBenhNoiChuyenDen?.MaBenh} - {phieukhamvv?.DmBenhNoiChuyenDen?.TenBenh}",
                    lydovaovien = phieukhamvv?.LyDoVv,
					quatrinhbenhly = phieukhamvv?.QuaTrinhBenhLy,
					tiensubanthan = phieukhamvv?.TienSuBanThan,
					tiensugiadinh = phieukhamvv?.TienSuGiaDinh,
					toanthan = phieukhamvv?.KhamToanThan,
					mach = phieukhamvv?.Mach,
					nhietdo = phieukhamvv?.NhietDo,
					nhiptho = phieukhamvv?.NhipTho,
					huyetap = phieukhamvv?.HuyetAp,
					cannang = "",
					cacbophan = phieukhamvv?.CacBoPhan,
					tomtatlamsan = PrintHelper.RegexStringReplace(phieukhamvv?.TomTatKqcls, " "),
                    chandoanvv = $"{phieukhamvv?.DmChanDoanKkb?.MaBenh} - {phieukhamvv?.DmChanDoanKkb?.TenBenh}",
                    daxuly = phieukhamvv?.DaXuLy,
					khoa = phieukhamvv?.Dmkhoa?.TenKhoa,
					chuy = phieukhamvv?.ChuY,
					bsdieutri = phieukhamvv?.DmBsKham?.HoTen,
					NgayThang = PrintHelper.DateText(dataBenhAn?.NgayVv)
				}
			};


			string birthday = PrintHelper.BirthText(dataBenhAn?.BenhNhan?.NgaySinh);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, birthday, "ngaysinh", 8, ' ');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.Tuoi?.ToString(), "tuoi", 2, '0');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.DanToc?.MaDanToc, "dantoc", 2, '0', true);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.NgheNghiep?.MaNn, "Nghenghiep", 2, '0', true);
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaQuocTich, "maquocgia", 2, '0');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.QuanHuyen?.MaBhxh, "huyen", 3, '0', true);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.PhuongXa?.MaBhxh, "xaphuong", 5, '0', true);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.Tinh?.MaTinh, "thanhpho", 2, '0', true);
			PrintHelper.TextboxFieldDoiTuongHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.DoiTuong?.MaDt);
			PrintHelper.TextboxFieldBHYTHanlder(ref fields, ref values, dataBenhAn?.BenhNhan?.SoTheBhyt, "bhyt");

			string path = PrintHelper.PrintFile<KhamVaoVienPrintDto>(_hostingEnvironment, "Phieu-kham-benh-vao-vien-chung-template.doc", fields, values, khamVaoViens, "KhamVaoVien");

			return path;
		}
	}
}
