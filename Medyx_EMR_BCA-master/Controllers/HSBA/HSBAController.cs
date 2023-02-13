using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Medyx_EMR_BCA.Controllers.HSBA
{
	public class HSBAController : BCAController
	{
		#region Khởi tạo
		// GET: Client/DMChucVu
		private IMemoryCache cache;
		//public readonly ISession session;
		public HSBAController(IMemoryCache cache)
		{
			this.cache = cache;
			//this.session = HttpContext.Session;
		}
		public ActionResult Index()
		{
			return Khoitao(cache);
		}
		#endregion Khởi tạo

	}
	[Route("HSBADS/[action]")]
	public class HSBADSController : BCAController
	{
		#region Khởi tạo
		// GET: Client/DMChucVu
		private IMemoryCache cache;
		//public readonly ISession session;
		public HSBADSController(IMemoryCache cache)
		{
			this.cache = cache;
			//this.session = HttpContext.Session;
		}
		public ActionResult Index()
		{
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult ThongTinBenhAn(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}

		[HttpGet("{id}")]
		public ActionResult HoSoBenhAn(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult ThongTinRaVien(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult PhacDoDieuTri(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult PhieuKhamBenhVaoVien(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult KhoaDieuTri(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult ToBenhAn(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult PhieuThuPhanUngThuoc(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult PhieuKhamChuyenKhoa(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult ThongTinPhieuXetNghiem(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult ThongTinChanDoanHinhAnh(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}

		[HttpGet("{id}")]

		public ActionResult ThongTinThamDoChucNang(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult VatLyTriLieu(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult PhauThuatThuThuat(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}

		[HttpGet("{id}")]

		public ActionResult HoiChan(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult ToDieuTri(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult ThongTinTheoDoiVaChamSocNguoiBenh(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult TheoDoiTruyenDich(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult TheoDoiTruyenMau(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietTheoDoiTruyenMau(string id , string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietPhacDoDT(string id , string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietTaiBienPhauThuThuat(string id , string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietThucHienVatLyTriLieu(string id , string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		
		[HttpGet("{id}")]
		public ActionResult ThucHienVatLyTriLieu(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult TongKet15NgayDieuTri(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult TaiBienThuocThuThuatPhauThuat(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]

		public ActionResult ThongTinTuVong(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult UploadFilePhiCauTruc(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietChanDoanHinhAnh(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult ThemChanDoanHinhAnh(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult ThemMoiThamDoChucNang(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietThamDoChucNang(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult ThemMoiTheoDoiVaChamSoc(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietTheoDoiVaChamSoc(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}")]
		public ActionResult ThemMoiPhieuKhamChuyenKhoa(string id)
		{
			ViewData["id"] = id;
			return Khoitao(cache);
		}
		[HttpGet("{id}/chi-tiet/{stt}")]
		public ActionResult ChiTietPhieuKhamChuyenKhoa(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/{stt}")]
		public ActionResult PhieuPhauThuat(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/{stt}")]
		public ActionResult CamKetPhauThuat(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/{stt}")]
		public ActionResult PhieuKhamGayMe(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		[HttpGet("{id}/{stt}")]
		public ActionResult PhieuDuyetMo(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		
		[HttpGet("{id}/loai-phieu/{stt}")]
		public ActionResult LoaiPhieuPhauThuat(string id, string stt)
		{
			ViewData["id"] = id;
			ViewData["stt"] = stt;
			return Khoitao(cache);
		}
		#endregion Khởi tạo

	}
}
