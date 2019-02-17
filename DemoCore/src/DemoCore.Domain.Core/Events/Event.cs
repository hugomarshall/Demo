using MediatR;
using System;

namespace DemoCore.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
