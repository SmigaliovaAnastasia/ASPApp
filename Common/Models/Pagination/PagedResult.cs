using System.Net;

namespace ASPApp.Common.Models.Pagination
{
    public class PagedResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PagedResult(int pageIndex, int pageSize, int total, IEnumerable<T> items)
        {
            if(pageIndex < 1 || pageSize < 1 || total < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
            Items = items;
        }
    }
}
