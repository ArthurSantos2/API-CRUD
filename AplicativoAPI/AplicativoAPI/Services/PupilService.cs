using AplicativoAPI.Entities;
using AplicativoAPI.Persistence.Repositories;

namespace AplicativoAPI.Services
{
    public class PupilService : ITutoringService<Pupil>
    {
        private readonly PupilRepository<Pupil> _pupilRepository;

        public PupilService(PupilRepository<Pupil> pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }

        public void Delete(Guid id, Pupil pupil)
        {
            _pupilRepository.Delete(id, pupil);
        }

        public IEnumerable<Pupil> GetAll()
        {
            return _pupilRepository.GetAll();
        }

        public Pupil GetById(Guid id)
        {
            return _pupilRepository.GetById(id);
        }

        public void Insert(Pupil pupil)
        {
            _pupilRepository.Insert(pupil);
        }

        public void Update(Guid id, Pupil pupil)
        {
            _pupilRepository.Update(id, pupil);
        }
        
    }
}
