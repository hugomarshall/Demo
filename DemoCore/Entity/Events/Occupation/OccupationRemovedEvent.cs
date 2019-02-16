using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class OccupationRemovedEvent: Event
    {
        public OccupationRemovedEvent(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
