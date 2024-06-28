using FluentResults;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;

public class RecordNotFoundError : Error
{
    public RecordNotFoundError(string message)
        : base(message)
    {
    }
}