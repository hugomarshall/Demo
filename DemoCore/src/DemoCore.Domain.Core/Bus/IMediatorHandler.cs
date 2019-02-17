using DemoCore.Domain.Core.Commands;
using DemoCore.Domain.Core.Events;
using System.Threading.Tasks;

namespace DemoCore.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
