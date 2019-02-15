using DemoCore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DemoCore.Application.Interfaces
{
    public interface IDeveloperService: IDisposable
    {
        void Register(DeveloperVM developerVM);
        IEnumerable<DeveloperVM> GetAll();
        DeveloperVM GetById(int id);
        void Update(DeveloperVM developerVM);
        void Remove(int id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
