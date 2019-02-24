using DemoCore.Domain.Models;
using System.Collections.Generic;

namespace DemoCore.Domain.Commands
{
    public class UpdateOccupationCommand: OccupationCommand
    {
        public UpdateOccupationCommand(int peopleId, People people, List<OccupationWorkAvailability> workAvailabilities, List<OccupationBestWorkTime> bestWorkTimes)
        {
            PeopleId = peopleId;
            People = people;
            WorkAvailabilities = workAvailabilities;
            BestWorkTimes = bestWorkTimes;
        }

        public override bool IsValid()
        {
            //Todo validate!
            return true;
        }
    }
}
