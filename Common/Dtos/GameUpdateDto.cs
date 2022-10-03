using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos
{
    public class GameUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
        [StringLength(10000)]
        public string? Rules { get; set; }
        [Required]
        [Range(1, 100)]
        public int MinNumOfPlayers { get; set; }
        [Required]
        [Range(1, 100)]
        public int MaxNumOfPlayers { get; set; }
        [Required]
        [Range(1, 100)]
        public int MinPalyerAge { get; set; }
        [RegularExpression(@"^[0-9]{1,3}((-[0-9]{1,3})|\+) (min|hours?)$")]
        public string? PlayingTime { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

    }
}
