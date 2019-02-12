using DemoCore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Domain.Validations
{
    public class UpdatePeopleCommandValidation: PeopleValidation<UpdatePeopleCommand>
    {
        public UpdatePeopleCommandValidation()
        {
            ValidatePeople();
        }
    }
}
