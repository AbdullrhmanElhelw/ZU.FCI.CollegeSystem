using FluentResults;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;

public class PasswordNotCorrect : Error
{
    public PasswordNotCorrect() :
        base("Password is not correct")
    {
    }
}