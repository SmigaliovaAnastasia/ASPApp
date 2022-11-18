using ASPApp.Domain.Entities.Auth;

namespace ASPApp.Domain.Entities
{
    public class Collection : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<CollectionGame> CollectionGames { get; set; }
    }
}
