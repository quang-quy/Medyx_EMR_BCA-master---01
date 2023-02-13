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
    public class BenhAnTheoDoiTruyenDichService
    {
        private IRepository<BenhanTheodoiTruyenDich> _benhanTheodoiTruyenDichRepository = null;
        private PrintSetting PrintSetting { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        public BenhAnTheoDoiTruyenDichService(IHostingEnvironment hostingEnvironment = null, IHttpContextAccessor accessor = null, IOptions<PrintSetting> options = null)
        {
            _benhanTheodoiTruyenDichRepository = new GenericRepository<BenhanTheodoiTruyenDich>(accessor);
            PrintSetting = options != null ? options.Value : new PrintSetting();
            _hostingEnvironment = hostingEnvironment;
        }

        public IQueryable<BenhanTheodoiTruyenDichDto> Get(BenhanTheodoiTruyenDichParameters parameters, UserSession user = null)
        {
            var query = _benhanTheodoiTruyenDichRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);

            IQueryable<BenhanTheodoiTruyenDichDto> benhAnPhauThuatQuery = query.Select(x => new BenhanTheodoiTruyenDichDto()
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
                },
                ThoiGianBatDau = x.ThoiGianBatDau,
                ThoiGianKetThuc = x.ThoiGianKetThuc,
                MaDichTruyen = x.MaDichTruyen,
                TenDichTruyen = x.TenDichTruyen,
                SoLuong = x.SoLuong,
                SoLo = x.SoLo,
                TocDo = x.TocDo,
                BschiDinh = new DmnhanVienDto()
                {
                    MaNv = x.DmBschiDinh.MaNv,
                    HoTen = x.DmBschiDinh.HoTen
                },
                DieuDuong = new DmnhanVienDto()
                {
                    MaNv = x.DmDieuDuong.MaNv,
                    HoTen = x.DmDieuDuong.HoTen
                },
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
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
            return benhAnPhauThuatQuery;
        }

        private IQueryable<BenhanTheodoiTruyenDich> QueryFilter(IQueryable<BenhanTheodoiTruyenDich> query, BenhanTheodoiTruyenDichParameters parameters)
        {
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            return query;
        }

        public BenhanTheodoiTruyenDichDto Detail(decimal idba, int stt)
        {
            return _benhanTheodoiTruyenDichRepository.Table.Where(x => x.Idba == idba && x.Stt == stt).Select(x => new BenhanTheodoiTruyenDichDto()
            {
                Idba = x.Idba,
                Stt = x.Stt,
                Sttkhoa = x.Sttkhoa,
                KhoaDieuTri = new BenhAnKhoaDieuTriDto()
                {
                    NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
                    Khoa = new DmkhoaDto()
                    {
                        TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                        MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                    },
                    BsdieuTri = new DmnhanVienDto()
                    {
                        HoTen = x.BenhAnKhoaDieuTri.DmnhanVien.HoTen,
                        MaNv = x.BenhAnKhoaDieuTri.DmnhanVien.MaNv
                    }
                },
                ThoiGianBatDau = x.ThoiGianBatDau,
                ThoiGianKetThuc = x.ThoiGianKetThuc,
                MaDichTruyen = x.MaDichTruyen,
                TenDichTruyen = x.TenDichTruyen,
                SoLuong = x.SoLuong,
                SoLo = x.SoLo,
                TocDo = x.TocDo,
                BschiDinh = new DmnhanVienDto()
                {
                    MaNv = x.DmBschiDinh.MaNv,
                    HoTen = x.DmBschiDinh.HoTen
                },
                DieuDuong = new DmnhanVienDto()
                {
                    MaNv = x.DmDieuDuong.MaNv,
                    HoTen = x.DmDieuDuong.HoTen
                },
                Huy = x.Huy,
                NgayLap = x.NgayLap,
                NgayHuy = x.NgayHuy,
                NgaySd = x.NgaySd,
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
            }).FirstOrDefault();
        }

        public void Store(BenhAnTheoDoiTruyenDichCreateVM parameters)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
            var stt = (_benhanTheodoiTruyenDichRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

            parameters.Stt = stt;
            parameters.MaBa = benhAn.MaBa;
            parameters.MaBn = benhAn.MaBn;
            // parameters.Idhis = stt.ToString();

            _benhanTheodoiTruyenDichRepository.Insert(parameters);
        }

        public void Update(decimal idba, int stt, BenhAnTheoDoiTruyenDichVM benhanTheodoiTruyenDich)
        {
             PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhanTheodoiTruyenDichRepository.Update(benhanTheodoiTruyenDich, idba, stt);
        }

        public void Destroy(decimal idba, int stt)
        {
             PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhanTheodoiTruyenDichRepository.Delete(idba, stt);
        }
        // public string Print(decimal idba, int stt){

        // }
        public string Print(decimal idba)
        {
            var dataBenhAn = _benhanTheodoiTruyenDichRepository._context.BenhAn
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
                            DoiTuong = new DmdoiTuongDto()
                            {
                                MaDt = ba.ThongTinBn.DmdoiTuong.MaDt,
                                TenDt = ba.ThongTinBn.DmdoiTuong.TenDt
                            }

                        },
                    }).FirstOrDefault(x => x.Idba == idba);
            var benhAnTheoGioi = Get(new BenhanTheodoiTruyenDichParameters()
            {
                Idba = idba
            }).OrderBy(x => x.Sttkhoa).ThenBy(x => x.NgayLap).ToList();
            List<TheoDoiTruyenDichPrint> dataFill = new List<TheoDoiTruyenDichPrint>();
            foreach (var item in benhAnTheoGioi)
            {
                var index = dataFill.FindIndex(x => x.MaKhoa == item.KhoaDieuTri.Khoa.MaKhoa);
                if (index == -1)
                {
                    dataFill.Add(new TheoDoiTruyenDichPrint()
                    {
                        SoYTe = PrintSetting.SoYTe,
                        BenhVien = PrintSetting.BenhVien,
                        MaKhoa = item.KhoaDieuTri.Khoa.MaKhoa,
                        Khoa = item.KhoaDieuTri.Khoa.TenKhoa,
                        SoVV = dataBenhAn.SoVaoVien,
                        HoTen = dataBenhAn.BenhNhan.HoTen,
                        Tuoi = dataBenhAn.BenhNhan.Tuoi.ToString(),
                        GT = dataBenhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
                        Giuong = item.KhoaDieuTri.Buong.TenBuong,
                        Buong = item.KhoaDieuTri.Buong.TenBuong,
                        DoiTuong_0 = dataBenhAn?.BenhNhan?.DoiTuong?.MaDt == "3" ? "x" : "",
                        DoiTuong_1 = dataBenhAn?.BenhNhan?.DoiTuong?.MaDt == "1" ? "x" : "",
                        DoiTuong_2 = dataBenhAn?.BenhNhan?.DoiTuong?.MaDt == "2" ? "x" : "",
                        ChanDoan = !String.IsNullOrEmpty(item.KhoaDieuTri.BenhChinh.MaBenh) ? $"{item.KhoaDieuTri.BenhChinh.MaBenh} : {item.KhoaDieuTri.BenhChinh.TenBenh}" : "",
                        DetailTheoDoiTruyenDichPrint = new List<DetailTheoDoiTruyenDichPrint>(){
                            new DetailTheoDoiTruyenDichPrint(){
                                NgayThang = PrintHelper.DateTextShortest(item.NgayLap),
                                Ten = item.TenDichTruyen,
                                SoLuong = item.SoLuong.ToString(),
                                SoLo = item.SoLo,
                                TocDo = item.TocDo,
                                TGBatDau = PrintHelper.DateTimeFullTextShort(item.ThoiGianBatDau),
                                TGKetThuc = PrintHelper.DateTimeFullTextShort(item.ThoiGianKetThuc),
                                BsChiDinh = item.KhoaDieuTri.BsdieuTri.HoTen,
                                ThucHien = item.DieuDuong.HoTen,
                            }
                        }
                    });
                }
                else
                {
                    dataFill[index].DetailTheoDoiTruyenDichPrint.Add(
                        new DetailTheoDoiTruyenDichPrint()
                        {
                            NgayThang =  PrintHelper.DateTextShortest(item.NgayLap),
                            Ten = item.TenDichTruyen,
                            SoLuong = item.SoLuong.ToString(),
                            SoLo = item.SoLo,
                            TocDo = item.TocDo,
                            TGBatDau = PrintHelper.DateTimeFullTextShort(item.ThoiGianBatDau),
                            TGKetThuc = PrintHelper.DateTimeFullTextShort(item.ThoiGianKetThuc),
                            BsChiDinh = item.KhoaDieuTri.BsdieuTri.HoTen,
                            ThucHien = item.DieuDuong.HoTen,
                        }
                    );
                }
            }
            //var fields = new List<string>(){};
            //var values = new List<string>(){};

            //PrintHelper.HanlderDoiTuongSpecail(ref fields, ref values, dataBenhAn?.BenhNhan?.DoiTuong?.MaDt);

            var dataset = DatasetHelper.ConvertToDataSet<TheoDoiTruyenDichPrint>(dataFill);
            var list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry("TheoDoiTruyenDichPrint", string.Empty));
            list.Add(new DictionaryEntry("DetailTheoDoiTruyenDichPrint", "ParentID= %TheoDoiTruyenDichPrint.ID%"));
            string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, "Phieu-theo-doi-truyen-dich.docx", dataset, list);

            return path;
        }
        private class DetailTheoDoiTruyenDichPrint
        {
            public string NgayThang { get; set; }
            public string Ten { get; set; }
            public string SoLuong { get; set; }
            public string SoLo { get; set; }
            public string TocDo { get; set; }
            public string TGBatDau { get; set; }
            public string TGKetThuc { get; set; }
            public string BsChiDinh { get; set; }
            public string ThucHien { get; set; }

        }
        private class TheoDoiTruyenDichPrint
        {
            public string SoYTe { get; set; }
            public string BenhVien { get; set; }
            public string MaKhoa { get; set; }
            public string Khoa { get; set; }
            public string SoVV { get; set; }
            public string HoTen { get; set; }
            public string Tuoi { get; set; }
            public string GT { get; set; }
            public string Giuong { get; set; }
            public string Buong { get; set; }
            public string ChanDoan { get; set; }
            public string DoiTuong_0 { get; set; }
            public string DoiTuong_1 { get; set; }
            public string DoiTuong_2 { get; set; }
            public List<DetailTheoDoiTruyenDichPrint> DetailTheoDoiTruyenDichPrint { get; set; }
        }
    }

}
