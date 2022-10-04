using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos
{
    public class GameUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The Name field should contain 3-200 symbols")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
        [StringLength(10000)]
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
        [RegularExpression(@"^[0-9]{1,3}((-[0-9]{1,3})|\+) (min|hours?)$",
            ErrorMessage = "Playing time should represent a range of minutes or hours.")]
        public string? PlayingTime { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
