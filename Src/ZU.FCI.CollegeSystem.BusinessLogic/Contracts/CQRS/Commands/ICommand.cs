using FluentResults;
using MediatR;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}