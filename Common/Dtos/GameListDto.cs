using ASPApp.Domain.Entities;

namespace ASPApp.Common.Dtos
{
    public class GameListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MinNumOfPlayers { get; set; }
        public int MaxNumOfPlayers { get; set; }
        public int MinPalyerAge { get; set; }
        public int minPlayingTimeMinutes { get; set; }
        public int maxPlayingTimeMinutes { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<string> Genres { get; set; }
        public string ComplexityLevelName { get; set; }
    }
}
