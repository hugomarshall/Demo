using DemoCore.Domain.Core.Models;

namespace DemoCore.Domain.Models
{
    public class People: Entity
    {
        public People(int id)
        {
            Id = id;
        }
        public People(): this(0)
        {
            IsNew = true;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string LinkedIn { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Portfolio { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsDesigner { get; set; }
        public Occupation Occupation { get; set; }
        public Knowledge Knowledge { get; set; }
        public override bool Validate()
        {
            //TODO Implement specifc entity Validate
            return true;
        }
    }
}
