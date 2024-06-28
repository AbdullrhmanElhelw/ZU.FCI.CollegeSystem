using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Students.Queries.GetStudent;

public sealed record GetStudentQuery
    (int Id) : IQuery<GetStudentDto>;