using FluentResults;
using MediatR;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}