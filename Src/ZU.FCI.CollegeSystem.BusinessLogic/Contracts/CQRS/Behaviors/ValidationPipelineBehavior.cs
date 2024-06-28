using FluentResults;
using FluentValidation;
using MediatR;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        Error[] errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => new Error(error.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
        {
            var validationError = ValidationError.Create(errors);
            return new Result().WithError(validationError) as TResponse;
        }

        return await next();
    }

    private static TResponse CreateFailureResponse<TResponse>(Error[] errors)
       where TResponse : Result
    {
        if (typeof(TResponse) == typeof(Result))
        {
            return (TResponse)(object)Result.Fail(errors);
        }

        object[] args = [errors];
        return (TResponse)Activator.CreateInstance(typeof(TResponse), args);
    }
}