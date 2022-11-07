using Microsoft.AspNetCore.Identity;

namespace ASPApp.Domain.Entities.Auth
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
