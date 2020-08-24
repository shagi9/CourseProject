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
                .NotEmpty()
                .Length(2, 20)
                .Matches("^[a-zA-Z0-9]+$");

            RuleFor(l => l.LastName)
                .NotEmpty()
                .Length(2, 20)
                .Matches("^[a-zA-Z0-9]+$");

            RuleFor(n => n.UserName)
                .NotEmpty()
                .Length(2, 20)
                .Matches("^[a-zA-Z0-9]+$");

            RuleFor(a => a.DateOfBirth)
                .NotEmpty();
        }
    }
}
