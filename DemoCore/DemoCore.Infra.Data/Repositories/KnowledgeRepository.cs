using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class KnowledgeRepository : Repository<Knowledge>, IKnowledgeRepository
    {
        public KnowledgeRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
