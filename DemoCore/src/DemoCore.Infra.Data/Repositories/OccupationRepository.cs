using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
