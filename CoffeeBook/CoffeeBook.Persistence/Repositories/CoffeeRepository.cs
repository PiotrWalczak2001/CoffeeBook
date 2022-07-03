using CoffeeBook.Domain.Entities;

namespace CoffeeBook.Persistence.Repositories
{
    public class CoffeeRepository : BaseRepository<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
