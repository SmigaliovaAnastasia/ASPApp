using Microsoft.EntityFrameworkCore;
using ASPApp.Domain.Entities;

namespace ASPApp.Dal.Repository
{
    public class GameContext : DbContext
    {
        DbSet<Game> Games { get; set; }
        public GameContext() : base() { }
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
