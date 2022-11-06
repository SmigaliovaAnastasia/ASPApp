using Microsoft.EntityFrameworkCore;
using ASPApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ASPApp.Dal
{
    public class GameContext : IdentityDbContext<IdentityUser>
    {
        DbSet<Game> Games { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<ComplexityLevel> ComplexityLevels { get; set; }
        DbSet<GameSeries> GameSeries { get; set; }

        public GameContext() : base() { }
        public GameContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<Game>()
                .Property(e => e.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<Game>()
                .Property(e => e.Description)
                .HasColumnType("text");
            modelBuilder.Entity<Game>()
                .Property(e => e.Rules)
                .HasColumnType("text");
            modelBuilder.Entity<Game>()
                .Property(e => e.ReleaseDate)
                .HasColumnType("date");
            modelBuilder.Entity<Game>()
                .HasOne(e => e.ComplexityLevel)
                .WithMany(e => e.Games)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Game>()
                .HasOne(e => e.GameSeries)
                .WithMany(e => e.Games)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Genre>()
               .Property(e => e.Id)
               .HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<Genre>()
                .Property(e => e.Name)
                .HasMaxLength(200);


            modelBuilder.Entity<ComplexityLevel>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<ComplexityLevel>()
                .Property(e => e.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<ComplexityLevel>()
                .Property(e => e.Description)
                .HasColumnType("text");

            modelBuilder.Entity<GameSeries>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<GameSeries>()
                .Property(e => e.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<GameSeries>()
                .Property(e => e.Description)
                .HasColumnType("text");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
