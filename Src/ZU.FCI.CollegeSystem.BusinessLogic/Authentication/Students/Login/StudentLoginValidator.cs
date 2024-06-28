using FluentValidation;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Login;

public sealed class StudentLoginValidator : AbstractValidator<StudentLoginCommand>
{
    public StudentLoginValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
    }
}