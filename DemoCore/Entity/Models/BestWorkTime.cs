using DemoCore.Domain.Core.Models;

namespace DemoCore.Domain.Models
{
    public class BestWorkTime: Entity
    {
        public BestWorkTime(): this(0)
        {

        }
        public BestWorkTime(int id)
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
