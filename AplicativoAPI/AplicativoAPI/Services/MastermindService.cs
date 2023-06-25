using AplicativoAPI.Entities;
using AplicativoAPI.Persistence.Repositories;

namespace AplicativoAPI.Services
{
    public class MastermindService : ITutoringService<Mastermind>
    {
        private readonly MastermindRepository _mastermindRepository;
        public MastermindService(MastermindRepository mastermindRepository)
        {
            _mastermindRepository = mastermindRepository;
        }

        public void Delete(Guid id, Mastermind t)
        {
            _mastermindRepository.Delete(id, t);
        }

        public IEnumerable<Mastermind> GetAll()
        {
            return _mastermindRepository.GetAll();
        }

        public Mastermind GetById(Guid id)
        {
            return _mastermindRepository.GetById(id);
        }

        public void Insert(Mastermind t)
        {
            _mastermindRepository.Insert(t);
        }

        public void Update(Guid id, Mastermind t)
        {
            _mastermindRepository.Update(id, t);
        }
    }
}
