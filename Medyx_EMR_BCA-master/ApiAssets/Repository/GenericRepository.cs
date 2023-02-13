using AutoMapper;
using Medyx.ApiAssets.LogApi;
using Medyx.ApiAssets.Models.Interface;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public string LogActionName { get; set; }
        public ActionLogType? actionLogType { get; set; }
        public MedyxDbContext _context { get; set; }
        public DbSet<T> Table { get; set; }
        private IHttpContextAccessor Context { get; set; }
        public GenericRepository(IHttpContextAccessor context = null, MedyxDbContext dbContext = null)
        {
            this._context = dbContext != null ? dbContext : new MedyxDbContext();
            Table = _context.Set<T>();
            Context = context;
        }
        public GenericRepository(MedyxDbContext _context)
        {
            this._context = _context;
            Table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }
        public T GetById(object id)
        {
            return Table.Find(id);
        }
        public T GetById(params object[] id)
        {
            return Table.Find(id);
        }
        public void Insert(T obj, Action<T> callback = null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var model = Table.Add(obj);
                    if (callback != null)
                    {
                        callback(model.Entity);
                    }

                    OnBeforeInsertSaving(obj);
                    Save();
                    transaction.Commit();
                    //log
                    Log(ActionLogType.Create, obj);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Log(ActionLogType.Create, obj, false, ex.Message);
                    throw ex;
                }
            }
        }

        public void Insert<Tb>(Tb obj, Action<T> callback = null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                T entity = (T)Activator.CreateInstance(typeof(T));
                MapEntity<Tb>(entity, obj);
                try
                {
                    var model = Table.Add(entity);
                    if (callback != null)
                    {
                        callback(model.Entity);
                    }
                    OnBeforeInsertSaving(entity);
                    Save();
                    transaction.Commit();
                    //log
                    Log(ActionLogType.Create, entity);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Log(ActionLogType.Create, entity, false, ex.Message);
                    throw ex;
                }
            }
        }
        public void InsertWithoutTransaction(T obj, Action<T> callback = null)
        {
            try
            {
                var model = Table.Add(obj);
                if (callback != null)
                {
                    callback(model.Entity);
                }
                OnBeforeInsertSaving(obj);
                Save();
                Log(ActionLogType.Create, obj);
            }
            catch (Exception ex)
            {
                //log
                //Log(ActionLogType.Create, obj, false, ex.Message);
                throw ex;
            }

        }

        public void InsertWithoutTransaction<Tb>(Tb obj, Action<T> callback = null)
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            MapEntity<Tb>(entity, obj);
            try
            {
                var model = Table.Add(entity);
                if (callback != null)
                {
                    callback(model.Entity);
                }
                OnBeforeInsertSaving(entity);
                Save();
                //log
                Log(ActionLogType.Create, entity);
            }
            catch (Exception ex)
            {
                //Log(ActionLogType.Create, entity, false, ex.Message);
                throw ex;
            }
        }


        public void Update(T obj, params object[] id)
        {
            Update<T>(obj, id);
        }
        public void Update(T obj, Action<T> callback, params object[] id)
        {
            Update<T>(obj, callback, id);
        }
        public virtual void Update<Tb>(Tb obj, params object[] id)
        {
            Update<Tb>(obj, null, id);
        }
        public virtual void Update<Tb>(Tb obj, Action<T> callback, params object[] id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                MapEntity<Tb>(entity, obj);
                try
                {
                    if (callback != null)
                    {
                        callback(entity);
                    }
                    OnBeforeEditSaving(entity);
                    //save
                    Log(ActionLogType.Modify, entity, true, "");
                    Save();
                    transaction.Commit();
                    //log
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Log(ActionLogType.Modify, entity, false, ex.Message);
                    throw ex;
                }
            }
        }
        public void UpdateWithoutTransaction(T obj, params object[] id)
        {
            UpdateWithoutTransaction<T>(obj, id);
        }
        public void UpdateWithoutTransaction(T obj, Action<T> callback, params object[] id)
        {
            UpdateWithoutTransaction<T>(obj, callback, id);
        }
        public virtual void UpdateWithoutTransaction<Tb>(Tb obj, params object[] id)
        {
            UpdateWithoutTransaction<Tb>(obj, null, id);
        }
        public void UpdateWithoutTransaction<Tb>(Tb obj, Action<T> callback, params object[] id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy");
            }
            MapEntity<Tb>(entity, obj);
            try
            {
                if (callback != null)
                {
                    callback(entity);
                }
                OnBeforeEditSaving(entity);
                Log(ActionLogType.Modify, entity);
                Save();
                //log
            }
            catch (Exception ex)
            {
                //Log(ActionLogType.Modify, entity, false, ex.Message);
                throw ex;
            }
        }

        private void MapEntity<Tb>(T entity, Tb obj)
        {
            Mapper.CreateMap<Tb, T>().ForAllMembers(opt => opt.Condition(
                srs =>
                {
                    try
                    {
                        if (srs.IsSourceValueNull)
                        {
                            return true;
                        }
                        if (srs.SourceType.FullName == "System.Boolean" || srs.SourceType.FullName == "System.Byte")
                        {
                            return true;
                        }
                        if (srs.SourceType.IsValueType && srs.SourceValue.Equals(Activator.CreateInstance(srs.SourceType)))
                        {
                            return false;
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }));
            Mapper.Map(obj, entity);
        }
        public void Update(T obj)
        {
            Table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(params object[] id)
        {
            Delete(null, id);
        }
        public void Delete(Action<T> callback, params object[] id)
        {
            T existing = Table.Find(id);
            if (existing == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (callback != null)
                    {
                        callback(existing);
                    }
                    // Table.Remove(existing);
                    var checkTrackable = OnBeforeDestroySaving(existing);
                    if (!checkTrackable)
                    {
                        Table.Remove(existing);
                    }
                    Save();
                    transaction.Commit();
                    //log
                    Log(ActionLogType.Delete, existing);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Log(ActionLogType.Delete, existing, false, ex.Message);
                    throw ex;
                }
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool OnBeforeDestroySaving(T obj)
        {
            var entry = _context.Entry(obj);

            if (entry.Entity is ITrackableMaMay trackableMaMay)
            {
                trackableMaMay.MaMay = LocationHelper.GetLocalIPAddress();
            }
            if (entry.Entity is ITrackable trackable)
            {
                trackable.Huy = true;
                trackable.NguoiHuy = GetUser();
                trackable.NgayHuy = DateTime.Now;
                trackable.MaMay = LocationHelper.GetLocalIPAddress();
                return true;
            }
            else if (entry.Entity is ITrackableHuy trackableHuy)
            {
                trackableHuy.Huy = true;
                trackableHuy.NguoiHuy = GetUser();
                trackableHuy.NgayHuy = DateTime.Now;
                return true;
            }
            else if (entry.Entity is ITrackableTrangThaiHuy trackableTrangThaiHuy)
            {
                trackableTrangThaiHuy.Huy = true;
                return true;
            }
            return false;
        }
        private void OnBeforeEditSaving(T obj)
        {
            var entry = _context.Entry(obj);
            if (entry.Properties.Where(x => x.IsModified).Count() < 1)
            {
                return;
            }
            if (entry.Entity is ITrackableMaMay trackableMaMay)
            {
                trackableMaMay.MaMay = LocationHelper.GetLocalIPAddress();
            }
            if (entry.Entity is ITrackable trackable)
            {
                trackable.NguoiSd = GetUser();
                trackable.NgaySd = DateTime.Now;
                trackable.MaMay = LocationHelper.GetLocalIPAddress();
            }
            else if (entry.Entity is ITrackableUpdate trackableUpdate)
            {
                trackableUpdate.NguoiSd = GetUser();
                trackableUpdate.NgaySd = DateTime.Now;
            }
        }
        private void OnBeforeInsertSaving(T obj)
        {
            var entry = _context.Entry(obj);
            if (entry.Entity is ITrackableMaMay trackableMaMay)
            {
                trackableMaMay.MaMay = LocationHelper.GetLocalIPAddress();
            }
            if (entry.Entity is ITrackable trackable)
            {
                trackable.NguoiLap = GetUser();
                trackable.NgayLap = DateTime.Now;
                trackable.MaMay = LocationHelper.GetLocalIPAddress();
            }
            else if (entry.Entity is ITrackableCreate trackableCreate)
            {
                trackableCreate.NguoiLap = GetUser();
                trackableCreate.NgayLap = DateTime.Now;
            }
        }

        public string GetUser()
        {
            //var session = System.Web.HttpContext.Current.Session;
            if (Context == null)
            {
                return null;
            }
            var user = SessionHelper.GetObjectFromJson<UserSession>(Context?.HttpContext?.Session, "UserProfileSessionData");
            if (user != null)
            {
                return user.Pub_sNguoiSD;
            }
            return null;
        }
        public string GetAccount()
        {
            if (Context == null)
            {
                return null;
            }
            var user = SessionHelper.GetObjectFromJson<UserSession>(Context?.HttpContext?.Session, "UserProfileSessionData");
            if (user != null)
            {
                return user.Pub_sAccount;
            }
            return null;
        }
        public void setLogActionName(string value)
        {
            this.LogActionName = value;
        }
        public void setActionLogType(ActionLogType? value)
        {
            this.actionLogType = value;
        }
        private class PrimaryKey
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        private class ActionResult
        {
            public string ID { get; set; }
            public string ErrorName { get; set; }
            public string Description { get; set; }
        }
        private List<PrimaryKey> getPrimaryKey(T entity)
        {
            return getPrimaryKey<T>(entity);
        }
        private List<PrimaryKey> getPrimaryKey<Tb>(Tb entity) where Tb : class
        {
            var entry = _context.Entry(entity);
            List<PrimaryKey> keyParts = entry.Metadata.FindPrimaryKey()
                 .Properties
                 .Select(p => new PrimaryKey()
                 {
                     Key = p.Name,
                     Value = entry.Property(p.Name).CurrentValue.ToString()
                 })
                 .ToList();
            return keyParts;
        }
        private T CreateWithValues(PropertyValues values)
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            Type type = typeof(T);

            foreach (var name in values.Properties)
            {
                var property = type.GetProperty(name.Name);
                property.SetValue(entity, values.GetValue<object>(name));
            }

            return entity;
        }
        string MyDictionaryToJson(Dictionary<string, object> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": {1}", d.Key, d.Value));
            return "{" + string.Join(",", entries) + "}";
        }
        private Dictionary<string, object> handlerUpdateChange(IEnumerable<PropertyEntry> properties)
        {
            var obj = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                if (property.IsModified)
                {
                    obj.Add(property.Metadata.Name, property.CurrentValue);
                }
            }
            return obj;
        }
        public void Log<Tb>(ActionLogType? Type, Tb entity = null, bool isSuccess = true, string error = "") where Tb : class{
            string MaBN = "";
            string actionResult = "";
            string typeResult = isSuccess ? "thành công" : "thất bại";
            if (this.actionLogType != null)
            {
                Type = this.actionLogType;
                setActionLogType(null);
            }
            if (entity != null && entity is ITrackableIDBA track)
            {
                MaBN = track.Idba.ToString();
            }
            try
            {
                string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
                IMongoCollection<TraceLogApiMongo> collection = dbm.GetCollection<TraceLogApiMongo>("TraceLog");
                var traceLogMongo = new TraceLogApiMongo()
                {
                    NguoiSD = GetUser(),
                    MaMay = LocationHelper.GetLocalIPAddress(),
                    TenBang = _context.Model.FindEntityType(typeof(Tb)).Relational().TableName,
                    MaBN = MaBN,
                    NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                };
                switch (Type)
                {
                    case ActionLogType.Create:
                        // code block
                        traceLogMongo.KieuTacDong = "Insert";
                        actionResult = "Thêm mới";
                        break;
                    case ActionLogType.Modify:
                        // code block
                        traceLogMongo.KieuTacDong = "Update";
                        actionResult = "Cập nhật";
                        break;
                    case ActionLogType.Delete:
                        // code block
                        traceLogMongo.KieuTacDong = "Delete";
                        actionResult = "Xoá";
                        break;
                    case ActionLogType.Import:
                        // code block
                        traceLogMongo.KieuTacDong = "Upload file";
                        break;
                    case ActionLogType.Export:
                        // code block
                        traceLogMongo.KieuTacDong = "In, download file";
                        break;
                    case ActionLogType.Close:
                        // code block
                        traceLogMongo.KieuTacDong = "Đóng";
                        break;
                    default:
                        // code block
                        break;
                }
                if (!String.IsNullOrEmpty(traceLogMongo.KieuTacDong))
                {
                    string json = "";
                    var primaryKeys = new List<PrimaryKey>();
                    var jsonActionResult = Newtonsoft.Json.JsonConvert.SerializeObject(new ActionResult()
                    {
                        ID = isSuccess ? "200" : "500",
                        ErrorName = error,
                        Description = $"{actionResult} {typeResult}."
                    });
                    //_context.ChangeTracker.DetectChanges();
                    foreach (var entityEntry in _context.ChangeTracker.Entries<Tb>()) // Detects changes automatically
                    {
                        if (Type == ActionLogType.Modify)
                        {
                            var propertiesChanged = handlerUpdateChange(entityEntry.Properties);
                            if (propertiesChanged.Count < 1)
                            {
                                return;
                            }
                            json = MyDictionaryToJson(propertiesChanged);
                        }
                        else
                        {
                            json = Newtonsoft.Json.JsonConvert.SerializeObject(entityEntry.Entity);
                        }
                        primaryKeys = getPrimaryKey<Tb>(entityEntry.Entity);
                    }
                    traceLogMongo.MaBN = string.Join(", ", primaryKeys.Select(x => $"{x.Key}: {x.Value}"));
                    traceLogMongo.NoiDungSD = $"API: {Context?.HttpContext?.Request?.Path}:";
                    if (Type == ActionLogType.Delete)
                    {
                        traceLogMongo.NoiDungSD = $"{traceLogMongo.NoiDungSD} delete {string.Join(", ", primaryKeys.Select(x => $"{x.Key}: {x.Value}"))}";
                    }
                    else
                    {
                        traceLogMongo.NoiDungSD = $"{traceLogMongo.NoiDungSD} json {json}";
                    }
                    traceLogMongo.NoiDungSD = $"{traceLogMongo.NoiDungSD} return: ${jsonActionResult}";
                }
                collection.InsertOne(traceLogMongo);
            }
            catch (Exception ext)
            {
            }
            setLogActionName("");
        }
        public void Log(ActionLogType? Type, T entity = null, bool isSuccess = true, string error = "")
        {
            Log<T>(Type, entity, isSuccess, error);
        }
    }
}