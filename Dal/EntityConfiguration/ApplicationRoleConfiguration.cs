using ASPApp.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASPApp.Dal.EntityConfiguration
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
        }
    }
}
