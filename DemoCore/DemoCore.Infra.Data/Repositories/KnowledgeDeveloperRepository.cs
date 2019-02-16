using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class KnowledgeDeveloperRepository : Repository<KnowledgeDeveloper>, IKnowledgeDeveloperRepository
    {
        public KnowledgeDeveloperRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
