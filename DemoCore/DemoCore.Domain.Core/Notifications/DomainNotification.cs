using DemoCore.Domain.Core.Events;
using System;

namespace DemoCore.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private protected set; }
        public string Key { get; private protected set; }
        public string Value { get; private protected set; }
        public int Version { get; private protected set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
