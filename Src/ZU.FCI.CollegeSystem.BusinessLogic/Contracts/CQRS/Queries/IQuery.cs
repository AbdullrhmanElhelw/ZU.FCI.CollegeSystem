using FluentResults;
using MediatR;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}