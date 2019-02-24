using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;
using System.Linq;

namespace DemoCore.Infra.Data.Repositories
{
    public class KnowledgeDesignerRepository : Repository<KnowledgeDesigner>, IKnowledgeDesignerRepository
    {
        public KnowledgeDesignerRepository(DemoCoreContext context) : base(context)
        {
        }
        public void RemoveAll(int knowledgeId)
        {
            var db = DbSet.Where(x => x.KnowledgeId.Equals(knowledgeId)).ToList();
            DbSet.RemoveRange(db);
        }
    }
}
