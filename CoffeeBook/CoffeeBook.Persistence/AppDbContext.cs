using CoffeeBook.Domain.Entities;
using CoffeeBook.Domain.Enums;
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

            modelBuilder.Entity<Origin>().HasData(new Origin
            {
                Id = 1,
                Country = "Brazil",
                Region = "Mococa"
            });

            modelBuilder.Entity<Roaster>().HasData(new Roaster
            {
                Id = 1,
                Country = "Sweden",
                Name = "Johan & Nystrom",
                City = "Stockholm"
            });

            modelBuilder.Entity<Coffee>().HasData(new Coffee
            {
                Id = 1,
                Name = "Testowa Kawa",
                RoasterId = 1,
                OriginId = 1,
                Variety = "Bourbon, Mundo Novo, Catuai",
                MachiningProcess = MachiningProcessEnum.Natural,
                Type = BeansTypeEnum.Arabica,
                RoastingDate = DateTime.Today
            });

            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 1,
                Name = "Testowa notka",
                Description = "Super opis super kawy",
                CoffeeId = 1,
                BrewedDate = DateTime.Now,
                BrewingTypeEnum = BrewingTypeEnum.Drip
            });

            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 2,
                Name = "Testowa notka2",
                Description = "Super opis super kawy2",
                CoffeeId = 1,
                BrewedDate = DateTime.Now,
                BrewingTypeEnum = BrewingTypeEnum.Chemex
            });

            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 3,
                Name = "Testowa notka3",
                Description = "Super opis super kawy3",
                CoffeeId = 1,
                BrewedDate = DateTime.Now,
                BrewingTypeEnum = BrewingTypeEnum.Syphon
            });
        }

    }
}
