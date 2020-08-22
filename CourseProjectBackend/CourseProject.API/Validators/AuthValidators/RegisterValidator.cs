using CourseProject.BusinessLogic.Dto.AuthDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.API.Validators.AuthValidators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email must contain @ symbol");

            RuleFor(p => p.Password)
                .NotEmpty()
                .Length(5, 25);

            RuleFor(f => f.FirstName)
                .NotEmpty();

            RuleFor(l => l.LastName)
                .NotEmpty();

            RuleFor(n => n.UserName)
                .NotEmpty();

            RuleFor(a => a.DateOfBirth)
                .NotEmpty();
        }
    }
}
