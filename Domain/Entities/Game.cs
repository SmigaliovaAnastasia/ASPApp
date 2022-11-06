using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPApp.Domain.Entities
{
    public class Game : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Rules { get; set; }
        public int MinNumOfPlayers { get; set; }
        public int MaxNumOfPlayers { get; set; }
        public int MinPalyerAge { get; set; }
        public int minPlayingTimeMinutes { get; set; }
        public int maxPlayingTimeMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public Guid GameSeriesId { get; set; }
        public GameSeries GameSeries { get; set; }
        public Guid ComplexityLevelId { get; set; }
        public ComplexityLevel ComplexityLevel { get; set; }
        public ICollection<CollectionGame> CollectionGames { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
