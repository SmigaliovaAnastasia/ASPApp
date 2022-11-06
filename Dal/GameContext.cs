using Microsoft.EntityFrameworkCore;
using ASPApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ASPApp.Domain.Entities.Auth;
using ASPApp.Dal.EntityConfiguration;

namespace ASPApp.Dal
{
    public class GameContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        DbSet<Game> Games { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<ComplexityLevel> ComplexityLevels { get; set; }
        DbSet<GameSeries> GameSeries { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Collection> Collections { get; set; }
        DbSet<CollectionGame> CollectionsGames { get; set; }

        public GameContext() : base() { }
        public GameContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectionGameConfiguration).Assembly); ;
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComplexityLevelConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameSeriesConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewConfiguration).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
