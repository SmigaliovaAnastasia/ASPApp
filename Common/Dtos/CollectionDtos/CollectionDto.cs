using ASPApp.Domain.Entities.Auth;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Dtos.CollectionDtos
{
    public class CollectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int GamesNumber { get; set; } 
        public int FavouriteGamesNumber { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
