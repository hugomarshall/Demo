using DemoCore.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace DemoCore.Infra.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(int aggregateId);
    }
}
