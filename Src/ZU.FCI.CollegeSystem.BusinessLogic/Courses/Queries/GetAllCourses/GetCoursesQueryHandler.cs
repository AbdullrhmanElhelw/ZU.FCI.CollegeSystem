using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetAllCourses;

public sealed class GetCoursesQueryHandler :
    IQueryHandler<GetCoursesQuery, IReadOnlyCollection<GetCourseDto>>
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result<IReadOnlyCollection<GetCourseDto>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var getCourses = await _courseRepository.GetCourses(cancellationToken);

        IReadOnlyCollection<GetCourseDto> courses = getCourses.Select(x => new GetCourseDto(
            x.Id,
            x.Name,
            x.Level,
            x.Term,
            x.Hours,
            x.Code,
            x.Department.Name)).ToList();

        return Result.Ok(courses);
    }
}