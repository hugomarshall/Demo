using DemoCore.Domain.Validations;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class UpdateDeveloperCommand: DeveloperCommand
    {
        public UpdateDeveloperCommand(int id, string descriptionPT, string descriptionEN, EntityStateOptions entityState)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDeveloperCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
