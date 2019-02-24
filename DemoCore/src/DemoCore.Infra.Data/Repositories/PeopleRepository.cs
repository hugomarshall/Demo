using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DemoCore.Infra.Data.Repositories
{
    public class PeopleRepository: Repository<People>, IPeopleRepository
    {
        private readonly DemoCoreContext context;

        public PeopleRepository(DemoCoreContext context): base(context)
        {
            this.context = context;
        }

        public async Task<People> GetByEmail(string email)
        {
            var people = await DbSet.Include(x => x.Occupation).ThenInclude(x => x.BestWorkTimes)
                .Include(x => x.Occupation).ThenInclude(x => x.WorkAvailabilities)
                .Include(x => x.Knowledge).ThenInclude(x => x.KnowledgeDesigner)
                .Include(x => x.Knowledge).ThenInclude(x => x.KnowledgeDeveloper).AsNoTracking().FirstOrDefaultAsync(x=>x.Email == email);

            return people;
            
        }

    }
}
