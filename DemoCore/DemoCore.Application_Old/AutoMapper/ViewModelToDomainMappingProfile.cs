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
                .ConstructUsing(c => new RegisterNewBestWorkTimeCommand(c.DescriptionPT, c.DescriptionEN));
            CreateMap<BestWorkTimeVM, UpdateBestWorkTimeCommand>()
                .ConstructUsing(c => new UpdateBestWorkTimeCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState));
            CreateMap<DesignerVM, RegisterNewDesignerCommand>()
                .ConstructUsing(c => new RegisterNewDesignerCommand(c.DescriptionPT, c.DescriptionEN));
            CreateMap<DesignerVM, UpdateDesignerCommand>()
                .ConstructUsing(c => new UpdateDesignerCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState));
            CreateMap<DeveloperVM, RegisterNewDeveloperCommand>()
                .ConstructUsing(c => new RegisterNewDeveloperCommand(c.DescriptionPT, c.DescriptionEN));
            CreateMap<DeveloperVM, UpdateDeveloperCommand>()
                .ConstructUsing(c => new UpdateDeveloperCommand(c.Id, c.DescriptionPT, c.DescriptionEN, c.EntityState));
            //CreateMap<KnowledgeVM,>
            //CreateMap<OccupationVM,>
            CreateMap<PeopleVM, RegisterNewPeopleCommand>()
                .ConstructUsing(c => new RegisterNewPeopleCommand(c.Name, c.Email, c.Skype, c.Phone, c.LinkedIn, c.City, c.State, c.Portfolio, c.IsDeveloper, c.IsDesigner));
            CreateMap<PeopleVM, UpdatePeopleCommand>()
                .ConstructUsing(c => new UpdatePeopleCommand(c.Id, c.Name, c.Email, c.Skype, c.Phone, c.LinkedIn, c.City, c.State, c.Portfolio, c.IsDeveloper, c.IsDesigner));

        }
    }
}
