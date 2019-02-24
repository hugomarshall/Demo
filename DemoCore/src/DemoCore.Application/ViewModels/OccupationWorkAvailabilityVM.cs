using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.ViewModels
{
    public class OccupationWorkAvailabilityVM
    {
        public OccupationWorkAvailabilityVM()
        {
            //Occupation = new OccupationVM();
            //WorkAvailability = new WorkAvailabilityVM();
            //PageContent = new List<SelectedItems>();
        }

        public int OccupationId { get; set; }
        public virtual OccupationVM Occupation { get; set; }
        public int WorkAvailabilityId { get; set; }
        public virtual WorkAvailabilityVM WorkAvailability { get; set; }

        public IList<SelectedItems> PageContent { get; set; }
    }
}
