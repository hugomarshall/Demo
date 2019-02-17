using AutoMapper;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Models;

namespace DemoCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BestWorkTime, BestWorkTimeVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<Designer, DesignerVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<Developer, DeveloperVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<Knowledge, KnowledgeVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<KnowledgeDesigner, KnowledgeDesignerVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<KnowledgeDeveloper, KnowledgeDeveloperVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<Occupation, OccupationVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<OccupationBestWorkTime, OccupationBestWorkTimeVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<OccupationWorkAvailability, OccupationWorkAvailabilityVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<People, PeopleVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<WorkAvailability, WorkAvailabilityVM>().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
