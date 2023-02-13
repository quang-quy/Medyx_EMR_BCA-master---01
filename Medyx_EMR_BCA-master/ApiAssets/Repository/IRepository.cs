using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Repository
{
    public interface IRepository<T> where T : class
    {
        string LogActionName { get; set; }
        ActionLogType? actionLogType { get; set; }
        MedyxDbContext _context { get; set; }
        DbSet<T> Table { get; set; }
        IEnumerable<T> GetAll();
        T GetById(object id);
        T GetById(params object[] id);
        void Insert(T obj, Action<T> callback = null);
        void Insert<Tb>(Tb obj, Action<T> callback = null);
        void InsertWithoutTransaction(T obj, Action<T> callback = null);
        void InsertWithoutTransaction<Tb>(Tb obj, Action<T> callback = null);
        void Update(T obj, params object[] id);
        void Update(T obj, Action<T> callback, params object[] id);
        void Update<Tb>(Tb obj, params object[] id);
        void Update<Tb>(Tb obj, Action<T> callback, params object[] id);
        void UpdateWithoutTransaction(T obj, params object[] id);
        void UpdateWithoutTransaction(T obj, Action<T> callback, params object[] id);
        void UpdateWithoutTransaction<Tb>(Tb obj, params object[] id);
        void UpdateWithoutTransaction<Tb>(Tb obj, Action<T> callback, params object[] id);
        void Update(T obj);
        //void MapEntity<Tb>(T entity, Tb obj);
        void Delete(params object[] id);
        void Delete(Action<T> action, params object[] id);
        void Save();
        string GetUser();
        void setLogActionName(string value);
        void setActionLogType(ActionLogType? value);
        void Log<Tb>(ActionLogType? Type, Tb entity = null, bool isSuccess = true, string error = "") where Tb : class;
        void Log(ActionLogType? Type, T entity = null, bool isSuccess = true, string error = "");
    }
}
