using AplicativoAPI.Persistence;
using AplicativoAPI.Persistence.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Metadata.Internal;

namespace AplicativoAPI.Services
{
    public class TutoringService<T> : ITutoringService<T> where T : class
    {
        private readonly ITutoringRepository<T> _repository;
        public TutoringService(ITutoringRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Delete(Guid id, T t)
        {
            var obj = _repository.GetById(id);

            if (obj != null) 
            {
                _repository.Delete(id, obj);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
           return _repository.GetAll();
        }

        public virtual T GetById(Guid id)
        {
            var obj = _repository.GetById(id);
            
            if (obj != null)
            {
                return obj;
            }

            return null;


        }

        public virtual void Insert(T t)
        {
            _repository.Insert(t);
        }

        public virtual void Update(Guid id, T t)
        {
            var obj = GetById(id);

            if(obj != null)
            {
                _repository.Update(id, t);
            }
        }
    }
}
