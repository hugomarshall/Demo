using DemoCore.Domain.Models;

namespace DemoCore.Domain.Interfaces
{
    public interface IKnowledgeDeveloperRepository: IRepository<KnowledgeDeveloper>
    {
        void RemoveAll(int knowledgeId);
    }
}
