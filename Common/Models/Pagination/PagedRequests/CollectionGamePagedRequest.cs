using ASPApp.Common.Models.Pagination.Filters;
using ASPApp.Common.Models.Pagination.SortingMethods;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.PagedRequests
{
    public class CollectionGamePagedRequest : PagedRequest<CollectionGame>
    {
        public CollectionGamePagedRequest()
        {
            SortingMethod = new CollectionGameSortingMethod();
            Filters = new List<CollectionGameFilter>();
        }
    }
}
