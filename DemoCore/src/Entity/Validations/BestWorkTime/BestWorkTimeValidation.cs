using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class BestWorkTimeValidation<T>: AbstractValidator<T> where T: BestWorkTimeCommand
    {
        protected void ValidateBestWorkTime()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.DescriptionPT).NotEmpty().WithMessage("{PropertyName} is required.");
        }

        protected void ValidateRemove()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
