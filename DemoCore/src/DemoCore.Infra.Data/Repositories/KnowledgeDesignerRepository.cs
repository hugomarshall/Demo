using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;

namespace DemoCore.Infra.Data.Repositories
{
    public class KnowledgeDesignerRepository : Repository<KnowledgeDesigner>, IKnowledgeDesignerRepository
    {
        public KnowledgeDesignerRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
