using System;
using System.Collections.Generic;
using System.Text;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    public class OccupationVM
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public PeopleVM People { get; set; }
        public List<OccupationWorkAvailabilityVM> WorkAvailabilities { get; set; }
        public List<OccupationBestWorkTimeVM> BestWorkTimes { get; set; }
        public EntityStateOptions EntityState { get; set; }
    }
}
