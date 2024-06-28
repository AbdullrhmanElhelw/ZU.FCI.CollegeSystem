using FluentValidation;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Register;

public sealed class StudentRegisterValidator : AbstractValidator<StudentRegisterCommand>
{
    public StudentRegisterValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
        RuleFor(x => x.SSN).NotEmpty().WithMessage("SSN is required");
        RuleFor(x => x.SSN).Length(14).WithMessage("SSN must be 14 digits");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required")
            .Matches(@"^(011|012|015|010)\d{8}$")
            .WithMessage("Phone must be 11 digits and start with 011, 012, 015, or 010");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
    }
}