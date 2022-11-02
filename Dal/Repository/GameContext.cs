using Microsoft.EntityFrameworkCore;
using ASPApp.Domain.Entities;

namespace ASPApp.Dal.Repository
{
    public class GameContext : DbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<ComplexityLevel> ComplexityLevels { get; set; }
        DbSet<GameSeries> GameSeries { get; set; }

        public GameContext() : base() { }
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
