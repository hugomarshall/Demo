using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterWorkAvailabilityCommandValidation: WorkAvailabilityValidation<RegisterNewWorkAvailabilityCommand>
    {
        public RegisterWorkAvailabilityCommandValidation()
        {
            ValidateWorkAvailability();
        }
    }
}
