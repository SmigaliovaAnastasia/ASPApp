using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPApp.Common.Dtos.GameDtos
{
    public class GameUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The Name field should contain 3-200 symbols")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
        [StringLength(1000)]
        public string? Rules { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Number of players should be a positive number from 1 to 100")]
        public int MinNumOfPlayers { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Number of players should be a positive number from 1 to 100")]
        public int MaxNumOfPlayers { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Minimum player's age should be a positive number from 1 to 100")]
        public int MinPalyerAge { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Min playing time should be a number greater than 1")]
        public int minPlayingTimeMinutes { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Max playing time should be a number greater than 1")]
        public int maxPlayingTimeMinutes { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }
        public Guid GameSeriesId { get; set; }
        public Guid ComplexityLevelId { get; set; }
        [NotMapped]
        public ICollection<Guid> GenreIds { get; set; }
    }
}
