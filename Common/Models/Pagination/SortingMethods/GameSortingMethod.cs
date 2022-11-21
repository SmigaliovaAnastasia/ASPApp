using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class GameSortingMethod : SortingMethod<Game>
    {
        public override IQueryable<Game> ApplySorting(IQueryable<Game> query) => SortingColumn switch
        {
            "id" => query.OrderBy(g => g.Id),
            "name" => Direction switch
            {
                "asc" => query.OrderBy(g => g.Name),
                "desc" => query.OrderByDescending(g => g.Name),
                _ => throw new ArgumentException(),
            },
            "releasedate" => Direction switch
            {
                "asc" => query.OrderBy(g => g.ReleaseDate),
                "desc" => query.OrderByDescending(g => g.ReleaseDate),
                _ => throw new ArgumentException(),
            },
            "rating" => Direction switch
            {
                "asc" => query.OrderBy(g => g.Reviews.Select(r => r.Rating).Average()),
                "desc" => query.OrderByDescending(g => g.Reviews.Select(r => r.Rating).Average()),
                _ => throw new ArgumentException(),
            },
            _ => throw new ArgumentException(),
        };
    }
}
