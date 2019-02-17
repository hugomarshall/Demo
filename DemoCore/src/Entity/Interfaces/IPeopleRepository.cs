using DemoCore.Domain.Models;

namespace DemoCore.Domain.Interfaces
{
    public interface IPeopleRepository: IRepository<People>
    {
        People GetByEmail(string email);
    }
}
