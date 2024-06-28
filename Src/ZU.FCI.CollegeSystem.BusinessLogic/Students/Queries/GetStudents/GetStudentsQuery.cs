using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Students.Queries.GetStudents;

public sealed record GetStudentsQuery
    () : IQuery<IReadOnlyCollection<GetStudentDto>>;

public sealed class GetStudentsQueryHandler :
    IQueryHandler<GetStudentsQuery, IReadOnlyCollection<GetStudentDto>>
{
    private readonly UserManager<Student> _userManager;

    public GetStudentsQueryHandler(UserManager<Student> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<IReadOnlyCollection<GetStudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<GetStudentDto> students = await _userManager.Users
            .Include(u => u.Department)
            .Select(s => new GetStudentDto(
                s.Id,
                s.FirstName + " " + s.LastName,
                s.Email,
                s.PhoneNumber,
                s.Gender,
                s.Department.Name
                )).ToListAsync(cancellationToken);

        return Result.Ok(students);
    }
}