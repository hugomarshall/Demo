using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class BestWorkTimeRepository : Repository<BestWorkTime>, IBestWorkTimeRepository
    {
        public BestWorkTimeRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
