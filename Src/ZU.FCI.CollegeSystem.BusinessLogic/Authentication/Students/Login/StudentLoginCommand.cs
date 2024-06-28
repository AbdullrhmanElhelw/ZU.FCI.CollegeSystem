using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Login;

// user login with email || username and password

public sealed record StudentLoginCommand
    (
    string UserName,
    string Password) : ICommand;