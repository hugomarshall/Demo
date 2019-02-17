using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class PeopleRemovedEvent: Event
    {
        public PeopleRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
