using DemoCore.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("WorkAvailability", Schema = "DemoCoreData")]
    public class WorkAvailability: Entity
    {
        public WorkAvailability(): this(0)
        {

        }
        public WorkAvailability(int id)
        {
            Id = id;
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
