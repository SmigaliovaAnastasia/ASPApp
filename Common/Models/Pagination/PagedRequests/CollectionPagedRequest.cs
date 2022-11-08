using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination.Filters;
using ASPApp.Common.Models.Pagination.SortingMethods;
using ASPApp.Domain.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;

namespace ASPApp.Common.Models.Pagination.PagedRequests
{
    public class CollectionPagedRequest : PagedRequest<Collection>
    {
        public CollectionPagedRequest()
        {
            SortingMethod = new CollectionSortingMethod();
            Filters = new List<CollectionFilter>();
        }

        public bool HasAccess(string userId)
        {
            var filter = Filters.SingleOrDefault(f => f.FilterProperty == "application_user_id");
            if(filter == null)
            {
                throw new ApiException(HttpStatusCode.BadRequest, "Collection filters must include user id");
            }
            else if (userId.ToUpper() == filter.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
