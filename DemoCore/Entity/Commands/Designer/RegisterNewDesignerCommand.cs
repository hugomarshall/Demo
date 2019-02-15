using DemoCore.Domain.Validations;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewDesignerCommand: DesignerCommand
    {
        public RegisterNewDesignerCommand(string descriptionPT, string descriptionEN)
        {
            Id = 0;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = EntityStateOptions.Active;
            DateCreated = DateTime.UtcNow;
            DateLastUpdate = null;
            IsNew = true;
            HasChanges = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDesignerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
