using DemoCore.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("Occupation", Schema = "DemoCoreData")]
    public class Occupation: Entity
    {
        public Occupation(int id)
        {
            Id = id;
            if (id != 0)
            {
                HasChanges = true;
                DateLastUpdate = DateTime.UtcNow;
                DateCreated = this.DateCreated;
            };
        }
        public Occupation(): this(0)
        {
            IsNew = true;
            DateCreated = DateTime.UtcNow;
        }
        public int Id { get; private set; }
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
        public virtual List<OccupationWorkAvailability> WorkAvailabilities { get; set; }
        public virtual List<OccupationBestWorkTime> BestWorkTimes { get; set; }

        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
