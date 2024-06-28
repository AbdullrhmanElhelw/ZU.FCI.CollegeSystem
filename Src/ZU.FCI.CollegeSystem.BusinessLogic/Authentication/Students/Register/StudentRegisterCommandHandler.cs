using FluentResults;
using Microsoft.AspNetCore.Identity;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Extensions;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Register;

public sealed class StudentRegisterCommandHandler : ICommandHandler<StudentRegisterCommand>
{
    private readonly UserManager<Student> _userManager;

    public StudentRegisterCommandHandler(UserManager<Student> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(StudentRegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExist = await _userManager.FindByEmailAsync(request.Email);

        if (checkUserIsExist is not null)
            return Result.Fail("User is already exist");

        var userName = request.Email.Split('@')[0];

        var student = new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = userName,
            SSN = request.SSN,
            Gender = request.Gender,
            CreatedOnUtc = DateTime.UtcNow,
        };

        var createResult = await _userManager.CreateAsync(student, request.Password);

        if (!createResult.Succeeded)
            return Result.Fail(createResult.GetErrors());

        var roleResult = await _userManager.AddToRoleAsync(student, nameof(ApplicationRoles.Student));

        if (!roleResult.Succeeded)
            return Result.Fail(roleResult.GetErrors());

        return Result.Ok();
    }
}
