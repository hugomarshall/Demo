using DemoCore.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("Designer", Schema = "DemoCoreData")]
    public class Designer: Entity
    {
        public Designer(): this(0)
        {
            IsNew = true;
            DateCreated = DateTime.UtcNow;
        }
        public Designer(int id)
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

        //public virtual List<KnowledgeDesigner> Knowledge { get; set; }
        public override bool Validate()
        {
            //TODO Implement Validate
            return true;
            
        }
    }
}
