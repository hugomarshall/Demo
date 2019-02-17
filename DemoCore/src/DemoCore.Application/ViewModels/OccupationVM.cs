using System;
using System.Collections.Generic;
using System.Text;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    public class OccupationVM
    {
        public int Id { get; private set; }
        public int PeopleId { get; set; }
        public PeopleVM People { get; set; }
        public List<OccupationWorkAvailabilityVM> WorkAvailabilities { get; set; }
        public List<OccupationBestWorkTimeVM> BestWorkTimes { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public bool HasChanges { get; set; }
        public bool IsNew { get; protected set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastUpdate { get; set; }
    }
}
