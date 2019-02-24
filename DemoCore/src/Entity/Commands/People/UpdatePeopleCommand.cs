using DemoCore.Domain.Models;
using DemoCore.Domain.Validations;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class UpdatePeopleCommand : PeopleCommand
    {
        public UpdatePeopleCommand(int id, string name, string email, string skype, string celular, string linkedIn, string cidade, string estado, string portfolio, bool isDeveloper, bool isDesigner, Occupation occupation, Knowledge knowledge)
        {
            Id = id;
            Name = name;
            Email = email;
            Skype = skype;
            Phone = celular;
            LinkedIn = linkedIn;
            City = cidade;
            State = estado;
            Portfolio = portfolio;
            IsDeveloper = isDeveloper;
            IsDesigner = isDesigner;
            EntityState = EntityStateOptions.Active;
            Occupation = occupation;
            Knowledge = knowledge;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdatePeopleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
