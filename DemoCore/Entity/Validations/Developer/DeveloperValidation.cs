using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class DeveloperValidation<T>: AbstractValidator<T> where T: DeveloperCommand
    {
        protected void ValidateDeveloper()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("");
            RuleFor(x => x.DescriptionPT).NotEmpty().WithMessage("");
        }
    }
}
