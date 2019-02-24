using DemoCore.Domain.Models;
using System.Threading.Tasks;

namespace DemoCore.Domain.Interfaces
{
    public interface IPeopleRepository: IRepository<People>
    {
        Task<People> GetByEmail(string email);
    }
}
