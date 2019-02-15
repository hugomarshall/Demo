using DemoCore.Domain.Validations;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class UpdateDesignerCommand: DesignerCommand
    {
        public UpdateDesignerCommand(int id, string descriptionPT, string descriptionEN, EntityStateOptions entityState)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
            EntityState = entityState;
            DateLastUpdate = DateTime.UtcNow;
            IsNew = false;
            HasChanges = true;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDesignerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
