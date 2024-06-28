using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Login;

public sealed record DoctorLoginCommand
    (string Email, string Password) : ICommand<TokenResponse>;