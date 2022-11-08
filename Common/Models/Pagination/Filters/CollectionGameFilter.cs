using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.Filters
{
    public class CollectionGameFilter : Filter<CollectionGame>
    {
        public override IQueryable<CollectionGame> ApplyFilter(IQueryable<CollectionGame> query) => FilterProperty switch
        {
            "collection_id" => query.Where(e => e.CollectionId.ToString() == Value),
            "name" => query.Where(g => g.Game.Name.ToLower().Contains(Value.ToLower())),
            "complexitylevel" => query.Where(g => g.Game.ComplexityLevel.Name == Value),
            "age" => FilterOperator switch
            {
                '>' => query.Where(g => g.Game.MinPalyerAge > int.Parse(Value)),
                _ => throw new ArgumentException()
            },
            "playingtime" => FilterOperator switch
            {
                '>' => query.Where(g => g.Game.minPlayingTimeMinutes > int.Parse(Value)),
                '<' => query.Where(g => g.Game.maxPlayingTimeMinutes < int.Parse(Value)),
                _ => throw new ArgumentException()
            },
            "players" => FilterOperator switch
            {
                '>' => query.Where(g => g.Game.MinNumOfPlayers > int.Parse(Value)),
                '<' => query.Where(g => g.Game.MaxNumOfPlayers < int.Parse(Value)),
                _ => throw new ArgumentException()
            },
            "genres" => query.Where(g => g.Game.Genres.Any(e => e.Name.Equals(Value))),
            _ => throw new ArgumentException(),
        };
    }
}

