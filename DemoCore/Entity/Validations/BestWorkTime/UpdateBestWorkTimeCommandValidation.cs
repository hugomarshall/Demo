using DemoCore.Domain.Commands;

namespace DemoCore.Domain.Validations
{
    public class UpdateBestWorkTimeCommandValidation: BestWorkTimeValidation<UpdateBestWorkTimeCommand>
    {
        public UpdateBestWorkTimeCommandValidation()
        {
            ValidateBestWorkTime();
        }
    }
}
