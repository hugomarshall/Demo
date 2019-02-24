using DemoCore.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("BestWorkTime", Schema = "DemoCoreData")]
    public class BestWorkTime: Entity
    {
        public BestWorkTime(): this(0)
        {
            IsNew = true;
            DateCreated = DateTime.UtcNow;
        }
        public BestWorkTime(int id)
        {
            Id = id;
            if (id != 0)
            {
                HasChanges = true;
                DateLastUpdate = DateTime.UtcNow;
                DateCreated = DateCreated;
            };
        }
        public int Id { get; private set; }
        public string DescriptionPT { get; set; }
        public string DescriptionEN { get; set; }
        //public virtual ICollection<OccupationBestWorkTime> Occupation { get; set; }
        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
