using DemoCore.Domain.Core.Events;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class WorkAvailabilityRegisteredEvent: Event
    {
        public WorkAvailabilityRegisteredEvent(int id, string descriptionEN, string descriptionPT, EntityStateOptions entityState, DateTime dateCreated)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
            DateCreated = dateCreated;
        }

        public int Id { get; private set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateCreated { get; set; }
    }

    

}
