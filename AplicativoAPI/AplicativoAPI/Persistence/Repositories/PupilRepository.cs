using AplicativoAPI.Entities;

namespace AplicativoAPI.Persistence.Repositories
{
    public class PupilRepository<T> : TutoringRepository<T> where T: Pupil
    {
        private readonly TutoringDbContext _context;
        public PupilRepository(TutoringDbContext context) : base(context)
        {
            _context = context;
        }

        public override void Update(Guid id, T t)
        {
            var pupil = base.GetById(id);

            pupil.Name = t.Name;
            pupil.Id = id;
            pupil.Description = t.Description;
            pupil.CreatedDate = t.CreatedDate;
            pupil.UpdatedDate = t.UpdatedDate;
            pupil.IsDeleted = t.IsDeleted;

            base.Update(id, pupil);
        }
    }
}
