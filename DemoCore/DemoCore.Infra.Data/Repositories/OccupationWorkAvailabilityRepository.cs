using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class OccupationWorkAvailabilityRepository : Repository<OccupationWorkAvailability>, IOccupationWorkAvailabilityRepository
    {
        public OccupationWorkAvailabilityRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
