using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Students.Queries.GetStudent;

public sealed class GetStudentQueryHandler :
    IQueryHandler<GetStudentQuery, GetStudentDto>
{
    private readonly UserManager<Student> _userManager;

    public GetStudentQueryHandler(UserManager<Student> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<GetStudentDto>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var getStudent = await _userManager.Users
            .Include(x => x.Department)
            .Where(x => x.Id == request.Id)
            .Select(x => new GetStudentDto(
                x.Id,
                x.FirstName + " " + x.LastName,
                x.Email,
                x.PhoneNumber,
                x.Gender,
                x.Department.Name))
            .FirstOrDefaultAsync(cancellationToken);

        if (getStudent is null)
            return new Result<GetStudentDto>().WithError(new RecordNotFoundError($"Student with {request.Id} not found"));

        return Result.Ok(getStudent);
    }
}