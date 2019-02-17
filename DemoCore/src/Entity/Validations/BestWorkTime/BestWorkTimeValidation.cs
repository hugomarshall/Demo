using DemoCore.Domain.Commands;
using FluentValidation;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;
using static DemoCore.Domain.Validations.PropertyValidatorExtension;

namespace DemoCore.Domain.Validations
{
    public class BestWorkTimeValidation<T>: AbstractValidator<T> where T: BestWorkTimeCommand
    {
        protected void ValidateBestWorkTime()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("Description in english is required.");
            RuleFor(x => x.DescriptionPT).NotEmpty().WithMessage("Description in portuguese is required.");
        }

    }
}
