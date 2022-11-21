using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.SortingMethods
{
    public class CollectionSortingMethod : SortingMethod<Collection>
    {
        public override IQueryable<Collection> ApplySorting(IQueryable<Collection> query) => SortingColumn switch
        {
            "id" => query.OrderBy(c => c.Id),
            "name" => Direction switch
            {
                "asc" => query.OrderBy(c => c.Name),
                "desc" => query.OrderByDescending(c => c.Name),
                _ => throw new ArgumentException(),
            },
            "number_of_games" => Direction switch
            {
                "asc" => query.OrderBy(c => c.CollectionGames.Count()),
                "desc" => query.OrderByDescending(c => c.CollectionGames.Count()),
                _ => throw new ArgumentException(),
            },
            "number_of_favourite_games" => Direction switch
            {
                "asc" => query.OrderBy(c => c.CollectionGames.Select(cg => cg.IsFavourite == true).Count()),
                "desc" => query.OrderByDescending(c => c.CollectionGames.Select(cg => cg.IsFavourite == true).Count()),
                _ => throw new ArgumentException(),
            },
            _ => throw new ArgumentException(),
        }; 
    }
}
