using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.ReviewDtos
{
    public class ReviewUpdateDto
    {
        [StringLength(1000)]
        public string? Commentary { get; set; }
        [Range(0, 5, ErrorMessage = "Rating is an integer number from 0 to 5")]
        public int Rating { get; set; }
    }
}
