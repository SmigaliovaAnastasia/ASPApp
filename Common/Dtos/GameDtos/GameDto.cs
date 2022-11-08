using ASPApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.GameDtos
{
    public class GameDto
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
        public double? Rating { get; set; }
        public ICollection<GenreDto> GenreDtos { get; set; }
        public GameSeriesDto GameSeriesDto { get; set; }
        public ComplexityLevelDto ComplexityLevelDto { get; set; }
        public ICollection<Guid> ReviewIds { get; set; }
    }
}
