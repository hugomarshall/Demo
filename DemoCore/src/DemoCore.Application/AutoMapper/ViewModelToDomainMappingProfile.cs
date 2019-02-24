using AutoMapper;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;
using DemoCore.Domain.Models;
using System.Collections.Generic;

namespace DemoCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BestWorkTimeVM, RegisterNewBestWorkTimeCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewBestWorkTimeCommand(c.DescriptionPT, c.DescriptionEN)).IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<BestWorkTimeVM, UpdateBestWorkTimeCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new UpdateBestWorkTimeCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<DesignerVM, RegisterNewDesignerCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewDesignerCommand(c.DescriptionPT, c.DescriptionEN, c.EntityState))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<DesignerVM, UpdateDesignerCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new UpdateDesignerCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<DeveloperVM, RegisterNewDeveloperCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewDeveloperCommand(c.DescriptionPT, c.DescriptionEN, c.EntityState))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<DeveloperVM, UpdateDeveloperCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new UpdateDeveloperCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<PeopleVM, RegisterNewPeopleCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewPeopleCommand(c.Name, c.Email, c.Skype, c.Phone, c.LinkedIn, c.City, c.State, c.Portfolio, c.IsDeveloper, c.IsDesigner))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<People, UpdatePeopleCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new UpdatePeopleCommand(c.Id, c.Name, c.Email, c.Skype, c.Phone, c.LinkedIn, c.City, c.State, c.Portfolio, c.IsDeveloper, c.IsDesigner, c.Occupation, c.Knowledge))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<WorkAvailabilityVM, RegisterNewWorkAvailabilityCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewWorkAvailabilityCommand(c.DescriptionPT, c.DescriptionEN))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<WorkAvailabilityVM, UpdateWorkAvailabilityCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ConstructUsing(c => new UpdateWorkAvailabilityCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<OccupationVM, RegisterNewOccupationCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewOccupationCommand(c.PeopleId, OccupationWorkAvailabilitiesMappingExtension(c.WorkAvailabilities), OccupationBestWorkTimeMappingExtension(c.BestWorkTimes)))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<KnowledgeVM, RegisterNewKnowledgeCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateLastUpdate, opt => opt.Ignore())
                .ForMember(x => x.HasChanges, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new RegisterNewKnowledgeCommand(c.PeopleId, KnowledgeDesignerMappingExtension(c.KnowledgeDesigner), KnowledgeDevelopersMappingExtension(c.KnowledgeDeveloper), c.Other, c.UrlLinkCRUD))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<KnowledgeVM, UpdateKnowledgeCommand>()
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateLastUpdate, opt => opt.Ignore())
                .ForMember(x => x.HasChanges, opt => opt.Ignore())
                .IncludeAllDerived()
                .ConstructUsing(c => new UpdateKnowledgeCommand(c.PeopleId, KnowledgeDesignerMappingExtension(c.KnowledgeDesigner), KnowledgeDevelopersMappingExtension(c.KnowledgeDeveloper), c.Other, c.UrlLinkCRUD))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
        
        private List<KnowledgeDesigner> KnowledgeDesignerMappingExtension(List<KnowledgeDesignerVM> request)
        {
            var lst = new List<KnowledgeDesigner>();
            foreach(var item in request)
            {
                lst.Add(
                    new KnowledgeDesigner
                    {
                        DesignerId = item.DesignerId,   
                        KnowledgeId = item.KnowledgeId,
                        Value = item.Value
                    });
            }
            return lst;
        }

        private List<KnowledgeDeveloper> KnowledgeDevelopersMappingExtension(List<KnowledgeDeveloperVM> request)
        {
            var lst = new List<KnowledgeDeveloper>();
            foreach(var item in request)
            {
                lst.Add(
                        new KnowledgeDeveloper
                        {
                            DeveloperId = item.DeveloperId,
                            KnowledgeId = item.KnowledgeId,
                            Value = item.Value
                        });
            }
            return lst;
        }

        private List<OccupationWorkAvailability> OccupationWorkAvailabilitiesMappingExtension(List<OccupationWorkAvailabilityVM> request)
        {
            var lstWA = new List<OccupationWorkAvailability>();
            foreach (var item in request)
            {
                lstWA.Add(
                    new OccupationWorkAvailability()
                    {
                        OccupationId = item.OccupationId,
                        WorkAvailabilityId = item.WorkAvailabilityId,
                    }
                );
            }
            return lstWA;
        }

        private List<OccupationBestWorkTime> OccupationBestWorkTimeMappingExtension(List<OccupationBestWorkTimeVM> request)
        {
            var lstWA = new List<OccupationBestWorkTime>();
            foreach (var item in request)
            {
                lstWA.Add(
                    new OccupationBestWorkTime()
                    {
                        OccupationId = item.OccupationId,
                        BestWorkTimeId = item.BestWorkTimeId,
                    }
                );
            }
            return lstWA;
        }
    }
}
