using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class KnowledgeRegisteredEvent: Event
    {
        public KnowledgeRegisteredEvent(int id, string user)
        {
            Id = id;
            User = user;
        }

        public int Id { get; set; }
        public string User { get; set; }
    }
}
