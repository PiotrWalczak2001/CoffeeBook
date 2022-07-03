using CoffeeBook.Domain.Entities;

namespace CoffeeBook.Persistence.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
