using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Dtos.CollectionGameDtos
{
    public class CollectionGameDto
    {
        public Guid Id { get; set; }
        public bool IsFavourite { get; set; }
        public Guid GameId { get; set; }
        public string GameName { get; set; }
        public string GameImageUrl { get; set; }
        public Guid CollectionId { get; set; }
    }
}
