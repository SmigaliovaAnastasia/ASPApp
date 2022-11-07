using ASPApp.Common.Models.Pagination.Filters;
using ASPApp.Common.Models.Pagination.SortingMethods;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.PagedRequests
{
    public class ReviewPagedRequest : PagedRequest<Review>
    {
        public ReviewPagedRequest()
        {
            SortingMethod = new ReviewSortingMethod();
            Filters = new List<ReviewFilter>();
        }
    }
}
