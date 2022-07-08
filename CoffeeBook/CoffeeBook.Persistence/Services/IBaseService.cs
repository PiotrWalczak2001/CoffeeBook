namespace CoffeeBook.Persistence.Services
{
    public interface IBaseService<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        T AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntityById(int id);
    }
}
