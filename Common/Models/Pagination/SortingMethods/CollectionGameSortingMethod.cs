using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class CollectionGameSortingMethod : SortingMethod<CollectionGame>
    {
        public override IQueryable<CollectionGame> ApplySorting(IQueryable<CollectionGame> query) => Value switch
        {
            "id" => query.OrderBy(g => g.Id),
            "name_asc" => query.OrderBy(g => g.Game.Name),
            "name_desc" => query.OrderByDescending(g => g.Game.Name),
            "releasedate_asc" => query.OrderBy(g => g.Game.ReleaseDate),
            "releasedate_desc" => query.OrderByDescending(g => g.Game.ReleaseDate),
            _ => throw new ArgumentException(),
        };
    }
}