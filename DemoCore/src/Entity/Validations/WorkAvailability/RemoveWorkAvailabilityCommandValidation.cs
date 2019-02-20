using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RemoveWorkAvailabilityCommandValidation: WorkAvailabilityValidation<RemoveWorkAvailabilityCommand>
    {
        public RemoveWorkAvailabilityCommandValidation()
        {
            ValidateRemove();
        }
    }
}
