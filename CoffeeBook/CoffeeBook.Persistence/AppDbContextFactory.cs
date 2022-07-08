using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeBook.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>, IDisposable
    {
        private AppDbContext _dbContext;
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server=.;Database=CoffeeBookDb;Trusted_Connection=True;");

            _dbContext = new AppDbContext(options.Options);
            return _dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
