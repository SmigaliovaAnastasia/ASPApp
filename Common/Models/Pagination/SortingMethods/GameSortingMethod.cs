using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class GameSortingMethod : SortingMethod<Game>
    {
        public override IQueryable<Game> ApplySorting(IQueryable<Game> query) => Value switch
        {
            "id" => query.OrderBy(g => g.Id),
            "name_asc" => query.OrderBy(g => g.Name),
            "name_desc" => query.OrderByDescending(g => g.Name),
            "releasedate_asc" => query.OrderBy(g => g.ReleaseDate),
            "releasedate_desc" => query.OrderByDescending(g => g.ReleaseDate),
            _ => throw new ArgumentException(),
        };
    }
}
