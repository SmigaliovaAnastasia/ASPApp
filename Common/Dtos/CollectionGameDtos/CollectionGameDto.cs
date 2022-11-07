using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Dtos.CollectionGameDtos
{
    public class CollectionGameDto
    {
        public Guid Id { get; set; }
        public bool IsFavourite { get; set; }
        public Guid GameId { get; set; }
        public GameDto GameDto { get; set; }
    }
}
