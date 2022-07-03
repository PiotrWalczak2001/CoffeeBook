using CoffeeBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBook.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Roaster> Roasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
