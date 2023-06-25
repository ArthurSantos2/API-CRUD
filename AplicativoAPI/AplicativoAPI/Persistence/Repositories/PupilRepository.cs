using AplicativoAPI.Entities;

namespace AplicativoAPI.Persistence.Repositories
{
    public class PupilRepository : TutoringRepository<Pupil>
    {

       
        public PupilRepository(TutoringDbContext context) : base(context)
        {
           
        }

        public override void Update(Guid id, Pupil t)
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
