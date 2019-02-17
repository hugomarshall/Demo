using DemoCore.Domain.Validations;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class UpdateBestWorkTimeCommand : BestWorkTimeCommand
    {
        public UpdateBestWorkTimeCommand(int id, string descriptionPT, string descriptionEN)
        {
            Id = id;
            DescriptionEN = descriptionEN;
            DescriptionPT = descriptionPT;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBestWorkTimeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
