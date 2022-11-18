using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.CollectionDtos
{
    public class CollectionCreateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "The Name field should contain 1-200 symbols")]
        public string Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public Guid ApplicationUserId { get; set; }
    }
}
