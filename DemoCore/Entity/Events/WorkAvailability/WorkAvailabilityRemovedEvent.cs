using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class WorkAvailabilityRemovedEvent: Event
    {
        public WorkAvailabilityRemovedEvent(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
