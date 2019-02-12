using DemoCore.Domain.Core.Models;

namespace DemoCore.Domain.Models
{
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
        public string Description { get; set; }

        public override bool Validate()
        {
            //TODO Implement Validate
            return true;
            
        }
    }
}
