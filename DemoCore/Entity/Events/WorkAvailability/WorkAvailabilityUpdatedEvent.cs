using DemoCore.Domain.Core.Events;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class WorkAvailabilityUpdatedEvent: Event
    {
        public WorkAvailabilityUpdatedEvent(int id, string descriptionEN, string descriptionPT, EntityStateOptions entityState, DateTime dateUpdated)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
            DateLastUpdate = dateUpdated;
        }

        public int Id { get; private set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime? DateLastUpdate { get; set; }

    }
}
