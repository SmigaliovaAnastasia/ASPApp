using ASPApp.Common.Dtos.GameDtos;
using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.CollectionGameDtos
{
    public class CollectionGameUpdateDto
    {
        [Required]
        public bool IsFavourite { get; set; }
    }
}
