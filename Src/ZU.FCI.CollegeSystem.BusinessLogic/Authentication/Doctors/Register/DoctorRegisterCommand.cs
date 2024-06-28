using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Register;

public sealed record DoctorRegisterCommand
    (
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    int DepartmentId) : ICommand;