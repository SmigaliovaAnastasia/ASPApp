using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASPApp.Dal.EntityConfiguration
{
    public class GameSeriesConfiguration : IEntityTypeConfiguration<GameSeries>
    {
        public void Configure(EntityTypeBuilder<GameSeries> builder)
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
