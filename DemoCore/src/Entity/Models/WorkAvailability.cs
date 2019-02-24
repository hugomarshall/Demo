using DemoCore.Domain.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("WorkAvailability", Schema = "DemoCoreData")]
    public class WorkAvailability: Entity
    {
        public WorkAvailability(): this(0)
        {
            IsNew = true;
            DateCreated = DateTime.UtcNow;
        }
        public WorkAvailability(int id)
        {
            Id = id;
            if (id != 0)
            {
                HasChanges = true;
                DateLastUpdate = DateTime.UtcNow;
                DateCreated = this.DateCreated;
            };
        }
        public int Id { get; private set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }

        public override bool Validate()
        {
            //TODO Implement Validate
            return true;
        }
    }
}
