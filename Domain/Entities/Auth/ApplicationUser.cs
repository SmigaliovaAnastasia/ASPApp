using Microsoft.AspNetCore.Identity;

namespace ASPApp.Domain.Entities.Auth
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? ImageUrl { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Collection> Collections { get; set; }
    }
}
