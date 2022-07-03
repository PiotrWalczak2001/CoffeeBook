using CoffeeBook.Domain.Entities;

namespace CoffeeBook.Persistence.Repositories
{
    public class OriginRepository : BaseRepository<Origin>, IOriginRepository
    {
        public OriginRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
