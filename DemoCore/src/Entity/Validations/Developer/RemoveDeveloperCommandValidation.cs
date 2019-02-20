using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RemoveDeveloperCommandValidation: DeveloperValidation<RemoveDeveloperCommand>
    {
        public RemoveDeveloperCommandValidation()
        {
            ValidateRemove();
        }
    }
}
