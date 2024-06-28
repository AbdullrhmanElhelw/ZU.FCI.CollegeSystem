using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetCourse;

public sealed class GetCourseQueryHandler :
    IQueryHandler<GetCourseQuery, GetCourseDto>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result<GetCourseDto>> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var getCourse = await _courseRepository.GetCourse(request.Id, cancellationToken);
        if (getCourse is null)
            return new Result<GetCourseDto>().WithError(new RecordNotFoundError($"Course with {request.Id} not found"));

        var courseResult = new GetCourseDto(getCourse.Id,
            getCourse.Name,
            getCourse.Level,
            getCourse.Term,
            getCourse.Hours,
            getCourse.Code,
            getCourse.Department.Name);

        return Result.Ok(courseResult);
    }
}