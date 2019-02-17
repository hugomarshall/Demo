using FluentValidation.Validators;
using System;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Domain.Validations
{
    public class PropertyValidatorExtension
    {
        public class EnumValidator<T> : PropertyValidator
        {
            public EnumValidator() : base("Invalid update indicator") { }

            protected override bool IsValid(PropertyValidatorContext context)
            {
                T enumVal = (T)Enum.Parse(typeof(T), context.PropertyValue.ToString());

                if (!Enum.IsDefined(typeof(T), enumVal))
                    return false;

                return true;
            }
        }
    }
}
