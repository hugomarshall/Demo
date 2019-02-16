using DemoCore.Domain.Core.Events;

namespace DemoCore.Domain.Events
{
    public class DesignerRemovedEvent: Event
    {
        public DesignerRemovedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
