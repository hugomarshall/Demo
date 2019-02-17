using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class DesignerRepository : Repository<Designer>, IDesignerRepository
    {
        public DesignerRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
