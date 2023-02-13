using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Medyx_EMR_BCA.ApiAssets.ResponseHandler
{
    public class Res<T>
    {
        public static Response<T> Get(IQueryable<T> source, int? pageNumber, int pageSize)
        {
            if (pageNumber == null || pageNumber == 0)
            {
                return new Response<T>(source.ToList());
            }
            var data = source.ToPagedList((int)pageNumber, pageSize);
            var respose = new PagedResponse<T>(data.ToList(), (int)pageNumber, pageSize);

            respose.meta.HasPreviousPage = data.HasPreviousPage;
            respose.meta.HasNextPage = data.HasNextPage;
            respose.meta.IsFirstPage = data.IsLastPage;
            respose.meta.IsLastPage = data.IsLastPage;
            respose.meta.TotalPages = data.PageCount;
            respose.meta.TotalRecords = data.TotalItemCount;

            return respose;
        }
        public static Response<T> GetUnion(IQueryable<T> source, IQueryable<T> source_union, int? pageNumber, int pageSize)
        {
            if(pageNumber == null || pageNumber == 0)
            {
                return new Response<T>(source_union.Union(source).ToList());
            }
            List<T> data_union = new List<T>();
            var data = source.ToPagedList((int)pageNumber, pageSize);
            if((int)pageNumber < 2)
            {
                data_union = source_union.ToPagedList((int)1, 1).ToList();
            }
            var respose = new PagedResponse<T>(data_union.Union(data.ToList()).ToList(), (int)pageNumber, pageSize);

            respose.meta.HasPreviousPage = data.HasPreviousPage;
            respose.meta.HasNextPage = data.HasNextPage;
            respose.meta.IsFirstPage = data.IsLastPage;
            respose.meta.IsLastPage = data.IsLastPage;
            respose.meta.TotalPages = data.PageCount;
            respose.meta.TotalRecords = data.TotalItemCount;

            return respose;

        }
    }
}
