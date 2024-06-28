using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Register;

public sealed record StudentRegisterCommand
    (
    string FirstName,
    string LastName,
    string SSN,
    string Phone,
    Gender Gender,
    string Email,
    string Password) : ICommand;