using FluentValidation;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Login;

public sealed class DoctorLoginCommandValidator : AbstractValidator<DoctorLoginCommand>
{
    public DoctorLoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Invalid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long");
    }
}