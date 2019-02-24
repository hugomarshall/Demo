using DemoCore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DemoCore.Application.Interfaces
{
    public interface IOccupationService: IDisposable
    {
        void Register(OccupationVM request);
        IEnumerable<OccupationVM> GetAll();
        OccupationVM GetById(int id);
        void Update(OccupationVM request);
        void Remove(int id);
        OccupationVM GetOccupationIncludeChilds(int id);
        void UpdateOccupationBestWorkTime(string[] selectedBestWorkTime, OccupationVM occupationToUpdate);
        void UpdateOccupationWorkAvailability(string[] selectedWorkAvailability, OccupationVM occupationToUpdate);
    }
}
