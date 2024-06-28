using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication.Jwt;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Login;

public sealed class StudentLoginCommandHandler :
    ICommandHandler<StudentLoginCommand>
{
    private readonly UserManager<Student> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public StudentLoginCommandHandler(UserManager<Student> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result> Handle(StudentLoginCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExits = await _userManager.Users.Where(x => x.UserName == request.UserName)
            .FirstOrDefaultAsync(cancellationToken);

        if (checkUserIsExits is null)
            return new Result().WithError(new RecordNotFoundError($"User with {request.UserName} not found"));

        var passwordResult = await _userManager.CheckPasswordAsync(checkUserIsExits, request.Password);
        if (!passwordResult)
            return new Result().WithError(new PasswordNotCorrect());

        var token = await _jwtProvider.GenerateTokenAsync(checkUserIsExits.Id, nameof(ApplicationRoles.Student));

        var result = Result.Ok();
        result.WithSuccess(token);
        return result;
    }
}
