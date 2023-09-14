using Business.Constants.ValidationMessages;
using Entity.Concrete.MySqlEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage(UserValidatorMessages.UsernameMustNotEmpty);
            RuleFor(u => u.UserName).NotNull().WithMessage(UserValidatorMessages.UsernameMustNotEmpty);

            RuleFor(u => u.Email).NotEmpty().WithMessage(UserValidatorMessages.EmailMustNotEmpty);
            RuleFor(u => u.Email).NotNull().WithMessage(UserValidatorMessages.EmailMustNotEmpty);

            RuleFor(u => u.Password).NotNull().WithMessage(UserValidatorMessages.PasswordMustNotEmpty);
            RuleFor(u => u.Password).NotEmpty().WithMessage(UserValidatorMessages.PasswordMustNotEmpty);

        }
    }
}
