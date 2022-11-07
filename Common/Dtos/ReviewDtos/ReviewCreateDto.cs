using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.ReviewDtos
{
    public class ReviewCreateDto
    {
        [StringLength(1000)]
        public string? Commentary { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Rating is an integer number from 0 to 5")]
        public int Rating { get; set; }
        [Required]
        public Guid ApplicationUserId { get; set; }
        [Required]
        public Guid GameId { get; set; }
    }
}
