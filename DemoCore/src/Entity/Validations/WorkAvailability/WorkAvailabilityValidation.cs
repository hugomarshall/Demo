using DemoCore.Domain.Commands;
using FluentValidation;

namespace DemoCore.Domain.Validations
{
    public class WorkAvailabilityValidation<T>: AbstractValidator<T> where T: WorkAvailabilityCommand
    {
        protected void ValidateWorkAvailability()
        {
            RuleFor(x => x.DescriptionEN).NotEmpty().WithMessage("");
            RuleFor(x => x.DescriptionPT).NotEmpty().WithMessage("");
        }
    }
}
