using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class WorkAvailabilityRepository : Repository<WorkAvailability>, IWorkAvailabilityRepository
    {
        public WorkAvailabilityRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
