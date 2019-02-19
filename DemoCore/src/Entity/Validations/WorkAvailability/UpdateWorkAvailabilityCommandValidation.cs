using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdateWorkAvailabilityCommandValidation: WorkAvailabilityValidation<UpdateWorkAvailabilityCommand>
    {
        public UpdateWorkAvailabilityCommandValidation()
        {
            ValidateWorkAvailability();
        }
    }
}
