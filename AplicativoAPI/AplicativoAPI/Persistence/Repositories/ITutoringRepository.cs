namespace AplicativoAPI.Persistence.Repositories
{
    public interface ITutoringRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T t);
        void Update(Guid id, T t);
        void Delete(Guid id, T t);
    }
}
