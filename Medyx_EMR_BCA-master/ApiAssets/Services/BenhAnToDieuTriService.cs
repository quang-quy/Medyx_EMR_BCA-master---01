using Medyx.ApiAssets.Dto.Print;
using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnToDieuTriService
    {
        private IRepository<BenhAnToDieuTri> _benhAnToDieuTriRepository = null;
        private PrintSetting PrintSetting { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private IHttpContextAccessor _accessor { get; set; }
        public BenhAnToDieuTriService(IHostingEnvironment hostingEnvironment = null, IHttpContextAccessor accessor = null, IOptions<PrintSetting> options = null)
        {
            _benhAnToDieuTriRepository = new GenericRepository<BenhAnToDieuTri>(accessor);
            PrintSetting = options != null ? options.Value : new PrintSetting();
            _hostingEnvironment = hostingEnvironment;
            _accessor = accessor;
        }

        public IQueryable<BenhAnToDieuTriDto> Get(BenhAnToDieuTriParameters parameters, UserSession user = null)
        {
            var query = _benhAnToDieuTriRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }
            if (parameters.Huy.HasValue)
            {
                query = query.Where(x => x.Huy == parameters.Huy);
            }
            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);

            IQueryable<BenhAnToDieuTriDto> benhAnToDieuTriQuery = query.Select(batdt => new BenhAnToDieuTriDto()
            {
                Stt = batdt.Stt,
                Idba = batdt.Idba,
                Sttkhoa = batdt.Sttkhoa,
                NgayYLenh = batdt.NgayYlenh ?? null,
                KhoaDieuTri = new BenhAnToDieuTriDetailKhoaDieuTriDto()
                {
                    TenKhoa = batdt.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                    MaKhoa = batdt.BenhAnKhoaDieuTri.MaKhoa,
                    NgayVaoKhoa = batdt.BenhAnKhoaDieuTri.NgayVaoKhoa
                },
                BsdieuTri = new DmnhanVienDto()
                {
                    MaNv = batdt.DmnhanVien.MaNv ?? batdt.BenhAnKhoaDieuTri.DmnhanVien.MaNv,
                    HoTen = batdt.DmnhanVien.HoTen ?? batdt.BenhAnKhoaDieuTri.DmnhanVien.HoTen
                },
                Huy = batdt.Huy,
                NgaySd = batdt.NgaySd,
                NguoiSd = new DmnhanVienDto()
                {
                    MaNv = batdt.DmNguoiSD.MaNv,
                    HoTen = batdt.DmNguoiSD.HoTen
                },
                NgayHuy = batdt.NgayHuy,
                NguoiHuy = new DmnhanVienDto()
                {
                    MaNv = batdt.DmNguoiHuy.MaNv,
                    HoTen = batdt.DmNguoiHuy.HoTen
                },
                NgayLap = batdt.NgayLap,
                NguoiLap = new DmnhanVienDto()
                {
                    MaNv = batdt.DmNguoiLap.MaNv,
                    HoTen = batdt.DmNguoiLap.HoTen
                },
            });
            return benhAnToDieuTriQuery;
        }

        public BenhAnToDieuTriDetailDto Detail(string idba, string stt)
        {
            var query = _benhAnToDieuTriRepository.Table
                .Where(x => x.Idba == Convert.ToDecimal(idba) && x.Stt == Convert.ToUInt32(stt))
                .AsQueryable();
            var queryBenhAnToDieuTriDetail = query.Select(x => new BenhAnToDieuTriDetailDto()
            {
                BenhNhan = new BenhAnToDieuTriDetailThongTinBenhNhanDto()
                {
                    MaBn = x.ThongTinBn.MaBn,
                    HoTen = x.ThongTinBn.HoTen
                },
                KhoaDieuTri = x.BenhAnKhoaDieuTri.Idba != null ? new BenhAnToDieuTriDetailKhoaDieuTriDto()
                {
                    TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                    MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
                    NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa
                } : new BenhAnToDieuTriDetailKhoaDieuTriDto()
                {
                    TenKhoa = null,
                    MaKhoa = null,
                    NgayVaoKhoa = DateTime.MinValue
                },
                BsdieuTri = new BenhAnToDieuTriDetailDmnhanVienDto()
                {
                    MaNv = x.DmnhanVien.MaNv,
                    HoTen = x.DmnhanVien.HoTen,
                    Khoa = new DmkhoaDto()
                    {
                        MaKhoa = x.DmnhanVien.Dmkhoa.MaKhoa,
                        TenKhoa = x.DmnhanVien.Dmkhoa.TenKhoa
                    }
                },
                DienBienBenh = x.DienBienBenh,
                NgayYLenh = x.NgayYlenh ?? null,
                Ylenh = x.Ylenh,
                HuyetAp = x.HuyetAp,
                NhipTho = x.NhipTho,
                CanNang = x.CanNang,
                ChieuCao = x.ChieuCao,
                Bmi = x.Bmi,
                TrieuChung = x.TrieuChung,
                NhipTim = x.NhipTim,
                NhipTimDeu = x.NhipTimDeu,
                Kqxnmau = x.Kqxnmau,
                KqxnnuocTieu = x.KqxnnuocTieu,
                Kqcdha = x.Kqcdha,
                CsduongHuyet = x.CsduongHuyet,
                DieuTri = x.DieuTri,
                NgayHenKhamLai = x.NgayHenKhamLai,
                NgayHenXnlai = x.NgayHenXnlai,
                Huy = x.Huy,
            });
            return queryBenhAnToDieuTriDetail.FirstOrDefault();
        }
        private IQueryable<BenhAnToDieuTri> QueryFilter(IQueryable<BenhAnToDieuTri> query, BenhAnToDieuTriParameters parameters)
        {
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.NgayYlenh.HasValue)
            {
                query = query.Where(x => x.NgayYlenh == parameters.NgayYlenh);
            }
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                query = query.Where(x => x.Stt.ToString().ToLower().Contains(parameters.Search.ToLower()) || x.Dmkhoa.TenKhoa.ToLower().Contains(parameters.Search.ToLower()));
            }
            return query;
        }
        public void Store(BenhAnToDieuTriCreateVM benhAnToDieuTri)
        {
            var benhan = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnToDieuTri.Idba);
            var stt = (_benhAnToDieuTriRepository.Table.Where(x => x.Idba == benhAnToDieuTri.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            var khoaDieuTri = _benhAnToDieuTriRepository._context.BenhAnKhoaDieuTri.First(x => x.Idba == benhAnToDieuTri.Idba && x.Stt == benhAnToDieuTri.Sttkhoa);

            benhAnToDieuTri.MaBa = benhan.MaBa;
            benhAnToDieuTri.MaBn = benhan.MaBn;
            benhAnToDieuTri.Stt = stt;
            // benhAnToDieuTri.Idhis = stt.ToString();
            benhAnToDieuTri.MaKhoa = khoaDieuTri.MaKhoa;
            _benhAnToDieuTriRepository.Insert(benhAnToDieuTri);
        }

        public void MakeCopy(BenhAnToDieuTriSaoChepVM parameters)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(parameters.Idba);
            var benhAnToDieuTri = _benhAnToDieuTriRepository.Table
                .Include(x => x.BenhanThuocTayYs)
                .Include(x => x.BenhanThuocYhct).ThenInclude(x => x.BenhanThuocYhctCs)
                .Include(x => x.BenhanTtvltls)
                .Include(x => x.BenhanClses)
                .Include(x => x.BenhanPhauThuats)
                .Include(x => x.BenhanCpms)
                .First(x => x.Idba == parameters.Idba && x.NgayYlenh == parameters.NgaySaoChep);

            var stt = (_benhAnToDieuTriRepository.Table.Where(x => x.Idba == parameters.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;
            var khoaDieuTri = _benhAnToDieuTriRepository._context.BenhAnKhoaDieuTri.First(x => x.Idba == parameters.Idba && x.Stt == parameters.Sttkhoa);

            var toDieuTriClone = (BenhAnToDieuTri)_benhAnToDieuTriRepository._context.Entry(benhAnToDieuTri).CurrentValues.ToObject();

            toDieuTriClone.Stt = stt;
            toDieuTriClone.Sttkhoa = parameters.Sttkhoa;
            // toDieuTriClone.Idhis = stt.ToString();
            toDieuTriClone.MaKhoa = khoaDieuTri.MaKhoa;
            toDieuTriClone.NgayYlenh = parameters.NgayYlenh;
            toDieuTriClone.BsdieuTri = parameters.BsdieuTri;

            if (!parameters.HasDienBienBenh)
            {
                benhAnToDieuTri.DienBienBenh = null;
                benhAnToDieuTri.Ylenh = null;
            }

            _benhAnToDieuTriRepository.Insert(toDieuTriClone, (model) =>
            {
                #region Clone thuoc tay y
                if (parameters.HasBenhAnThuocTayY && benhAnToDieuTri.BenhanThuocTayYs.Any())
                {
                    var thuocTayYStt = _benhAnToDieuTriRepository._context.BenhanThuocTayY.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                    var benhanThuocTayYs = CloneList(benhAnToDieuTri.BenhanThuocTayYs.ToList());
                    for (int key = 0; key < benhanThuocTayYs.Count(); key++)
                    {
                        var benhAnThuocTayY = benhanThuocTayYs[key];

                        benhAnThuocTayY.Sttkhoa = parameters.Sttkhoa;
                        benhAnThuocTayY.NgayYlenh = parameters.NgayYlenh;
                        benhAnThuocTayY.BschiDinh = parameters.BsdieuTri;
                        benhAnThuocTayY.Stt = thuocTayYStt + key;
                        // benhAnThuocTayY.Idhis = (thuocTayYStt + key).ToString();
                        _benhAnToDieuTriRepository._context.BenhanThuocTayY.Add(benhAnThuocTayY);
                        _benhAnToDieuTriRepository.Log<BenhanThuocTayY>(ActionLogType.Create, benhAnThuocTayY);
                    }
                }
                #endregion
                #region Clone thuoc yhct
                if (parameters.HasBenhAnThuocYhct && benhAnToDieuTri.BenhanThuocYhct != null)
                {
                    var yhctStt = _benhAnToDieuTriRepository._context.BenhanThuocYhct.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                    var benhAnThuocYhct = benhAnToDieuTri.BenhanThuocYhct;

                    benhAnThuocYhct.Sttkhoa = parameters.Sttkhoa;
                    benhAnThuocYhct.NgayYlenh = parameters.NgayYlenh;
                    benhAnThuocYhct.BschiDinh = parameters.BsdieuTri;
                    benhAnThuocYhct.Stt = yhctStt;
                    // benhAnThuocYhct.Idhis = yhctStt.ToString();

                    _benhAnToDieuTriRepository._context.BenhanThuocYhct.Add(benhAnThuocYhct);
                    _benhAnToDieuTriRepository.Log<BenhanThuocYhct>(ActionLogType.Create, benhAnThuocYhct);

                    if (benhAnThuocYhct.BenhanThuocYhctCs.Any())
                    {
                        var yhctCStt = _benhAnToDieuTriRepository._context.BenhanThuocYhctC.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                        var benhanThuocYhctCs = CloneList(benhAnThuocYhct.BenhanThuocYhctCs.ToList());

                        for (int key = 0; key < benhanThuocYhctCs.Count(); key++)
                        {
                            var benhAnYhctC = benhanThuocYhctCs[key];

                            benhAnYhctC.Sttkhoa = parameters.Sttkhoa;
                            benhAnYhctC.Stt = yhctCStt + key;
                            // benhAnYhctC.Idhis = (yhctCStt + key).ToString();
                            benhAnYhctC.Sttthuoc = yhctStt;
                            _benhAnToDieuTriRepository._context.BenhanThuocYhctC.Add(benhAnYhctC);
                            _benhAnToDieuTriRepository.Log<BenhanThuocYhctC>(ActionLogType.Create, benhAnYhctC);
                        }
                    }
                }
                #endregion
                #region Clone ttvltl
                if (parameters.HasBenhAnTtvltl && benhAnToDieuTri.BenhanTtvltls.Any())
                {
                    var ttvvltlYStt = _benhAnToDieuTriRepository._context.BenhanTtvltl.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                    var benhanTtvltls = CloneList(benhAnToDieuTri.BenhanTtvltls.ToList());
                    for (int key = 0; key < benhanTtvltls.Count(); key++)
                    {
                        var benhAnTtvltl = benhanTtvltls[key];

                        benhAnTtvltl.Sttkhoa = parameters.Sttkhoa;
                        benhAnTtvltl.NgayYlenh = parameters.NgayYlenh;
                        benhAnTtvltl.Bschidinh = parameters.BsdieuTri;
                        benhAnTtvltl.Stt = ttvvltlYStt + key;
                        // benhAnTtvltl.Idhis = (ttvvltlYStt + key).ToString();
                        _benhAnToDieuTriRepository._context.BenhanTtvltl.Add(benhAnTtvltl);
                        _benhAnToDieuTriRepository.Log<BenhanTtvltl>(ActionLogType.Create, benhAnTtvltl);
                    }
                }
                #endregion
                #region Clone cls
                if (parameters.HasBenhAnCls && benhAnToDieuTri.BenhanClses.Any())
                {
                    var clsStt = _benhAnToDieuTriRepository._context.BenhanCls.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                    var benhanClses = CloneList(benhAnToDieuTri.BenhanClses.ToList());
                    for (int key = 0; key < benhanClses.Count(); key++)
                    {
                        var benhAnCls = benhanClses[key];

                        benhAnCls.Sttkhoa = parameters.Sttkhoa;
                        benhAnCls.NgayYlenh = parameters.NgayYlenh;
                        benhAnCls.Bschidinh = parameters.BsdieuTri;
                        benhAnCls.Stt = clsStt + key;
                        // benhAnCls.Idhis = (clsStt + key).ToString();
                        _benhAnToDieuTriRepository._context.BenhanCls.Add(benhAnCls);
                        _benhAnToDieuTriRepository.Log<BenhanCls>(ActionLogType.Create, benhAnCls);
                    }
                }
                #endregion
                #region Clone phau thuat
                if (parameters.HasBenhAnPhauThuat && benhAnToDieuTri.BenhanPhauThuats.Any())
                {
                    var phauThuatStt = _benhAnToDieuTriRepository._context.BenhanPhauThuat.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                    var benhanPhauThuats = CloneList(benhAnToDieuTri.BenhanPhauThuats.ToList());
                    for (int key = 0; key < benhanPhauThuats.Count(); key++)
                    {
                        var benhAnPhauThuat = benhanPhauThuats[key];

                        benhAnPhauThuat.Sttkhoa = parameters.Sttkhoa;
                        benhAnPhauThuat.NgayYlenh = parameters.NgayYlenh;
                        benhAnPhauThuat.Bschidinh = parameters.BsdieuTri;
                        benhAnPhauThuat.Stt = phauThuatStt + key;
                        // benhAnPhauThuat.Idhis = (phauThuatStt + key).ToString();
                        _benhAnToDieuTriRepository._context.BenhanPhauThuat.Add(benhAnPhauThuat);
                        _benhAnToDieuTriRepository.Log<BenhanPhauThuat>(ActionLogType.Create, benhAnPhauThuat);
                    }
                }
                #endregion
                #region Clone cpm
                if (parameters.HasBenhAnCpm && benhAnToDieuTri.BenhanCpms.Any())
                {
                    var cpmStt = _benhAnToDieuTriRepository._context.BenhanCpm.Where(x => x.Idba == parameters.Idba).Max(x => x.Stt) + 1;
                    var benhanCpms = CloneList(benhAnToDieuTri.BenhanCpms.ToList());

                    for (int key = 0; key < benhanCpms.Count(); key++)
                    {
                        var benhAnCpm = benhanCpms[key];

                        benhAnCpm.Sttkhoa = parameters.Sttkhoa;
                        benhAnCpm.NgayYlenh = parameters.NgayYlenh;
                        benhAnCpm.BschiDinh = parameters.BsdieuTri;
                        benhAnCpm.Stt = cpmStt + key;
                        // benhAnCpm.Idhis = (cpmStt + key).ToString();
                        _benhAnToDieuTriRepository._context.BenhanCpm.Add(benhAnCpm);
                        _benhAnToDieuTriRepository.Log<BenhanCpm>(ActionLogType.Create, benhAnCpm);
                    }
                }
                #endregion
                _benhAnToDieuTriRepository._context.SaveChanges();
            });

        }

        public List<T> CloneList<T>(List<T> data) where T : class
        {
            return new List<T>(data);
        }
        public void HanlderRepository<T>(T entity, bool isCreate = true, params object[] id) where T : class
        {
            var response = new GenericRepository<T>(_accessor);
            if (isCreate)
            {
                response.InsertWithoutTransaction(entity);
            }
            else
            {
                response.UpdateWithoutTransaction(entity);
            }

        }
        public void Update(decimal idba, int stt, BenhAnToDieuTriVM parameters)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            var benhAnToDieuTri = _benhAnToDieuTriRepository.Table
                .Select(x => new BenhAnToDieuTri
                {
                    Idba = x.Idba,
                    Stt = x.Stt,
                    Idhis = x.Idhis,
                    MaBa = x.MaBa,
                    MaBn = x.MaBn,
                    MaKhoa = x.MaKhoa,
                    Sttkhoa = x.Sttkhoa,
                    NgayYlenh = x.NgayYlenh ?? DateTime.Parse("1970-01-01"), // Avoid NgayYlenh = null
                    DienBienBenh = x.DienBienBenh,
                    Ylenh = x.Ylenh,
                    HuyetAp = x.HuyetAp,
                    NhipTho = x.NhipTho,
                    CanNang = x.CanNang,
                    ChieuCao = x.ChieuCao,
                    Bmi = x.Bmi,
                    TrieuChung = x.TrieuChung,
                    NhipTim = x.NhipTim,
                    NhipTimDeu = x.NhipTimDeu,
                    Kqxnmau = x.Kqxnmau,
                    KqxnnuocTieu = x.KqxnnuocTieu,
                    Kqcdha = x.Kqcdha,
                    CsduongHuyet = x.CsduongHuyet,
                    DieuTri = x.DieuTri,
                    NgayHenKhamLai = x.NgayHenKhamLai,
                    NgayHenXnlai = x.NgayHenXnlai,
                    BsdieuTri = x.BsdieuTri,
                    Huy = x.Huy,
                    MaMay = x.MaMay,
                    NgayLap = x.NgayLap,
                    NguoiLap = x.NguoiLap,
                    NgaySd = x.NgaySd,
                    NguoiSd = x.NguoiSd,
                    NgayHuy = x.NgayHuy,
                    NguoiHuy = x.NguoiHuy
                })
                .Include(x => x.BenhanThuocTayYs)
                .Include(x => x.BenhanThuocYhct)
                .Include(x => x.BenhanTtvltls)
                .Include(x => x.BenhanClses)
                .Include(x => x.BenhanPhauThuats)
                .Include(x => x.BenhanCpms)
                .First(x => x.Stt == stt && x.Idba == idba);

            var khoaDieuTri = _benhAnToDieuTriRepository._context.BenhAnKhoaDieuTri.First(x => x.Idba == benhAnToDieuTri.Idba && x.Stt == parameters.Sttkhoa);
            
            //Ngay Y Lenh thay doi
            if (benhAnToDieuTri.NgayYlenh.HasValue && parameters.NgayYlenh.HasValue && DateTime.Compare(Convert.ToDateTime(benhAnToDieuTri.NgayYlenh), Convert.ToDateTime(parameters.NgayYlenh)) != 0)
            {
                var oldNgayLap = benhAnToDieuTri.NgayLap;
                var oldNguoiLap = benhAnToDieuTri.NguoiLap;

                _benhAnToDieuTriRepository._context.Database.ExecuteSqlCommand("DELETE FROM BenhAn_ToDieuTri where IDBA = {0} and stt = {1}", idba, stt);

                benhAnToDieuTri.Sttkhoa = parameters.Sttkhoa;
                benhAnToDieuTri.NgayYlenh = parameters.NgayYlenh;
                benhAnToDieuTri.BsdieuTri = parameters.BsdieuTri;
                benhAnToDieuTri.MaKhoa = khoaDieuTri.MaKhoa;
                benhAnToDieuTri.NgaySd = DateTime.Now;
                benhAnToDieuTri.NguoiSd = _benhAnToDieuTriRepository.GetUser();

                _benhAnToDieuTriRepository.Insert(benhAnToDieuTri, (model) =>
                {
                    UpdateRelatedTable(benhAnToDieuTri, parameters);
                    _benhAnToDieuTriRepository._context.SaveChanges();
                });

                benhAnToDieuTri.NgayLap = oldNgayLap;
                benhAnToDieuTri.NguoiLap = oldNguoiLap;
                _benhAnToDieuTriRepository._context.SaveChanges();
            }
            //Stt khoa hoac Bs dieu tri thay doi
            else if (benhAnToDieuTri.Sttkhoa != parameters.Sttkhoa || benhAnToDieuTri.BsdieuTri != parameters.BsdieuTri)
            {
                parameters.MaKhoa = khoaDieuTri.MaKhoa;
                _benhAnToDieuTriRepository.Update(parameters, (model) =>
                {
                    UpdateRelatedTable(benhAnToDieuTri, parameters);
                    _benhAnToDieuTriRepository._context.SaveChanges();
                }, stt, idba);
            }
            else
            {
                _benhAnToDieuTriRepository.Update(parameters, stt, idba);
            }
        }
        public void Destroy(decimal idba, int stt)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnToDieuTriRepository.Delete(stt, idba);
        }
        public string Print(decimal idba, ToDieuTriPrintVM info)
        {
            var benhAnToDieuTriDetails = _benhAnToDieuTriRepository.Table.Where(x => x.Idba == idba && info.Stt.Any(stt => stt == x.Stt)).Select(x => new BenhAnToDieuTriDetailDto()
            {
                BenhNhan = new BenhAnToDieuTriDetailThongTinBenhNhanDto()
                {
                    MaBn = x.ThongTinBn.MaBn,
                    HoTen = x.ThongTinBn.HoTen
                },
                KhoaDieuTri = new BenhAnToDieuTriDetailKhoaDieuTriDto()
                {
                    TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa,
                    MaKhoa = x.BenhAnKhoaDieuTri.MaKhoa,
                    NgayVaoKhoa = x.BenhAnKhoaDieuTri.NgayVaoKhoa,
                    MaBenhChinhVk = x.BenhAnKhoaDieuTri.MaBenhChinhVk,
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
                BsdieuTri = new BenhAnToDieuTriDetailDmnhanVienDto()
                {
                    MaNv = x.DmnhanVien.MaNv,
                    HoTen = x.DmnhanVien.HoTen,
                },
                Sttkhoa = x.Sttkhoa,
                DienBienBenh = x.DienBienBenh,
                NgayYLenh = x.NgayYlenh,
                Ylenh = x.Ylenh,
                HuyetAp = x.HuyetAp,
                NhipTho = x.NhipTho,
                CanNang = x.CanNang,
                ChieuCao = x.ChieuCao,
                Bmi = x.Bmi,
                TrieuChung = x.TrieuChung,
                NhipTim = x.NhipTim,
                NhipTimDeu = x.NhipTimDeu,
                Kqxnmau = x.Kqxnmau,
                KqxnnuocTieu = x.KqxnnuocTieu,
                Kqcdha = x.Kqcdha,
                CsduongHuyet = x.CsduongHuyet,
                DieuTri = x.DieuTri,
                NgayHenKhamLai = x.NgayHenKhamLai,
                NgayHenXnlai = x.NgayHenXnlai,
                Huy = x.Huy,
            }).OrderBy(x => x.NgayYLenh).ThenBy(x => x.KhoaDieuTri.MaKhoa).ToList();
            var benhAn = _benhAnToDieuTriRepository._context.BenhAn
            .Select(ba => new BenhAnDto()
            {
                Idba = ba.Idba,
                SoVaoVien = ba.SoVaoVien,
                NgayVv = ba.NgayVv,
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

            List<string> list_path = new List<string>();
            string path = "";
            if (benhAn.LoaiBa == 3)
            {
                var datasets = GetDatasetManTinhPrint(benhAnToDieuTriDetails, idba, benhAn);
                var list = GetListDataPrint(true);
                foreach (var dataset in datasets)
                {
                    list_path.Add(PrintHelper.PrintFileWithTable(_hostingEnvironment, "Benhan_ToDieuTri_mantinh.docx", DatasetHelper.ConvertToDataSet<ThuocDto>(dataset.ChiTietThuocs), list, dataset.fields, dataset.values));
                }
                path = PrintHelper.MergePdfFile(list_path);
            }
            else
            {
                var datasets = GetDatasetPrint(benhAnToDieuTriDetails, idba, benhAn);
                var list = GetListDataPrint();
                foreach (var dataset in datasets)
                {
                    list_path.Add(PrintHelper.PrintFileWithTable(_hostingEnvironment, "Benhan_ToDieuTri_v2.docx", DatasetHelper.ConvertToDataSet<ThuocDto>(dataset.Thuocs), list, dataset.fields, dataset.values));
                }
                path = PrintHelper.MergePdfFile(list_path);
            }
            return path;
        }
        public List<BenhAnToDieuTriManTinhPrintDto> GetDatasetManTinhPrint(List<BenhAnToDieuTriDetailDto> benhAnToDieuTriDetails, decimal idba, BenhAnDto benhAn)
        {
            List<BenhAnToDieuTriManTinhPrintDto> BenhAnToDieuTriManTinhPrintDtos = new List<BenhAnToDieuTriManTinhPrintDto>();
            foreach (var benhAnToDieuTriDetail in benhAnToDieuTriDetails)
            {
                var benhAnThuocTayYs = (new BenhAnThuocTayYService()).Get(new BenhanThuocTayYParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh
                }).ToList();
                var benhanThuocYhct = (new BenhAnThuocYhctService()).Get(new BenhanThuocYhctParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh
                }).FirstOrDefault();
                var benhanThuocYhcts = benhanThuocYhct?.Stt != null ? (new BenhAnThuocYhctCService()).Get(new BenhanThuocYhctCParameters()
                {
                    Idba = idba,
                    Sttthuoc = benhanThuocYhct?.Stt
                }).ToList() : new List<BenhAnThuocYhctCDto>();
                var benhAnTtvltls = (new BenhAnTtvltlService()).Get(new BenhanTtvltlParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh
                }).ToList();
                BenhAnToDieuTriManTinhPrintDtos.Add(new BenhAnToDieuTriManTinhPrintDto()
                {
                    fields = new List<string>(){
                            "SoYTe",
                            "BenhVien",
                            "Khoa",
                            "SoVV",
                            "ChanDoan",
                            "HoVaTen",
                            "Tuoi",
                            "GioiTinh",
                            "Giuong",
                            "Buong",
                            "KhamLan",
                            "HAToDieuTri",
                            "NhipTimToDieuTri",
                            "ToDieuTriNhipTimDeu_0",
                            "ToDieuTriNhipTimDeu_1",
                            "ChiSoDuongHuyet",
                            "CanNangToDieuTri",
                            "ChieuCaoToDieuTri",
                            "ChiSoBMIToDieuTri",
                            "TrieuChungToDieuTri",
                            "KetQuaXetNghiemMau",
                            "KetQuaXetNghiemNuocTieu",
                            "KetQuaChuanDoanHinhAnh",
                            "NgayKhamLai",
                            "NgayXetNghiemLai",
                            "NgayDieuTri",
                            "BsDieuTri"
                        },
                    values = new List<string>(){
                            PrintSetting.SoYTe,
                            PrintSetting.BenhVien,
                            benhAnToDieuTriDetail.KhoaDieuTri.TenKhoa,
                            benhAn.SoVaoVien,
                            !String.IsNullOrEmpty(benhAnToDieuTriDetail.KhoaDieuTri.BenhChinh.MaBenh) ? $"{benhAnToDieuTriDetail.KhoaDieuTri.BenhChinh.MaBenh} - {benhAnToDieuTriDetail.KhoaDieuTri.BenhChinh.TenBenh}" : "",
                            benhAn.BenhNhan.HoTen.ToUpper(),
                            benhAn.BenhNhan.Tuoi.ToString(),
                            benhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
                            benhAnToDieuTriDetail.KhoaDieuTri.Giuong.TenGiuong,
                            benhAnToDieuTriDetail.KhoaDieuTri.Buong.TenBuong,
                            "", // khám lần
                            benhAnToDieuTriDetail.HuyetAp,
                            benhAnToDieuTriDetail.NhipTim?.ToString(),
                            benhAnToDieuTriDetail.NhipTimDeu == 1 ? "x" : "",
                            benhAnToDieuTriDetail.NhipTimDeu == 2 ? "x" : "",
                            benhAnToDieuTriDetail.CsduongHuyet,
                            benhAnToDieuTriDetail.CanNang?.ToString(),
                            benhAnToDieuTriDetail.ChieuCao?.ToString(),
                            benhAnToDieuTriDetail.Bmi?.ToString("0.00"),
                            benhAnToDieuTriDetail?.TrieuChung,
                            benhAnToDieuTriDetail?.Kqxnmau,
                            benhAnToDieuTriDetail?.KqxnnuocTieu,
                            benhAnToDieuTriDetail?.Kqcdha,
                            PrintHelper.DateText(benhAnToDieuTriDetail?.NgayHenKhamLai),
                            PrintHelper.DateText(benhAnToDieuTriDetail?.NgayHenXnlai),
                            PrintHelper.DateText(benhAnToDieuTriDetail?.NgayYLenh),
                            benhAnToDieuTriDetail.BsdieuTri?.HoTen
                        },
                    ChiTietThuocs = new List<ChiTietThuocDto>()
                });
                var index = BenhAnToDieuTriManTinhPrintDtos.Count() - 1;
                foreach (var item in benhAnThuocTayYs)
                {
                    BenhAnToDieuTriManTinhPrintDtos[index].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.Thuoc.TenTm} {item.Thuoc.HamLuong} x {PrintHelper.ConvertDecimalToInt(item.SoLuong)} {item.Thuoc.DonViTinh.TenDvt}",
                        ThuocCachDung = $"{item.Lieudung} {item.CachDung}"
                    });
                }
                foreach (var item in benhanThuocYhcts)
                {
                    BenhAnToDieuTriManTinhPrintDtos[index].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.Thuoc.TenTm} {item.Thuoc.HamLuong} x {PrintHelper.ConvertDecimalToInt(item.SoLuong)} {item.Thuoc.DonViTinh.TenDvt}",
                    });
                }
                foreach (var item in benhAnTtvltls)
                {
                    BenhAnToDieuTriManTinhPrintDtos[index].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.DichVu.TenDv}",
                        ThuocCachDung = $"{item.ViTri} {item.ThoiGian}"
                    });
                }
            }
            return BenhAnToDieuTriManTinhPrintDtos;
        }
        public List<BenhAnToDieuTriPrintV2Dto> GetDatasetPrint(List<BenhAnToDieuTriDetailDto> benhAnToDieuTriDetails, decimal idba, BenhAnDto benhAn)
        {
            List<BenhAnToDieuTriPrintV2Dto> BenhAnToDieuTriPrintDtos = new List<BenhAnToDieuTriPrintV2Dto>();

            foreach (var benhAnToDieuTriDetail in benhAnToDieuTriDetails)
            {
                var benhAnThuocTayYs = (new BenhAnThuocTayYService()).Get(new BenhanThuocTayYParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh
                }).ToList();
                var benhanThuocYhct = (new BenhAnThuocYhctService()).Get(new BenhanThuocYhctParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh
                }).FirstOrDefault();
                var benhanThuocYhcts = benhanThuocYhct?.Stt != null ? (new BenhAnThuocYhctCService()).Get(new BenhanThuocYhctCParameters()
                {
                    Idba = idba,
                    Sttthuoc = benhanThuocYhct?.Stt
                }).ToList() : new List<BenhAnThuocYhctCDto>();
                var benhAnTtvltls = (new BenhAnTtvltlService()).Get(new BenhanTtvltlParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh
                }).ToList();
                var benhAnCls = (new BenhAnClsService()).Get(new BenhAnClsParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh,
                    WithKq = false
                }).ToList();
                var benhAnPhauThuat = (new BenhAnPhauThuatService()).Get(new BenhanPhauThuatParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh,
                }).ToList();
                var benhAnCpms = new BenhAnCpmService().Get(new BenhanCpmParameters()
                {
                    Idba = idba,
                    NgayYlenh = benhAnToDieuTriDetail.NgayYLenh,
                }).ToList();
                var index = BenhAnToDieuTriPrintDtos.FindIndex(x => x.MaKhoa == benhAnToDieuTriDetail.KhoaDieuTri.MaKhoa);

                if (index == -1)
                {
                    BenhAnToDieuTriPrintDtos.Add(new BenhAnToDieuTriPrintV2Dto()
                    {
                        fields = new List<string>(){
                            "SoYTe",
                            "BenhVien",
                            "Khoa",
                            "SoVV",
                            "ChanDoan",
                            "HoTen",
                            "Tuoi",
                            "GioiTinh",
                            "Giuong",
                            "Buong"
                        },
                        values = new List<string>(){
                            PrintSetting.SoYTe,
                            PrintSetting.BenhVien,
                            benhAnToDieuTriDetail.KhoaDieuTri.TenKhoa,
                            benhAn.SoVaoVien,
                            !String.IsNullOrEmpty(benhAnToDieuTriDetail.KhoaDieuTri.BenhChinh.MaBenh) ? $"{benhAnToDieuTriDetail.KhoaDieuTri.BenhChinh.MaBenh} - {benhAnToDieuTriDetail.KhoaDieuTri.BenhChinh.TenBenh}" : "",
                            benhAn.BenhNhan.HoTen.ToUpper(),
                            benhAn.BenhNhan.Tuoi.ToString(),
                            benhAn.BenhNhan.GioiTinh == 1 ? "Nam" : "Nữ",
                            benhAnToDieuTriDetail.KhoaDieuTri.Giuong.TenGiuong,
                            benhAnToDieuTriDetail.KhoaDieuTri.Buong.TenBuong,
                        },
                        MaKhoa = benhAnToDieuTriDetail.KhoaDieuTri.MaKhoa,
                        Thuocs = new List<ThuocDto>()
                    });
                    index = BenhAnToDieuTriPrintDtos.Count - 1;
                }

                BenhAnToDieuTriPrintDtos[index].Thuocs.Add(new ThuocDto()
                {
                    NgayYLenh = benhAnToDieuTriDetail.NgayYLenh.HasValue ? benhAnToDieuTriDetail.NgayYLenh.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    DienBien = benhAnToDieuTriDetail.DienBienBenh,
                    BsdieuTri = benhAnToDieuTriDetail.BsdieuTri.HoTen,
                    YLenhChamSoc = benhAnToDieuTriDetail.Ylenh,
                    ChiTietThuocs = new List<ChiTietThuocDto>()
                });
                var indexThuoc = BenhAnToDieuTriPrintDtos[index].Thuocs.Count - 1;
                foreach (var item in benhAnThuocTayYs)
                {
                    BenhAnToDieuTriPrintDtos[index].Thuocs[indexThuoc].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.Thuoc.TenTm} {item.Thuoc.HamLuong} x {PrintHelper.ConvertDecimalToInt(item.SoLuong)} {item.Thuoc.DonViTinh.TenDvt}",
                        ThuocCachDung = $"{item.Lieudung} {item.CachDung}"
                    });
                }
                foreach (var item in benhanThuocYhcts)
                {
                    BenhAnToDieuTriPrintDtos[index].Thuocs[indexThuoc].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.Thuoc.TenTm} {item.Thuoc.HamLuong} x {PrintHelper.ConvertDecimalToInt(item.SoLuong)} {item.Thuoc.DonViTinh.TenDvt}",
                    });
                }
                foreach (var item in benhAnTtvltls)
                {
                    BenhAnToDieuTriPrintDtos[index].Thuocs[indexThuoc].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.DichVu.TenDv}",
                        ThuocCachDung = $"{item.ViTri} {item.ThoiGian}"
                    });
                }
                foreach (var item in benhAnCls)
                {
                    BenhAnToDieuTriPrintDtos[index].Thuocs[indexThuoc].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.DichVu.TenDv}",
                    });
                }
                foreach (var item in benhAnPhauThuat)
                {
                    BenhAnToDieuTriPrintDtos[index].Thuocs[indexThuoc].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.PhauThuat.TenPt}",
                    });
                }
                foreach (var item in benhAnCpms)
                {
                    BenhAnToDieuTriPrintDtos[index].Thuocs[indexThuoc].ChiTietThuocs.Add(new ChiTietThuocDto()
                    {
                        ThuocSoLuong = $"{item.ChePhamMau.TenDV} x {item.SoLuong} {item.DonVi}",
                    });
                }
            }
            return BenhAnToDieuTriPrintDtos;
            // return DatasetHelper.ConvertToDataSet<BenhAnToDieuTriPrintDto>(BenhAnToDieuTriPrintDtos);
        }
        public List<DictionaryEntry> GetListDataPrint(bool isManTinh = false)
        {
            var list = new List<DictionaryEntry>();
            if (isManTinh)
            {
                list.Add(new DictionaryEntry("ChiTietThuocDto", string.Empty));
            }
            else
            {
                list.Add(new DictionaryEntry("ThuocDto", string.Empty));
                list.Add(new DictionaryEntry("ChiTietThuocDto", "ParentID= %ThuocDto.ID%"));
            }
            return list;
        }

        private void UpdateRelatedTable(BenhAnToDieuTri benhAnToDieuTri, BenhAnToDieuTriVM parameters)
        {
            #region Update thuoc tay y
            foreach (var benhAnThuocTayY in benhAnToDieuTri.BenhanThuocTayYs ?? new List<BenhanThuocTayY>())
            {
                benhAnThuocTayY.Sttkhoa = parameters.Sttkhoa;
                benhAnThuocTayY.NgayYlenh = parameters.NgayYlenh;
                benhAnThuocTayY.BschiDinh = parameters.BsdieuTri;
                _benhAnToDieuTriRepository._context.BenhanThuocTayY.Update(benhAnThuocTayY);
                _benhAnToDieuTriRepository.Log<BenhanThuocTayY>(ActionLogType.Modify, benhAnThuocTayY);
            }
            #endregion
            #region Yhct
            var benhAnThuocYhct = benhAnToDieuTri.BenhanThuocYhct;
            if (benhAnThuocYhct != null)
            {
                benhAnThuocYhct.Sttkhoa = parameters.Sttkhoa;
                benhAnThuocYhct.NgayYlenh = parameters.NgayYlenh;
                benhAnThuocYhct.BschiDinh = parameters.BsdieuTri;
                _benhAnToDieuTriRepository._context.BenhanThuocYhct.Update(benhAnThuocYhct);
                _benhAnToDieuTriRepository.Log<BenhanThuocYhct>(ActionLogType.Modify, benhAnThuocYhct);
            }
            #endregion
            #region Ttvltl
            foreach (var benhAnTtvltl in benhAnToDieuTri.BenhanTtvltls ?? new List<BenhanTtvltl>())
            {
                benhAnTtvltl.Sttkhoa = parameters.Sttkhoa;
                benhAnTtvltl.NgayYlenh = parameters.NgayYlenh;
                benhAnTtvltl.Bschidinh = parameters.BsdieuTri;
                _benhAnToDieuTriRepository._context.BenhanTtvltl.Update(benhAnTtvltl);
                _benhAnToDieuTriRepository.Log<BenhanTtvltl>(ActionLogType.Modify, benhAnTtvltl);
            }
            #endregion
            #region Cls
            foreach (var benhAnCls in benhAnToDieuTri.BenhanClses ?? new List<BenhanCls>())
            {
                benhAnCls.Sttkhoa = parameters.Sttkhoa;
                benhAnCls.NgayYlenh = parameters.NgayYlenh;
                benhAnCls.Bschidinh = parameters.BsdieuTri;
                _benhAnToDieuTriRepository._context.BenhanCls.Update(benhAnCls);
                _benhAnToDieuTriRepository.Log<BenhanCls>(ActionLogType.Modify, benhAnCls);
            }
            #endregion
            #region Phau thu thuat
            foreach (var benhAnPhauThuat in benhAnToDieuTri.BenhanPhauThuats ?? new List<BenhanPhauThuat>())
            {
                benhAnPhauThuat.Sttkhoa = parameters.Sttkhoa;
                benhAnPhauThuat.NgayYlenh = parameters.NgayYlenh;
                benhAnPhauThuat.Bschidinh = parameters.BsdieuTri;
                _benhAnToDieuTriRepository._context.BenhanPhauThuat.Update(benhAnPhauThuat);
                _benhAnToDieuTriRepository.Log<BenhanPhauThuat>(ActionLogType.Modify, benhAnPhauThuat);
            }
            #endregion
            #region Cpm
            foreach (var benhanCpm in benhAnToDieuTri.BenhanCpms ?? new List<BenhanCpm>())
            {
                benhanCpm.Sttkhoa = parameters.Sttkhoa;
                benhanCpm.NgayYlenh = parameters.NgayYlenh;
                benhanCpm.BschiDinh = parameters.BsdieuTri;
                _benhAnToDieuTriRepository._context.BenhanCpm.Update(benhanCpm);
                _benhAnToDieuTriRepository.Log<BenhanCpm>(ActionLogType.Modify, benhanCpm);
            }
            #endregion
        }
    }
}
