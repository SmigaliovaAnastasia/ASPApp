using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class CollectionSortingMethod : SortingMethod<Collection>
    {
        public override IQueryable<Collection> ApplySorting(IQueryable<Collection> query) => Value switch
        {
            "id" => query.OrderBy(c => c.Id),
            "name_asc" => query.OrderBy(c => c.Name),
            "name_desc" => query.OrderByDescending(c => c.Name),
            "number_of_games_asc" => query.OrderBy(c => c.CollectionGames.Count()),
            "number_of_games_desc" => query.OrderByDescending(c => c.CollectionGames.Count()),
            "number_of_favourite_games_asc" => query.OrderBy(c => c.CollectionGames.Select(cg => cg.IsFavourite == true).Count()),
            "number_of_favourite_games_desc" => query.OrderByDescending(c => c.CollectionGames.Select(cg => cg.IsFavourite == true).Count()),
            _ => throw new ArgumentException(),
        };
    }
}
