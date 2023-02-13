using Medyx.ApiAssets.Dto.Print;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnClsService
    {
        private IRepository<BenhanCls> repository = null;
        private IRepository<BenhAnClsKq> _benhAnClsKqRepositoty;
        private IRepository<DmdichvuGoiC> _dmdichvuGoiCRepositoty;
        private readonly IHostingEnvironment _hostingEnvironment;
        private BenhAnFilePhiCauTrucService _benhAnFilePhiCauTrucService;
        private UploadFileRespository _uploadFileRespository;
        private PrintSetting PrintSetting { get; set; }
        private IHttpContextAccessor _accessor { get; set; }
        public BenhAnClsService(IHostingEnvironment hostingEnvironment = null, IOptions<PrintSetting> options = null, IHttpContextAccessor accessor = null, UploadFileRespository uploadFileRespository = null)
        {
            repository = new GenericRepository<BenhanCls>(accessor);
            _benhAnFilePhiCauTrucService = new BenhAnFilePhiCauTrucService(accessor);
            _dmdichvuGoiCRepositoty = new GenericRepository<DmdichvuGoiC>(accessor);
            // _benhAnClsKqRepositoty = new GenericRepository<BenhAnClsKq>(accessor, repository._context);
            _benhAnClsKqRepositoty = new GenericRepository<BenhAnClsKq>(accessor);
            _hostingEnvironment = hostingEnvironment;
            PrintSetting = options != null ? options.Value : new PrintSetting();
            _uploadFileRespository = uploadFileRespository;
            _accessor = accessor;
            if (uploadFileRespository != null)
            {
                _uploadFileRespository.setDirectoryName("Public/BenhanCls");
            }
        }

        private IQueryable<BenhanCls> QueryFilter(IQueryable<BenhanCls> query, BenhAnClsParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.Search))
            {
            }
            if (!string.IsNullOrEmpty(parameters.MaChungLoai))
            {
                query = query.Where(x => x.DmdichVu.MaChungloai == parameters.MaChungLoai);
            }
            if (!string.IsNullOrEmpty(parameters.ExcludeMaChungLoai))
            {
                query = query.Where(x => x.DmdichVu.MaChungloai != parameters.ExcludeMaChungLoai);
            }
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.NgayYlenh.HasValue)
            {
                query = query.Where(x => x.NgayYlenh == parameters.NgayYlenh);
            }
            query = SortHelper.ApplySort(query, parameters.SortBy);
            return query;
        }
        public IQueryable<BenhAnClsDto> Get(BenhAnClsParameters parameters, UserSession user = null)
        {
            var query = repository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }
            query = QueryFilter(query, parameters);
            var querySelect = BenhAnClsDtoQuery(true, parameters.WithKq, parameters.WithKqCls);
            var query_result = query.Select(querySelect);
            if (parameters.ForPhieuXetNghiem)
            {
                query_result = from pxn in query_result 
                               join chiDinh in repository._context.DmdichvuNhomInChiDinh on pxn.MaDv equals chiDinh.MaDv
                               select new  BenhAnClsDto()
                               {
                                   Idba = pxn.Idba,
                                   Stt = pxn.Stt,
                                   Idhis = pxn.Idhis,
                                   MaBa = pxn.Idhis,
                                   MaBn = pxn.MaBn,
                                   Sttkhoa = pxn.Sttkhoa,
                                   DoiTuong = pxn.DoiTuong,
                                   MaDv = pxn.MaDv,
                                   ViTri = pxn.ViTri,
                                   Capcuu = pxn.Capcuu,
                                   Huy = pxn.Huy,
                                   MaMay = pxn.MaMay,
                                   NgayLap = pxn.NgayLap,
                                   NgaySd = pxn.NgaySd,
                                   NgayHuy = pxn.NgayHuy,
                                   NgayYlenh = pxn.NgayYlenh,
                                   BsChiDinh = new DmnhanVienDto()
                                   {
                                       MaNv = pxn.BsChiDinh.MaNv,
                                       HoTen = pxn.BsChiDinh.HoTen
                                   },
                                   NguoiHuy = new DmnhanVienDto()
                                   {
                                       MaNv = pxn.NguoiHuy.MaNv,
                                       HoTen = pxn.NguoiHuy.HoTen
                                   },
                                   NguoiLap = new DmnhanVienDto()
                                   {
                                       MaNv = pxn.NguoiLap.MaNv,
                                       HoTen = pxn.NguoiLap.HoTen
                                   },
                                   NguoiSD = new DmnhanVienDto()
                                   {
                                       MaNv = pxn.NguoiSD.MaNv,
                                       HoTen = pxn.NguoiSD.HoTen
                                   },
                                   KhoaDieuTri = new BenhAnKhoaDieuTriDto()
                                   {
                                       NgayVaoKhoa = pxn.KhoaDieuTri.NgayVaoKhoa,
                                       Stt = pxn.KhoaDieuTri.Stt,
                                       Idba = pxn.KhoaDieuTri.Idba,
                                       MaBsDieutri = pxn.KhoaDieuTri.MaBsDieutri,
                                       Khoa = new DmkhoaDto()
                                       {
                                           TenKhoa = pxn.KhoaDieuTri.Khoa.TenKhoa,
                                           MaKhoa = pxn.KhoaDieuTri.Khoa.MaKhoa,
                                       },
                                       BsdieuTri = new DmnhanVienDto()
                                       {
                                           HoTen = pxn.KhoaDieuTri.BsdieuTri.HoTen,
                                           MaNv = pxn.KhoaDieuTri.BsdieuTri.MaNv,
                                       }
                                   },
                                   DichVu = new DmdichVuDto()
                                   {
                                       MaDv = pxn.DichVu.MaDv,
                                       MaChungloai = pxn.DichVu.MaChungloai,
                                       TenDv = pxn.DichVu.TenDv,
                                       TenTat = pxn.DichVu.TenTat,
                                       MaLh = pxn.DichVu.MaLh
                                   },

                               };
            }
            return query_result;
        }
        public BenhAnClsDto Show(decimal id, int stt)
        {
            var query = repository.Table.AsQueryable();
            var querySelect = BenhAnClsDtoQuery(false, false);
            var query_result = query.Select(querySelect);
            var data = query_result.FirstOrDefault(x => x.Idba == id && x.Stt == stt);
            var benhAnClsKq = repository._context.BenhAnClsKq.Select(x => new BenhAnClsKqDto()
            {
                Idba = x.Idba,
                Stt = x.Stt,
                Sttdv = x.Sttdv,
                MoTa = x.MoTa,
                KetLuan = x.KetLuan,
                SoPhieu = x.SoPhieu,
                LinkPacsLis = x.LinkPacsLis,
                MaKhoaThucHien = x.MaKhoaThucHien,
                KyThuat = x.KyThuat,
                NgayTiepNhan = x.NgayTiepNhan,
                NgayKq = x.NgayKq,
                CapCuu = x.CapCuu,
                BschuyenKhoa = new DmnhanVienDto()
                {
                    MaNv = x.DmBschuyenKhoa.MaNv,
                    HoTen = x.DmBschuyenKhoa.HoTen
                }
            }).FirstOrDefault(x => x.Idba == data.Idba && x.Sttdv == data.Stt);
            benhAnClsKq = benhAnClsKq ?? new BenhAnClsKqDto()
            {
                BschuyenKhoa = new DmnhanVienDto()
            };
            data.BenhAnClsKq = benhAnClsKq;
            return data;
        }

        #region Khong su dung
        public void Store(BenhAnClsWithFileCreateVM info)
        {
            var benhan = repository._context.BenhAn.First(x => x.Idba == info.Idba);
            info.MaBa = benhan.MaBa;
            info.MaBn = benhan.MaBn;
            info.Stt = (repository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            repository.Insert<BenhAnClsVM>(info, (model) =>
            {

                //add or update BenhAnClsKq
                BenhAnClsKqCreateOrUpdate(info, model);
                //add file
                if (info.Files.Any())
                {
                    foreach (var file in info.Files)
                    {
                        var fileVM = new BenhAnFilePhiCauTrucVM()
                        {
                            Idba = info.Idba,
                            LoaiTaiLieu = info.LoaiTaiLieu,
                            File = file,
                            Sttdv = info.Stt
                        };
                        _benhAnFilePhiCauTrucService.Store(fileVM);
                    }
                }
            });
        }
        #endregion

        public void StoreInToDieuTri(BenhAnClsCreateVM benhAnClsCreateVM)
        {
            var benhan = GetBenhAnAndCheckPermission(benhAnClsCreateVM.Idba);
            var benhAnToDieuTri = repository._context.BenhAnToDieuTri.First(x => x.Idba == benhAnClsCreateVM.Idba && x.NgayYlenh == benhAnClsCreateVM.NgayYlenh);
            var stt = (repository.Table.Where(x => x.Idba == benhAnClsCreateVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

            if (!string.IsNullOrEmpty(benhAnClsCreateVM.MaGoi))
            {
                var dichVuGois = repository._context.DmdichvuGoiC.Where(x => x.MaGoi == benhAnClsCreateVM.MaGoi).ToList();
                for (int key = 0; key < dichVuGois.Count(); key++)
                {
                    benhAnClsCreateVM.Stt = stt + key;
                    // benhAnClsCreateVM.Idhis = "";
                    benhAnClsCreateVM.MaBa = benhan.MaBa;
                    benhAnClsCreateVM.MaBn = benhan.MaBn;
                    benhAnClsCreateVM.MaDv = dichVuGois[key].MaDv;
                    benhAnClsCreateVM.Sttkhoa = benhAnToDieuTri.Sttkhoa;
                    benhAnClsCreateVM.Bschidinh = benhAnToDieuTri.BsdieuTri;
                    repository.Insert(benhAnClsCreateVM, model => StoreKqInToDieuTri(model));
                }
            }
            else
            {
                benhAnClsCreateVM.Stt = stt;
                // benhAnClsCreateVM.Idhis = "";
                benhAnClsCreateVM.MaBa = benhan.MaBa;
                benhAnClsCreateVM.MaBn = benhan.MaBn;
                benhAnClsCreateVM.Sttkhoa = benhAnToDieuTri.Sttkhoa;
                benhAnClsCreateVM.Bschidinh = benhAnToDieuTri.BsdieuTri;
                repository.Insert(benhAnClsCreateVM, model => StoreKqInToDieuTri(model));
            }
        }
        private BenhAn GetBenhAnAndCheckPermission(decimal idba)
        {
            var benhan = repository._context.BenhAn.First(x => x.Idba == idba);
            //permission
            PermissionThrowHelper.DongBenhAnCheck(benhan.XacNhanKetThucHs);
            return benhan;
        }

        private void StoreKqInToDieuTri(BenhanCls model)
        {
            var find = _benhAnClsKqRepositoty.Table.FirstOrDefault(x => x.Idba == model.Idba && x.Sttdv == model.Stt);
            if (find == null)
            {
                var sttClskq = (_benhAnClsKqRepositoty.Table.Where(x => x.Idba == model.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
                var benhAnClsKq = new BenhAnClsKq()
                {
                    Idba = model.Idba,
                    MaBa = model.MaBa,
                    MaBn = model.MaBn,
                    Stt = sttClskq,
                    Idhis = "",
                    SoPhieu = "",
                    Sttdv = model.Stt,
                };
                repository._context.BenhAnClsKq.Add(benhAnClsKq);
                repository.Log<BenhAnClsKq>(ActionLogType.Create, benhAnClsKq);
            }
        }
        #region Su dung trong phieu kham chuyen khoa, chan doan hinh anh, tham do chuc nang
        public void Update(decimal idba, int stt, BenhAnClsVM info)
        {
            GetBenhAnAndCheckPermission(idba);

            var model = repository.GetById(idba, stt);
            CheckPermission(model);
            model.Capcuu = info.Capcuu;
            repository.Update(model, (m) =>
            {
                BenhAnClsKqCreateOrUpdate(info, m);
            }, model.Idba, model.Stt);
        }
        #endregion

        public void UpdateInToDieuTri(decimal idba, int stt, BenhAnClsUpdateVM info)
        {
            GetBenhAnAndCheckPermission(idba);
            repository.Update(info, (model) =>
            {
                CheckPermission(model, true);
                StoreKqInToDieuTri(model);
            }, idba, stt);
        }
        private void CheckPermission(BenhanCls model, bool isToDieuTri = false)
        {
            var maChungLoai = new string[] { "3", "1", "4" };
            var dichvu = repository._context.DmdichVu.Where(x => x.MaDv == model.MaDv && maChungLoai.Contains(x.MaChungloai)).FirstOrDefault();
            BenhAnClsKq benhanClsKq = null;
            if (isToDieuTri)
            {
                benhanClsKq = repository._context.BenhAnClsKq.FirstOrDefault(x => x.Idba == model.Idba && x.Sttdv == model.Stt);
            }

            if (dichvu != null)
            {
                var idhis = model.Idhis;
                var messages = "Idhis <> '' bạn không có quyền được chỉnh sửa hay xoá bản ghi này";
                if (benhanClsKq != null && (!String.IsNullOrEmpty(benhanClsKq.SoPhieu) && !String.IsNullOrEmpty(benhanClsKq.MaKhoaThucHien)))
                {
                    idhis = "1";
                    messages = "Đã tồn tại kết quả không thể chỉnh sửa hay xoá bản ghi này";
                }
                PermissionThrowHelper.IDHISCheck(idhis, messages);
            }
        }
        public void Destroy(decimal idba, int stt)
        {
            repository.Delete((model) =>
            {
                GetBenhAnAndCheckPermission(idba);
                CheckPermission(model, true);
            }, idba, stt);
        }
        private void BenhAnClsKqCreateOrUpdate(BenhAnClsVM info, BenhanCls model)
        {
            var benhAnClsKqRepository = new GenericRepository<BenhAnClsKq>(_accessor);
            var find = benhAnClsKqRepository.Table.FirstOrDefault(x => x.Idba == model.Idba && x.Sttdv == model.Stt);
            var benhAnClsKq = new BenhAnClsKq()
            {
                SoPhieu = info.SoPhieu,
                Idba = model.Idba,
                MaBa = model.MaBa,
                MaBn = model.MaBn,
                KetLuan = info.KetLuan,
                KyThuat = info.KyThuat,
                MoTa = info.MoTa,
                Sttdv = model.Stt,
                MaDv = model.MaDv,
                NgayKq = info.NgayKq,
                MaKhoaThucHien = info.MaKhoaThucHien,
                LinkPacsLis = info.LinkPacsLis,
                BschuyenKhoa = info.BsChuyenKhoa,
                NgayTiepNhan = info.NgayTiepNhan,
                CapCuu = info.Capcuu
            };
            if (find == null)
            {
                var stt = (benhAnClsKqRepository.Table.Where(x => x.Idba == info.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
                benhAnClsKq.Stt = stt;
                // benhAnClsKq.Idhis = "";
                benhAnClsKqRepository.InsertWithoutTransaction(benhAnClsKq);
            }
            else
            {
                benhAnClsKqRepository.UpdateWithoutTransaction(benhAnClsKq, find.Idba, find.Stt);
            }

        }
        public string Print(decimal idba, int stt, BenhAnClsPrintParameters parameters = null)
        {
            var benhAnCls = Show(idba, stt);
            var files = new List<BenhAnFilePhiCauTrucDto>();
            if (parameters != null)
            {
                files = (new BenhAnFilePhiCauTrucService()).Get(new BenhAnFilePhiCauTrucParameters()
                {
                    Idba = idba,
                    Sttdv = stt,
                    LoaiTaiLieu = parameters.LoaiTaiLieu,
                }).Where(x => x.Link.EndsWith(".jpg") || x.Link.EndsWith(".png")).ToList();
            }
            var dataBenhAn = repository._context.BenhAn
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
                        MaDt = ba.ThongTinBn.DmdoiTuong.MaDt
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
            string templateFile = "";
            if (parameters != null && !string.IsNullOrEmpty(parameters.MaChungLoai) && parameters.MaChungLoai == "1")
            {
                //if (parameters.MaChungLoai == "1")
                //{
                templateFile = "phieu-kham-chuyen-khoa.doc";
                //}
            }
            else
            {
                templateFile = "Ket-qua-benhan-cls-template.doc";
            }
            if (String.IsNullOrEmpty(templateFile))
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy dịch vụ");
            }
            List<BenhAnClsPrintDto> dataFill = new List<BenhAnClsPrintDto>(){
                new BenhAnClsPrintDto(){
                    SoYTe = PrintSetting?.SoYTe,
                    BenhVien = PrintSetting?.BenhVien,
                    DiaChiBenhVien = PrintSetting?.DiaChiBV,
                    DienThoaiBV = PrintSetting?.DienThoaiBV,
                    HotlineBV = PrintSetting?.HotLienBV,
                    Khoa = benhAnCls?.KhoaDieuTri?.Khoa?.TenKhoa,
                    Buong = benhAnCls?.KhoaDieuTri?.Buong?.TenBuong,
                    Giuong = benhAnCls?.KhoaDieuTri?.Giuong?.TenGiuong,
                    HoTen = dataBenhAn?.BenhNhan.HoTen?.ToUpper(),
                    SoVaoVien = dataBenhAn?.SoVaoVien,
                    Tuoi = dataBenhAn?.BenhNhan?.Tuoi?.ToString(),
                    DiaChi = PrintHelper.HanlderDiaChiText(dataBenhAn?.BenhNhan?.SoNha, dataBenhAn?.BenhNhan?.Thon, dataBenhAn?.BenhNhan?.PhuongXa?.TenPxa, dataBenhAn?.BenhNhan?.QuanHuyen?.TenQh, dataBenhAn?.BenhNhan?.Tinh?.TenTinh),
                    GioiTinh = dataBenhAn?.BenhNhan?.GioiTinh == 1 ? "Nam" : "Nữ",
                    ChanDoan = !String.IsNullOrEmpty(benhAnCls?.KhoaDieuTri?.BenhChinh?.MaBenh) ? $"{benhAnCls?.KhoaDieuTri?.BenhChinh?.MaBenh} - {benhAnCls?.KhoaDieuTri?.BenhChinh?.TenBenh}" : "",
                    BSChiDinh = benhAnCls?.BsChiDinh?.HoTen,
                    BsChuyenKhoa = benhAnCls?.BenhAnClsKq?.BschuyenKhoa?.HoTen,
                    BsDieuTri = benhAnCls?.KhoaDieuTri?.BsdieuTri?.HoTen,
                    KyThuat = benhAnCls?.BenhAnClsKq?.KyThuat,
                    HtmlMota = benhAnCls?.BenhAnClsKq?.MoTa,
                    HtmlKetLuan = benhAnCls?.BenhAnClsKq?.KetLuan,
                    TenDichVu = benhAnCls?.DichVu?.TenDv,
                    NamSinh = dataBenhAn?.BenhNhan?.NgaySinh.ToString("yyyy"),
                    BenhanClsFileDinhKemDto = new List<BenhanClsFileDinhKemDto>(),
                    YeuCauKiemTra = benhAnCls.DichVu.TenDv,
                    DoiTuong_0 = dataBenhAn?.BenhNhan?.DoiTuong.MaDt == "3" ? "x" : "",
                    DoiTuong_1 = dataBenhAn?.BenhNhan?.DoiTuong.MaDt == "1" ? "x" : "",
                    DoiTuong_2 = dataBenhAn?.BenhNhan?.DoiTuong.MaDt == "2" ? "x" : "",
                    NgayGio = PrintHelper.DateText(benhAnCls?.BenhAnClsKq?.NgayKq),
                    NgayKham = PrintHelper.DateText(benhAnCls?.KhoaDieuTri?.NgayVaoKhoa),
                    NgayChiDinh = PrintHelper.DateText(benhAnCls?.NgayYlenh),
                    MaBenhICDX = benhAnCls?.KhoaDieuTri?.BenhChinh?.MaBenh
                }
            };
            foreach (var file in files)
            {
                if (_uploadFileRespository != null && File.Exists(_uploadFileRespository.GetFullDirectoryWithDishStorage(file.Link)))
                {
                    dataFill[0].BenhanClsFileDinhKemDto.Add(new BenhanClsFileDinhKemDto()
                    {
                        ImageFile = _uploadFileRespository.GetFullDirectoryWithDishStorage(file.Link)
                    });
                }
            }
            var dataset = DatasetHelper.ConvertToDataSet<BenhAnClsPrintDto>(dataFill);
            var list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry("BenhAnClsPrintDto", string.Empty));
            list.Add(new DictionaryEntry("BenhanClsFileDinhKemDto", "ParentID= %BenhAnClsPrintDto.ID%"));
            string path = PrintHelper.PrintFileWithTable(_hostingEnvironment, templateFile, dataset, list, null, null);
            // string path = PrintHelper.PrintFile<BenhAnClsPrintDto>(_hostingEnvironment, templateFile, null, null, dataFill, "BenhAnClsPrintDto");
            return path;
        }
        private Expression<Func<BenhanCls, BenhAnClsDto>> BenhAnClsDtoQuery(bool withoutMotaKetLuan = false, bool withKq = true, bool withKqCls = false)
        {
            if (!withKq)
            {
                return ba => new BenhAnClsDto()
                {
                    Idba = ba.Idba,
                    Stt = ba.Stt,
                    Idhis = ba.Idhis,
                    MaBa = ba.Idhis,
                    MaBn = ba.MaBn,
                    Sttkhoa = ba.Sttkhoa,
                    DoiTuong = ba.DoiTuong,
                    MaDv = ba.MaDv,
                    ViTri = ba.ViTri,
                    Capcuu = ba.Capcuu,
                    Huy = ba.Huy,
                    MaMay = ba.MaMay,
                    NgayLap = ba.NgayLap,
                    NgaySd = ba.NgaySd,
                    NgayHuy = ba.NgayHuy,
                    NgayYlenh = ba.NgayYlenh,
                    BsChiDinh = new DmnhanVienDto()
                    {
                        MaNv = ba.DmnhanVien.MaNv,
                        HoTen = ba.DmnhanVien.HoTen
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
                        MaKhoa = ba.BenhAnKhoaDieuTri.MaKhoa,
                        MaBsDieutri = ba.BenhAnKhoaDieuTri.BsdieuTri,
                        BsdieuTri = new DmnhanVienDto()
                        {
                            HoTen = ba.BenhAnKhoaDieuTri.DmnhanVien.HoTen,
                            MaNv = ba.BenhAnKhoaDieuTri.DmnhanVien.MaNv
                        },
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
                    } : new BenhAnKhoaDieuTriDto(),
                    DichVu = new DmdichVuDto()
                    {
                        MaDv = ba.DmdichVu.MaDv,
                        MaChungloai = ba.DmdichVu.MaChungloai,
                        TenDv = ba.DmdichVu.TenDv,
                        TenTat = ba.DmdichVu.TenTat,
                        MaLh = ba.DmdichVu.MaLh
                    },

                };
            }
            if (withKqCls)
            {
                return ba => new BenhAnClsDto()
                {
                    Idba = ba.Idba,
                    Stt = ba.Stt,
                    Idhis = ba.Idhis,
                    MaBa = ba.Idhis,
                    MaBn = ba.MaBn,
                    Sttkhoa = ba.Sttkhoa,
                    DoiTuong = ba.DoiTuong,
                    MaDv = ba.MaDv,
                    ViTri = ba.ViTri,
                    Capcuu = ba.Capcuu,
                    Huy = ba.Huy,
                    MaMay = ba.MaMay,
                    NgayLap = ba.NgayLap,
                    NgaySd = ba.NgaySd,
                    NgayHuy = ba.NgayHuy,
                    NgayYlenh = ba.NgayYlenh,
                    BsChiDinh = new DmnhanVienDto()
                    {
                        MaNv = ba.DmnhanVien.MaNv,
                        HoTen = ba.DmnhanVien.HoTen
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
                        MaKhoa = ba.BenhAnKhoaDieuTri.MaKhoa,
                        MaBsDieutri = ba.BenhAnKhoaDieuTri.BsdieuTri,
                        BsdieuTri = new DmnhanVienDto()
                        {
                            HoTen = ba.BenhAnKhoaDieuTri.DmnhanVien.HoTen,
                            MaNv = ba.BenhAnKhoaDieuTri.DmnhanVien.MaNv
                        },
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
                    } : new BenhAnKhoaDieuTriDto(),
                    DichVu = new DmdichVuDto()
                    {
                        MaDv = ba.DmdichVu.MaDv,
                        MaChungloai = ba.DmdichVu.MaChungloai,
                        TenDv = ba.DmdichVu.TenDv,
                        TenTat = ba.DmdichVu.TenTat,
                        MaLh = ba.DmdichVu.MaLh
                    },
                    BenhAnClsKq = new BenhAnClsKqDto()
                    {
                        Idba = ba.Idba,
                        Stt = ba.BenhAnClsKq.Stt,
                        Sttdv = ba.BenhAnClsKq.Sttdv,
                        MoTa = withoutMotaKetLuan ? "" : ba.BenhAnClsKq.MoTa,
                        KetLuan = withoutMotaKetLuan ? "" : ba.BenhAnClsKq.KetLuan,
                        SoPhieu = ba.BenhAnClsKq.SoPhieu,
                        LinkPacsLis = ba.BenhAnClsKq.LinkPacsLis,
                        MaKhoaThucHien = ba.BenhAnClsKq.MaKhoaThucHien,
                        KyThuat = ba.BenhAnClsKq.KyThuat,
                        NgayTiepNhan = ba.BenhAnClsKq.NgayTiepNhan,
                        NgayKq = ba.BenhAnClsKq.NgayKq,
                        CapCuu = ba.BenhAnClsKq.CapCuu,
                        BschuyenKhoa = new DmnhanVienDto()
                        {
                            MaNv = ba.BenhAnClsKq.DmBschuyenKhoa.MaNv,
                            HoTen = ba.BenhAnClsKq.DmBschuyenKhoa.HoTen
                        }
                    },
                    BenhanClsKqcs = ba.BenhanClsKqcss.Select(kqcs => new BenhAnClsKqcsDto()
                    {
                        SoPhieu = kqcs.SoPhieu,
                        TenCs = kqcs.TenCs,
                        Kq = kqcs.Kq,
                        DonViDo = kqcs.DonViDo,
                        ChiSoBinhThuongNam = kqcs.ChiSoBinhThuongNam,
                        ChiSoBinhThuongNu = kqcs.ChiSoBinhThuongNu,
                        ChiSoBinhThuongNhi = kqcs.ChiSoBinhThuongNhi,
                        BatThuong = kqcs.BatThuong,
                        MaMayThucHien = kqcs.MaMayThucHien,
                        KetLuan = kqcs.KetLuan,
                        NgayTraKq = kqcs.NgayKyKq,
                        NgayKyKq = kqcs.NgayKyKq,
                        NguoiDuyetKq = new DmnhanVienDto()
                        {
                            HoTen = kqcs.DmNguoiDuyetKq.HoTen
                        },
                        Ktv = new DmnhanVienDto()
                        {
                            HoTen = kqcs.DmKtv.HoTen
                        },
                        KhoaThucHien = new DmkhoaDto()
                        {
                            TenKhoa = kqcs.DmKhoaThucHien.TenKhoa
                        }
                    }).ToList()
                };
            }
            return ba => new BenhAnClsDto()
            {
                Idba = ba.Idba,
                Stt = ba.Stt,
                Idhis = ba.Idhis,
                MaBa = ba.Idhis,
                MaBn = ba.MaBn,
                Sttkhoa = ba.Sttkhoa,
                DoiTuong = ba.DoiTuong,
                MaDv = ba.MaDv,
                ViTri = ba.ViTri,
                Capcuu = ba.Capcuu,
                Huy = ba.Huy,
                MaMay = ba.MaMay,
                NgayLap = ba.NgayLap,
                NgaySd = ba.NgaySd,
                NgayHuy = ba.NgayHuy,
                NgayYlenh = ba.NgayYlenh,
                BsChiDinh = new DmnhanVienDto()
                {
                    MaNv = ba.DmnhanVien.MaNv,
                    HoTen = ba.DmnhanVien.HoTen
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
                    MaBsDieutri = ba.BenhAnKhoaDieuTri.BsdieuTri,
                    BsdieuTri = new DmnhanVienDto()
                    {
                        HoTen = ba.BenhAnKhoaDieuTri.DmnhanVien.HoTen,
                        MaNv = ba.BenhAnKhoaDieuTri.DmnhanVien.MaNv
                    },
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
                } : new BenhAnKhoaDieuTriDto(),
                DichVu = new DmdichVuDto()
                {
                    MaDv = ba.DmdichVu.MaDv,
                    MaChungloai = ba.DmdichVu.MaChungloai,
                    TenDv = ba.DmdichVu.TenDv,
                    TenTat = ba.DmdichVu.TenTat,
                    MaLh = ba.DmdichVu.MaLh
                },
                BenhAnClsKq = new BenhAnClsKqDto()
                {
                    Idba = ba.Idba,
                    Stt = ba.BenhAnClsKq.Stt,
                    Sttdv = ba.BenhAnClsKq.Sttdv,
                    MoTa = withoutMotaKetLuan ? "" : ba.BenhAnClsKq.MoTa,
                    KetLuan = withoutMotaKetLuan ? "" : ba.BenhAnClsKq.KetLuan,
                    SoPhieu = ba.BenhAnClsKq.SoPhieu,
                    LinkPacsLis = ba.BenhAnClsKq.LinkPacsLis,
                    MaKhoaThucHien = ba.BenhAnClsKq.MaKhoaThucHien,
                    KyThuat = ba.BenhAnClsKq.KyThuat,
                    NgayTiepNhan = ba.BenhAnClsKq.NgayTiepNhan,
                    NgayKq = ba.BenhAnClsKq.NgayKq,
                    CapCuu = ba.BenhAnClsKq.CapCuu,
                    BschuyenKhoa = new DmnhanVienDto()
                    {
                        MaNv = ba.BenhAnClsKq.DmBschuyenKhoa.MaNv,
                        HoTen = ba.BenhAnClsKq.DmBschuyenKhoa.HoTen
                    }
                },
            };
        }

        public void PrintSaveImageFile(decimal idba, int stt, BenhAnClsFilePrintUploadVM info)
        {
            foreach (var property in info.GetType().GetProperties())
            {
                var value = property.GetValue(info, null);
                if (property.Name.StartsWith("path"))
                {
                    continue;
                }
                var getPath = info.GetType().GetProperty($"path{property.Name}").GetValue(info, null);
                if (value != null && value is IFormFile file)
                {
                    _uploadFileRespository.RemoveDirectoryPath($"{idba}_{stt}/{property.Name}", true, true);
                    _uploadFileRespository.Store(file, $"{idba}_{stt}/{property.Name}");
                }
                else if (getPath == null || getPath?.ToString() == "null")
                {
                    _uploadFileRespository.RemoveDirectoryPath($"{idba}_{stt}/{property.Name}", true, true);
                }
            }
        }
        public BenhAnClsFilePrintVM getFilePrint(decimal idba, int stt)
        {
            var result = new BenhAnClsFilePrintVM();
            var path = $"{idba}_{stt}";
            var dirs = _uploadFileRespository.GetDirectory(path);
            foreach (var dir in dirs)
            {
                foreach (var property in result.GetType().GetProperties())
                {
                    if (property.Name == $"path{dir}")
                    {
                        var files = _uploadFileRespository.GetFiles($"{path}/{dir}");
                        if (files.Length > 0)
                        {
                            property.SetValue(result, $"/StaticFiles/BenhanCls/{path}/{dir}/{files[0]}");
                        }
                    }
                }
            }
            return result;
        }
    }
}
