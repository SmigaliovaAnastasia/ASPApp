using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASPApp.Dal.EntityConfiguration
{
    public class ComplexityLevelConfiguration : IEntityTypeConfiguration<ComplexityLevel>
    {
        public void Configure(EntityTypeBuilder<ComplexityLevel> builder)
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
