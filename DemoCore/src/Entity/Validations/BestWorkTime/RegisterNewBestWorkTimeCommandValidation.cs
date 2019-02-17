using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class RegisterNewBestWorkTimeCommandValidation: BestWorkTimeValidation<RegisterNewBestWorkTimeCommand>
    {
        public RegisterNewBestWorkTimeCommandValidation()
        {
            ValidateBestWorkTime();
        }
    }
}
