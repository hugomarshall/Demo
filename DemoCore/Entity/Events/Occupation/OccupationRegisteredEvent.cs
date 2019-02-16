using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Models;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class OccupationRegisteredEvent: Event
    {
        public OccupationRegisteredEvent(int id, int peopleId, People people, List<OccupationWorkAvailability> workAvailabilities, List<OccupationBestWorkTime> bestWorkTimes, EntityStateOptions entityState, DateTime dateCreated)
        {
            Id = id;
            PeopleId = peopleId;
            People = people;
            WorkAvailabilities = workAvailabilities;
            BestWorkTimes = bestWorkTimes;
            EntityState = entityState;
            DateCreated = dateCreated;
        }

        public int Id { get; private set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public List<OccupationWorkAvailability> WorkAvailabilities { get; set; }
        public List<OccupationBestWorkTime> BestWorkTimes { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
