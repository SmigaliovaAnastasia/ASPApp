using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class CollectionGameSortingMethod : SortingMethod<CollectionGame>
    {
        public override IQueryable<CollectionGame> ApplySorting(IQueryable<CollectionGame> query) => SortingColumn switch
        {
            "id" => query.OrderBy(g => g.Id),
            "name" => Direction switch
            {
                "asc" => query.OrderBy(g => g.Game.Name),
                "desc" => query.OrderByDescending(g => g.Game.Name),
                _ => throw new ArgumentException(),
            },
            "releasedate" => Direction switch
            {
                "asc" => query.OrderBy(g => g.Game.ReleaseDate),
                "desc" => query.OrderByDescending(g => g.Game.ReleaseDate),
                _ => throw new ArgumentException(),
            },
            "rating" => Direction switch
            {
                "asc" => query.OrderBy(g => g.Game.Reviews.Select(r => r.Rating).Average()),
                "desc" => query.OrderByDescending(g => g.Game.Reviews.Select(r => r.Rating).Average()),
                _ => throw new ArgumentException(),
            },
            _ => throw new ArgumentException(),
        };
    }
}