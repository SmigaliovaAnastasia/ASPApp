using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class ReviewSortingMethod : SortingMethod<Review>
    {
        public override IQueryable<Review> ApplySorting(IQueryable<Review> query) => Value switch
        {
            "id" => query.OrderBy(r => r.Id),
            "username_asc" => query.OrderBy(r => r.ApplicationUser.UserName),
            "username_desc" => query.OrderByDescending(r => r.ApplicationUser.UserName),
            "rating_asc" => query.OrderBy(r => r.Rating),
            "rating_desc" => query.OrderByDescending(r => r.Rating),
            _ => throw new ArgumentException(),
        };
    }
}
