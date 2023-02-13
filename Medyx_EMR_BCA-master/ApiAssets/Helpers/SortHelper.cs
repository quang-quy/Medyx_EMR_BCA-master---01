using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
    public static class SortHelper
    {
        public static IQueryable<T> ApplySort<T>(IQueryable<T> source, string orderByQueryString)
        {
            if (!source.Any())
                return source;
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return source;

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if(string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param;
                var orderType = "asc";
                if (param[0] == '-')
                {
                    propertyFromQueryName = param.Substring(1);
                    orderType = "desc";
                }
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {orderType}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrEmpty(orderQuery))
            {
                return source;
            }
            return source.OrderBy(orderQuery);
        }
    }
}
