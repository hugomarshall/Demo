using DemoCore.Domain.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Domain.Models
{
    [Table("People", Schema = "DemoCoreData")]
    public class People: Entity
    {
        public People(int id)
        {
            Id = id;
            if (id != 0)
            {
                HasChanges = true;
                DateLastUpdate = DateTime.UtcNow;
                DateCreated = this.DateCreated;
            };
        }
        public People(): this(0)
        {
            DateCreated = DateTime.UtcNow;
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
        public virtual Occupation Occupation { get; set; }
        public virtual Knowledge Knowledge { get; set; }
        public override bool Validate()
        {
            //TODO Implement specifc entity Validate
            return true;
        }
    }
}
