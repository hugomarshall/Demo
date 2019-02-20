using DemoCore.Domain.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("Designer", Schema = "DemoCoreData")]
    public class Designer: Entity
    {
        public Designer(): this(0)
        {
        }
        public Designer(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }

        public ICollection<KnowledgeDesigner> Knowledge { get; set; }
        public override bool Validate()
        {
            //TODO Implement Validate
            return true;
            
        }
    }
}
