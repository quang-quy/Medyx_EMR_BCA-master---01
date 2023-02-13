using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.ResponseHandler
{
    public class MetaData
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    } 
    public class PagedResponse<T> : Response<T>
    {
        public MetaData meta { get; set; }

        public PagedResponse(List<T> data, int pageNumber, int pageSize)
        {
            meta = new MetaData();
            meta.PageNumber = pageNumber;
            meta.PageSize = pageSize;
            this.data = data;
        }
    }
}
