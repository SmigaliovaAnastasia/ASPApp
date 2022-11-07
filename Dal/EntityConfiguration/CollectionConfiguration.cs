using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASPApp.Dal.EntityConfiguration
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder
                .Property(e => e.Name)
                .HasMaxLength(200);
            builder
                .Property(e => e.Description)
                .HasColumnType("text");
        }
    }
}
