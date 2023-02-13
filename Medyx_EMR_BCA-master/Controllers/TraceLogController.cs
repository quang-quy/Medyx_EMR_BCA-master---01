using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Medyx_EMR_BCA.Models;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Medyx_EMR_BCA.Controllers
{
    public class TraceLogController : BCAController
    {
        private IMemoryCache cache;
        private readonly IConfiguration _config;
        public TraceLogController(IConfiguration config, IMemoryCache cache)
        {
            this.cache = cache;
            _config = config;
        }
        public IActionResult Index()
        {
            return Khoitao(cache);
        }
        [HttpGet]
        public JsonResult LoadData(string tenbang, string mabn, string kieutacdong, string maMay, string tungay, string denngay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(tenbang))
                tenbang = "";
            if (string.IsNullOrEmpty(mabn))
                mabn = "";
            if (string.IsNullOrEmpty(kieutacdong))
                kieutacdong = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            //DateTime tn = DateTime.Parse(tungay);
            DateTime tn = DateTime.ParseExact(tungay, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            tn = DateTime.SpecifyKind(tn, DateTimeKind.Utc);
            //DateTime dn = DateTime.Parse(denngay);
            DateTime dn = DateTime.ParseExact(denngay, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            dn = DateTime.SpecifyKind(dn, DateTimeKind.Utc);
            var response = db.TraceLogGetListPaging(tenbang, mabn, kieutacdong, maMay, tn,dn, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            //if (u != null)
            //{ }
            //string constr = _config.GetValue<string>("Medyx_BCADatabase:ConnectionString");
            string constr = u.MongoDBConnectionString;
            var client = new MongoClient(constr);
            //IMongoDatabase dbm = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
            //IMongoDatabase dbm = client.GetDatabase(_config.GetValue<string>("Medyx_BCADatabase:DatabaseName"));
            IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
            IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
            var filter = Builders<TraceLogMongo>.Filter.Where(
                //x => ((x.KieuTacDong == null) ? "" : x.KieuTacDong.ToUpper()).Contains(kieutacdong.ToUpper())
                x => ((x.KieuTacDong != null && x.KieuTacDong.ToUpper().Contains(kieutacdong.ToUpper())) || (x.KieuTacDong == null && "".Contains(kieutacdong.ToUpper())))
                && ((x.TenBang != null && x.TenBang.ToUpper().Contains(tenbang.ToUpper())) || (x.TenBang == null && "".Contains(tenbang.ToUpper())))
                && ((x.MaBN != null && x.MaBN.ToUpper().Contains(mabn.ToUpper())) || (x.MaBN == null && "".Contains(mabn.ToUpper())))
                && ((x.MaMay != null && x.MaMay.ToUpper().Contains(maMay.ToUpper())) || (x.MaMay == null && "".Contains(maMay.ToUpper())))
                && ((x.NguoiSD != null && x.NguoiSD.ToUpper().Contains(nguoiSD.ToUpper())) || (x.NguoiSD == null && "".Contains(nguoiSD.ToUpper())))
                && (x.NgaySD.CompareTo(tn) >= 0 && x.NgaySD.CompareTo(dn) <= 0)
                );
            var mongo = collection.Find(filter).ToList().OrderByDescending(s => s.NgaySD).ToList();
            if (mongo.Count > 0)
            {
                response.TotalCounts += mongo.Count;
                response.TotalPages = (int)Math.Ceiling(((double)response.TotalCounts / pageSize));
            }
            int c = response.Items == null ? 0 : response.Items.Count();
            if (c == 0) 
            {
                //khong co dl tu sql: lay tu mongo 
                var mongoitem = mongo.ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                List<TraceLogSQLVM> sql = new List<TraceLogSQLVM>();
                decimal stt = 1;
                foreach (TraceLogMongo item in mongoitem)
                {
                    TraceLogSQLVM i = new TraceLogSQLVM();
                    i.Id = - stt;
                    i.KieuTacDong = item.KieuTacDong;
                    i.MaBN = item.MaBN;
                    i.MaMay = item.MaMay;
                    i.NgaySD = item.NgaySD;
                    i.NguoiSD = item.NguoiSD;
                    i.NoiDungSD = item.NoiDungSD;
                    i.TenBang = item.TenBang;
                    i.TotalRows = response.TotalCounts;
                    sql.Add(i);
                    stt++;
                }
                response.Items = sql;
            }
            else if (c > 0 && c < pageSize)
            {
                //sql lay dl it hon pageside: add them dl tu mongo
                int d = pageSize - c;
                #region vd
                //like
                //                db.users.find({ "name": /.* m.*/})

                //Or, similar:

                //                db.users.find({ "name": / m /})

                //find
                //            db.emp.find({
                //                "type" : { "$in": ["WebUser", "User"] },
                //"city" : { "$in": ["Pune", "Mumbai"] }
                //            })
                //                db.getCollection('TheCollection').find({
                //    $and:
                //                    [
                //        { 'the_key': { $exists: true } },
                //        { 'the_key': null}
                //    ]
                //})
                //                db.getCollection('TheCollection').find({
                //    $or:
                //                    [
                //        { 'the_key': 'value1'},
                //        {`the_key': 'value2'}
                //    ]
                //})

                //concat
                //var result = list1.Concat(list2).OrderBy(x => x.Elevation).ToList();
                //var result = list1.Union(list2).OrderBy(x => x.Elevation).ToList();
                //list1.AddRange(list2);
                //list1.OrderBy(l => l.Elevation);

                //skip
                //     db.students.find()
                //.sort( { _id: 1 } )
                //  .skip(pageNumber > 0 ? ((pageNumber - 1) * nPerPage) : 0)
                //  .limit(nPerPage)
                #endregion
                var mongoitem = mongo.ToList().Take(d).ToList();
                List<TraceLogSQLVM> sql = response.Items.ToList();
                foreach (TraceLogMongo item in mongoitem)
                {
                    TraceLogSQLVM i = new TraceLogSQLVM();
                    i.Id = - decimal.Parse(item.Id.ToString());
                    i.KieuTacDong = item.KieuTacDong;
                    i.MaBN = item.MaBN;
                    i.MaMay = item.MaMay;
                    i.NgaySD = item.NgaySD;
                    i.NguoiSD = item.NguoiSD;
                    i.NoiDungSD = item.NoiDungSD;
                    i.TenBang = item.TenBang;
                    i.TotalRows = response.TotalCounts;
                    sql.Add(i);
                }
                response.Items = sql;
            }
            
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }
    }
}
