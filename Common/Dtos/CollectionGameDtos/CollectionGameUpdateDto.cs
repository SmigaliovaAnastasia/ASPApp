using ASPApp.Common.Dtos.GameDtos;
using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.CollectionGameDtos
{
    public class CollectionGameUpdateDto
    {
        [Required]
        public Guid CollectionId { get; set; }
        [Required]
        public Guid GameId { get; set; }
        [Required]
        public bool IsFavourite { get; set; }
    }
}
