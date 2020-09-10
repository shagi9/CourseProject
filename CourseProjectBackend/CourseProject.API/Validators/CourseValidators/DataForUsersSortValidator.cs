using CourseProject.BusinessLogic.Dto.UsersDto;
using FluentValidation;

namespace CourseProject.API.Validators.CourseValidators
{
    public class DataForUsersSortValidator : AbstractValidator<DataForUsersSortDto>
    {
        public DataForUsersSortValidator()
        {
            RuleFor(x => x.SearchString)
                .NotNull()
                .WithMessage("Searching string must be not null");

            RuleFor(x => x.Current)
                .GreaterThan(-1)
                .WithMessage("Current page should be greater than -1");

            RuleFor(x => x.PageSize)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(x => $"Page size must be not 0 and empty, your entered {x.PageSize}");
        }
    }
}
