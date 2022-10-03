using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos
{
    public class GameDto
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Rules { get; set; }
        public int MinNumOfPlayers { get; set; }
        public int MaxNumOfPlayers { get; set; }
        public int MinPalyerAge { get; set; }
        public string? PlayingTime { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
