using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class OccupationBestWorkTimeRepository : Repository<OccupationBestWorkTime>, IOccupationBestWorkTimeRepository
    {
        public OccupationBestWorkTimeRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
