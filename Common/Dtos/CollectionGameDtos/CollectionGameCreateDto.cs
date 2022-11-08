using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.CollectionGameDtos
{
    public class CollectionGameCreateDto
    {
        [Required]
        public Guid CollectionId { get; set; }
        [Required]
        public Guid GameId { get; set; }
        [Required]
        public bool IsFavourite { get; set; }
    }
}
