using AutoMapper;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Models;

namespace DemoCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<WorkAvailability, WorkAvailabilityVM>()
                .ReverseMap();
                //.IncludeAllDerived()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<BestWorkTime, BestWorkTimeVM>()
                .ReverseMap();
                //.IncludeAllDerived()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Designer, DesignerVM>()
                .ReverseMap();
            //.IncludeAllDerived()
            //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Developer, DeveloperVM>()
                .ReverseMap();
            //.IncludeAllDerived()
            //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //.IgnoreAllPropertiesWithAnInaccessibleSetter();


            CreateMap<Knowledge, KnowledgeVM>()
                .ReverseMap()
                //.ForMember(x => x.People, opt => opt.Ignore())
                //.ForMember(dest => dest.KnowledgeDesigner, opt => opt.MapFrom(src => src.KnowledgeDesigner))
                //.ForMember(dest => dest.KnowledgeDeveloper, opt => opt.MapFrom(src => src.KnowledgeDeveloper))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                //.AfterMap((src, dest) => {
                //    foreach (var i in dest.KnowledgeDesigner)
                //        i.Knowledge = dest;
                //})
                //.AfterMap((src, dest) => {
                //    foreach (var i in dest.KnowledgeDeveloper)
                //        i.Knowledge = dest;
                //})
                .PreserveReferences();

            CreateMap<KnowledgeDesigner, KnowledgeDesignerVM>()
                //.ForMember(x => x.Knowledge, opt => opt.Ignore())
                //.ForMember(dest => dest.Designer, opt => opt.MapFrom(src => src.Designer))
                .ReverseMap()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter()
                .PreserveReferences();


            CreateMap<KnowledgeDeveloper, KnowledgeDeveloperVM>()
                //.ForMember(x => x.Knowledge, opt => opt.Ignore())
                //.ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src.Developer))
                .ReverseMap()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter()
                .PreserveReferences();


            CreateMap<Occupation, OccupationVM>()
                //.ForMember(x => x.People, opt => opt.Ignore())
                //.ForMember(x => x.People, opt => opt.Ignore())
                //.ForMember(dest => dest.BestWorkTimes, opt => opt.MapFrom(src => src.BestWorkTimes))
                //.ForMember(dest => dest.WorkAvailabilities, opt => opt.MapFrom(src => src.WorkAvailabilities))
                .ReverseMap()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter()
                //.AfterMap((src, dest) => {
                //    foreach (var i in dest.WorkAvailabilities)
                //        i.Occupation = dest;
                //})
                //.AfterMap((src, dest) => {
                //    foreach (var i in dest.BestWorkTimes)
                //        i.Occupation = dest;
                //})
                .PreserveReferences();


            CreateMap<OccupationBestWorkTime, OccupationBestWorkTimeVM>()
                //.ForMember(x => x.Occupation, opt => opt.Ignore())
                .ReverseMap()
                //.ForMember(dest => dest.BestWorkTime, opt => opt.MapFrom(src => src.BestWorkTime))
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter()
                .PreserveReferences();

            CreateMap<OccupationWorkAvailability, OccupationWorkAvailabilityVM>()
                //.ForMember(x => x.Occupation, opt => opt.Ignore())
                .ForMember(x => x.PageContent, opt => opt.Ignore())
                //.ForMember(dest => dest.WorkAvailability, opt => opt.MapFrom(src => src.WorkAvailability))
                .ReverseMap()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .PreserveReferences();

            CreateMap<People, PeopleVM>()
                .ReverseMap()
                //.IncludeAllDerived()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                //.IgnoreAllPropertiesWithAnInaccessibleSetter()
                .PreserveReferences();

        }
    }
}
