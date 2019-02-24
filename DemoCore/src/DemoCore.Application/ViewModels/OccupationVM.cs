using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    
    public class OccupationVM
    {
        public OccupationVM()
        {
            //WorkAvailabilities = new List<OccupationWorkAvailabilityVM>();
            //BestWorkTimes = new List<OccupationBestWorkTimeVM>();
            //People = new PeopleVM();
        }

        public int Id { get; set; }
        public int PeopleId { get; set; }
        public PeopleVM People { get; set; }
        public List<OccupationWorkAvailabilityVM> WorkAvailabilities { get; set; }
        public List<OccupationBestWorkTimeVM> BestWorkTimes { get; set; }
        public EntityStateOptions EntityState { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastUpdate { get; set; }
    }

    
}
