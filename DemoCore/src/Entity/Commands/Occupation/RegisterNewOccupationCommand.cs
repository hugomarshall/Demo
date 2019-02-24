using DemoCore.Domain.Models;
using System.Collections.Generic;


namespace DemoCore.Domain.Commands
{
    public class RegisterNewOccupationCommand : OccupationCommand
    {
        public RegisterNewOccupationCommand(int peopleId, List<OccupationWorkAvailability> workAvailabilities, List<OccupationBestWorkTime> bestWorkTimes)
        {
            PeopleId = peopleId;
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
