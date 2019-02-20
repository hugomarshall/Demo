using AutoMapper;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Commands;

namespace DemoCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BestWorkTimeVM, RegisterNewBestWorkTimeCommand>()
                .ConstructUsing(c => new RegisterNewBestWorkTimeCommand(c.DescriptionPT, c.DescriptionEN)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<BestWorkTimeVM, UpdateBestWorkTimeCommand>()
                .ConstructUsing(c => new UpdateBestWorkTimeCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<DesignerVM, RegisterNewDesignerCommand>()
                .ConstructUsing(c => new RegisterNewDesignerCommand(c.DescriptionPT, c.DescriptionEN, c.EntityState)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<DesignerVM, UpdateDesignerCommand>()
                .ConstructUsing(c => new UpdateDesignerCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<DeveloperVM, RegisterNewDeveloperCommand>()
                .ConstructUsing(c => new RegisterNewDeveloperCommand(c.DescriptionPT, c.DescriptionEN, c.EntityState)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<DeveloperVM, UpdateDeveloperCommand>()
                .ConstructUsing(c => new UpdateDeveloperCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            //CreateMap<KnowledgeVM,>
            //CreateMap<OccupationVM,>
            CreateMap<PeopleVM, RegisterNewPeopleCommand>()
                .ConstructUsing(c => new RegisterNewPeopleCommand(c.Name, c.Email, c.Skype, c.Phone, c.LinkedIn, c.City, c.State, c.Portfolio, c.IsDeveloper, c.IsDesigner)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<PeopleVM, UpdatePeopleCommand>()
                .ConstructUsing(c => new UpdatePeopleCommand(c.Id, c.Name, c.Email, c.Skype, c.Phone, c.LinkedIn, c.City, c.State, c.Portfolio, c.IsDeveloper, c.IsDesigner)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<WorkAvailabilityVM, RegisterNewWorkAvailabilityCommand>()
                .ConstructUsing(c => new RegisterNewWorkAvailabilityCommand(c.DescriptionPT, c.DescriptionEN)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<WorkAvailabilityVM, UpdateWorkAvailabilityCommand>()
                .ConstructUsing(c => new UpdateWorkAvailabilityCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState)).IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();


        }
    }
}
