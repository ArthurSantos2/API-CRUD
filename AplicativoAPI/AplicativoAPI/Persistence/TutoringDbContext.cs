using AplicativoAPI.Entities;

namespace AplicativoAPI.Persistence
{
    public class TutoringDbContext
    {
        public List<Pupil> Tutoring { get; set; }

        public TutoringDbContext() 
        {
            Tutoring = new List<Pupil>();
        }
    }
}
