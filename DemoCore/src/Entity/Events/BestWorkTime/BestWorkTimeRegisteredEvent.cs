using DemoCore.Domain.Core.Events;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class BestWorkTimeRegisteredEvent: Event
    {
        public BestWorkTimeRegisteredEvent(int id, string descriptionPT, string descriptionEN)
        {
            Id = id;
            DescriptionPT = descriptionPT;
            DescriptionEN = descriptionEN;
            AggregateId = id;
        }

        public int Id { get; set; }
        public string DescriptionPT { get; set; }
        public string DescriptionEN { get; set; }
    }
}
