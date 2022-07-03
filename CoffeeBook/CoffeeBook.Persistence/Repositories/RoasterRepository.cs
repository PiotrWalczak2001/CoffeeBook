using CoffeeBook.Domain.Entities;

namespace CoffeeBook.Persistence.Repositories
{
    public class RoasterRepository : BaseRepository<Roaster>, IRoasterRepository
    {
        public RoasterRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
