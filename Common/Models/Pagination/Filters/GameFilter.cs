using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.Filters
{
    public class GameFilter : Filter<Game>
    {
        public override IQueryable<Game> ApplyFilter(IQueryable<Game> query) => FilterProperty switch
        {
            "name" => query.Where(g => g.Name.ToLower().Contains(Value.ToLower())),
            "complexitylevel" => query.Where(g => g.ComplexityLevel.Name == Value),
            "age" => FilterOperator switch
            {
                '>' => query.Where(g => g.MinPalyerAge > int.Parse(Value)),
                _ => throw new ArgumentException()
            },
            "playingtime" => FilterOperator switch
            {
                '>' => query.Where(g => g.minPlayingTimeMinutes > int.Parse(Value)),
                '<' => query.Where(g => g.maxPlayingTimeMinutes < int.Parse(Value)),
                _ => throw new ArgumentException()
            },
            "players" => FilterOperator switch
            {
                '>' => query.Where(g => g.MinNumOfPlayers > int.Parse(Value)),
                '<' => query.Where(g => g.MaxNumOfPlayers < int.Parse(Value)),
                _ => throw new ArgumentException()
            },
            "genres" => query.Where(g => g.Genres.Any(e => e.Name.Equals(Value))),
            _ => throw new ArgumentException(),
        };
    }
}
