using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Models;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class OccupationUpdatedEvent: Event
    {
        public OccupationUpdatedEvent(int id, int peopleId, People people, List<OccupationWorkAvailability> workAvailabilities, List<OccupationBestWorkTime> bestWorkTimes, EntityStateOptions entityState, DateTime dateUpdated)
        {
            Id = id;
            PeopleId = peopleId;
            People = people;
            WorkAvailabilities = workAvailabilities;
            BestWorkTimes = bestWorkTimes;
            EntityState = entityState;
            DateLastUpdated = dateUpdated;
        }

        public int Id { get; private set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public List<OccupationWorkAvailability> WorkAvailabilities { get; set; }
        public List<OccupationBestWorkTime> BestWorkTimes { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
