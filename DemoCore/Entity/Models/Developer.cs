using DemoCore.Domain.Core.Models;

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
        public string Description { get; set; }

        public override bool Validate()
        {
            //TODO Implement Validate
            return true;

        }
    }
}
