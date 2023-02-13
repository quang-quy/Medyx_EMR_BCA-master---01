namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public abstract class QueryStringParameters
    {
        public string Search { get; set; }
        public string SearchUnion { get; set; }
        public string SortBy { get; set; } = "NgayLap";

        const int MAX_PAGE_SIZE = 5000;
        public int? PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
            }
        }
        public bool? Huy { get; set; }
    }
}
