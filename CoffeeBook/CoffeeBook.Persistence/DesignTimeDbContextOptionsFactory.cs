using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeBook.Persistence
{
    public class DesignTimeDbContextOptionsFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server=.;Database=CoffeeBookDb;Trusted_Connection=True;");

            return new AppDbContext(options.Options);
        }
    }
}
