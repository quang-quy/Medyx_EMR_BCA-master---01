using AutoMapper;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.StoreProcedureModels;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class DmbaLoaiTaiLieuService
    {
        private readonly IRepository<DmbaLoaiTaiLieu> _dmbaLoaiTaiLieuRepository;

        public DmbaLoaiTaiLieuService(IHttpContextAccessor accessor)
        {
            _dmbaLoaiTaiLieuRepository = new GenericRepository<DmbaLoaiTaiLieu>(accessor);
        }

        public Response<DmbaLoaiTaiLieu> Get(DmbaLoaiTaiLieuParameters parameters, UserSession user = null)
        {
            var query = _dmbaLoaiTaiLieuRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                query.Where(x => x.TenLoaiTaiLieu.ToLower().Contains(parameters.Search.ToLower()));
            }
            var a = _dmbaLoaiTaiLieuRepository._context.Model.GetEntityTypes();
            query = SortHelper.ApplySort(query, parameters.SortBy);

            return QueryParamsHelper.ResultDanhMucParams<DmbaLoaiTaiLieu>(_dmbaLoaiTaiLieuRepository, query, parameters, "MaLoaiTaiLieu");
        }

        public IQueryable<BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto> GetDichVu(DmbaLoaiTaiLieuDichVuParameters parameters, UserSession user = null)
        {
            var tableName = _dmbaLoaiTaiLieuRepository.GetById(parameters.LoaiTaiLieu).TableName;
            
            switch (tableName.ToUpper())
            {
                case "BENHAN_KHOADIEUTRI":
                    return _dmbaLoaiTaiLieuRepository._context.BenhAnKhoaDieuTri.Where(x => x.Idba == parameters.Idba).Select(x => new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        Stt = x.Stt,
                        SttKhoa = x.Stt,
                        NgayChiDinh = x.NgayVaoKhoa,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = x.Dmkhoa.MaKhoa,
                            TenKhoa = x.Dmkhoa.TenKhoa
                        },
                        MaDichVu = x.Dmkhoa.MaKhoa,
                        TenDichVu = x.Dmkhoa.TenKhoa,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = x.DmnhanVien.MaNv,
                            HoTen = x.DmnhanVien.HoTen
                        },
                    });
                case "BENHAN_CLS":
                    return _dmbaLoaiTaiLieuRepository._context.BenhanCls.Where(x => x.Idba == parameters.Idba).Select(x => new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        Stt = x.Stt,
                        SttKhoa = x.Sttkhoa,
                        NgayChiDinh = x.NgayYlenh,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                            TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
                        },
                        MaDichVu = x.DmdichVu.MaDv,
                        TenDichVu = x.DmdichVu.TenDv,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = x.DmnhanVien.MaNv,
                            HoTen = x.DmnhanVien.HoTen
                        },
                    });
                case "BENHAN_TTVLTL":
                    return _dmbaLoaiTaiLieuRepository._context.BenhanTtvltl.Where(x => x.Idba == parameters.Idba).Select(x => new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        Stt = x.Stt,
                        SttKhoa = x.Sttkhoa,
                        NgayChiDinh = x.NgayYlenh,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                            TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
                        },
                        MaDichVu = x.DmdichVu.MaDv,
                        TenDichVu = x.DmdichVu.TenDv,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = x.DmnhanVien.MaNv,
                            HoTen = x.DmnhanVien.HoTen
                        },
                    });
                case "BENHAN_PHAUTHUAT":
                    return _dmbaLoaiTaiLieuRepository._context.BenhanPhauThuat.Where(x => x.Idba == parameters.Idba).Select(x => new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        Stt = x.Stt,
                        SttKhoa = x.Sttkhoa,
                        NgayChiDinh = x.NgayYlenh,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                            TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
                        },
                        MaDichVu = x.DmphauThuat.MaPt,
                        TenDichVu = x.DmphauThuat.TenPt,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = x.DmBschiDinh.MaNv,
                            HoTen = x.DmBschiDinh.HoTen
                        },
                    });
                case "BENHAN_CPM":
                    return _dmbaLoaiTaiLieuRepository._context.BenhanCpm.Where(x => x.Idba == parameters.Idba).Select(x => new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        Stt = x.Stt,
                        SttKhoa = x.Sttkhoa,
                        NgayChiDinh = x.NgayYlenh,
                        KhoaDieuTri = new DmkhoaDto()
                        {
                            MaKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.MaKhoa,
                            TenKhoa = x.BenhAnKhoaDieuTri.Dmkhoa.TenKhoa
                        },
                        MaDichVu = x.DmchephamMau.MaCpmau,
                        TenDichVu = x.DmchephamMau.TenCpmau,
                        BsChiDinh = new DmnhanVienDto()
                        {
                            MaNv = x.DmnhanVien.MaNv,
                            HoTen = x.DmnhanVien.HoTen
                        },
                    });
                default:
                    return _dmbaLoaiTaiLieuRepository._context.BenhAnFilePhiCauTruc.Where(x => x.Idba == parameters.Idba).Select(x => new BenhAnFilePhiCauTrucDmbaLoaiTaiLieuDichVuDto()
                    {
                        Stt = x.Stt,
                    });
            }
        }
    }
}
