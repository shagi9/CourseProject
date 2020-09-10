using CourseProject.BusinessLogic.Dto.CourseDto;
using FluentValidation;
using System;

namespace CourseProject.API.Validators.CourseValidators
{
    public class SubscribeToCourseValidator : AbstractValidator<SubscribeToCourseDto>
    {
        public SubscribeToCourseValidator()
        {
            RuleFor(x => x.CourseId)
               .NotEmpty()
               .WithMessage(x => $"Can't be {x.CourseId}")
               .GreaterThan(0)
               .WithMessage(x => $"Must be greater than 0, but was {x.CourseId}");

            RuleFor(x => x.UserId)
                .Empty()
                .WithMessage(x => $"StudentId should be empty. Not {x.UserId}");

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now)
                .WithMessage(x => $"Start date must be greater than now, not {x.StartDate}");
        }
    }
}
