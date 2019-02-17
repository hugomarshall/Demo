using DemoCore.Domain.Core.Events;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class DesignerUpdatedEvent: Event
    {
        public DesignerUpdatedEvent(int id, string descriptionPT, string descriptionEN, EntityStateOptions entityState, DateTime dateUpdate)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
            DateLastUpdate = dateUpdate;
        }

        public int Id { get; set; }
        public string DescriptionPT { get; set; }
        public string DescriptionEN { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateLastUpdate { get; set; }
    }
}
