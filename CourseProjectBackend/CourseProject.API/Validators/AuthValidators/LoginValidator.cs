using CourseProject.BusinessLogic.Dto.AuthDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CourseProject.API.Validators.AuthValidators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Login).NotEmpty();
            RuleFor(u => u.Login).EmailAddress();
            RuleFor(u => u.Password).NotEmpty().WithMessage("Not less than 6 characters");
        }
    }
}
