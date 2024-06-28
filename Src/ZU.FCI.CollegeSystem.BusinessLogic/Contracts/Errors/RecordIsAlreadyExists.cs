using FluentResults;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;

public class RecordIsAlreadyExists : Error
{
    public RecordIsAlreadyExists(string message)
        : base(message)
    {
    }
}