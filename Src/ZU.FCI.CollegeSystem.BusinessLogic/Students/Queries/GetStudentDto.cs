using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Students.Queries;

public sealed record GetStudentDto
    (int Id,
    string Name,
    string Email,
    string Phone,
    Gender Gender,
    string DepartmentName);