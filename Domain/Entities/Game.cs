using System.ComponentModel.DataAnnotations;

namespace ASPApp.Domain.Entities
{
    public class Game
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
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Game() { }
        public Game(string name, string? description, string? rules, int minNumOfPlayers, int maxNumOfPlayers, int minPalyerAge, string? playingTime, DateTime releaseDate, byte[] timestamp)
        {
            Name = name;
            Description = description;
            Rules = rules;
            MinNumOfPlayers = minNumOfPlayers;
            MaxNumOfPlayers = maxNumOfPlayers;
            MinPalyerAge = minPalyerAge;
            PlayingTime = playingTime;
            ReleaseDate = releaseDate;
            Timestamp = timestamp;
        }
    }
}
