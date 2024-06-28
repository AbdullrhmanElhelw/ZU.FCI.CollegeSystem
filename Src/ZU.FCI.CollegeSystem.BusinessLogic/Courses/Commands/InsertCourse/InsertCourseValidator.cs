using FluentValidation;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.InsertCourse;

public sealed class InsertCourseValidator : AbstractValidator<InsertCourseCommand>
{
    public InsertCourseValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Name is required");

        RuleFor(x => x.Level)
            .IsInEnum();

        RuleFor(x => x.Term)
            .IsInEnum();

        RuleFor(x => x.Hours)
            .IsInEnum();

        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(10);
    }
}