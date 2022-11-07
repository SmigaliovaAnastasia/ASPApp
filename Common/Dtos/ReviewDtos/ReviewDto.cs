using ASPApp.Domain.Entities.Auth;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Dtos.ReviewDtos
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string? Commentary { get; set; }
        public int Rating { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public Guid GameId { get; set; }
    }
}
