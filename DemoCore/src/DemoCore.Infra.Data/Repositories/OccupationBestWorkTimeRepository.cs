using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;
using System.Linq;

namespace DemoCore.Infra.Data.Repositories
{
    public class OccupationBestWorkTimeRepository : Repository<OccupationBestWorkTime>, IOccupationBestWorkTimeRepository
    {
        public OccupationBestWorkTimeRepository(DemoCoreContext context) : base(context)
        {
        }

        public void RemoveAll(int occupationId)
        {
            var db = DbSet.Where(x => x.OccupationId.Equals(occupationId)).ToList();
            DbSet.RemoveRange(db);
        }
    }
}
