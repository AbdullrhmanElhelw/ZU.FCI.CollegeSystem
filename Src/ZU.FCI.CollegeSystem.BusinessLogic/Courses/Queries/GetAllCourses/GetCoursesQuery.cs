using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetAllCourses;

public sealed record class GetCoursesQuery
    () : IQuery<IReadOnlyCollection<GetCourseDto>>;