using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.ViewModels
{
    public class OccupationWorkAvailabilityVM
    {
        public int Id { get; private set; }
        public int OccupationId { get; set; }
        public OccupationVM Occupation { get; set; }
        public int WorkAvailabilityId { get; set; }
        public WorkAvailabilityVM WorkAvailability { get; set; }
    }
}
