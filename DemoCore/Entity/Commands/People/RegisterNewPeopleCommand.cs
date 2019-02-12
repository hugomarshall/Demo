﻿using DemoCore.Domain.Models;
using DemoCore.Domain.Validations;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Commands
{
    public class RegisterNewPeopleCommand : PeopleCommand
    {
        public RegisterNewPeopleCommand(string name, string email, string skype, string celular, string linkedIn, string cidade, string estado, string portfolio, bool isDeveloper, bool isDesigner)
        {
            Id = 0;
            Name = name;
            Email = email;
            Skype = skype;
            Celular = celular;
            LinkedIn = linkedIn;
            Cidade = cidade;
            Estado = estado;
            Portfolio = portfolio;
            IsDeveloper = isDeveloper;
            IsDesigner = isDesigner;
            DateCreated = DateTime.Now;
            DateLastUpdate = null;
            EntityState = EntityStateOptions.Active;
            HasChanges = false;
            IsNew = true;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPeopleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
