using Microsoft.EntityFrameworkCore;


namespace AplicativoAPI.Persistence.Repositories
{
    public class TutoringRepository<T> : ITutoringRepository<T> where T : class
    {
        private readonly TutoringDbContext _dbContext;

        public TutoringRepository(TutoringDbContext dbContext)
        {

            _dbContext = dbContext; 

        }

        public virtual void Insert(T t)
        {
            _dbContext.Set<T>().Add(t);
            _dbContext.SaveChanges();
        }

        public virtual T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual void Update(Guid id, T t)
        {
            var entity = _dbContext.Set<T>().Find(id);

            if (entity != null)
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(t);
                _dbContext.SaveChanges();
            }
        }

        public virtual void Delete(Guid id, T t)
        { 
            _dbContext.Remove(t);
        }
    }

}
