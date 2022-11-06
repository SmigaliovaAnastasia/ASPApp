namespace ASPApp.Domain.Entities
{
    public class CollectionGame : IBaseEntity
    {
        public Guid Id { get; set; }
        public bool IsFavourite { get; set; }
        public Guid CollectionId { get; set; }
        public Collection Collection { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
