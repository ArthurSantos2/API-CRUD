using AplicativoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AplicativoAPI.Persistence.Repositories
{
    public class MastermindRepository : TutoringRepository<Mastermind>
    {
       
        public MastermindRepository(TutoringDbContext context) : base(context)
        {
            
        }

        public override void Update(Guid id, Mastermind mastermind)
        {
            var master = base.GetById(id);

            master.AreaName = mastermind.AreaName;
            master.NameMastermind = mastermind.NameMastermind;
            master.MastermindDescription = mastermind.MastermindDescription;
            master.Id = id;

            base.Update(id, master);
        }
    }
}
