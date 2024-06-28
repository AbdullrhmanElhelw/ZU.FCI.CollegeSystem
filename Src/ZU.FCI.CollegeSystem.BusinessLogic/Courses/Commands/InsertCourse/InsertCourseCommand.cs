using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.InsertCourse;

public sealed record InsertCourseCommand
    (
    string Name,
    Level Level,
    Term Term,
    Hours Hours,
    string Code,
    int DepartmentId) : ICommand;