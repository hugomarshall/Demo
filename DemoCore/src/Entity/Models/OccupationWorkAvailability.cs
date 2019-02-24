using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCore.Domain.Models
{
    [Table("OccupationWorkAvailability", Schema = "DemoCoreData")]
    public class OccupationWorkAvailability
    {
        public int OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }
        public int WorkAvailabilityId { get; set; }
        public virtual WorkAvailability WorkAvailability { get; set; }
    }
}
