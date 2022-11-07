using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ASPApp.Domain.Entities.Auth;

namespace ASPApp.Dal.EntityConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
        }
    }
}
