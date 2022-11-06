using ASPApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASPApp.Dal.EntityConfiguration
{
    public class CollectionGameConfiguration : IEntityTypeConfiguration<CollectionGame>
    {
        public void Configure(EntityTypeBuilder<CollectionGame> builder)
        {
            builder
                .HasAlternateKey(r => new { r.CollectionId, r.GameId });
        }
    }
}
