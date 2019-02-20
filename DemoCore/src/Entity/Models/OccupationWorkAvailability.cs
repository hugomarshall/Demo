using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCore.Domain.Models
{
    [Table("OccupationWorkAvailability", Schema = "DemoCoreData")]
    public class OccupationWorkAvailability
    {
        public OccupationWorkAvailability():this(0)
        {

        }
        public OccupationWorkAvailability(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }
        public int WorkAvailabilityId { get; set; }
        public WorkAvailability WorkAvailability { get; set; }
    }
}
