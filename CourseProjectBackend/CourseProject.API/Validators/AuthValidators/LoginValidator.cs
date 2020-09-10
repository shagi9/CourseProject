using CourseProject.BusinessLogic.Dto.AuthDto;
using FluentValidation;

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
