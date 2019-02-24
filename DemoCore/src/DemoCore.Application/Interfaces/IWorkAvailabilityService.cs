using DemoCore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Application.Interfaces
{
    public interface IWorkAvailabilityService: IDisposable
    {
        void Register(WorkAvailabilityVM request);
        IEnumerable<WorkAvailabilityVM> GetAll();
        WorkAvailabilityVM GetById(int id);
        void Update(WorkAvailabilityVM request);
        void Remove(int id);
        IEnumerable<SelectedItems> GetSelectedWorkAvailability();
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
