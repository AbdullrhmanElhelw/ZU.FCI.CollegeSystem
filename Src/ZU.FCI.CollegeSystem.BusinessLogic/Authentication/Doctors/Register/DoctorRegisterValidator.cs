using FluentValidation;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Register;

public sealed class DoctorRegisterValidator : AbstractValidator<DoctorRegisterCommand>
{
    public DoctorRegisterValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Invalid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long");

        RuleFor(x => x.PhoneNumber)
             .NotEmpty().WithMessage("Phone is required")
             .Matches(@"^(011|012|015|010)\d{8}$")
             .WithMessage("Phone must be 11 digits and start with 011, 012, 015, or 010");
    }
}