using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.FindCoursesByLevelAndTerm;

public sealed record FindCoursesByLevelAndTermQuery
    (Level Level, Term Term) : IQuery<IReadOnlyCollection<GetCourseDto>>;

public sealed class FindCoursesByLevelAndTermQueryHandler
    : IQueryHandler<FindCoursesByLevelAndTermQuery, IReadOnlyCollection<GetCourseDto>>
{
    private readonly ICourseRepository _courseRepository;

    public FindCoursesByLevelAndTermQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result<IReadOnlyCollection<GetCourseDto>>> Handle(FindCoursesByLevelAndTermQuery request,
        CancellationToken cancellationToken)
    {
        var getCourses = await _courseRepository.FindCourseByLevelAndTerm(request.Level, request.Term, cancellationToken);

        IReadOnlyCollection<GetCourseDto> courseDtos = getCourses.
            Select(x => new GetCourseDto(x.Id,
            x.Name,
            x.Level,
            x.Term,
            x.Hours,
            x.Code,
            x.Department.Name)).ToList();

        return Result.Ok(courseDtos);
    }
}