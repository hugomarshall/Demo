using DemoCore.Domain.Core.Models;
using System.Collections.Generic;

namespace DemoCore.Domain.Models
{
    public class Developer: Entity
    {
        public Developer(): this(0)
        {

        }
        public Developer(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public ICollection<KnowledgeDeveloper> Knowledge { get; set; }
        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
