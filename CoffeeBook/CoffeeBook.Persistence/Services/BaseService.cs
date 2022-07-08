using Microsoft.EntityFrameworkCore;

namespace CoffeeBook.Persistence.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly AppDbContextFactory _contextFactory;

        public BaseService(AppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual T GetById(Guid id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                return  context.Set<T>().Find(id);
            }
        }
        
        public IEnumerable<T> GetAll()
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                return context.Set<T>().ToList();
            }
        }


        public T AddEntity(T entity)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                 context.Set<T>().Add(entity);
                 context.SaveChanges();

                return entity;
            }
        }

        public void DeleteEntityById(int id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                var entityToDelete = context.Set<T>().Find(id);
                context.Set<T>().Remove(entityToDelete);
                context.SaveChanges();
            }
        }

        public void UpdateEntity(T entity)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                 context.Entry(entity).State = EntityState.Modified;
                 context.SaveChanges();
            }
        }
    }
}
