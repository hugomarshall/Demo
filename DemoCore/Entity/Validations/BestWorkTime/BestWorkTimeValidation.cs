using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class BestWorkTimeValidation<T>: AbstractValidator<T> where T: BestWorkTimeCommand
    {
        protected void ValidateBestWorkTime()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("");
            RuleFor(x => x.DescriptionPT).NotEmpty().WithMessage("");
        }
    }
}
