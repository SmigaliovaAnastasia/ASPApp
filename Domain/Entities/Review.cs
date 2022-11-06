using ASPApp.Domain.Entities.Auth;

namespace ASPApp.Domain.Entities
{
    public class Review : IBaseEntity
    {
        public Guid Id { get; set; }
        public string? Commentary { get; set; }
        public double Rating { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }

    }
}
