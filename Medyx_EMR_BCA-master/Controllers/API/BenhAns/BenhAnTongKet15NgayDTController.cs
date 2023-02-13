using System.Security.Cryptography.X509Certificates;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using Medyx.ApiAssets.Dto.Print;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Medyx.ApiAssets.Models.Configure;
using Microsoft.AspNetCore.Http;
using Medyx_EMR_BCA.ApiAssets.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAnKhoaDieuTris
{
    [Route("api/benh-an-tong-ket-15-ngay")]
    [ApiController]
    [SessionFilter]
    public class BenhAnTongKet15NgayDTController : ControllerBase
    {
        private IRepository<BenhAnTongKet15NgayDt> repository = null;
        private readonly IHostingEnvironment _hostingEnvironment;
        private UploadFileRespository uploadFileRespository = null;
        private PrintSetting PrintSetting { get; set; }

        public BenhAnTongKet15NgayDTController(IHostingEnvironment hostingEnvironment, IOptions<PrintSetting> options, IHttpContextAccessor accessor)
        {
            repository = new GenericRepository<BenhAnTongKet15NgayDt>(accessor);
            _hostingEnvironment = hostingEnvironment;
            uploadFileRespository = new UploadFileRespository();
            PrintSetting = options.Value;
        }

        // GET: api/<BenhAnKhoaDieuTriController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<BenhAnTongKet15NgayDtDto> Get([FromQuery] BenhAnTongKet15NgayDTParameters parameters)
        {
            var user = SessionHelper.GetObjectFromJson<UserSession>(HttpContext.Session, "UserProfileSessionData");
            var query = repository.Table.AsQueryable();
            query = query.Include(x => x.DmTruongKhoa)
                        .Include(x => x.DmBsdieuTri)
                        .Include(x => x.DmNguoiLap)
                        .Include(x => x.DmNguoiSD)
                        .Include(x => x.DmNguoiHuy)
                        .Include(x => x.BenhAnKhoaDieuTri).ThenInclude(x => x.Dmkhoa);
            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }

            query = SortHelper.ApplySort(query, parameters.SortBy);

            var querySelect = BenhAnTongKet15NgayDtDtoQuery();
            var new_query = query.Select(querySelect);


            return Res<BenhAnTongKet15NgayDtDto>.Get(new_query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<BenhAnKhoaDieuTriController>/5
        [HttpGet("{id}/chi-tiet/{stt}")]
        public BenhAnTongKet15NgayDt Detail(decimal id, int stt)
        {
            var model = repository.GetById(id, stt);
            return model;
        }

        [HttpPost("{idba}/them-moi")]
        [SetActionContextItem(ActionType.Create)]
		[SessionMiddlewareFilter("HSBA/SoKet15NgayDT/create")]
        public ActionResult Store(decimal idba, [FromBody] BenhAnTongKet15NgayDtCreateVM info)
        {
            if (ModelState.IsValid)
            {
                var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
                var stt = (repository.Table.Where(x => x.Idba == idba).Max(x => (int?)x.Stt) ?? 0) + 1;
                info.MaBa = benhan.MaBa;
                info.MaBn = benhan.MaBn;
                info.Idba = idba;
                info.Stt = stt;
                repository.Insert(info);
            }
            return Ok();
        }

        // PUT api/<BenhAnKhoaDieuTriController>/5
        [HttpPut("{idba}/cap-nhat/{stt}")]
        [SetActionContextItem(ActionType.Update)]
		[SessionMiddlewareFilter("HSBA/SoKet15NgayDT/modify")]
        public ActionResult Update(decimal idba, int stt, [FromBody] BenhAnTongKet15NgayDtVM info)
        {
            if (ModelState.IsValid)
            {
                PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
                repository.Update(info, idba, stt);
            }
            return Ok();
        }

        // DELETE api/<BenhAnKhoaDieuTriController>/5
        [HttpDelete("{idba}/xoa/{stt}")]
        [SetActionContextItem(ActionType.Delete)]
		[SessionMiddlewareFilter("HSBA/SoKet15NgayDT/delete")]
        public ActionResult Delete(decimal idba, int stt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            repository.Delete(idba, stt);
            return Ok();
        }
        [HttpGet("{idba}/print-ba-file/{stt}/{maba}.pdf")]
		[SessionMiddlewareFilter("HSBA/SoKet15NgayDT/export")]
        public ActionResult Print(decimal idba, int stt)
        {
            var benhAn = repository._context.BenhAn
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
            var query = repository.Table.AsQueryable();
            var querySelect = BenhAnTongKet15NgayDtDtoQuery();
            var new_query = query.Select(querySelect);
            var BenhAnTongKet15NgayDT = new_query.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);

            List<BenhAnTongKet15NgayDTPrintDto> BenhAnTongKet15NgayDTs = new List<BenhAnTongKet15NgayDTPrintDto>();

            BenhAnTongKet15NgayDTs.Add(new BenhAnTongKet15NgayDTPrintDto()
            {
                SoYTe = PrintSetting.SoYTe,
                BenhVien = PrintSetting.BenhVien,
                SoVaoVien = benhAn.SoVaoVien,
                HoTen = benhAn.BenhNhan.HoTen,
                Tuoi = benhAn.BenhNhan.Tuoi.ToString(),
                GioiTinh = benhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
                DiaChi = PrintHelper.HanlderDiaChiText(benhAn?.BenhNhan?.SoNha, benhAn?.BenhNhan?.Thon, benhAn?.BenhNhan?.PhuongXa?.TenPxa, benhAn?.BenhNhan?.QuanHuyen?.TenQh, benhAn?.BenhNhan?.Tinh?.TenTinh),
                Giuong = BenhAnTongKet15NgayDT.KhoaDieuTri.Giuong.TenGiuong,
                Buong = BenhAnTongKet15NgayDT.KhoaDieuTri.Buong.TenBuong,
                ChuanDoan = BenhAnTongKet15NgayDT.KhoaDieuTri.BenhChinh.TenBenh,
                DienBienLamSan = BenhAnTongKet15NgayDT.DienBienLamSang,
                XetNghiemLamSan = BenhAnTongKet15NgayDT.XnlamSang,
                QuaTrinhDieuTri = BenhAnTongKet15NgayDT.QuaTrinhDt,
                DanhGiaKetQua = BenhAnTongKet15NgayDT.DanhGiaKq,
                HuongDieuTri = BenhAnTongKet15NgayDT.HuongDt,
                TruongKhoa = BenhAnTongKet15NgayDT.TruongKhoa.HoTen,
                BacSiDieuTri = BenhAnTongKet15NgayDT.BsdieuTri.HoTen
            });

            string path = PrintHelper.PrintFile<BenhAnTongKet15NgayDTPrintDto>(_hostingEnvironment, "Phieu-so-ket-15-ngay-dieu-tri.doc", null, null, BenhAnTongKet15NgayDTs, "TongKet15NgayDT");
            DownloadFileResult downloadFileResult = uploadFileRespository.Download(path, true, true);
            return File(downloadFileResult.FileBytes, downloadFileResult.contentType);
        }
        private Expression<Func<BenhAnTongKet15NgayDt, BenhAnTongKet15NgayDtDto>> BenhAnTongKet15NgayDtDtoQuery()
        {
            return ba => new BenhAnTongKet15NgayDtDto()
            {
                Idba = ba.Idba,
                Stt = ba.Stt,
                Idhis = ba.Idhis,
                MaBa = ba.MaBa,
                MaBn = ba.MaBn,
                Sttkhoa = ba.Sttkhoa,
                TuNgay = ba.TuNgay,
                DenNgay = ba.DenNgay,
                DienBienLamSang = ba.DienBienLamSang,
                XnlamSang = ba.XnlamSang,
                QuaTrinhDt = ba.QuaTrinhDt,
                DanhGiaKq = ba.DanhGiaKq,
                HuongDt = ba.HuongDt,
                NgayKyTruongKhoa = ba.NgayKyTruongKhoa,
                TruongKhoa = new DmnhanVienDto()
                {
                    HoTen = ba.DmTruongKhoa.HoTen,
                    MaNv = ba.DmTruongKhoa.MaNv,
                },
                NgayKyBsdieuTri = ba.NgayKyBsdieuTri,
                BsdieuTri = new DmnhanVienDto()
                {
                    HoTen = ba.DmBsdieuTri.HoTen,
                    MaNv = ba.DmBsdieuTri.MaNv,
                },
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
                    MaKhoa = ba.BenhAnKhoaDieuTri.MaKhoa,
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
        public string Print(decimal idba, int stt, bool shouldReturnPath = true)
        {
            var benhAn = repository._context.BenhAn
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
            var query = repository.Table.AsQueryable();
            var querySelect = BenhAnTongKet15NgayDtDtoQuery();
            var new_query = query.Select(querySelect);
            var BenhAnTongKet15NgayDT = new_query.FirstOrDefault(x => x.Idba == idba && x.Stt == stt);

            List<BenhAnTongKet15NgayDTPrintDto> BenhAnTongKet15NgayDTs = new List<BenhAnTongKet15NgayDTPrintDto>();

            BenhAnTongKet15NgayDTs.Add(new BenhAnTongKet15NgayDTPrintDto()
            {
                SoYTe = PrintSetting.SoYTe,
                BenhVien = PrintSetting.BenhVien,
                SoVaoVien = benhAn.SoVaoVien,
                HoTen = benhAn.BenhNhan.HoTen,
                Tuoi = benhAn.BenhNhan.Tuoi.ToString(),
                GioiTinh = Convert.ToBoolean(benhAn.BenhNhan.GioiTinh) ? "Nam" : "Nữ",
                DiaChi = $"{benhAn.BenhNhan.SoNha}, {benhAn.BenhNhan.PhuongXa.TenPxa}, {benhAn.BenhNhan.QuanHuyen.TenQh}, {benhAn.BenhNhan.Tinh.TenTinh}, {benhAn.BenhNhan.QuocGia.TenQg}",
                Giuong = BenhAnTongKet15NgayDT.KhoaDieuTri.Giuong.TenGiuong,
                Buong = BenhAnTongKet15NgayDT.KhoaDieuTri.Buong.TenBuong,
                ChuanDoan = BenhAnTongKet15NgayDT.KhoaDieuTri.BenhChinh.TenBenh,
                DienBienLamSan = BenhAnTongKet15NgayDT.DienBienLamSang,
                XetNghiemLamSan = BenhAnTongKet15NgayDT.XnlamSang,
                QuaTrinhDieuTri = BenhAnTongKet15NgayDT.QuaTrinhDt,
                DanhGiaKetQua = BenhAnTongKet15NgayDT.DanhGiaKq,
                HuongDieuTri = BenhAnTongKet15NgayDT.HuongDt,
                TruongKhoa = BenhAnTongKet15NgayDT.TruongKhoa.HoTen,
                BacSiDieuTri = BenhAnTongKet15NgayDT.BsdieuTri.HoTen
            });

            string path = PrintHelper.PrintFile<BenhAnTongKet15NgayDTPrintDto>(_hostingEnvironment, "Phieu-so-ket-15-ngay-dieu-tri.doc", null, null, BenhAnTongKet15NgayDTs, "TongKet15NgayDT");
            return path;
        }
    }
}
