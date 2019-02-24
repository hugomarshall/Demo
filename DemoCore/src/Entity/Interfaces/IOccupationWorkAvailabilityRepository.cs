using DemoCore.Domain.Models;

namespace DemoCore.Domain.Interfaces
{
    public interface IOccupationWorkAvailabilityRepository: IRepository<OccupationWorkAvailability>
    {
        void RemoveAll(int occupationId);
    }
}
