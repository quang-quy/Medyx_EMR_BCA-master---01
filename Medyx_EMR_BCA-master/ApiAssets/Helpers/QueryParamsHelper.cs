using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
	public static class QueryParamsHelper
	{
		// key => Column in Database
		public static IQueryable<T> QueryDanhMucParams<T>(IRepository<T> repository, IQueryable<T> query, QueryStringParameters parameters, params string[] key) where T : class
		{

			if (!string.IsNullOrEmpty(parameters.SearchUnion))
			{
				string key_query = null;
				foreach (var item in key)
				{
					key_query = !string.IsNullOrEmpty(key_query) ? $"{key_query} ||  {item} == \"{parameters.SearchUnion}\"" : $"{item} == \"{parameters.SearchUnion}\"";
				}
				if (key_query != null)
				{
					IQueryable<T> query_union = repository.Table.Where(key_query);
					query = query_union.Union(query);
				}
				//query = repository.Table.Where(x => GetPropertyValue<string>(x, key) == parameters.SearchUnion).Take(1).Union(query);
			}
            query = SortHelper.ApplySort(query, parameters.SortBy);
            return query;
		}

		public static Response<T> ResultDanhMucParams<T>(IRepository<T> repository, IQueryable<T> query, QueryStringParameters parameters, params string[] key) where T : class
		{

			if (!string.IsNullOrEmpty(parameters.SearchUnion))
			{
				string key_query = null;
				string key_query_negative = null;
				foreach (var item in key)
				{
					key_query = !string.IsNullOrEmpty(key_query) ? $"{key_query} ||  {item} == \"{parameters.SearchUnion}\"" : $"{item} == \"{parameters.SearchUnion}\"";
					key_query_negative = !string.IsNullOrEmpty(key_query_negative) ? $"{key_query_negative} &&  {item} != \"{parameters.SearchUnion}\"" : $"{item} != \"{parameters.SearchUnion}\"";
				}
				if (key_query != null)
				{
					IQueryable<T> query_union = repository.Table.Where(key_query);
					query = query.Where(key_query_negative);
					return Res<T>.GetUnion(query, query_union, parameters.PageNumber, parameters.PageSize);
				}
			}
			query = SortHelper.ApplySort(query, parameters.SortBy);
			return Res<T>.Get(query, parameters.PageNumber, parameters.PageSize);
		}
		public static Response<Tb> ResultDanhMucDTOParams<T, Tb>(IRepository<T> repository, IQueryable<Tb> query, QueryStringParameters parameters, Expression<Func<T, Tb>> querySelect, params string[] key) where T : class
		{
			if (!string.IsNullOrEmpty(parameters.SearchUnion))
			{
				string key_query = null;
				string key_query_negative = null;
				foreach (var item in key)
				{
					key_query = !string.IsNullOrEmpty(key_query) ? $"{key_query} ||  {item} == \"{parameters.SearchUnion}\"" : $"{item} == \"{parameters.SearchUnion}\"";
					key_query_negative = !string.IsNullOrEmpty(key_query_negative) ? $"{key_query_negative} &&  {item} != \"{parameters.SearchUnion}\"" : $"{item} != \"{parameters.SearchUnion}\"";
				}
				if (key_query != null)
				{
					IQueryable<Tb> query_union = repository.Table.Where(key_query).Select(querySelect);
					query = query.Where(key_query_negative);
					return Res<Tb>.GetUnion(query, query_union, parameters.PageNumber, parameters.PageSize);
				}
			}

			query = SortHelper.ApplySort(query, parameters.SortBy);
			return Res<Tb>.Get(query, parameters.PageNumber, parameters.PageSize);
		}

		private static T GetPropertyValue<T>(object obj, string propName)
		{
			return (T)obj.GetType().GetProperty(propName).GetValue(obj, null);
		}
		private static string getTableName<T>(IRepository<T> repository) where T : class
		{
			var mapping = repository._context.Model.FindEntityType(typeof(T)).Relational();
			var schema = mapping.Schema;
			var tableName = mapping.TableName;
			return tableName;
		}
	}
}
