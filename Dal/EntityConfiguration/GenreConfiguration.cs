using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASPApp.Dal.EntityConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
              .Property(e => e.Id)
              .HasDefaultValueSql("newsequentialid()");
            builder
                .Property(e => e.Name)
                .HasMaxLength(200);
        }
    }
}


