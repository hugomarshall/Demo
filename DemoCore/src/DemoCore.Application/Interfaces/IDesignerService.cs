using DemoCore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DemoCore.Application.Interfaces
{
    public interface IDesignerService: IDisposable
    {
        void Register(DesignerVM designerVM);
        IEnumerable<DesignerVM> GetAll();
        DesignerVM GetById(int id);
        void Update(DesignerVM designerVM);
        void Remove(int id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
