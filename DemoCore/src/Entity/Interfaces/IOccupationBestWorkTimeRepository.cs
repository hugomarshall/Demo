using DemoCore.Domain.Models;

namespace DemoCore.Domain.Interfaces
{
    public interface IOccupationBestWorkTimeRepository: IRepository<OccupationBestWorkTime>
    {
        void RemoveAll(int occupationId);
    }
}
