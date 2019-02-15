using AutoMapper;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Models;

namespace DemoCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BestWorkTime, BestWorkTimeVM>();                
            CreateMap<Designer, DesignerVM>();
            CreateMap<Developer, DeveloperVM>();
            CreateMap<Knowledge, KnowledgeVM>();
            CreateMap<Occupation, OccupationVM>();
            CreateMap<People, PeopleVM>();

        }
    }
}
