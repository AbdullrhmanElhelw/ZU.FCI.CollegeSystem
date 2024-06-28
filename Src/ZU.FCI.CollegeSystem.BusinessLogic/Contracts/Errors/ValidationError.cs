using FluentResults;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;

public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
    }

    public static ValidationError Create(Error[] errors)
    {
        var errorMessages = errors.Select(error => error.Message).ToArray();

        // join error messages

        var message = string.Join(", ", errorMessages);

        return new ValidationError(message);
    }
}