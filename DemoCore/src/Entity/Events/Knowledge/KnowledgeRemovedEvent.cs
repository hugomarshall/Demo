using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class KnowledgeRemovedEvent: Event
    {
        public KnowledgeRemovedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
