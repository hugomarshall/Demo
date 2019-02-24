using DemoCore.Domain.Core.Commands;
using DemoCore.Domain.Models;
using System.Collections.Generic;

namespace DemoCore.Domain.Commands
{
    public abstract class OccupationCommand: Command
    {
        public int Id { get; protected set; }
        public int PeopleId { get; protected set; }
        public People People { get; protected set; }
        public List<OccupationWorkAvailability> WorkAvailabilities { get; protected set; }
        public List<OccupationBestWorkTime> BestWorkTimes { get; protected set; }
    }
}
