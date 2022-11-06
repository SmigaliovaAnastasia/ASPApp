using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASPApp.Dal.EntityConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
               .HasAlternateKey(r => new { r.GameId, r.ApplicationUserId });
            builder
                .HasOne(e => e.ApplicationUser)
                .WithMany(e => e.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
