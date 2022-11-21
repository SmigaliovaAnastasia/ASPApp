using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.Filters
{
    public class ReviewFilter : Filter<Review>
    {
        public override IQueryable<Review> ApplyFilter(IQueryable<Review> query) => FilterProperty switch
        {
            "game_id" => query.Where(r => r.GameId.ToString() == Value),
            "name" => query.Where(r => r.ApplicationUser.UserName.ToLower().Contains(Value.ToLower())),
            "application_user_id" => query.Where(r => r.ApplicationUserId.ToString() == Value),
            _ => throw new ArgumentException(),
        };
    }
}

