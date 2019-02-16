using DemoCore.Domain.Core.Events;
using DemoCore.Domain.Models;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Events
{
    public class PeopleRegisteredEvent: Event
    {
        public PeopleRegisteredEvent(int id, string name, string email, string skype, string celular, string linkedIn, bool isDeveloper, bool isDesigner)
        {
            Id = id;
            Name = name;
            Email = email;
            Skype = skype;
            Celular = celular;
            LinkedIn = linkedIn;
            IsDeveloper = isDeveloper;
            IsDesigner = isDesigner;
            DateCreated = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Celular { get; set; }
        public string LinkedIn { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsDesigner { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
