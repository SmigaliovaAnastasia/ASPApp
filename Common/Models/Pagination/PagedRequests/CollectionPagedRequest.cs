using ASPApp.Common.Models.Pagination.Filters;
using ASPApp.Common.Models.Pagination.SortingMethods;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.PagedRequests
{
    public class CollectionPagedRequest : PagedRequest<Collection>
    {
        public CollectionPagedRequest()
        {
            SortingMethod = new CollectionSortingMethod();
            Filters = new List<CollectionFilter>();
        }
    }
}
