using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class ReviewSortingMethod : SortingMethod<Review>
    {
        public override IQueryable<Review> ApplySorting(IQueryable<Review> query) => SortingColumn switch
        {
            "id" => query.OrderBy(r => r.Id),
            "userName" => Direction switch
            {
                "asc" => query.OrderBy(r => r.ApplicationUser.UserName),
                "desc" => query.OrderByDescending(r => r.ApplicationUser.UserName),
                _ => throw new ArgumentException(),
            },
            "rating" => Direction switch
            {
                "asc" => query.OrderBy(r => r.Rating),
                "desc" => query.OrderByDescending(r => r.Rating),
                _ => throw new ArgumentException(),
            },
            _ => throw new ArgumentException(),
        }; 
    }
}
