using DemoCore.Domain.Core.Events;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class DeveloperRegisteredEvent: Event
    {
        public DeveloperRegisteredEvent(int id, string descriptionPT, string descriptionEN, EntityStateOptions entityState, DateTime dateCreated)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
            DateCreated = dateCreated;
        }

        public int Id { get; set; }
        public string DescriptionPT { get; set; }
        public string DescriptionEN { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
