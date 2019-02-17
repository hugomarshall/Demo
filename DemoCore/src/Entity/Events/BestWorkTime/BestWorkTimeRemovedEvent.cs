using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class BestWorkTimeRemovedEvent: Event
    {
        public BestWorkTimeRemovedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
