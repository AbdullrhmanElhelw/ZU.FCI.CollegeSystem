using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries;

public sealed record GetCourseDto
    (int Id,
    string Name,
    Level Level,
    Term Term,
    Hours Hours,
    string Code,
    string DepartmentName);
