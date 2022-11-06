using ASPApp.Common.Exceptions;
using System.Net;

namespace ASPApp.Common.Models.Pagination
{
    public class PagedRequest<T>
    {
        private int _pageIndex;
        public int PageIndex 
        {
            get => _pageIndex;
            set
            {
                if (value < 1)
                    throw new BadHttpRequestException("Page index value should be a positive number.", (int)HttpStatusCode.BadRequest);
                else _pageIndex = value;
            }
        }
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < 1)
                    throw new BadHttpRequestException("Page index value should be a positive number.", (int)HttpStatusCode.BadRequest);
                else _pageSize = value;
            }
        }
        public SortingMethod<T> SortingMethod { get; set; }
        public IEnumerable<Filter<T>> Filters { get; set; }

        public IQueryable<T> ApplyFilters(IQueryable<T> query)
        {
            var result = query;
            foreach(var filter in Filters)
            {
                result = filter.ApplyFilter(result);
            }
            return result;
        }

        public IQueryable<T> ApplySortingMethod(IQueryable<T> query)
        {
            return SortingMethod.ApplySorting(query);
        }
    }
}
