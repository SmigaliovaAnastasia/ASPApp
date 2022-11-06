using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ASPApp.Dal.EntityConfiguration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
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
            builder
                .Property(e => e.Rules)
                .HasColumnType("text");
            builder
                .Property(e => e.ReleaseDate)
                .HasColumnType("date");
            builder
                .HasOne(e => e.ComplexityLevel)
                .WithMany(e => e.Games)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder
                .HasOne(e => e.GameSeries)
                .WithMany(e => e.Games)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
