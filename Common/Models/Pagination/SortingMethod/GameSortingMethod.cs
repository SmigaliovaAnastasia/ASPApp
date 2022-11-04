using ASPApp.Domain.Entities;
using Microsoft.CodeAnalysis.QuickInfo;

namespace ASPApp.Common.Models.Pagination.SortingMethod
{
    public class GameSortingMethod : SortingMethod<Game>
    {
        public override IQueryable<Game> ApplySorting(IQueryable<Game> query) => Value switch
        {
            "name_asc" => query.OrderBy(g => g.Name),
            "name_desc" => query.OrderByDescending(g => g.Name),
            "releasedate_asc" => query.OrderBy(g => g.ReleaseDate),
            "releasedate_desc" => query.OrderByDescending(g => g.ReleaseDate),
            _ => throw new ArgumentException(),
        };
    }
}
