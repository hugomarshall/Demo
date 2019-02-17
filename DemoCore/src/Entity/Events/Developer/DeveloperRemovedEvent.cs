using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class DeveloperRemovedEvent: Event
    {
        public DeveloperRemovedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
