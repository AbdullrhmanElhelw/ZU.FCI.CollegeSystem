using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetCourse;

public sealed record GetCourseQuery
    (int Id) : IQuery<GetCourseDto>;