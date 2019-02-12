using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Core.Models
{
    public abstract class Entity
    {
        public EntityStateOptions EntityState { get; set; }
        public bool HasChanges { get; set; }
        public bool IsNew { get; protected set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastUpdate { get; set; }
        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        public abstract bool Validate();
    }
}
