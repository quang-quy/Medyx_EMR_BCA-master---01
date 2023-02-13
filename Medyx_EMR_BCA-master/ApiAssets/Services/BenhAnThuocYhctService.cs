using AutoMapper;
using Medyx_EMR_BCA.ApiAssets.Dto;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Medyx_EMR_BCA.ApiAssets.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Services
{
    public class BenhAnThuocYhctService
    {
        private IRepository<BenhanThuocYhct> _benhAnThuocYhctRepository;
        public BenhAnThuocYhctService(IHttpContextAccessor accessor = null)
        {
            _benhAnThuocYhctRepository = new GenericRepository<BenhanThuocYhct>(accessor);
        }

        public IQueryable<BenhanThuocYhct> Get(BenhanThuocYhctParameters parameters, UserSession user = null)
        {
            var query = _benhAnThuocYhctRepository.Table.AsQueryable();

            if (user == null || !Convert.ToBoolean(user.Pub_bQadmin))
            {
                query = query.Where(x => !Convert.ToBoolean(x.Huy));
            }

            query = QueryFilter(query, parameters);
            query = SortHelper.ApplySort(query, parameters.SortBy);
            return query;
        }

        private IQueryable<BenhanThuocYhct> QueryFilter(IQueryable<BenhanThuocYhct> query, BenhanThuocYhctParameters parameters)
        {
            if (parameters.Idba.HasValue)
            {
                query = query.Where(x => x.Idba == parameters.Idba);
            }
            if (parameters.NgayYlenh.HasValue)
            {
                query = query.Where(x => x.NgayYlenh == parameters.NgayYlenh);
            }
            return query;
        }

        public BenhanThuocYhct Detail(decimal idba, int stt)
        {
            return _benhAnThuocYhctRepository.GetById(stt, idba);
        }

        public void Store(BenhAnThuocYhctCreateVM benhAnThuocYhctVM)
        {
            var benhAn = PermissionThrowHelper.GetBenhAnAndCheckPermission(benhAnThuocYhctVM.Idba);
            var stt = (_benhAnThuocYhctRepository.Table.Where(x => x.Idba == benhAnThuocYhctVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

            benhAnThuocYhctVM.MaBa = benhAn.MaBa;
            // benhAnThuocYhctVM.Idhis = stt.ToString();
            benhAnThuocYhctVM.Stt = stt;
            benhAnThuocYhctVM.MaBn = benhAn.MaBn;

            _benhAnThuocYhctRepository.Insert<BenhAnThuocYhctCreateVM>(benhAnThuocYhctVM, (model) =>
            {
                if (benhAnThuocYhctVM.ThuocYhctCs.Any())
                {
                    var thuocYhctCStt = (_benhAnThuocYhctRepository._context.BenhanThuocYhctC.Where(x => x.Idba == benhAnThuocYhctVM.Idba).Max(x => (int?)x.Stt) ?? 0) + 1;

                    for (int key = 0; key < benhAnThuocYhctVM.ThuocYhctCs.Count(); key++)
                    {
                        _benhAnThuocYhctRepository._context.BenhanThuocYhctC.Add(new BenhanThuocYhctC()
                        {
                            Idba = benhAnThuocYhctVM.Idba,
                            Stt = thuocYhctCStt + key,
                            // Idhis = (thuocYhctCStt + key).ToString(),
                            MaBa = benhAn.MaBa,
                            MaBn = benhAn.MaBn,
                            Sttkhoa = benhAnThuocYhctVM.Sttkhoa,
                            Sttthuoc = stt,
                            MaThuoc = benhAnThuocYhctVM.ThuocYhctCs[key].MaThuoc,
                            SoLuong = benhAnThuocYhctVM.ThuocYhctCs[key].SoLuong,
                            Huy = benhAnThuocYhctVM.ThuocYhctCs[key].Huy,
                            NgayLap = DateTime.Now,
                            NguoiLap = _benhAnThuocYhctRepository.GetUser(),
                            MaMay = LocationHelper.GetLocalIPAddress()
                        });
                    }
                }

                _benhAnThuocYhctRepository._context.SaveChanges();
            });
        }

        public void Update(decimal idba, int stt, BenhAnThuocYhctVM benhAnThuocYhctVM)
        {
            PermissionThrowHelper.GetBenhAnAndCheckPermission(idba);
            _benhAnThuocYhctRepository.Update(benhAnThuocYhctVM, stt, idba);
        }
    }
}
