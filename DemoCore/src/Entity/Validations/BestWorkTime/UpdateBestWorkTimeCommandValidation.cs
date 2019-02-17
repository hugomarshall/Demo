using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdateBestWorkTimeCommandValidation: BestWorkTimeValidation<BestWorkTimeCommand>
    {
        public UpdateBestWorkTimeCommandValidation()
        {
            ValidateBestWorkTime();
        }
    }
}
